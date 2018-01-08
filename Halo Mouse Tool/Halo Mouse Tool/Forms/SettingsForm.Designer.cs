namespace Halo_Mouse_Tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.HotkeyTextbox = new System.Windows.Forms.TextBox();
            this.HotkeyCheckbox = new System.Windows.Forms.CheckBox();
            this.CheckForUpdatesCheckbox = new System.Windows.Forms.CheckBox();
            this.SoundsCheckbox = new System.Windows.Forms.CheckBox();
            this.SuccessMessagesCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HotkeyTextbox
            // 
            this.HotkeyTextbox.Location = new System.Drawing.Point(78, 6);
            this.HotkeyTextbox.Name = "HotkeyTextbox";
            this.HotkeyTextbox.Size = new System.Drawing.Size(71, 20);
            this.HotkeyTextbox.TabIndex = 1;
            // 
            // HotkeyCheckbox
            // 
            this.HotkeyCheckbox.AutoSize = true;
            this.HotkeyCheckbox.Location = new System.Drawing.Point(13, 8);
            this.HotkeyCheckbox.Name = "HotkeyCheckbox";
            this.HotkeyCheckbox.Size = new System.Drawing.Size(63, 17);
            this.HotkeyCheckbox.TabIndex = 2;
            this.HotkeyCheckbox.Text = "Hotkey:";
            this.HotkeyCheckbox.UseVisualStyleBackColor = true;
            // 
            // CheckForUpdatesCheckbox
            // 
            this.CheckForUpdatesCheckbox.AutoSize = true;
            this.CheckForUpdatesCheckbox.Location = new System.Drawing.Point(12, 58);
            this.CheckForUpdatesCheckbox.Name = "CheckForUpdatesCheckbox";
            this.CheckForUpdatesCheckbox.Size = new System.Drawing.Size(155, 17);
            this.CheckForUpdatesCheckbox.TabIndex = 3;
            this.CheckForUpdatesCheckbox.Text = "Check for Updates on Start";
            this.CheckForUpdatesCheckbox.UseVisualStyleBackColor = true;
            // 
            // SoundsCheckbox
            // 
            this.SoundsCheckbox.AutoSize = true;
            this.SoundsCheckbox.Location = new System.Drawing.Point(12, 81);
            this.SoundsCheckbox.Name = "SoundsCheckbox";
            this.SoundsCheckbox.Size = new System.Drawing.Size(104, 17);
            this.SoundsCheckbox.TabIndex = 4;
            this.SoundsCheckbox.Text = "Sounds Enabled";
            this.SoundsCheckbox.UseVisualStyleBackColor = true;
            // 
            // SuccessMessagesCheckbox
            // 
            this.SuccessMessagesCheckbox.AutoSize = true;
            this.SuccessMessagesCheckbox.Location = new System.Drawing.Point(12, 104);
            this.SuccessMessagesCheckbox.Name = "SuccessMessagesCheckbox";
            this.SuccessMessagesCheckbox.Size = new System.Drawing.Size(118, 17);
            this.SuccessMessagesCheckbox.TabIndex = 5;
            this.SuccessMessagesCheckbox.Text = "Success Messages";
            this.SuccessMessagesCheckbox.UseVisualStyleBackColor = true;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(12, 127);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(155, 23);
            this.CloseBtn.TabIndex = 6;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "DLL Hotkey:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 8;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 158);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SuccessMessagesCheckbox);
            this.Controls.Add(this.SoundsCheckbox);
            this.Controls.Add(this.CheckForUpdatesCheckbox);
            this.Controls.Add(this.HotkeyCheckbox);
            this.Controls.Add(this.HotkeyTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HotkeyTextbox;
        private System.Windows.Forms.CheckBox HotkeyCheckbox;
        private System.Windows.Forms.CheckBox CheckForUpdatesCheckbox;
        private System.Windows.Forms.CheckBox SoundsCheckbox;
        private System.Windows.Forms.CheckBox SuccessMessagesCheckbox;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}