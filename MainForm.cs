using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Media;
using NAudio.Wave;
using System.Diagnostics;

namespace JNSoundboard
{
    public partial class MainForm : Form
    {
        internal class ListViewItemComparer : IComparer
        {
            private int col;

            public ListViewItemComparer()
            {
                col = 0;
            }

            public ListViewItemComparer(int column)
            {
                col = column;
            }

            public int Compare(object x, object y)
            {
                return string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }

        //There might be a smarter way to output the sound to two devices, but this is quick and it works.

        //Generally the virtual cable output
        AudioPlaybackEngine playbackEngine1 = new AudioPlaybackEngine();

        //A second output to also output the sound to your headphones or speaker.
        AudioPlaybackEngine playbackEngine2 = new AudioPlaybackEngine();

        //Linear volume for sounds sent to AudioPlaybackEngine (doesn't affect microphone loopback volume)
        private float soundVolume;
        private int SelectedPlaybackDevice1
        {
            get
            {
                if (cbPlaybackDevices1.Items.Count > 0)
                {
                    return cbPlaybackDevices1.SelectedIndex;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (value >= 0 && value <= cbPlaybackDevices1.Items.Count - 1)
                {
                    cbPlaybackDevices1.SelectedIndex = value;
                }
            }
        }

        private int SelectedPlaybackDevice2
        {
            get
            {
                if (cbPlaybackDevices2.Items.Count > 0)
                {
                    //minus one to account for null entry
                    return cbPlaybackDevices2.SelectedIndex - 1;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (value >= -1 && value <= cbPlaybackDevices2.Items.Count - 2)
                {
                    cbPlaybackDevices2.SelectedIndex = value + 1;
                }
            }
        }

        WaveIn loopbackSourceStream = null;
        BufferedWaveProvider loopbackWaveProvider = null;
        WaveOut loopbackWaveOut = null;

        Random rand = new Random();

        const string DO_NOT_USE = "[Do not use]";

        bool keyUpPushToTalkKey = false;

        internal List<XMLSettings.SoundHotkey> soundHotkeys = new List<XMLSettings.SoundHotkey>();

        Keys pushToTalkKey;

        string xmlLocation;

        const string PLAYBACK1_TOOLTIP =
@"The playback device through which to play the audio.
Generally the virtual audio cable.
(Or your speakers or headphones for local playback only.)";

        const string PLAYBACK2_TOOLTIP =
@"A second playback device through which to play the audio. 
Generally your headset, so that you can hear the sounds being played, too.";

        const string LOOPBACK_TOOLTIP =
@"The input device which will also be sent into the above playback device.
Generally your real microphone to speak through.
DO NOT choose the virtual auidio cable!";

        const string SOUND_VOLUME_TOOLTIP =
@"The volume of soundboard audio files.
Doesn't affect sounds with custom volumes or that are currently playing.";

        private bool allowVisible = true;
        public MainForm()
        {
            InitializeComponent();

            var tooltip = new ToolTip();

            tooltip.SetToolTip(btnReloadDevices, "Refresh sound devices");
            tooltip.SetToolTip(btnReloadWindows, "Reload windows");
            tooltip.SetToolTip(cbPlaybackDevices1, PLAYBACK1_TOOLTIP);
            tooltip.SetToolTip(cbPlaybackDevices2, PLAYBACK2_TOOLTIP);
            tooltip.SetToolTip(cbLoopbackDevices, LOOPBACK_TOOLTIP);
            tooltip.SetToolTip(lblPlayback1, PLAYBACK1_TOOLTIP);
            tooltip.SetToolTip(lblPlayback2, PLAYBACK2_TOOLTIP);
            tooltip.SetToolTip(lblLoopback, LOOPBACK_TOOLTIP);
            tooltip.SetToolTip(vsSoundVolume, SOUND_VOLUME_TOOLTIP);
            tooltip.SetToolTip(nSoundVolume, SOUND_VOLUME_TOOLTIP);

            XMLSettings.LoadSoundboardSettingsXML();

            //Disable change events for elements that would trigger settings changes and unnecessarily write to settings.xml
            DisableCheckboxChangeEvents();
            DisableSoundVolumeChangeEvents();

            loadSoundDevices(false); //false argument keeps device change events disabled

            Helper.getWindows(cbWindows);
            Helper.selectWindow(cbWindows, XMLSettings.soundboardSettings.AutoPushToTalkWindow);

            if (XMLSettings.soundboardSettings.StartMinimised)
            {
                this.WindowState = FormWindowState.Minimized;

                if (XMLSettings.soundboardSettings.MinimiseToTray)
                {
                    this.HideFormToTray();
                }
            }

            Helper.setStartup(XMLSettings.soundboardSettings.StartWithWindows);

            cbEnableHotkeys.Checked = XMLSettings.soundboardSettings.EnableHotkeys;
            cbEnableLoopback.Checked = XMLSettings.soundboardSettings.EnableLoopback;

            soundVolume = XMLSettings.soundboardSettings.SoundVolume;
            vsSoundVolume.Volume = soundVolume;
            nSoundVolume.Value = Helper.linearVolumeToInteger(vsSoundVolume.Volume); //needed because change events are still disabled

            pushToTalkKey = XMLSettings.soundboardSettings.AutoPushToTalkKey;

            tbPushToTalkKey.Text = pushToTalkKey.ToString() == "None" ? "" : pushToTalkKey.ToString();

            cbEnablePushToTalk.Checked = XMLSettings.soundboardSettings.EnableAutoPushToTalk;
            tbPushToTalkKey.Enabled = !cbEnablePushToTalk.Checked;
            clearHotkey.Enabled = !cbEnablePushToTalk.Checked;

            if (File.Exists(XMLSettings.soundboardSettings.LastXMLFile))
            {
                //loadXMLFile() returns true if error occurred
                if (loadXMLFile(XMLSettings.soundboardSettings.LastXMLFile))
                {
                    XMLSettings.soundboardSettings.LastXMLFile = "";
                    XMLSettings.SaveSoundboardSettingsXML();
                }
            }

            //Add events after settings have been loaded
            EnableCheckboxChangeEvents();
            EnableSoundVolumeChangeEvents();
            EnableDeviceChangeEvents();

            mainTimer.Enabled = cbEnableHotkeys.Checked;
            initAudioPlaybackEngine1();
            initAudioPlaybackEngine2();
            restartLoopback();

            //When sound stops, fire event which lets go of push-to-talk key.
            playbackEngine1.AllInputEnded += OnAllInputEnded;
            //Don't need to stop holding the push-to-talk key when engine2 stops playing, that's just our in-ear echo.
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowVisible);
        }

        private void DisableCheckboxChangeEvents()
        {
            cbEnableHotkeys.CheckedChanged -= cbEnableHotkeys_CheckedChanged;
            cbEnableLoopback.CheckedChanged -= cbEnableLoopback_CheckedChanged;
            cbEnablePushToTalk.CheckedChanged -= cbEnablePushToTalk_CheckedChanged;
        }

        private void EnableCheckboxChangeEvents()
        {
            cbEnableHotkeys.CheckedChanged += cbEnableHotkeys_CheckedChanged;
            cbEnableLoopback.CheckedChanged += cbEnableLoopback_CheckedChanged;
            cbEnablePushToTalk.CheckedChanged += cbEnablePushToTalk_CheckedChanged;
        }

        private void DisableSoundVolumeChangeEvents()
        {
            vsSoundVolume.VolumeChanged -= vsSoundVolume_VolumeChanged;
            nSoundVolume.ValueChanged -= nSoundVolume_ValueChanged;
        }

        private void EnableSoundVolumeChangeEvents()
        {
            vsSoundVolume.VolumeChanged += vsSoundVolume_VolumeChanged;
            nSoundVolume.ValueChanged += nSoundVolume_ValueChanged;
        }

        private void DisableDeviceChangeEvents()
        {
            cbPlaybackDevices1.SelectedIndexChanged -= cbPlaybackDevices1_SelectedIndexChanged;
            cbPlaybackDevices2.SelectedIndexChanged -= cbPlaybackDevices2_SelectedIndexChanged;
            cbLoopbackDevices.SelectedIndexChanged -= cbLoopbackDevices_SelectedIndexChanged;
        }

        private void EnableDeviceChangeEvents()
        {
            cbPlaybackDevices1.SelectedIndexChanged += cbPlaybackDevices1_SelectedIndexChanged;
            cbPlaybackDevices2.SelectedIndexChanged += cbPlaybackDevices2_SelectedIndexChanged;
            cbLoopbackDevices.SelectedIndexChanged += cbLoopbackDevices_SelectedIndexChanged;
        }

        private void OnAllInputEnded(object sender, EventArgs e)
        {
            if (keyUpPushToTalkKey)
            {
                keyUpPushToTalkKey = false;
                Keyboard.sendKey(pushToTalkKey, false);
            }
        }

        private void initAudioPlaybackEngine1()
        {
            try
            {
                playbackEngine1.Init(SelectedPlaybackDevice1);
            }
            catch (NAudio.MmException ex)
            {
                SystemSounds.Beep.Play();

                string msg = ex.ToString();

                if (msg.Contains("AlreadyAllocated calling waveOutOpen"))
                {
                    msg = "Failed to open device. Already in exclusive use by another application? \n\n" + msg;
                }

                MessageBox.Show("Playback 1" + msg);
            }
        }

        private void initAudioPlaybackEngine2()
        {
            //Don't init if the null entry is selected
            if (SelectedPlaybackDevice2 >= 0)
            {
                try
                {
                    playbackEngine2.Init(SelectedPlaybackDevice2);
                }
                catch (NAudio.MmException ex)
                {
                    SystemSounds.Beep.Play();

                    string msg = ex.ToString();

                    if (msg.Contains("AlreadyAllocated calling waveOutOpen"))
                    {
                        msg = "Failed to open device. Already in exclusive use by another application? \n\n" + msg;
                    }

                    MessageBox.Show("Playback 2" + msg);
                }
            }
        }

        private void loadSoundDevices(bool enableEvents = true)
        {
            DisableDeviceChangeEvents(); //avoid audio related errors

            var playbackSources = new List<WaveOutCapabilities>();
            var loopbackSources = new List<WaveInCapabilities>();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                playbackSources.Add(WaveOut.GetCapabilities(i));
            }

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                loopbackSources.Add(WaveIn.GetCapabilities(i));
            }

