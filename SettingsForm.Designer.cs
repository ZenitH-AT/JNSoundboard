namespace JNSoundboard
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbStopSoundKeys = new System.Windows.Forms.TextBox();
            this.lvKeysLocations = new System.Windows.Forms.ListView();
            this.chKeys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chXMLLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.keysTimer = new System.Windows.Forms.Timer(this.components);
            this.gbKeysLocations = new System.Windows.Forms.GroupBox();
            this.cbMinimiseToTray = new System.Windows.Forms.CheckBox();
            this.clearHotkey = new System.Windows.Forms.Button();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.cbStartMinimised = new System.Windows.Forms.CheckBox();
            this.cbAllowOverlap = new System.Windows.Forms.CheckBox();
            this.gbKeysLocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stop all sounds keys";
            // 
            // tbStopSoundKeys
            // 
            this.tbStopSoundKeys.Location = new System.Drawing.Point(16, 31);
            this.tbStopSoundKeys.Margin = new System.Windows.Forms.Padding(4);
            this.tbStopSoundKeys.Name = "tbStopSoundKeys";
            this.tbStopSoundKeys.ReadOnly = true;
            this.tbStopSoundKeys.ShortcutsEnabled = false;
            this.tbStopSoundKeys.Size = new System.Drawing.Size(283, 22);
            this.tbStopSoundKeys.TabIndex = 0;
            this.tbStopSoundKeys.Enter += new System.EventHandler(this.tbStopSoundKeys_Enter);
            this.tbStopSoundKeys.Leave += new System.EventHandler(this.tbStopSoundKeys_Leave);
            // 
            // lvKeysLocations
            // 
            this.lvKeysLocations.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvKeysLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvKeysLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chKeys,
            this.chXMLLocation});
            this.lvKeysLocations.FullRowSelect = true;
            this.lvKeysLocations.GridLines = true;
            this.lvKeysLocations.HideSelection = false;
            this.lvKeysLocations.Location = new System.Drawing.Point(8, 23);
            this.lvKeysLocations.Margin = new System.Windows.Forms.Padding(4);
            this.lvKeysLocations.MultiSelect = false;
            this.lvKeysLocations.Name = "lvKeysLocations";
            this.lvKeysLocations.ShowItemToolTips = true;
            this.lvKeysLocations.Size = new System.Drawing.Size(559, 143);
            this.lvKeysLocations.TabIndex = 3;
            this.lvKeysLocations.UseCompatibleStateImageBehavior = false;
            this.lvKeysLocations.View = System.Windows.Forms.View.Details;
            this.lvKeysLocations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvKeysLocations_MouseDoubleClick);
            // 
            // chKeys
            // 
            this.chKeys.Text = "Keys";
            this.chKeys.Width = 150;
            // 
            // chXMLLocation
            // 
            this.chXMLLocation.Text = "XML location";
            this.chXMLLocation.Width = 266;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(384, 439);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(8, 174);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(116, 174);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 28);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(224, 174);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(492, 439);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // keysTimer
            // 
            this.keysTimer.Tick += new System.EventHandler(this.keysTimer_Tick);
            // 
            // gbKeysLocations
            // 
            this.gbKeysLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbKeysLocations.Controls.Add(this.lvKeysLocations);
            this.gbKeysLocations.Controls.Add(this.btnAdd);
            this.gbKeysLocations.Controls.Add(this.btnRemove);
            this.gbKeysLocations.Controls.Add(this.btnEdit);
            this.gbKeysLocations.Location = new System.Drawing.Point(16, 65);
            this.gbKeysLocations.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.gbKeysLocations.Name = "gbKeysLocations";
            this.gbKeysLocations.Padding = new System.Windows.Forms.Padding(4);
            this.gbKeysLocations.Size = new System.Drawing.Size(576, 240);
            this.gbKeysLocations.TabIndex = 2;
            this.gbKeysLocations.TabStop = false;
            this.gbKeysLocations.Text = "Load XML file with keys";
            // 
            // cbMinimiseToTray
            // 
            this.cbMinimiseToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbMinimiseToTray.AutoSize = true;
            this.cbMinimiseToTray.Location = new System.Drawing.Point(16, 372);
            this.cbMinimiseToTray.Margin = new System.Windows.Forms.Padding(4);
            this.cbMinimiseToTray.Name = "cbMinimiseToTray";
            this.cbMinimiseToTray.Size = new System.Drawing.Size(267, 20);
            this.cbMinimiseToTray.TabIndex = 9;
            this.cbMinimiseToTray.Text = "Send application to tray when minimised";
            this.cbMinimiseToTray.UseVisualStyleBackColor = true;
            // 
            // clearHotkey
            // 
            this.clearHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearHotkey.ForeColor = System.Drawing.Color.Red;
            this.clearHotkey.Location = new System.Drawing.Point(308, 30);
            this.clearHotkey.Margin = new System.Windows.Forms.Padding(4);
            this.clearHotkey.Name = "clearHotkey";
            this.clearHotkey.Size = new System.Drawing.Size(29, 27);
            this.clearHotkey.TabIndex = 1;
            this.clearHotkey.Text = "X";
            this.clearHotkey.UseVisualStyleBackColor = true;
            this.clearHotkey.Click += new System.EventHandler(this.clearHotkey_Click);
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Location = new System.Drawing.Point(16, 343);
            this.cbStartWithWindows.Margin = new System.Windows.Forms.Padding(4);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(208, 20);
            this.cbStartWithWindows.TabIndex = 8;
            this.cbStartWithWindows.Text = "Start application with Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // cbStartMinimised
            // 
            this.cbStartMinimised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStartMinimised.AutoSize = true;
            this.cbStartMinimised.Location = new System.Drawing.Point(16, 315);
            this.cbStartMinimised.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.cbStartMinimised.Name = "cbStartMinimised";
            this.cbStartMinimised.Size = new System.Drawing.Size(189, 20);
            this.cbStartMinimised.TabIndex = 7;
            this.cbStartMinimised.Text = "Start application minimised";
            this.cbStartMinimised.UseVisualStyleBackColor = true;
            // 
            // cbAllowOverlap
            // 
            this.cbAllowOverlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAllowOverlap.AutoSize = true;
            this.cbAllowOverlap.Location = new System.Drawing.Point(16, 400);
            this.cbAllowOverlap.Margin = new System.Windows.Forms.Padding(4);
            this.cbAllowOverlap.Name = "cbAllowOverlap";
            this.cbAllowOverlap.Size = new System.Drawing.Size(220, 20);
            this.cbAllowOverlap.TabIndex = 12;
            this.cbAllowOverlap.Text = "Allow multiple sounds to overlap";
            this.cbAllowOverlap.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 482);
            this.Controls.Add(this.cbAllowOverlap);
            this.Controls.Add(this.cbStartMinimised);
            this.Controls.Add(this.cbStartWithWindows);
            this.Controls.Add(this.clearHotkey);
            this.Controls.Add(this.cbMinimiseToTray);
            this.Controls.Add(this.gbKeysLocations);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbStopSoundKeys);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(623, 473);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Soundboard Settings";
            this.gbKeysLocations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStopSoundKeys;
        internal System.Windows.Forms.ListView lvKeysLocations;
        internal System.Windows.Forms.ColumnHeader chKeys;
        internal System.Windows.Forms.ColumnHeader chXMLLocation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer keysTimer;
        private System.Windows.Forms.GroupBox gbKeysLocations;
        private System.Windows.Forms.CheckBox cbMinimiseToTray;
        private System.Windows.Forms.Button clearHotkey;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.CheckBox cbStartMinimised;
        private System.Windows.Forms.CheckBox cbAllowOverlap;
    }
}