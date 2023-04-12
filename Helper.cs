using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace JNSoundboard
{
    class Helper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        internal static bool isForegroundWindow(string windowTitle)
        {
            IntPtr foregroundWindow = GetForegroundWindow();

            return isForegroundWindow(foregroundWindow, windowTitle);
        }

        internal static bool isForegroundWindow(IntPtr foregroundWindow, string windowTitle)
        {
            IntPtr window = FindWindow(null, windowTitle);

            if (window == IntPtr.Zero) return false; //not found

            return foregroundWindow == window;
        }

        internal static string userGetXmlLocation()
        {
            SaveFileDialog diag = new SaveFileDialog();

            diag.Filter = "XML file containing keys and sounds|*.xml";

            var result = diag.ShowDialog();

            if (result == DialogResult.OK)
            {
                return diag.FileName;
            }
            else return null;
        }

        internal static bool stringToKey(string keyString, out Keyboard.Keys key)
        {
            if (keyString.Contains("VK_"))
            {
                //key has no name
                keyString = keyString.Substring(keyString.LastIndexOf('_') + 1);

                try
                {
                    key = (Keyboard.Keys)int.Parse(keyString, System.Globalization.NumberStyles.HexNumber);

                    return true;
                }
                catch
                {
                    key = 0;

                    return false;
                }
            }
            else if (Enum.TryParse(keyString, out key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static string keysArrayToString(Keyboard.Keys[] keysArray)
        {
            if (keysArray == null) return "";

            string keysString = "";

            int i = 0;

            foreach (Keyboard.Keys key in keysArray)
            {
                keysString += key.ToString() + (i++ == keysArray.Length - 1 ? "" : "+");
            }

            return keysString;
        }

        internal static string[] keysArrayToStringArray(Keyboard.Keys[] keysArray)
        {
            var keysList = new List<string>();

            foreach (Keyboard.Keys key in keysArray)
            {
                keysList.Add(key.ToString());
            }

            return keysList.ToArray();
        }

        internal static bool stringToKeysArray(string keysString, out Keyboard.Keys[] keysArray, out string errorMessage)
        {
            errorMessage = "";

            if (keysString.Contains("+"))
            {
                string[] stringArray = keysString.Split('+');
                var keysList = new List<Keyboard.Keys>();

                foreach (string keyString in stringArray)
                {
                    if (stringToKey(keyString, out Keyboard.Keys key))
                    {
                        keysList.Add(key);
                    }
                    else
                    {
                        errorMessage = "Key string \"" + keyString + "\" doesn't exist";
                        keysArray = null;

                        return false;
                    }
                }

                keysArray = keysList.ToArray();

                return true;
            }
            else
            {
                if (stringToKey(keysString, out Keyboard.Keys key))
                {
                    keysArray = new Keyboard.Keys[] { key };
                    
                    return true;
                }
                else
                {
                    errorMessage = "Key string \"" + keysString + "\" doesn't exist";
                    keysArray = null;

                    return false;
                }
            }
        }

        internal static bool stringArrayToKeysArray(string[] stringArray, out Keyboard.Keys[] keysArray, out string errorMessage)
        {
            errorMessage = "";

            if (stringArray == null) {
                keysArray = new Keyboard.Keys[] { 0 };

                return true;
            }

            var keysList = new List<Keyboard.Keys>();

            foreach (string keyString in stringArray)
            {
                if (stringToKey(keyString, out Keyboard.Keys key))
                {
                    keysList.Add(key);
                }
                else
                {
                    errorMessage = "Key string \"" + keyString + "\" doesn't exist";
                    keysArray = null;

                    return false;
                }
            }

            keysArray = keysList.ToArray();

            return true;
        }

        internal static bool stringToFileLocationsArray(string fileLocationsString, out string[] fileLocations, out string errorMessage)
        {
            errorMessage = "";

            if (fileLocationsString.Contains(";"))
            {
                string[] sLocations = fileLocationsString.Split(';');
                var lLocations = new List<string>();

                for (int i = 0; i < sLocations.Length; i++)
                {
                    if (File.Exists(sLocations[i]))
                    {
                        lLocations.Add(sLocations[i]);
                    }
                    else
                    {
                        errorMessage = "File \"" + sLocations[i] + "\" does not exist";
                        fileLocations = null;
                        return false;
                    }
                }

                fileLocations = lLocations.ToArray();
                return true;
            }
            else
            {
                if (File.Exists(fileLocationsString))
                {
                    fileLocations = new string[] { fileLocationsString };
                    return true;
                }
                else
                {
                    errorMessage = "File \"" + fileLocationsString + "\" does not exist";
                    fileLocations = null;
                    return false;
                }
            }
        }

        internal static string fileLocationsArrayToString(string[] fileLocations)
        {
            string temp = "";
            int sLength = fileLocations.Length;

            for (int i = 0; i < sLength; i++)
            {
                temp += fileLocations[i].ToString() + (i == sLength - 1 ? "" : ";");
            }

            return temp;
        }

        internal static string getFileNamesTooltip(string[] fileLocations)
        {
            string soundNames = "";

            for (int i = 0; i < fileLocations.Length - 1; i++)
            {
                soundNames += Path.GetFileNameWithoutExtension(fileLocations[i]) + "\n";
            }

            return soundNames += Path.GetFileNameWithoutExtension(fileLocations[fileLocations.Length - 1]);
        }

        internal static string cleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), ""));
        }
        
        internal static void getWindows(ComboBox cbWindows)
        {
            string oldWindow = cbWindows.Text;

            cbWindows.Items.Clear();

            cbWindows.Items.Add("[Any window]");

            cbWindows.SelectedIndex = 0;

            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    cbWindows.Items.Add(process.MainWindowTitle);

                    //keep selection if program still in list
                    if (oldWindow == process.MainWindowTitle)
                    {
                        cbWindows.SelectedItem = process.MainWindowTitle;
                    }
                }
            }
        }

        internal static void selectWindow(ComboBox cbWindows, string windowToSelect)
        {
            if (windowToSelect != "")
            {
                int index = cbWindows.Items.IndexOf(windowToSelect);

                if (index != -1)
                {
                    //select the item
                    cbWindows.SelectedIndex = index;
                }
                else
                {
                    //add and select the item
                    cbWindows.Items.Add(windowToSelect);
                    cbWindows.SelectedIndex = cbWindows.Items.Count - 1;
                }
            }
        }

        internal static void setStartup(bool StartWithWindows)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (StartWithWindows && key.GetValue("JN Soundboard") == null)
            {
                key.SetValue("JN Soundboard", Application.ExecutablePath.ToString());
            }
            else if (key.GetValue("JN Soundboard") != null)
            {
                key.DeleteValue("JN Soundboard");
            }
        }

        internal static int linearVolumeToInteger(float linearVolume)
        {
            return linearVolume > 0.1 ? (int)Math.Round(linearVolume * 100) : (int)Math.Ceiling(linearVolume * 100);
        }

        internal static string linearVolumeToString(float linearVolume)
        {
            double decibels = NAudio.Utils.Decibels.LinearToDecibels(linearVolume);
            int linearInteger = linearVolumeToInteger(linearVolume);

            return string.Format("{0:N2} dB ({1})", decibels, linearInteger);
        }

        internal static float getNewSoundVolume(float oldVolume, int delta)
        {
            float[] increments = { 0, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1 };

            if (delta > 0 && oldVolume < 1)
            {
                for (int i = 1; i < increments.Length; i++)
                {
                    if (oldVolume < increments[i]) return increments[i];
                }
            }
            else if (delta < 0 && oldVolume > 0)
            {
                for (int i = increments.Length - 2; i >= 0; i--)
                {
                    if (oldVolume > increments[i]) return increments[i];
                }
            }

            return oldVolume;
        }
    }
}