            cbPlaybackDevices1.Items.Clear();
            cbPlaybackDevices2.Items.Clear();
            cbLoopbackDevices.Items.Clear();

            foreach (var source in playbackSources)
            {
                cbPlaybackDevices1.Items.Add(source.ProductName);
                cbPlaybackDevices2.Items.Add(source.ProductName);
            }

            cbLoopbackDevices.Items.Insert(0, DO_NOT_USE);
            cbPlaybackDevices2.Items.Insert(0, DO_NOT_USE);

            SelectedPlaybackDevice1 = -1;
            SelectedPlaybackDevice2 = -1;

            if (cbPlaybackDevices1.Items.Count > 0)
            {
                SelectedPlaybackDevice1 = 0;
            }

            if (cbPlaybackDevices2.Items.Count > 0)
            {
                SelectedPlaybackDevice2 = -1;
            }

            foreach (var source in loopbackSources)
            {
                cbLoopbackDevices.Items.Add(source.ProductName);
            }

            cbLoopbackDevices.SelectedIndex = 0;

            if (enableEvents)
            {
                EnableDeviceChangeEvents();
            }

            if (cbPlaybackDevices1.Items.Contains(XMLSettings.soundboardSettings.LastPlaybackDevice)) cbPlaybackDevices1.SelectedItem = XMLSettings.soundboardSettings.LastPlaybackDevice;
            if (cbPlaybackDevices2.Items.Contains(XMLSettings.soundboardSettings.LastPlaybackDevice2)) cbPlaybackDevices2.SelectedItem = XMLSettings.soundboardSettings.LastPlaybackDevice2;
            if (cbLoopbackDevices.Items.Contains(XMLSettings.soundboardSettings.LastLoopbackDevice)) cbLoopbackDevices.SelectedItem = XMLSettings.soundboardSettings.LastLoopbackDevice;
        }

