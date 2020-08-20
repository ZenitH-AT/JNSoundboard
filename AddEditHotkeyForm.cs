using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JNSoundboard
{
    public partial class AddEditHotkeyForm : Form
    {
        MainForm mainForm;
        SettingsForm settingsForm;

        internal static string lastWindow = "";
        internal static float lastSoundVolume = 1;

        internal string[] editStrings = null;
        internal float editVolume;
        internal int editIndex = -1;

        public AddEditHotkeyForm()
        {
            InitializeComponent();
        }

        private void AddEditSoundKeys_Load(object sender, EventArgs e)
        {
            if (SettingsForm.addingEditingLoadXMLFile)
            {
                //resize and hide components unrelated to settings form
                this.Size = new Size(282, 176);
                pnAddEditSound.Visible = false;

                settingsForm = Application.OpenForms[1] as SettingsForm;

                this.Text = "Add/edit keys and XML location";

                if (editIndex != -1)
                {
                    tbKeys.Text = editStrings[0];
                    tbLocation.Text = editStrings[1];
                }
            }
            else
            {
                mainForm = Application.OpenForms[0] as MainForm;

                labelLocation.Text += "(s) (use ; to separate multiple locations)";
                labelKeys.Text += " (optional)";

                if (editIndex != -1)
                {
                    tbLocation.Text = editStrings[2];
                    tbKeys.Text = editStrings[0];
                }

                vsSoundVolume.Volume = (editIndex != -1) ? editVolume : lastSoundVolume;

                Helper.getWindows(cbWindows);

                string windowToSelect = (editIndex != -1) ? editStrings[1] : lastWindow;

                Helper.selectWindow(cbWindows, windowToSelect);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLocation.Text))
            {
                MessageBox.Show("Location is empty");
                return;
            }

            if (SettingsForm.addingEditingLoadXMLFile && string.IsNullOrWhiteSpace(tbKeys.Text))
            {
                MessageBox.Show("No keys entered");
                return;
            }

            string[] soundLocations = null;
            string fileNames;
            string errorMessage;

            if (!SettingsForm.addingEditingLoadXMLFile)
            {
                if (Helper.stringToFileLocationsArray(tbLocation.Text, out soundLocations, out errorMessage))
                {
                    if (soundLocations.Any(x => string.IsNullOrWhiteSpace(x) || !File.Exists(x)))
                    {
                        MessageBox.Show("One or more files do not exist");

                        this.Close();

                        return;
                    }
                }

                if (soundLocations == null)
                {
                    MessageBox.Show(errorMessage);
                    return;
                }
            }

            if (!Helper.stringToKeysArray(tbKeys.Text, out Keyboard.Keys[] keysArray, out _)) keysArray = new Keyboard.Keys[] { };

            if (SettingsForm.addingEditingLoadXMLFile)
            {
                fileNames = Helper.fileLocationsArrayToString(new string[] { tbLocation.Text });

                if (editIndex != -1)
                {
                    settingsForm.lvKeysLocations.Items[editIndex].Text = tbKeys.Text;
                    settingsForm.lvKeysLocations.Items[editIndex].SubItems[1].Text = tbLocation.Text;

                    settingsForm.lvKeysLocations.Items[editIndex].ToolTipText = fileNames;

                    settingsForm.loadXMLFilesList[editIndex].Keys = keysArray;
                    settingsForm.loadXMLFilesList[editIndex].XMLLocation = tbLocation.Text;
                }
                else
                {
                    var item = new ListViewItem(tbKeys.Text);
                    item.SubItems.Add(tbLocation.Text);

                    item.ToolTipText = fileNames;

                    settingsForm.lvKeysLocations.Items.Add(item);

                    settingsForm.loadXMLFilesList.Add(new XMLSettings.LoadXMLFile(keysArray, tbLocation.Text));
                }
            }
            else
            {
                fileNames = Helper.getFileNamesTooltip(soundLocations);

                string volumeString = vsSoundVolume.Volume == 1 ? "" : Helper.linearVolumeToString(vsSoundVolume.Volume);

                string windowText = (cbWindows.SelectedIndex > 0) ? cbWindows.Text : "";

                if (editIndex != -1)
                {
                    mainForm.lvKeySounds.Items[editIndex].SubItems[0].Text = tbKeys.Text;
                    mainForm.lvKeySounds.Items[editIndex].SubItems[1].Text = volumeString;
                    mainForm.lvKeySounds.Items[editIndex].SubItems[2].Text = windowText;
                    mainForm.lvKeySounds.Items[editIndex].SubItems[3].Text = tbLocation.Text;

                    mainForm.lvKeySounds.Items[editIndex].ToolTipText = fileNames;

                    mainForm.soundHotkeys[editIndex] = new XMLSettings.SoundHotkey(keysArray, vsSoundVolume.Volume, windowText, soundLocations);
                }
                else
                {
                    var newItem = new ListViewItem(tbKeys.Text);
                    newItem.SubItems.Add(volumeString);
                    newItem.SubItems.Add(windowText);
                    newItem.SubItems.Add(tbLocation.Text);

                    newItem.ToolTipText = fileNames;

                    mainForm.lvKeySounds.Items.Add(newItem);

                    mainForm.soundHotkeys.Add(new XMLSettings.SoundHotkey(keysArray, vsSoundVolume.Volume, windowText, soundLocations));
                }

                mainForm.sortHotkeys();

                //remember last used options
                lastSoundVolume = vsSoundVolume.Volume;
                lastWindow = cbWindows.Text;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseSoundLocation_Click(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog();

            diag.Multiselect = !SettingsForm.addingEditingLoadXMLFile;

            diag.Filter = (SettingsForm.addingEditingLoadXMLFile ? "XML file containing keys and sounds|*.xml" : "Supported audio formats|*.mp3;*.m4a;*.wav;*.wma;*.ac3;*.aiff;*.mp2|All files|*.*");

            var result = diag.ShowDialog();

            if (result == DialogResult.OK)
            {
                string text = "";

                for (int i = 0; i < diag.FileNames.Length; i++)
                {
                    string fileName = diag.FileNames[i];

                    if (fileName != "") text += (i == 0 ? "" : ";") + fileName;
                }

                tbLocation.Text = text;
            }
        }

        private void tbKeys_Enter(object sender, EventArgs e)
        {
            keysTimer.Enabled = true;
        }

        private void tbKeys_Leave(object sender, EventArgs e)
        {
            keysTimer.Enabled = false;
            keysTimer.Interval = 100;
        }


        private int lastAmountPressed = 0;
        private void keysTimer_Tick(object sender, EventArgs e)
        {
            keysTimer.Interval = 10; //lowering the interval to avoid missing key presses (e.g. when an input is corrected)

            var keysData = Keyboard.getKeys(lastAmountPressed, tbKeys.Text);

            lastAmountPressed = keysData.Item1;
            tbKeys.Text = keysData.Item2;
        }

        private void btnReloadWindows_Click(object sender, EventArgs e)
        {
            Helper.getWindows(cbWindows);
        }

        private void clearHotkey_Click( object sender, EventArgs e )
        {
            tbKeys.Text = "";
        }


        private bool volumeChangedBySlider = false;
        private bool volumeChangedByField = false;
        public void vsSoundVolume_VolumeChanged(object sender, EventArgs e)
        {
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
    }
}
