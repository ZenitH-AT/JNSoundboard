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
            this.gbKeysLocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stop all sounds keys";
            // 
            // tbStopSoundKeys
            // 
            this.tbStopSoundKeys.Location = new System.Drawing.Point(12, 25);
            this.tbStopSoundKeys.Name = "tbStopSoundKeys";
            this.tbStopSoundKeys.ReadOnly = true;
            this.tbStopSoundKeys.ShortcutsEnabled = false;
            this.tbStopSoundKeys.Size = new System.Drawing.Size(213, 20);
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
            this.lvKeysLocations.Location = new System.Drawing.Point(6, 19);
            this.lvKeysLocations.MultiSelect = false;
            this.lvKeysLocations.Name = "lvKeysLocations";
            this.lvKeysLocations.ShowItemToolTips = true;
            this.lvKeysLocations.Size = new System.Drawing.Size(420, 128);
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
            this.btnOK.Location = new System.Drawing.Point(288, 319);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(6, 153);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(87, 153);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(168, 153);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(369, 319);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
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
            this.gbKeysLocations.Location = new System.Drawing.Point(12, 53);
            this.gbKeysLocations.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.gbKeysLocations.Name = "gbKeysLocations";
            this.gbKeysLocations.Size = new System.Drawing.Size(432, 182);
            this.gbKeysLocations.TabIndex = 2;
            this.gbKeysLocations.TabStop = false;
            this.gbKeysLocations.Text = "Load XML file with keys";
            // 
            // cbMinimiseToTray
            // 
            this.cbMinimiseToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbMinimiseToTray.AutoSize = true;
            this.cbMinimiseToTray.Location = new System.Drawing.Point(12, 289);
            this.cbMinimiseToTray.Name = "cbMinimiseToTray";
            this.cbMinimiseToTray.Size = new System.Drawing.Size(214, 17);
            this.cbMinimiseToTray.TabIndex = 9;
            this.cbMinimiseToTray.Text = "Send application to tray when minimised";
            this.cbMinimiseToTray.UseVisualStyleBackColor = true;
            // 
            // clearHotkey
            // 
            this.clearHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearHotkey.ForeColor = System.Drawing.Color.Red;
            this.clearHotkey.Location = new System.Drawing.Point(231, 24);
            this.clearHotkey.Name = "clearHotkey";
            this.clearHotkey.Size = new System.Drawing.Size(22, 22);
            this.clearHotkey.TabIndex = 1;
            this.clearHotkey.Text = "X";
            this.clearHotkey.UseVisualStyleBackColor = true;
            this.clearHotkey.Click += new System.EventHandler(this.clearHotkey_Click);
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Location = new System.Drawing.Point(12, 266);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(171, 17);
            this.cbStartWithWindows.TabIndex = 8;
            this.cbStartWithWindows.Text = "Start application with Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // cbStartMinimised
            // 
            this.cbStartMinimised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStartMinimised.AutoSize = true;
            this.cbStartMinimised.Location = new System.Drawing.Point(12, 243);
            this.cbStartMinimised.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cbStartMinimised.Name = "cbStartMinimised";
            this.cbStartMinimised.Size = new System.Drawing.Size(150, 17);
            this.cbStartMinimised.TabIndex = 7;
            this.cbStartMinimised.Text = "Start application minimised";
            this.cbStartMinimised.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 354);
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
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(472, 393);
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
    }
}