        private void restartLoopback()
        {
            stopLoopback();

            //Subtract one from index to account for null entry.
            int deviceNumber = cbLoopbackDevices.SelectedIndex - 1;

            if (deviceNumber >= 0 && cbEnableLoopback.Checked)
            {
                if (loopbackSourceStream == null)
                    loopbackSourceStream = new WaveIn();
                loopbackSourceStream.DeviceNumber = deviceNumber;
                loopbackSourceStream.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(deviceNumber).Channels);
                loopbackSourceStream.BufferMilliseconds = 25;
                loopbackSourceStream.NumberOfBuffers = 5;
                loopbackSourceStream.DataAvailable += loopbackSourceStream_DataAvailable;

                loopbackWaveProvider = new BufferedWaveProvider(loopbackSourceStream.WaveFormat);
                loopbackWaveProvider.DiscardOnBufferOverflow = true;

                if (loopbackWaveOut == null)
                    loopbackWaveOut = new WaveOut();
                loopbackWaveOut.DeviceNumber = cbPlaybackDevices1.SelectedIndex;
                loopbackWaveOut.DesiredLatency = 125;
                loopbackWaveOut.Init(loopbackWaveProvider);

                loopbackSourceStream.StartRecording();
                loopbackWaveOut.Play();
            }
        }

