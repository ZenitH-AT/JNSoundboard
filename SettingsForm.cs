using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JNSoundboard
{
    public partial class SettingsForm : Form
    {
        internal List<XMLSettings.LoadXMLFile> loadXMLFilesList = new List<XMLSettings.LoadXMLFile>(XMLSettings.soundboardSettings.LoadXMLFiles); //list so can dynamically add/remove

        internal static bool addingEditingLoadXMLFile = false;

        public SettingsForm()
        {
            InitializeComponent();

            for (int i = 0; i < loadXMLFilesList.Count; i++)
            {
                string xmlLocation = loadXMLFilesList[i].XMLLocation;

                bool keysLengthCorrect = loadXMLFilesList[i].Keys.Length > 0;
                bool xmlLocationUnempty = !string.IsNullOrWhiteSpace(xmlLocation);

                if (!keysLengthCorrect && !xmlLocationUnempty) //remove if empty
                {
                    loadXMLFilesList.RemoveAt(i);
                    i--;
                    continue;
                }

                var item = new ListViewItem((keysLengthCorrect ? string.Join("+", loadXMLFilesList[i].Keys) : ""));
                item.SubItems.Add((xmlLocationUnempty ? xmlLocation : ""));

                item.ToolTipText = Helper.getFileNamesTooltip(new string[] { xmlLocation });

                lvKeysLocations.Items.Add(item);
            }

            tbStopSoundKeys.Text = Helper.keysArrayToString(XMLSettings.soundboardSettings.StopSoundKeys);

            cbStartWithWindows.Checked = XMLSettings.soundboardSettings.StartWithWindows;

            cbStartMinimised.Checked = XMLSettings.soundboardSettings.StartMinimised;

            cbMinimiseToTray.Checked = XMLSettings.soundboardSettings.MinimiseToTray;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addingEditingLoadXMLFile = true;

            var form = new AddEditHotkeyForm();
            form.ShowDialog();

            addingEditingLoadXMLFile = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvKeysLocations.SelectedIndices.Count > 0)
            {
                addingEditingLoadXMLFile = true;

                var form = new AddEditHotkeyForm();

                form.editIndex = lvKeysLocations.SelectedIndices[0];
                form.editStrings = new string[] { lvKeysLocations.SelectedItems[0].Text, lvKeysLocations.SelectedItems[0].SubItems[1].Text };

                form.ShowDialog();

                addingEditingLoadXMLFile = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvKeysLocations.SelectedIndices.Count > 0 && MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = lvKeysLocations.SelectedIndices[0];

                lvKeysLocations.Items.RemoveAt(index);
                loadXMLFilesList.RemoveAt(index);
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Helper.stringToKeysArray(tbStopSoundKeys.Text, out Keyboard.Keys[] keysArray, out _)) keysArray = new Keyboard.Keys[] { };

            if (loadXMLFilesList.Count == 0 || loadXMLFilesList.All(x => x.Keys.Length > 0 && !string.IsNullOrWhiteSpace(x.XMLLocation) && File.Exists(x.XMLLocation)))
            {
                XMLSettings.soundboardSettings.StopSoundKeys = keysArray;

                XMLSettings.soundboardSettings.LoadXMLFiles = loadXMLFilesList.ToArray();

                XMLSettings.soundboardSettings.StartWithWindows = cbStartWithWindows.Checked;
                Helper.setStartup(XMLSettings.soundboardSettings.StartWithWindows);

                XMLSettings.soundboardSettings.StartMinimised = cbStartMinimised.Checked;

                XMLSettings.soundboardSettings.MinimiseToTray = cbMinimiseToTray.Checked;

                XMLSettings.SaveSoundboardSettingsXML();

                this.Close();
            }
            else
            {
                MessageBox.Show("One or more entries either have no keys added, the location is empty, or the file the location points to does not exist");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvKeysLocations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void tbStopSoundKeys_Enter(object sender, EventArgs e)
        {
            keysTimer.Enabled = true;
        }

        private void tbStopSoundKeys_Leave(object sender, EventArgs e)
        {
            keysTimer.Enabled = false;
            keysTimer.Interval = 100;
        }


        private int lastAmountPressed = 0;
        private void keysTimer_Tick(object sender, EventArgs e)
        {
            keysTimer.Interval = 10; //lowering the interval to avoid missing key presses (e.g. when an input is corrected)

            var keysData = Keyboard.getKeys(lastAmountPressed, tbStopSoundKeys.Text);

            lastAmountPressed = keysData.Item1;
            tbStopSoundKeys.Text = keysData.Item2;
        }

        private void clearHotkey_Click(object sender, EventArgs e)
        {
            tbStopSoundKeys.Text = "";
        }
    }
}