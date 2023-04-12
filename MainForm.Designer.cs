namespace JNSoundboard
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblPlayback1 = new System.Windows.Forms.Label();
            this.cbPlaybackDevices1 = new System.Windows.Forms.ComboBox();
            this.cbEnableHotkeys = new System.Windows.Forms.CheckBox();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvKeySounds = new System.Windows.Forms.ListView();
            this.chKeys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVolume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWindow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReloadDevices = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.texttospeechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLoopback = new System.Windows.Forms.Label();
            this.cbLoopbackDevices = new System.Windows.Forms.ComboBox();
            this.btnPlaySelectedSound = new System.Windows.Forms.Button();
            this.btnStopAllSounds = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPushToTalk = new System.Windows.Forms.GroupBox();
            this.clearHotkey = new System.Windows.Forms.Button();
            this.btnReloadWindows = new System.Windows.Forms.Button();
            this.cbEnablePushToTalk = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPushToTalkKey = new System.Windows.Forms.TextBox();
            this.cbWindows = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbAudioDevices = new System.Windows.Forms.GroupBox();
            this.cbPlaybackDevices2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPlayback2 = new System.Windows.Forms.Label();
            this.pushToTalkKeyTimer = new System.Windows.Forms.Timer(this.components);
            this.cbEnableLoopback = new System.Windows.Forms.CheckBox();
            this.vsSoundVolume = new NAudio.Gui.VolumeSlider();
            this.nSoundVolume = new System.Windows.Forms.NumericUpDown();
            this.gbSoundboard = new System.Windows.Forms.GroupBox();
            this.saveSettingsTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.gbPushToTalk.SuspendLayout();
            this.gbAudioDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoundVolume)).BeginInit();
            this.gbSoundboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlayback1
            // 
            this.lblPlayback1.AutoSize = true;
            this.lblPlayback1.Location = new System.Drawing.Point(8, 21);
            this.lblPlayback1.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.lblPlayback1.Name = "lblPlayback1";
            this.lblPlayback1.Size = new System.Drawing.Size(126, 13);
            this.lblPlayback1.TabIndex = 5;
            this.lblPlayback1.Text = "Speakers or Virtual Cable";
            // 
            // cbPlaybackDevices1
            // 
            this.cbPlaybackDevices1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaybackDevices1.FormattingEnabled = true;
            this.cbPlaybackDevices1.Location = new System.Drawing.Point(142, 18);
            this.cbPlaybackDevices1.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.cbPlaybackDevices1.Name = "cbPlaybackDevices1";
            this.cbPlaybackDevices1.Size = new System.Drawing.Size(176, 21);
            this.cbPlaybackDevices1.TabIndex = 11;
            // 
            // cbEnableHotkeys
            // 
            this.cbEnableHotkeys.AutoSize = true;
            this.cbEnableHotkeys.Location = new System.Drawing.Point(8, 20);
            this.cbEnableHotkeys.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.cbEnableHotkeys.Name = "cbEnableHotkeys";
            this.cbEnableHotkeys.Size = new System.Drawing.Size(101, 17);
            this.cbEnableHotkeys.TabIndex = 16;
            this.cbEnableHotkeys.Text = "Enable Hotkeys";
            this.cbEnableHotkeys.UseVisualStyleBackColor = true;
            this.cbEnableHotkeys.CheckedChanged += new System.EventHandler(this.cbEnableHotkeys_CheckedChanged);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 50;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(138, 321);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(572, 125);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 43);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(572, 76);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 43);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(572, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 43);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvKeySounds
            // 
            this.lvKeySounds.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvKeySounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvKeySounds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chKeys,
            this.chVolume,
            this.chWindow,
            this.chLocation});
            this.lvKeySounds.FullRowSelect = true;
            this.lvKeySounds.GridLines = true;
            this.lvKeySounds.HideSelection = false;
            this.lvKeySounds.Location = new System.Drawing.Point(12, 27);
            this.lvKeySounds.MultiSelect = false;
            this.lvKeySounds.Name = "lvKeySounds";
            this.lvKeySounds.ShowItemToolTips = true;
            this.lvKeySounds.Size = new System.Drawing.Size(554, 288);
            this.lvKeySounds.TabIndex = 0;
            this.lvKeySounds.UseCompatibleStateImageBehavior = false;
            this.lvKeySounds.View = System.Windows.Forms.View.Details;
            this.lvKeySounds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvKeySounds_MouseDoubleClick);
            // 
            // chKeys
            // 
            this.chKeys.Text = "Keys";
            this.chKeys.Width = 100;
            // 
            // chVolume
            // 
            this.chVolume.Text = "Volume";
            this.chVolume.Width = 85;
            // 
            // chWindow
            // 
            this.chWindow.Text = "Window";
            this.chWindow.Width = 100;
            // 
            // chLocation
            // 
            this.chLocation.Text = "Location";
            this.chLocation.Width = 265;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(12, 321);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReloadDevices
            // 
            this.btnReloadDevices.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadDevices.Image")));
            this.btnReloadDevices.Location = new System.Drawing.Point(324, 17);
            this.btnReloadDevices.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.btnReloadDevices.Name = "btnReloadDevices";
            this.btnReloadDevices.Size = new System.Drawing.Size(23, 23);
            this.btnReloadDevices.TabIndex = 14;
            this.btnReloadDevices.UseVisualStyleBackColor = true;
            this.btnReloadDevices.Click += new System.EventHandler(this.btnReloadDevices_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(572, 174);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 43);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveAs.Location = new System.Drawing.Point(264, 321);
            this.btnSaveAs.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(120, 23);
            this.btnSaveAs.TabIndex = 9;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.texttospeechToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(659, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Click += new System.EventHandler(this.form_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // texttospeechToolStripMenuItem
            // 
            this.texttospeechToolStripMenuItem.Name = "texttospeechToolStripMenuItem";
            this.texttospeechToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.texttospeechToolStripMenuItem.Text = "Text-to-speech";
            this.texttospeechToolStripMenuItem.Click += new System.EventHandler(this.texttospeechToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // lblLoopback
            // 
            this.lblLoopback.AutoSize = true;
            this.lblLoopback.Location = new System.Drawing.Point(8, 48);
            this.lblLoopback.Margin = new System.Windows.Forms.Padding(5);
            this.lblLoopback.Name = "lblLoopback";
            this.lblLoopback.Size = new System.Drawing.Size(114, 13);
            this.lblLoopback.TabIndex = 18;
            this.lblLoopback.Text = "Microphone Loopback";
            // 
            // cbLoopbackDevices
            // 
            this.cbLoopbackDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoopbackDevices.FormattingEnabled = true;
            this.cbLoopbackDevices.Location = new System.Drawing.Point(142, 45);
            this.cbLoopbackDevices.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cbLoopbackDevices.Name = "cbLoopbackDevices";
            this.cbLoopbackDevices.Size = new System.Drawing.Size(176, 21);
            this.cbLoopbackDevices.TabIndex = 12;
            // 
            // btnPlaySelectedSound
            // 
            this.btnPlaySelectedSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlaySelectedSound.Location = new System.Drawing.Point(572, 223);
            this.btnPlaySelectedSound.Name = "btnPlaySelectedSound";
            this.btnPlaySelectedSound.Size = new System.Drawing.Size(75, 43);
            this.btnPlaySelectedSound.TabIndex = 5;
            this.btnPlaySelectedSound.Text = "Play sound";
            this.btnPlaySelectedSound.UseVisualStyleBackColor = true;
            this.btnPlaySelectedSound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // btnStopAllSounds
            // 
            this.btnStopAllSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopAllSounds.Location = new System.Drawing.Point(572, 272);
            this.btnStopAllSounds.Name = "btnStopAllSounds";
            this.btnStopAllSounds.Size = new System.Drawing.Size(75, 43);
            this.btnStopAllSounds.TabIndex = 6;
            this.btnStopAllSounds.Text = "Stop all sounds";
            this.btnStopAllSounds.UseVisualStyleBackColor = true;
            this.btnStopAllSounds.Click += new System.EventHandler(this.btnStopAllSounds_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Minimised to the tray.";
            this.notifyIcon1.BalloonTipTitle = "JN Soundboard";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "JN Soundboard";
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // gbPushToTalk
            // 
            this.gbPushToTalk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPushToTalk.Controls.Add(this.clearHotkey);
            this.gbPushToTalk.Controls.Add(this.btnReloadWindows);
            this.gbPushToTalk.Controls.Add(this.cbEnablePushToTalk);
            this.gbPushToTalk.Controls.Add(this.label3);
            this.gbPushToTalk.Controls.Add(this.tbPushToTalkKey);
            this.gbPushToTalk.Controls.Add(this.cbWindows);
            this.gbPushToTalk.Controls.Add(this.label4);
            this.gbPushToTalk.Location = new System.Drawing.Point(373, 429);
            this.gbPushToTalk.Name = "gbPushToTalk";
            this.gbPushToTalk.Size = new System.Drawing.Size(274, 96);
            this.gbPushToTalk.TabIndex = 19;
            this.gbPushToTalk.TabStop = false;
            this.gbPushToTalk.Text = "Auto activate push to talk";
            this.gbPushToTalk.Click += new System.EventHandler(this.form_Click);
            // 
            // clearHotkey
            // 
            this.clearHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearHotkey.ForeColor = System.Drawing.Color.Red;
            this.clearHotkey.Location = new System.Drawing.Point(244, 17);
            this.clearHotkey.Margin = new System.Windows.Forms.Padding(3, 5, 5, 3);
            this.clearHotkey.Name = "clearHotkey";
            this.clearHotkey.Size = new System.Drawing.Size(22, 22);
            this.clearHotkey.TabIndex = 21;
            this.clearHotkey.Text = "X";
            this.clearHotkey.UseVisualStyleBackColor = true;
            this.clearHotkey.Click += new System.EventHandler(this.clearHotkey_Click);
            // 
            // btnReloadWindows
            // 
            this.btnReloadWindows.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadWindows.Image")));
            this.btnReloadWindows.Location = new System.Drawing.Point(244, 43);
            this.btnReloadWindows.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnReloadWindows.Name = "btnReloadWindows";
            this.btnReloadWindows.Size = new System.Drawing.Size(22, 23);
            this.btnReloadWindows.TabIndex = 23;
            this.btnReloadWindows.UseVisualStyleBackColor = true;
            this.btnReloadWindows.Click += new System.EventHandler(this.btnReloadWindows_Click);
            // 
            // cbEnablePushToTalk
            // 
            this.cbEnablePushToTalk.AutoSize = true;
            this.cbEnablePushToTalk.Location = new System.Drawing.Point(8, 71);
            this.cbEnablePushToTalk.Margin = new System.Windows.Forms.Padding(5, 3, 3, 5);
            this.cbEnablePushToTalk.Name = "cbEnablePushToTalk";
            this.cbEnablePushToTalk.Size = new System.Drawing.Size(59, 17);
            this.cbEnablePushToTalk.TabIndex = 24;
            this.cbEnablePushToTalk.Text = "Enable";
            this.cbEnablePushToTalk.UseVisualStyleBackColor = true;
            this.cbEnablePushToTalk.CheckedChanged += new System.EventHandler(this.cbEnablePushToTalk_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Key";
            // 
            // tbPushToTalkKey
            // 
            this.tbPushToTalkKey.Location = new System.Drawing.Point(62, 18);
            this.tbPushToTalkKey.Name = "tbPushToTalkKey";
            this.tbPushToTalkKey.ReadOnly = true;
            this.tbPushToTalkKey.ShortcutsEnabled = false;
            this.tbPushToTalkKey.Size = new System.Drawing.Size(176, 20);
            this.tbPushToTalkKey.TabIndex = 20;
            this.tbPushToTalkKey.Enter += new System.EventHandler(this.tbPushToTalkKey_Enter);
            this.tbPushToTalkKey.Leave += new System.EventHandler(this.tbPushToTalkKey_Leave);
            // 
            // cbWindows
            // 
            this.cbWindows.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbWindows.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbWindows.FormattingEnabled = true;
            this.cbWindows.Location = new System.Drawing.Point(62, 44);
            this.cbWindows.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cbWindows.Name = "cbWindows";
            this.cbWindows.Size = new System.Drawing.Size(176, 21);
            this.cbWindows.TabIndex = 22;
            this.cbWindows.Leave += new System.EventHandler(this.cbWindows_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Window";
            // 
            // gbAudioDevices
            // 
            this.gbAudioDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbAudioDevices.Controls.Add(this.cbPlaybackDevices2);
            this.gbAudioDevices.Controls.Add(this.label6);
            this.gbAudioDevices.Controls.Add(this.lblPlayback2);
            this.gbAudioDevices.Controls.Add(this.lblPlayback1);
            this.gbAudioDevices.Controls.Add(this.lblLoopback);
            this.gbAudioDevices.Controls.Add(this.btnReloadDevices);
            this.gbAudioDevices.Controls.Add(this.cbPlaybackDevices1);
            this.gbAudioDevices.Controls.Add(this.cbLoopbackDevices);
            this.gbAudioDevices.Location = new System.Drawing.Point(12, 352);
            this.gbAudioDevices.Name = "gbAudioDevices";
            this.gbAudioDevices.Size = new System.Drawing.Size(355, 173);
            this.gbAudioDevices.TabIndex = 10;
            this.gbAudioDevices.TabStop = false;
            this.gbAudioDevices.Text = "Soundboard Audio devices";
            this.gbAudioDevices.Click += new System.EventHandler(this.form_Click);
            // 
            // cbPlaybackDevices2
            // 
            this.cbPlaybackDevices2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaybackDevices2.FormattingEnabled = true;
            this.cbPlaybackDevices2.Location = new System.Drawing.Point(142, 95);
            this.cbPlaybackDevices2.Margin = new System.Windows.Forms.Padding(5);
            this.cbPlaybackDevices2.Name = "cbPlaybackDevices2";
            this.cbPlaybackDevices2.Size = new System.Drawing.Size(176, 21);
            this.cbPlaybackDevices2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "(do not choose virtual cable)";
            // 
            // lblPlayback2
            // 
            this.lblPlayback2.AutoSize = true;
            this.lblPlayback2.Location = new System.Drawing.Point(8, 98);
            this.lblPlayback2.Margin = new System.Windows.Forms.Padding(5);
            this.lblPlayback2.Name = "lblPlayback2";
            this.lblPlayback2.Size = new System.Drawing.Size(97, 13);
            this.lblPlayback2.TabIndex = 19;
            this.lblPlayback2.Text = "Playback Device 2";
            // 
            // pushToTalkKeyTimer
            // 
            this.pushToTalkKeyTimer.Tick += new System.EventHandler(this.pushToTalkKeyTimer_Tick);
            // 
            // cbEnableLoopback
            // 
            this.cbEnableLoopback.AutoSize = true;
            this.cbEnableLoopback.Location = new System.Drawing.Point(115, 20);
            this.cbEnableLoopback.Margin = new System.Windows.Forms.Padding(3, 5, 5, 3);
            this.cbEnableLoopback.Name = "cbEnableLoopback";
            this.cbEnableLoopback.Size = new System.Drawing.Size(110, 17);
            this.cbEnableLoopback.TabIndex = 17;
            this.cbEnableLoopback.Text = "Enable Loopback";
            this.cbEnableLoopback.UseVisualStyleBackColor = true;
            this.cbEnableLoopback.CheckedChanged += new System.EventHandler(this.cbEnableLoopback_CheckedChanged);
            // 
            // vsSoundVolume
            // 
            this.vsSoundVolume.Location = new System.Drawing.Point(8, 43);
            this.vsSoundVolume.Margin = new System.Windows.Forms.Padding(5, 3, 3, 5);
            this.vsSoundVolume.Name = "vsSoundVolume";
            this.vsSoundVolume.Size = new System.Drawing.Size(213, 20);
            this.vsSoundVolume.TabIndex = 100;
            this.vsSoundVolume.TabStop = false;
            this.vsSoundVolume.VolumeChanged += new System.EventHandler(this.vsSoundVolume_VolumeChanged);
            this.vsSoundVolume.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.vsSoundVolume_MouseWheel);
            // 
            // nSoundVolume
            // 
            this.nSoundVolume.Location = new System.Drawing.Point(227, 43);
            this.nSoundVolume.Margin = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.nSoundVolume.Name = "nSoundVolume";
            this.nSoundVolume.Size = new System.Drawing.Size(39, 20);
            this.nSoundVolume.TabIndex = 18;
            this.nSoundVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nSoundVolume.ValueChanged += new System.EventHandler(this.nSoundVolume_ValueChanged);
            // 
            // gbSoundboard
            // 
            this.gbSoundboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSoundboard.Controls.Add(this.vsSoundVolume);
            this.gbSoundboard.Controls.Add(this.nSoundVolume);
            this.gbSoundboard.Controls.Add(this.cbEnableLoopback);
            this.gbSoundboard.Controls.Add(this.cbEnableHotkeys);
            this.gbSoundboard.Location = new System.Drawing.Point(373, 352);
            this.gbSoundboard.Name = "gbSoundboard";
            this.gbSoundboard.Size = new System.Drawing.Size(274, 71);
            this.gbSoundboard.TabIndex = 15;
            this.gbSoundboard.TabStop = false;
            this.gbSoundboard.Text = "Soundboard";
            this.gbSoundboard.Click += new System.EventHandler(this.form_Click);
            // 
            // saveSettingsTimer
            // 
            this.saveSettingsTimer.Interval = 1000;
            this.saveSettingsTimer.Tick += new System.EventHandler(this.saveSettingsTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 537);
            this.Controls.Add(this.gbSoundboard);
            this.Controls.Add(this.gbAudioDevices);
            this.Controls.Add(this.gbPushToTalk);
            this.Controls.Add(this.btnStopAllSounds);
            this.Controls.Add(this.btnPlaySelectedSound);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvKeySounds);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(675, 576);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JN Soundboard";
            this.Click += new System.EventHandler(this.form_Click);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbPushToTalk.ResumeLayout(false);
            this.gbPushToTalk.PerformLayout();
            this.gbAudioDevices.ResumeLayout(false);
            this.gbAudioDevices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoundVolume)).EndInit();
            this.gbSoundboard.ResumeLayout(false);
            this.gbSoundboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayback1;
        private System.Windows.Forms.ComboBox cbPlaybackDevices1;
        private System.Windows.Forms.CheckBox cbEnableHotkeys;
        internal System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.ListView lvKeySounds;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReloadDevices;
        internal System.Windows.Forms.ColumnHeader chKeys;
        internal System.Windows.Forms.ColumnHeader chLocation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblLoopback;
        private System.Windows.Forms.ComboBox cbLoopbackDevices;
        private System.Windows.Forms.Button btnPlaySelectedSound;
        private System.Windows.Forms.Button btnStopAllSounds;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox gbPushToTalk;
        private System.Windows.Forms.CheckBox cbEnablePushToTalk;
        private System.Windows.Forms.ComboBox cbWindows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPushToTalkKey;
        private System.Windows.Forms.GroupBox gbAudioDevices;
        private System.Windows.Forms.ToolStripMenuItem texttospeechToolStripMenuItem;
        private System.Windows.Forms.Button btnReloadWindows;
        private System.Windows.Forms.Timer pushToTalkKeyTimer;
        internal System.Windows.Forms.ColumnHeader chWindow;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbPlaybackDevices2;
        private System.Windows.Forms.Label lblPlayback2;
        private System.Windows.Forms.Button clearHotkey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbEnableLoopback;
        private NAudio.Gui.VolumeSlider vsSoundVolume;
        private System.Windows.Forms.NumericUpDown nSoundVolume;
        private System.Windows.Forms.GroupBox gbSoundboard;
        private System.Windows.Forms.Timer saveSettingsTimer;
        internal System.Windows.Forms.ColumnHeader chVolume;
    }
}