        private void stopLoopback()
        {
            try
            {
                if (loopbackWaveOut != null)
                {
                    loopbackWaveOut.Stop();
                    loopbackWaveOut.Dispose();
                    loopbackWaveOut = null;
                }

                if (loopbackWaveProvider != null)
                {
                    loopbackWaveProvider.ClearBuffer();
                    loopbackWaveProvider = null;
                }

                if (loopbackSourceStream != null)
                {
                    loopbackSourceStream.StopRecording();
                    loopbackSourceStream.Dispose();
                    loopbackSourceStream = null;
                }
            }
            catch (Exception) { }
        }

        private void stopPlayback()
        {
            playbackEngine1.StopAllSounds();
            playbackEngine2.StopAllSounds();
        }

        private void playSound(string file, float soundVolume)
        {
            stopPlayback();

            try
            {
                playbackEngine1.PlaySound(file, soundVolume);

                //Don't try to play the sound if the device is not selected or the device is the same as #1.
                if (SelectedPlaybackDevice2 >= 0 && SelectedPlaybackDevice2 != SelectedPlaybackDevice1)
                {
                    playbackEngine2.PlaySound(file, soundVolume);
                }
            }
            catch (FormatException ex)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(ex.ToString());
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(ex.ToString());
            }
            catch (NAudio.MmException ex)
            {
                SystemSounds.Beep.Play();
                string msg = ex.ToString();
                MessageBox.Show((msg.Contains("UnspecifiedError calling waveOutOpen") ? "Something is wrong with either the sound you tried to play (" + file.Substring(file.LastIndexOf("\\") + 1) + ") (try converting it to another format) or your sound card driver\n\n" + msg : msg));
            }
        }

        private bool loadXMLFile(string path)
        {
            bool errorOccurred = true;

            try
            {
                XMLSettings.Settings s = (XMLSettings.Settings)XMLSettings.ReadXML(typeof(XMLSettings.Settings), path);
                
                if (s != null && s.SoundHotkeys != null && s.SoundHotkeys.Length > 0)
                {
                    var items = new List<ListViewItem>();
                    string errorMessage = "";
                    string sameKeys = "";

                    for (int i = 0; i < s.SoundHotkeys.Length; i++)
                    {
                        int kLength = s.SoundHotkeys[i].Keys.Length;
                        bool keysNull = (kLength > 0 && !s.SoundHotkeys[i].Keys.Any(x => x != 0));
                        int sLength = s.SoundHotkeys[i].SoundLocations.Length;
                        bool soundsNotEmpty = s.SoundHotkeys[i].SoundLocations.All(x => !string.IsNullOrWhiteSpace(x)); //false if even one location is empty
                        Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                        bool filesExist = s.SoundHotkeys[i].SoundLocations.All(x => File.Exists(x));

                        if (keysNull || sLength < 1 || !soundsNotEmpty || !filesExist) //error in XML file
                        {
                            string tempErr = "";

                            if (kLength == 0 && (sLength == 0 || !soundsNotEmpty)) tempErr = "entry is empty";
                            else if (!keysNull) tempErr = "one or more keys are null";
                            else if (sLength == 0) tempErr = "no sounds provided";
                            else if (!filesExist) tempErr = "one or more sounds do not exist";

                            errorMessage += "Entry #" + (i + 1).ToString() + " has an error: " + tempErr + "\r\n";
                        }

                        string keys = (kLength < 1 ? "" : Helper.keysToString(s.SoundHotkeys[i].Keys));

                        if (keys != "" && items.Count > 0 && items[items.Count - 1].Text == keys && !sameKeys.Contains(keys))
                        {
                            sameKeys += (sameKeys != "" ? ", " : "") + keys;
                        }

                        string windowString = string.IsNullOrWhiteSpace(s.SoundHotkeys[i].WindowTitle) ? "" : s.SoundHotkeys[i].WindowTitle;
                        string volumeString = s.SoundHotkeys[i].SoundVolume == 1 ? "" : Helper.linearVolumeToString(s.SoundHotkeys[i].SoundVolume);
                        string soundLocations = sLength < 1 ? "" : Helper.fileLocationsArrayToString(s.SoundHotkeys[i].SoundLocations);

                        var temp = new ListViewItem(keys);
                        temp.SubItems.Add(volumeString);
                        temp.SubItems.Add(windowString);
                        temp.SubItems.Add(soundLocations);

                        temp.ToolTipText = Helper.getFileNamesTooltip(s.SoundHotkeys[i].SoundLocations); //blank tooltips are not displayed

                        items.Add(temp); //add even if there was an error, so that the user can fix within the app
                    }

                    if (items.Count > 0)
                    {
                        if (errorMessage != "")
                        {
                            MessageBox.Show((errorMessage == "" ? "" : errorMessage));
                        }
                        else
                        {
                            errorOccurred = false;
                        }

                        if (sameKeys != "")
                        {
                            MessageBox.Show("Multiple entries using the same keys. The keys being used multiple times are: " + sameKeys);
                        }

                        soundHotkeys.Clear();
                        soundHotkeys.AddRange(s.SoundHotkeys);

                        lvKeySounds.Items.Clear();
                        lvKeySounds.Items.AddRange(items.ToArray());

                        sortHotkeys();

                        xmlLocation = path;
                    }
                    else
                    {
                        SystemSounds.Beep.Play();
                        MessageBox.Show("No entries found, or all entries had errors in them (key being None, sound location behind empty or non-existant)");
                    }
                }
                else
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("No entries found, or there was an error reading the settings file");
                }
            }
            catch
            {
                MessageBox.Show("Settings file structure is incorrect");
            }

            return errorOccurred;
        }

        public void sortHotkeys()
        {
            lvKeySounds.ListViewItemSorter = new ListViewItemComparer(0);
            lvKeySounds.Sort();

            soundHotkeys.Sort((XMLSettings.SoundHotkey x, XMLSettings.SoundHotkey y) =>
            {
                if (x.Keys == null && y.Keys == null) return 0;
                else if (x.Keys == null) return -1;
                else if (y.Keys == null) return 1;
                else return Helper.keysToString(x.Keys).CompareTo(Helper.keysToString(y.Keys));
            });

            lvKeySounds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvKeySounds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void editSelectedSoundHotkey()
        {
            if (lvKeySounds.SelectedItems.Count > 0)
            {
                var form = new AddEditHotkeyForm();

                int selectedIndex = lvKeySounds.SelectedIndices[0];

                form.editStrings = new string[4];

                form.editStrings[0] = Helper.keysToString(soundHotkeys[selectedIndex].Keys);
                form.editStrings[1] = soundHotkeys[selectedIndex].WindowTitle;
                form.editStrings[2] = Helper.fileLocationsArrayToString(soundHotkeys[selectedIndex].SoundLocations);
                form.editVolume = soundHotkeys[selectedIndex].SoundVolume;

                form.editIndex = lvKeySounds.SelectedIndices[0];

                form.ShowDialog();
            }
        }

        private void loopbackSourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (loopbackWaveProvider != null && loopbackWaveProvider.BufferedDuration.TotalMilliseconds <= 100)
                loopbackWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.ShowDialog();
        }

        private void texttospeechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TextToSpeechForm();
            form.ShowDialog();
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Jitnaught is inactive, so let's have some fun here 
            Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddEditHotkeyForm();
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editSelectedSoundHotkey();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvKeySounds.SelectedItems.Count > 0 && MessageBox.Show("Are you sure remove that item?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                soundHotkeys.RemoveAt(lvKeySounds.SelectedIndices[0]);
                lvKeySounds.Items.Remove(lvKeySounds.SelectedItems[0]);

                if (lvKeySounds.Items.Count == 0) cbEnableHotkeys.Checked = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all items?", "Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                soundHotkeys.Clear();
                lvKeySounds.Items.Clear();

                cbEnableHotkeys.Checked = false;
            }
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (lvKeySounds.SelectedItems.Count > 0) playKeySound(soundHotkeys[lvKeySounds.SelectedIndices[0]]);
        }

        private void btnStopAllSounds_Click(object sender, EventArgs e)
        {
            stopPlayback();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog();

            diag.Filter = "XML file containing keys and sounds|*.xml";

            var result = diag.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = diag.FileName;

                //loading hotkeys file and saving soundboard settings
                XMLSettings.soundboardSettings.LastXMLFile = loadXMLFile(path) ? "" : path;
                saveSettings();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(xmlLocation))
            {
                SaveHotkeysAs();
            }
            else
            {
                SaveHotkeys();
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveHotkeysAs();
        }

        private void SaveHotkeys()
        {
            XMLSettings.WriteXML(new XMLSettings.Settings() { SoundHotkeys = soundHotkeys.ToArray() }, xmlLocation);

            XMLSettings.soundboardSettings.LastXMLFile = xmlLocation;
            saveSettings();

            MessageBox.Show("Hotkeys saved");
        }

        private void SaveHotkeysAs()
        {
            string path = Helper.userGetXmlLocation();

            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            else
            {
                xmlLocation = path;
                SaveHotkeys();
            }
        }

        private void btnReloadDevices_Click(object sender, EventArgs e)
        {
            stopPlayback();
            stopLoopback();

            loadSoundDevices();
        }

        private void cbEnableHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            mainTimer.Enabled = cbEnableHotkeys.Checked;

            XMLSettings.soundboardSettings.EnableHotkeys = cbEnableHotkeys.Checked;
            saveSettings();
        }

        private void cbEnableLoopback_CheckedChanged(object sender, EventArgs e)
        {
            restartLoopback();

            XMLSettings.soundboardSettings.EnableLoopback = cbEnableLoopback.Checked;
            saveSettings();
        }

        private void lvKeySounds_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editSelectedSoundHotkey();
        }


        Keys[] keysJustPressed = null;
        bool showingMsgBox = false;
        int lastIndex = -1;
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (cbEnableHotkeys.Checked)
            {
                int keysPressed = 0;

                if (soundHotkeys.Count > 0) //check that required keys are pressed to play sound
                {
                    IntPtr foregroundWindow = Helper.GetForegroundWindow();

                    for (int i = 0; i < soundHotkeys.Count; i++)
                    {
                        keysPressed = 0;

                        if (soundHotkeys[i].Keys.Length == 0) continue;

                        if (soundHotkeys[i].WindowTitle != "" && !Helper.isForegroundWindow(foregroundWindow, soundHotkeys[i].WindowTitle)) continue;

                        for (int j = 0; j < soundHotkeys[i].Keys.Length; j++)
                        {
                            if (Keyboard.IsKeyDown(soundHotkeys[i].Keys[j]))
                                keysPressed++;
                        }

                        if (keysPressed == soundHotkeys[i].Keys.Length)
                        {
                            if (keysJustPressed == soundHotkeys[i].Keys) continue;

                            if (soundHotkeys[i].Keys.Length > 0 && soundHotkeys[i].Keys.All(x => x != 0) && soundHotkeys[i].SoundLocations.Length > 0
                                && soundHotkeys[i].SoundLocations.Length > 0 && soundHotkeys[i].SoundLocations.Any(x => File.Exists(x)))
                            {
                                if (cbEnablePushToTalk.Checked && !keyUpPushToTalkKey && !Keyboard.IsKeyDown(pushToTalkKey)
                                    && (cbWindows.SelectedIndex == 0 || Helper.isForegroundWindow(cbWindows.Text)))
                                {
                                    keyUpPushToTalkKey = true;
                                    bool result = Keyboard.sendKey(pushToTalkKey, true);
                                    Thread.Sleep(100);
                                }

                                playKeySound(soundHotkeys[i]);
                                return;
                            }
                        }
                        else if (keysJustPressed == soundHotkeys[i].Keys)
                            keysJustPressed = null;
                    }

                    keysPressed = 0;
                }

                if (XMLSettings.soundboardSettings.StopSoundKeys != null && XMLSettings.soundboardSettings.StopSoundKeys.Length > 0) //check that required keys are pressed to stop all sounds
                {
                    for (int i = 0; i < XMLSettings.soundboardSettings.StopSoundKeys.Length; i++)
                    {
                        if (Keyboard.IsKeyDown(XMLSettings.soundboardSettings.StopSoundKeys[i])) keysPressed++;
                    }

                    if (keysPressed == XMLSettings.soundboardSettings.StopSoundKeys.Length)
                    {
                        if (keysJustPressed == null || !keysJustPressed.Intersect(XMLSettings.soundboardSettings.StopSoundKeys).Any())
                        {
                            stopPlayback();

                            keysJustPressed = XMLSettings.soundboardSettings.StopSoundKeys;

                            return;
                        }
                    }
                    else if (keysJustPressed == XMLSettings.soundboardSettings.StopSoundKeys)
                    {
                        keysJustPressed = null;
                    }

                    keysPressed = 0;
                }

                if (XMLSettings.soundboardSettings.LoadXMLFiles != null && XMLSettings.soundboardSettings.LoadXMLFiles.Length > 0) //check that required keys are pressed to load XML file
                {
                    for (int i = 0; i < XMLSettings.soundboardSettings.LoadXMLFiles.Length; i++)
                    {
                        if (XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys.Length == 0) continue;

                        keysPressed = 0;

                        for (int j = 0; j < XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys.Length; j++)
                        {
                            if (Keyboard.IsKeyDown(XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys[j])) keysPressed++;
                        }

                        if (keysPressed == XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys.Length)
                        {
                            if (keysJustPressed == null || !keysJustPressed.Intersect(XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys).Any())
                            {
                                if (!string.IsNullOrWhiteSpace(XMLSettings.soundboardSettings.LoadXMLFiles[i].XMLLocation) && File.Exists(XMLSettings.soundboardSettings.LoadXMLFiles[i].XMLLocation))
                                {
                                    keysJustPressed = XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys;

                                    loadXMLFile(XMLSettings.soundboardSettings.LoadXMLFiles[i].XMLLocation);
                                }

                                return;
                            }
                        }
                        else if (keysJustPressed == XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys)
                        {
                            keysJustPressed = null;
                        }
                    }

                    keysPressed = 0;
                }

                if (keyUpPushToTalkKey)
                {
                    if (!Keyboard.IsKeyDown(pushToTalkKey)) keyUpPushToTalkKey = false;

                    if (cbWindows.SelectedIndex > 0 && !Helper.isForegroundWindow(cbWindows.Text))
                    {
                        keyUpPushToTalkKey = false;
                        Keyboard.sendKey(pushToTalkKey, false);
                        Keyboard.sendKey(pushToTalkKey, false);
                    }
                }
            }
        }

        private void playKeySound(XMLSettings.SoundHotkey currentKeysSounds)
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            string path;

            if (currentKeysSounds.SoundLocations.Length > 1)
            {
                //get random sound
                int temp;

                while (true)
                {
                    temp = rand.Next(0, currentKeysSounds.SoundLocations.Length);

                    if (temp != lastIndex && File.Exists(currentKeysSounds.SoundLocations[temp])) break;
                    Thread.Sleep(1);
                }

                lastIndex = temp;

                path = currentKeysSounds.SoundLocations[lastIndex];
            }
            else
                path = currentKeysSounds.SoundLocations[0]; //get first sound

            if (File.Exists(path))
            {
                float customSoundVolume = currentKeysSounds.SoundVolume;

                //use custom sound volume if the user changed it
                if (customSoundVolume < 1)
                {
                    playSound(path, customSoundVolume);
                }
                else
                {
                    playSound(path, soundVolume);
                }

                keysJustPressed = currentKeysSounds.Keys;
            }
            else if (!showingMsgBox) //dont run when already showing messagebox (don't want a bunch of these on your screen, do you?)
            {
                SystemSounds.Beep.Play();
                showingMsgBox = true;
                MessageBox.Show("File " + path + " does not exist");
                showingMsgBox = false;
            }
        }

        private void cbLoopbackDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEnableLoopback.Checked) //start loopback on new device, or stop loopback
            {
                restartLoopback();
            }

            string deviceName = (string)cbLoopbackDevices.SelectedItem;

            XMLSettings.soundboardSettings.LastLoopbackDevice = deviceName;
            saveSettings();
        }

        private void cbPlaybackDevices1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //start loopback on new device and stop all sounds playing
            if (loopbackWaveOut != null && loopbackSourceStream != null)
            {
                restartLoopback();
            }

            stopPlayback();

            string deviceName = (string)cbPlaybackDevices1.SelectedItem;

            initAudioPlaybackEngine1();

            XMLSettings.soundboardSettings.LastPlaybackDevice = deviceName;
            saveSettings();
        }

        private void cbPlaybackDevices2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //start loopback on new device and stop all sounds playing
            if (loopbackWaveOut != null && loopbackSourceStream != null)
            {
                restartLoopback();
            }
                
            stopPlayback();

            string deviceName = (string)cbPlaybackDevices2.SelectedItem;

            initAudioPlaybackEngine2();

            XMLSettings.soundboardSettings.LastPlaybackDevice2 = deviceName;
            saveSettings();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && XMLSettings.soundboardSettings.MinimiseToTray)
            {
                this.HideFormToTray();
            }

            //deselect all controls (to set values)
            this.ActiveControl = null;
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon1.Visible = false;

                this.ShowForm();
            }

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            this.ShowForm();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowForm()
        {
            allowVisible = true;

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void HideFormToTray()
        {
            allowVisible = false;
            notifyIcon1.Visible = true;

            this.Hide();
        }

        
        private bool cbEnableHotkeysWasChecked = false;
        private void tbPushToTalkKey_Enter(object sender, EventArgs e)
        {
            if (cbEnableHotkeys.Checked)
            {
                cbEnableHotkeys.Checked = false;
                cbEnableHotkeysWasChecked = true;
            }


            pushToTalkKeyTimer.Enabled = true;
        }

        private void tbPushToTalkKey_Leave(object sender, EventArgs e)
        {
            //only check enable hotkeys if it was previously checked before changing this field 
            if (cbEnableHotkeysWasChecked)
            {
                cbEnableHotkeys.Checked = true;
                cbEnableHotkeysWasChecked = false;
            }

            pushToTalkKeyTimer.Enabled = false;
            pushToTalkKeyTimer.Interval = 100;

            XMLSettings.soundboardSettings.AutoPushToTalkKey = pushToTalkKey;
            saveSettings();
        }

        private void pushToTalkKeyTimer_Tick(object sender, EventArgs e)
        {
            pushToTalkKeyTimer.Interval = 10; //lowering the interval to avoid missing key presses (e.g. when an input is corrected)

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                tbPushToTalkKey.Text = "";
                pushToTalkKey = default;
            }
            else
            {
                foreach (Keys key in Enum.GetValues(typeof(Keys)))
                {
                    if (Keyboard.IsKeyDown(key))
                    {
                        tbPushToTalkKey.Text = Helper.keysToString(key);
                        pushToTalkKey = key;

                        break;
                    }
                }
            }
        }

        private void cbEnablePushToTalk_CheckedChanged(object sender, EventArgs e)
        {
            if (tbPushToTalkKey.Text == "")
            {
                cbEnablePushToTalk.Checked = false;
                MessageBox.Show("There is no push to talk key entered");

                return;
            }

            tbPushToTalkKey.Enabled = !cbEnablePushToTalk.Checked;
            clearHotkey.Enabled = !cbEnablePushToTalk.Checked;

            XMLSettings.soundboardSettings.EnableAutoPushToTalk = cbEnablePushToTalk.Checked;
            saveSettings();
        }

        private void cbWindows_Leave(object sender, EventArgs e)
        {
            SaveAutoPushToTalkWindow();
        }

        private void btnReloadWindows_Click(object sender, EventArgs e)
        {
            Helper.getWindows(cbWindows);
            SaveAutoPushToTalkWindow();
        }

        private void SaveAutoPushToTalkWindow() {
            XMLSettings.soundboardSettings.AutoPushToTalkWindow = cbWindows.SelectedIndex == 0 ? "" : cbWindows.Text;
            saveSettings();
        }

        private void clearHotkey_Click( object sender, EventArgs e )
        {
            tbPushToTalkKey.Text = "";

            XMLSettings.soundboardSettings.AutoPushToTalkKey = default(Keys);
            saveSettings();
        }


        private bool volumeChangedBySlider = false;
        private bool volumeChangedByField = false;
        public void vsSoundVolume_VolumeChanged(object sender, EventArgs e)
        {
            soundVolume = vsSoundVolume.Volume;

            XMLSettings.soundboardSettings.SoundVolume = soundVolume;
            saveSettings();

            //prevent infinite or skipped changes
            if (volumeChangedByField)
            {
                volumeChangedByField = false;

                return;
            }

            volumeChangedBySlider = true;

            nSoundVolume.Value = Helper.linearVolumeToInteger(vsSoundVolume.Volume);
        }

        public void vsSoundVolume_MouseWheel(object sender, MouseEventArgs e)
        {
            vsSoundVolume.Volume = Helper.getNewSoundVolume(vsSoundVolume.Volume, e.Delta);
        }

        public void nSoundVolume_ValueChanged(object sender, EventArgs e)
        {
            //prevent infinite or skipped changes
            if (volumeChangedBySlider)
            {
                volumeChangedBySlider = false;

                return;
            }

            volumeChangedByField = true;

            vsSoundVolume.Volume = (float)(nSoundVolume.Value / 100);
        }

        private void saveSettings()
        {
            saveSettingsTimer.Stop();
            saveSettingsTimer.Start();
        }

        private void saveSettingsTimer_Tick(object sender, EventArgs e)
        {
            //only save settings after no setting changes have been made for one second
            saveSettingsTimer.Stop();
            XMLSettings.SaveSoundboardSettingsXML();
        }

        public void form_Click(object sender, EventArgs e)
        {
            //deselect all controls (to set values)
            this.ActiveControl = null;
        }
    }
}