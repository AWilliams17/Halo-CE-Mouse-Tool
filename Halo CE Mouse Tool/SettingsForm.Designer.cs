namespace Halo_CE_Mouse_Tool {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.EnableHotkeyCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HotkeyText = new System.Windows.Forms.TextBox();
            this.UpdateCheckbox = new System.Windows.Forms.CheckBox();
            this.MouseAccelCheckbox = new System.Windows.Forms.CheckBox();
            this.CheckforUpdatesBtn = new System.Windows.Forms.Button();
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SoundsEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // EnableHotkeyCheckbox
            // 
            this.EnableHotkeyCheckbox.AutoSize = true;
            this.EnableHotkeyCheckbox.Location = new System.Drawing.Point(15, 32);
            this.EnableHotkeyCheckbox.Name = "EnableHotkeyCheckbox";
            this.EnableHotkeyCheckbox.Size = new System.Drawing.Size(96, 17);
            this.EnableHotkeyCheckbox.TabIndex = 0;
            this.EnableHotkeyCheckbox.Text = "Enable Hotkey";
            this.Tooltip.SetToolTip(this.EnableHotkeyCheckbox, "Check this to enable your selected Hotkey.");
            this.EnableHotkeyCheckbox.UseVisualStyleBackColor = true;
            this.EnableHotkeyCheckbox.CheckedChanged += new System.EventHandler(this.EnableHotkeyCheckbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotkey:";
            // 
            // HotkeyText
            // 
            this.HotkeyText.Location = new System.Drawing.Point(62, 6);
            this.HotkeyText.Name = "HotkeyText";
            this.HotkeyText.ReadOnly = true;
            this.HotkeyText.Size = new System.Drawing.Size(104, 20);
            this.HotkeyText.TabIndex = 2;
            this.Tooltip.SetToolTip(this.HotkeyText, "Press this textbox and then press the button\r\nyou want to use as your hotkey.");
            this.HotkeyText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyText_KeyDown);
            // 
            // UpdateCheckbox
            // 
            this.UpdateCheckbox.AutoSize = true;
            this.UpdateCheckbox.Location = new System.Drawing.Point(15, 55);
            this.UpdateCheckbox.Name = "UpdateCheckbox";
            this.UpdateCheckbox.Size = new System.Drawing.Size(155, 17);
            this.UpdateCheckbox.TabIndex = 3;
            this.UpdateCheckbox.Text = "Check for Updates on Start";
            this.Tooltip.SetToolTip(this.UpdateCheckbox, "Check this to have the tool automatically check for\r\nupdates on launch and tell y" +
        "ou if one is available\r\nor not.");
            this.UpdateCheckbox.UseVisualStyleBackColor = true;
            this.UpdateCheckbox.CheckedChanged += new System.EventHandler(this.UpdateCheckbox_CheckedChanged);
            // 
            // MouseAccelCheckbox
            // 
            this.MouseAccelCheckbox.AutoSize = true;
            this.MouseAccelCheckbox.Location = new System.Drawing.Point(15, 78);
            this.MouseAccelCheckbox.Name = "MouseAccelCheckbox";
            this.MouseAccelCheckbox.Size = new System.Drawing.Size(151, 17);
            this.MouseAccelCheckbox.TabIndex = 4;
            this.MouseAccelCheckbox.Text = "Patch Mouse Acceleration";
            this.Tooltip.SetToolTip(this.MouseAccelCheckbox, resources.GetString("MouseAccelCheckbox.ToolTip"));
            this.MouseAccelCheckbox.UseVisualStyleBackColor = true;
            this.MouseAccelCheckbox.CheckedChanged += new System.EventHandler(this.MouseAccelCheckbox_CheckedChanged);
            // 
            // CheckforUpdatesBtn
            // 
            this.CheckforUpdatesBtn.Location = new System.Drawing.Point(15, 126);
            this.CheckforUpdatesBtn.Name = "CheckforUpdatesBtn";
            this.CheckforUpdatesBtn.Size = new System.Drawing.Size(151, 23);
            this.CheckforUpdatesBtn.TabIndex = 7;
            this.CheckforUpdatesBtn.Text = "Check for Updates";
            this.Tooltip.SetToolTip(this.CheckforUpdatesBtn, "Press this to manually check if there is an update available\r\nfor Halo Mouse Tool" +
        ". Useful if you don\'t check for updates\r\non start.");
            this.CheckforUpdatesBtn.UseVisualStyleBackColor = true;
            this.CheckforUpdatesBtn.Click += new System.EventHandler(this.CheckforUpdatesBtn_Click);
            // 
            // Tooltip
            // 
            this.Tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tooltip.ToolTipTitle = "About";
            // 
            // SoundsEnabledCheckbox
            // 
            this.SoundsEnabledCheckbox.AutoSize = true;
            this.SoundsEnabledCheckbox.Location = new System.Drawing.Point(15, 101);
            this.SoundsEnabledCheckbox.Name = "SoundsEnabledCheckbox";
            this.SoundsEnabledCheckbox.Size = new System.Drawing.Size(104, 17);
            this.SoundsEnabledCheckbox.TabIndex = 8;
            this.SoundsEnabledCheckbox.Text = "Sounds Enabled";
            this.SoundsEnabledCheckbox.UseVisualStyleBackColor = true;
            this.SoundsEnabledCheckbox.CheckedChanged += new System.EventHandler(this.SoundsEnabledCheckbox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 161);
            this.Controls.Add(this.SoundsEnabledCheckbox);
            this.Controls.Add(this.CheckforUpdatesBtn);
            this.Controls.Add(this.MouseAccelCheckbox);
            this.Controls.Add(this.UpdateCheckbox);
            this.Controls.Add(this.HotkeyText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnableHotkeyCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(195, 200);
            this.MinimumSize = new System.Drawing.Size(195, 200);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EnableHotkeyCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HotkeyText;
        private System.Windows.Forms.CheckBox UpdateCheckbox;
        private System.Windows.Forms.CheckBox MouseAccelCheckbox;
        private System.Windows.Forms.Button CheckforUpdatesBtn;
        private System.Windows.Forms.ToolTip Tooltip;
        private System.Windows.Forms.CheckBox SoundsEnabledCheckbox;
    }
}