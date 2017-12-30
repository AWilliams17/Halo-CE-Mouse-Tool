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
            this.HideHotkeyMsgCheckbox = new System.Windows.Forms.CheckBox();
            this.UpdateTimeoutUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.IncrementHotkeyCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IncrementAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateTimeoutUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementAmount)).BeginInit();
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
            this.UpdateCheckbox.Location = new System.Drawing.Point(15, 78);
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
            this.MouseAccelCheckbox.Location = new System.Drawing.Point(15, 127);
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
            this.CheckforUpdatesBtn.Location = new System.Drawing.Point(15, 222);
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
            this.SoundsEnabledCheckbox.Location = new System.Drawing.Point(15, 199);
            this.SoundsEnabledCheckbox.Name = "SoundsEnabledCheckbox";
            this.SoundsEnabledCheckbox.Size = new System.Drawing.Size(104, 17);
            this.SoundsEnabledCheckbox.TabIndex = 8;
            this.SoundsEnabledCheckbox.Text = "Sounds Enabled";
            this.Tooltip.SetToolTip(this.SoundsEnabledCheckbox, "If checked, sounds will play on successful/erroneous\r\nactions.");
            this.SoundsEnabledCheckbox.UseVisualStyleBackColor = true;
            this.SoundsEnabledCheckbox.CheckedChanged += new System.EventHandler(this.SoundsEnabledCheckbox_CheckedChanged);
            // 
            // HideHotkeyMsgCheckbox
            // 
            this.HideHotkeyMsgCheckbox.AutoSize = true;
            this.HideHotkeyMsgCheckbox.Location = new System.Drawing.Point(15, 55);
            this.HideHotkeyMsgCheckbox.Name = "HideHotkeyMsgCheckbox";
            this.HideHotkeyMsgCheckbox.Size = new System.Drawing.Size(136, 17);
            this.HideHotkeyMsgCheckbox.TabIndex = 9;
            this.HideHotkeyMsgCheckbox.Text = "Hide Hotkey Messages";
            this.Tooltip.SetToolTip(this.HideHotkeyMsgCheckbox, "When checked, the success messages generated\r\nupon a successful memory write oper" +
        "ation via\r\nthe hotkey will be hidden.");
            this.HideHotkeyMsgCheckbox.UseVisualStyleBackColor = true;
            this.HideHotkeyMsgCheckbox.CheckedChanged += new System.EventHandler(this.HideHotkeyMsgCheckbox_CheckedChanged);
            // 
            // UpdateTimeoutUpDown
            // 
            this.UpdateTimeoutUpDown.Location = new System.Drawing.Point(114, 101);
            this.UpdateTimeoutUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UpdateTimeoutUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateTimeoutUpDown.Name = "UpdateTimeoutUpDown";
            this.UpdateTimeoutUpDown.ReadOnly = true;
            this.UpdateTimeoutUpDown.Size = new System.Drawing.Size(52, 20);
            this.UpdateTimeoutUpDown.TabIndex = 10;
            this.Tooltip.SetToolTip(this.UpdateTimeoutUpDown, "How many milliseconds to attempt to retrieve an\r\nupdate before timing out.");
            this.UpdateTimeoutUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateTimeoutUpDown.ValueChanged += new System.EventHandler(this.UpdateTimeoutUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Update Timeout:";
            // 
            // IncrementHotkeyCheckbox
            // 
            this.IncrementHotkeyCheckbox.AutoSize = true;
            this.IncrementHotkeyCheckbox.Location = new System.Drawing.Point(15, 150);
            this.IncrementHotkeyCheckbox.Name = "IncrementHotkeyCheckbox";
            this.IncrementHotkeyCheckbox.Size = new System.Drawing.Size(151, 17);
            this.IncrementHotkeyCheckbox.TabIndex = 12;
            this.IncrementHotkeyCheckbox.Text = "Enable Increment Hotkeys";
            this.Tooltip.SetToolTip(this.IncrementHotkeyCheckbox, resources.GetString("IncrementHotkeyCheckbox.ToolTip"));
            this.IncrementHotkeyCheckbox.UseVisualStyleBackColor = true;
            this.IncrementHotkeyCheckbox.CheckedChanged += new System.EventHandler(this.IncrementHotkeyCheckbox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Increment Amount:";
            // 
            // IncrementAmount
            // 
            this.IncrementAmount.DecimalPlaces = 1;
            this.IncrementAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.IncrementAmount.Location = new System.Drawing.Point(114, 173);
            this.IncrementAmount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.IncrementAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.IncrementAmount.Name = "IncrementAmount";
            this.IncrementAmount.ReadOnly = true;
            this.IncrementAmount.Size = new System.Drawing.Size(52, 20);
            this.IncrementAmount.TabIndex = 14;
            this.Tooltip.SetToolTip(this.IncrementAmount, "How much to add/subtract from the sensitivity\r\nwhen an increment/decrement key is" +
        " pressed.");
            this.IncrementAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.IncrementAmount.ValueChanged += new System.EventHandler(this.IncrementAmount_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 256);
            this.Controls.Add(this.IncrementAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IncrementHotkeyCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpdateTimeoutUpDown);
            this.Controls.Add(this.HideHotkeyMsgCheckbox);
            this.Controls.Add(this.SoundsEnabledCheckbox);
            this.Controls.Add(this.CheckforUpdatesBtn);
            this.Controls.Add(this.MouseAccelCheckbox);
            this.Controls.Add(this.UpdateCheckbox);
            this.Controls.Add(this.HotkeyText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnableHotkeyCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(195, 295);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(195, 295);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpdateTimeoutUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementAmount)).EndInit();
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
        private System.Windows.Forms.CheckBox HideHotkeyMsgCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown UpdateTimeoutUpDown;
        private System.Windows.Forms.CheckBox IncrementHotkeyCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IncrementAmount;
    }
}