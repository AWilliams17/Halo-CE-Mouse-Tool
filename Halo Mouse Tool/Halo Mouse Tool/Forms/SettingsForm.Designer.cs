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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.HotkeyTextbox = new System.Windows.Forms.TextBox();
            this.HotkeyCheckbox = new System.Windows.Forms.CheckBox();
            this.CheckForUpdatesCheckbox = new System.Windows.Forms.CheckBox();
            this.SoundsCheckbox = new System.Windows.Forms.CheckBox();
            this.SuccessMessagesCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DllHotkeyTextbox = new System.Windows.Forms.TextBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DllSoundsCheckbox = new System.Windows.Forms.CheckBox();
            this.SuccessMessagesDll = new System.Windows.Forms.CheckBox();
            this.IncrementCheckbox = new System.Windows.Forms.CheckBox();
            this.IncrementDllCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IncrementAmountUpDown = new System.Windows.Forms.NumericUpDown();
            this.UpdateIncrement = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementAmountUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIncrement)).BeginInit();
            this.SuspendLayout();
            // 
            // HotkeyTextbox
            // 
            this.HotkeyTextbox.Location = new System.Drawing.Point(78, 6);
            this.HotkeyTextbox.Name = "HotkeyTextbox";
            this.HotkeyTextbox.ReadOnly = true;
            this.HotkeyTextbox.Size = new System.Drawing.Size(71, 20);
            this.HotkeyTextbox.TabIndex = 1;
            this.HotkeyTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyTextbox_KeyDown);
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
            this.HotkeyCheckbox.CheckedChanged += new System.EventHandler(this.HotkeyCheckbox_CheckedChanged);
            // 
            // CheckForUpdatesCheckbox
            // 
            this.CheckForUpdatesCheckbox.AutoSize = true;
            this.CheckForUpdatesCheckbox.Location = new System.Drawing.Point(13, 156);
            this.CheckForUpdatesCheckbox.Name = "CheckForUpdatesCheckbox";
            this.CheckForUpdatesCheckbox.Size = new System.Drawing.Size(155, 17);
            this.CheckForUpdatesCheckbox.TabIndex = 3;
            this.CheckForUpdatesCheckbox.Text = "Check for Updates on Start";
            this.CheckForUpdatesCheckbox.UseVisualStyleBackColor = true;
            this.CheckForUpdatesCheckbox.CheckedChanged += new System.EventHandler(this.CheckForUpdatesCheckbox_CheckedChanged);
            // 
            // SoundsCheckbox
            // 
            this.SoundsCheckbox.AutoSize = true;
            this.SoundsCheckbox.Location = new System.Drawing.Point(13, 179);
            this.SoundsCheckbox.Name = "SoundsCheckbox";
            this.SoundsCheckbox.Size = new System.Drawing.Size(104, 17);
            this.SoundsCheckbox.TabIndex = 4;
            this.SoundsCheckbox.Text = "Sounds Enabled";
            this.SoundsCheckbox.UseVisualStyleBackColor = true;
            this.SoundsCheckbox.CheckedChanged += new System.EventHandler(this.SoundsCheckbox_CheckedChanged);
            // 
            // SuccessMessagesCheckbox
            // 
            this.SuccessMessagesCheckbox.AutoSize = true;
            this.SuccessMessagesCheckbox.Location = new System.Drawing.Point(13, 225);
            this.SuccessMessagesCheckbox.Name = "SuccessMessagesCheckbox";
            this.SuccessMessagesCheckbox.Size = new System.Drawing.Size(118, 17);
            this.SuccessMessagesCheckbox.TabIndex = 5;
            this.SuccessMessagesCheckbox.Text = "Success Messages";
            this.SuccessMessagesCheckbox.UseVisualStyleBackColor = true;
            this.SuccessMessagesCheckbox.CheckedChanged += new System.EventHandler(this.SuccessMessagesCheckbox_CheckedChanged);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(12, 271);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(145, 23);
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
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hotkey(DLL):";
            // 
            // DllHotkeyTextbox
            // 
            this.DllHotkeyTextbox.Location = new System.Drawing.Point(78, 32);
            this.DllHotkeyTextbox.Name = "DllHotkeyTextbox";
            this.DllHotkeyTextbox.ReadOnly = true;
            this.DllHotkeyTextbox.Size = new System.Drawing.Size(71, 20);
            this.DllHotkeyTextbox.TabIndex = 8;
            this.DllHotkeyTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DllHotkeyTextbox_KeyDown);
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 20000;
            this.ToolTip.InitialDelay = 250;
            this.ToolTip.ReshowDelay = 100;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Help";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Update Timeout:";
            // 
            // DllSoundsCheckbox
            // 
            this.DllSoundsCheckbox.AutoSize = true;
            this.DllSoundsCheckbox.Location = new System.Drawing.Point(13, 202);
            this.DllSoundsCheckbox.Name = "DllSoundsCheckbox";
            this.DllSoundsCheckbox.Size = new System.Drawing.Size(130, 17);
            this.DllSoundsCheckbox.TabIndex = 11;
            this.DllSoundsCheckbox.Text = "Sounds Enabled(DLL)";
            this.DllSoundsCheckbox.UseVisualStyleBackColor = true;
            this.DllSoundsCheckbox.CheckedChanged += new System.EventHandler(this.DllSoundsCheckbox_CheckedChanged);
            // 
            // SuccessMessagesDll
            // 
            this.SuccessMessagesDll.AutoSize = true;
            this.SuccessMessagesDll.Location = new System.Drawing.Point(13, 248);
            this.SuccessMessagesDll.Name = "SuccessMessagesDll";
            this.SuccessMessagesDll.Size = new System.Drawing.Size(144, 17);
            this.SuccessMessagesDll.TabIndex = 12;
            this.SuccessMessagesDll.Text = "Success Messages(DLL)";
            this.SuccessMessagesDll.UseVisualStyleBackColor = true;
            this.SuccessMessagesDll.CheckedChanged += new System.EventHandler(this.SuccessMessagesDll_CheckedChanged);
            // 
            // IncrementCheckbox
            // 
            this.IncrementCheckbox.AutoSize = true;
            this.IncrementCheckbox.Location = new System.Drawing.Point(13, 110);
            this.IncrementCheckbox.Name = "IncrementCheckbox";
            this.IncrementCheckbox.Size = new System.Drawing.Size(116, 17);
            this.IncrementCheckbox.TabIndex = 13;
            this.IncrementCheckbox.Text = "+/- Keys Increment";
            this.IncrementCheckbox.UseVisualStyleBackColor = true;
            this.IncrementCheckbox.CheckedChanged += new System.EventHandler(this.IncrementCheckbox_CheckedChanged);
            // 
            // IncrementDllCheckbox
            // 
            this.IncrementDllCheckbox.AutoSize = true;
            this.IncrementDllCheckbox.Location = new System.Drawing.Point(13, 133);
            this.IncrementDllCheckbox.Name = "IncrementDllCheckbox";
            this.IncrementDllCheckbox.Size = new System.Drawing.Size(142, 17);
            this.IncrementDllCheckbox.TabIndex = 14;
            this.IncrementDllCheckbox.Text = "+/- Keys Increment(DLL)";
            this.IncrementDllCheckbox.UseVisualStyleBackColor = true;
            this.IncrementDllCheckbox.CheckedChanged += new System.EventHandler(this.IncrementDllCheckbox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Increment Amnt:";
            // 
            // IncrementAmountUpDown
            // 
            this.IncrementAmountUpDown.DecimalPlaces = 1;
            this.IncrementAmountUpDown.Location = new System.Drawing.Point(96, 85);
            this.IncrementAmountUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            65536});
            this.IncrementAmountUpDown.Name = "IncrementAmountUpDown";
            this.IncrementAmountUpDown.ReadOnly = true;
            this.IncrementAmountUpDown.Size = new System.Drawing.Size(53, 20);
            this.IncrementAmountUpDown.TabIndex = 17;
            this.IncrementAmountUpDown.ValueChanged += new System.EventHandler(this.IncrementAmountUpDown_ValueChanged);
            // 
            // UpdateIncrement
            // 
            this.UpdateIncrement.Location = new System.Drawing.Point(96, 58);
            this.UpdateIncrement.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.UpdateIncrement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateIncrement.Name = "UpdateIncrement";
            this.UpdateIncrement.ReadOnly = true;
            this.UpdateIncrement.Size = new System.Drawing.Size(53, 20);
            this.UpdateIncrement.TabIndex = 18;
            this.UpdateIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateIncrement.ValueChanged += new System.EventHandler(this.UpdateIncrement_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 302);
            this.Controls.Add(this.UpdateIncrement);
            this.Controls.Add(this.IncrementAmountUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IncrementDllCheckbox);
            this.Controls.Add(this.IncrementCheckbox);
            this.Controls.Add(this.SuccessMessagesDll);
            this.Controls.Add(this.DllSoundsCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DllHotkeyTextbox);
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
            ((System.ComponentModel.ISupportInitialize)(this.IncrementAmountUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIncrement)).EndInit();
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
        private System.Windows.Forms.TextBox DllHotkeyTextbox;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox DllSoundsCheckbox;
        private System.Windows.Forms.CheckBox SuccessMessagesDll;
        private System.Windows.Forms.CheckBox IncrementCheckbox;
        private System.Windows.Forms.CheckBox IncrementDllCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IncrementAmountUpDown;
        private System.Windows.Forms.NumericUpDown UpdateIncrement;
    }
}