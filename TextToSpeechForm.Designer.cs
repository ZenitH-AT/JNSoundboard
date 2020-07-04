namespace JNSoundboard
{
    partial class TextToSpeechForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextToSpeechForm));
            this.tbText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbKeys = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateWAV = new System.Windows.Forms.Button();
            this.keysTimer = new System.Windows.Forms.Timer(this.components);
            this.clearHotkey = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.Button();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stopPreview = new System.Windows.Forms.Button();
            this.cbAddToList = new System.Windows.Forms.CheckBox();
            this.btnReloadWindows = new System.Windows.Forms.Button();
            this.cbWindows = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.vsSoundVolume = new NAudio.Gui.VolumeSlider();
            this.nSoundVolume = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nSoundVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(12, 25);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(310, 65);
            this.tbText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(247, 311);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbKeys
            // 
            this.tbKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbKeys.Location = new System.Drawing.Point(12, 189);
            this.tbKeys.Name = "tbKeys";
            this.tbKeys.ReadOnly = true;
            this.tbKeys.ShortcutsEnabled = false;
            this.tbKeys.Size = new System.Drawing.Size(213, 20);
            this.tbKeys.TabIndex = 5;
            this.tbKeys.Enter += new System.EventHandler(this.tbKeys_Enter);
            this.tbKeys.Leave += new System.EventHandler(this.tbKeys_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Keys (optional)";
            // 
            // btnCreateWAV
            // 
            this.btnCreateWAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateWAV.Location = new System.Drawing.Point(141, 311);
            this.btnCreateWAV.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnCreateWAV.Name = "btnCreateWAV";
            this.btnCreateWAV.Size = new System.Drawing.Size(100, 23);
            this.btnCreateWAV.TabIndex = 10;
            this.btnCreateWAV.Text = "Create WAV";
            this.btnCreateWAV.UseVisualStyleBackColor = true;
            this.btnCreateWAV.Click += new System.EventHandler(this.btnCreateWAV_Click);
            // 
            // keysTimer
            // 
            this.keysTimer.Tick += new System.EventHandler(this.keysTimer_Tick);
            // 
            // clearHotkey
            // 
            this.clearHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearHotkey.ForeColor = System.Drawing.Color.Red;
            this.clearHotkey.Location = new System.Drawing.Point(231, 188);
            this.clearHotkey.Name = "clearHotkey";
            this.clearHotkey.Size = new System.Drawing.Size(22, 22);
            this.clearHotkey.TabIndex = 6;
            this.clearHotkey.Text = "X";
            this.clearHotkey.UseVisualStyleBackColor = true;
            this.clearHotkey.Click += new System.EventHandler(this.clearHotkey_Click);
            // 
            // preview
            // 
            this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.preview.AutoSize = true;
            this.preview.Location = new System.Drawing.Point(166, 113);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(75, 23);
            this.preview.TabIndex = 2;
            this.preview.Text = "Preview";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // cbGender
            // 
            this.cbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(12, 114);
            this.cbGender.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(120, 21);
            this.cbGender.TabIndex = 1;
            this.cbGender.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Gender";
            // 
            // stopPreview
            // 
            this.stopPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopPreview.Location = new System.Drawing.Point(247, 113);
            this.stopPreview.Name = "stopPreview";
            this.stopPreview.Size = new System.Drawing.Size(75, 23);
            this.stopPreview.TabIndex = 3;
            this.stopPreview.Text = "Stop";
            this.stopPreview.UseVisualStyleBackColor = true;
            this.stopPreview.Click += new System.EventHandler(this.stopPreview_Click);
            // 
            // cbAddToList
            // 
            this.cbAddToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAddToList.AutoSize = true;
            this.cbAddToList.Location = new System.Drawing.Point(12, 148);
            this.cbAddToList.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cbAddToList.Name = "cbAddToList";
            this.cbAddToList.Size = new System.Drawing.Size(72, 17);
            this.cbAddToList.TabIndex = 4;
            this.cbAddToList.Text = "Add to list";
            this.cbAddToList.UseVisualStyleBackColor = true;
            this.cbAddToList.CheckedChanged += new System.EventHandler(this.cbAddToList_CheckedChanged);
            // 
            // btnReloadWindows
            // 
            this.btnReloadWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReloadWindows.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadWindows.Image")));
            this.btnReloadWindows.Location = new System.Drawing.Point(231, 276);
            this.btnReloadWindows.Name = "btnReloadWindows";
            this.btnReloadWindows.Size = new System.Drawing.Size(22, 23);
            this.btnReloadWindows.TabIndex = 9;
            this.btnReloadWindows.UseVisualStyleBackColor = true;
            this.btnReloadWindows.Click += new System.EventHandler(this.btnReloadWindows_Click);
            // 
            // cbWindows
            // 
            this.cbWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbWindows.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbWindows.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbWindows.FormattingEnabled = true;
            this.cbWindows.Location = new System.Drawing.Point(12, 277);
            this.cbWindows.Name = "cbWindows";
            this.cbWindows.Size = new System.Drawing.Size(213, 21);
            this.cbWindows.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 261);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Restrict to a certain window";
            // 
            // vsSoundVolume
            // 
            this.vsSoundVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vsSoundVolume.Location = new System.Drawing.Point(12, 233);
            this.vsSoundVolume.Name = "vsSoundVolume";
            this.vsSoundVolume.Size = new System.Drawing.Size(213, 20);
            this.vsSoundVolume.TabIndex = 100;
            this.vsSoundVolume.TabStop = false;
            this.vsSoundVolume.VolumeChanged += new System.EventHandler(this.vsSoundVolume_VolumeChanged);
            this.vsSoundVolume.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.vsSoundVolume_MouseWheel);
            // 
            // nSoundVolume
            // 
            this.nSoundVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nSoundVolume.Location = new System.Drawing.Point(231, 233);
            this.nSoundVolume.Name = "nSoundVolume";
            this.nSoundVolume.Size = new System.Drawing.Size(39, 20);
            this.nSoundVolume.TabIndex = 7;
            this.nSoundVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nSoundVolume.ValueChanged += new System.EventHandler(this.nSoundVolume_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Custom volume";
            // 
            // TextToSpeechForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nSoundVolume);
            this.Controls.Add(this.vsSoundVolume);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbWindows);
            this.Controls.Add(this.btnReloadWindows);
            this.Controls.Add(this.cbAddToList);
            this.Controls.Add(this.stopPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.clearHotkey);
            this.Controls.Add(this.btnCreateWAV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbKeys);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 385);
            this.Name = "TextToSpeechForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text-to-speech";
            this.Load += new System.EventHandler(this.TTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nSoundVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbKeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateWAV;
        private System.Windows.Forms.Timer keysTimer;
        private System.Windows.Forms.Button clearHotkey;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stopPreview;
        private System.Windows.Forms.CheckBox cbAddToList;
        private System.Windows.Forms.Button btnReloadWindows;
        private System.Windows.Forms.ComboBox cbWindows;
        private System.Windows.Forms.Label label5;
        private NAudio.Gui.VolumeSlider vsSoundVolume;
        private System.Windows.Forms.NumericUpDown nSoundVolume;
        private System.Windows.Forms.Label label3;
    }
}