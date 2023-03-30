using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace JNSoundboard
{
    public class XMLSettings
    {
        readonly static SoundboardSettings DEFAULT_SOUNDBOARD_SETTINGS = new SoundboardSettings(new Keyboard.Keys[] { }, new LoadXMLFile[] { new LoadXMLFile(new Keyboard.Keys[] { }, "") }, false, false, true, true, true, 1, false, new Keyboard.Keys { }, "", "", "", "", "", false);

        internal static SoundboardSettings soundboardSettings = new SoundboardSettings();

        //saving XML files like this makes the XML messy, but it works
        #region Keys and sounds settings
        public class SoundHotkey
        {
            public Keyboard.Keys[] Keys;
            public float SoundVolume;
            public string WindowTitle;
            public string[] SoundLocations;

            public SoundHotkey() { }

            public SoundHotkey(Keyboard.Keys[] keys, float soundVolume, string windowTitle, string[] soundLocations)
            {
                Keys = keys;
                SoundVolume = soundVolume;
                WindowTitle = windowTitle;
                SoundLocations = soundLocations;
            }
        }

        [Serializable]
        public class Settings
        {
            public SoundHotkey[] SoundHotkeys;

            public Settings() { }

            public Settings(SoundHotkey[] soundHotkeys)
            {
                SoundHotkeys = soundHotkeys;
            }
        }
        #endregion

        #region Soundboard settings
        public class LoadXMLFile
        {
            public Keyboard.Keys[] Keys;
            public string XMLLocation;

            public LoadXMLFile() { }

            public LoadXMLFile(Keyboard.Keys[] keys, string xmlLocation)
            {
                Keys = keys;
                XMLLocation = xmlLocation;
            }
        }

        [Serializable]
        public class SoundboardSettings
        {
            public Keyboard.Keys AutoPushToTalkKey;
            public Keyboard.Keys[] StopSoundKeys;
            public LoadXMLFile[] LoadXMLFiles;
            public bool StartWithWindows, StartMinimised, MinimiseToTray, EnableHotkeys, EnableLoopback, EnableAutoPushToTalk, AllowOverlap;
            public string AutoPushToTalkWindow, LastPlaybackDevice, LastPlaybackDevice2, LastLoopbackDevice, LastXMLFile;
            public float SoundVolume;

            public SoundboardSettings() { }

            public SoundboardSettings(Keyboard.Keys[] stopSoundKeys, LoadXMLFile[] loadXMLFiles, bool startWithWindows, bool startMinimised, bool minimiseToTray, bool enableHotkeys, bool enableLoopback, float soundVolume,
                bool enableAutoPushToTalk, Keyboard.Keys autoPushToTalkKey, string autoPushToTalkWindow, string lastPlaybackDevice, string lastPlaybackDevice2, string lastLoopbackDevice, string lastXMLFile, bool allowOverlap)
            {
                StopSoundKeys = stopSoundKeys;
                LoadXMLFiles = loadXMLFiles;
                StartWithWindows = startWithWindows;
                StartMinimised = startMinimised;
                MinimiseToTray = minimiseToTray;
                EnableHotkeys = enableHotkeys;
                EnableLoopback = enableLoopback;
                SoundVolume = soundVolume;
                EnableAutoPushToTalk = enableAutoPushToTalk;
                AutoPushToTalkKey = autoPushToTalkKey;
                AutoPushToTalkWindow = autoPushToTalkWindow;
                LastPlaybackDevice = lastPlaybackDevice;
                LastPlaybackDevice2 = lastPlaybackDevice2;
                LastLoopbackDevice = lastLoopbackDevice;
                LastXMLFile = lastXMLFile;
                AllowOverlap = allowOverlap;
            }
        }
        #endregion

        internal static void WriteXML(object kl, string xmlLocation)
        {
            XmlSerializer serializer = new XmlSerializer(kl.GetType());

            using (MemoryStream memStream = new MemoryStream())
            {
                using (StreamWriter stream = new StreamWriter(memStream, Encoding.Unicode))
                {
                    var settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;

                    using (var writer = XmlWriter.Create(stream, settings))
                    {
                        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                        serializer.Serialize(writer, kl, emptyNamepsaces);

                        int count = (int)memStream.Length;

                        byte[] arr = new byte[count];
                        memStream.Seek(0, SeekOrigin.Begin);

                        memStream.Read(arr, 0, count);

                        using (BinaryWriter binWriter = new BinaryWriter(File.Open(xmlLocation, FileMode.Create)))
                        {
                            binWriter.Write(arr);
                        }
                    }
                }
            }
        }

        internal static object ReadXML(Type type, string xmlLocation)
        {
            var serializer = new XmlSerializer(type);

            using (var reader = XmlReader.Create(xmlLocation))
            {
                if (serializer.CanDeserialize(reader))
                {
                    return serializer.Deserialize(reader);
                }
                else return null;
            }
        }

        internal static void SaveSoundboardSettingsXML()
        {
            //a proper mitigation technique for rapid calls to this function should be implemented
            try { WriteXML(soundboardSettings, Path.GetDirectoryName(Application.ExecutablePath) + "\\settings.xml"); }
            catch { }
        }

        internal static void LoadSoundboardSettingsXML()
        {
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\settings.xml";

            if (File.Exists(filePath))
            {
                try
                {
                    SoundboardSettings settings = (SoundboardSettings)ReadXML(typeof(SoundboardSettings), filePath);

                    bool settingsInvalid = false;

                    //validation start

                    if (settings.StopSoundKeys == null)
                    {
                        settings.StopSoundKeys = new Keyboard.Keys[] { };
                        settingsInvalid = true;
                    }

                    if (settings.LoadXMLFiles == null)
                    {
                        settings.LoadXMLFiles = new LoadXMLFile[] { };
                        settingsInvalid = true;
                    }

                    if (settings.AutoPushToTalkWindow == null)
                    {
                        settings.AutoPushToTalkWindow = "";
                        settingsInvalid = true;
                    }

                    if (settings.LastPlaybackDevice == null)
                    {
                        settings.LastPlaybackDevice = "";
                        settingsInvalid = true;
                    }

                    if (settings.LastPlaybackDevice2 == null)
                    {
                        settings.LastPlaybackDevice2 = "";
                        settingsInvalid = true;
                    }

                    if (settings.LastLoopbackDevice == null)
                    {
                        settings.LastLoopbackDevice = "";
                        settingsInvalid = true;
                    }

                    if (settings.LastXMLFile == null)
                    {
                        settings.LastXMLFile = "";
                        settingsInvalid = true;
                    }
                    
                    if (settings.SoundVolume < 0)
                    {
                        settings.SoundVolume = 0;
                        settingsInvalid = true;
                    }
                    else if (settings.SoundVolume > 1)
                    {
                        settings.SoundVolume = 1;
                        settingsInvalid = true;
                    }

                    //validation end

                    soundboardSettings = settings;

                    if (settingsInvalid)
                    {
                        //recreate settings.xml with the corrected values
                        SaveSoundboardSettingsXML();
                    }
                }
                catch
                {
                    MessageBox.Show("Settings file invalid, using default settings");

                    WriteXML(DEFAULT_SOUNDBOARD_SETTINGS, filePath);
                    soundboardSettings = DEFAULT_SOUNDBOARD_SETTINGS;
                }
            }
            else
            {
                WriteXML(DEFAULT_SOUNDBOARD_SETTINGS, filePath);
                soundboardSettings = DEFAULT_SOUNDBOARD_SETTINGS;
            }
        }
    }
}
