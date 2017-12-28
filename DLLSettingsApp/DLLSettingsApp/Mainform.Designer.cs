namespace DLLSettingsApp
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.MouseAccelCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SensXTextbox = new System.Windows.Forms.TextBox();
            this.SensYTextbox = new System.Windows.Forms.TextBox();
            this.SetBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // MouseAccelCheckbox
            // 
            this.MouseAccelCheckbox.AutoSize = true;
            this.MouseAccelCheckbox.Location = new System.Drawing.Point(15, 59);
            this.MouseAccelCheckbox.Name = "MouseAccelCheckbox";
            this.MouseAccelCheckbox.Size = new System.Drawing.Size(120, 17);
            this.MouseAccelCheckbox.TabIndex = 0;
            this.MouseAccelCheckbox.Text = "Mouse Acceleration";
            this.Tooltip.SetToolTip(this.MouseAccelCheckbox, "If checked, Mouse Acceleration will be enabled ingame. If unchecked, Mouse Accele" +
        "ration will be disabled ingame.");
            this.MouseAccelCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sensitivity X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sensitivity Y:";
            // 
            // SensXTextbox
            // 
            this.SensXTextbox.Location = new System.Drawing.Point(85, 6);
            this.SensXTextbox.Name = "SensXTextbox";
            this.SensXTextbox.Size = new System.Drawing.Size(92, 20);
            this.SensXTextbox.TabIndex = 3;
            this.Tooltip.SetToolTip(this.SensXTextbox, "Indicate your desired Horizontal Axis sensitivity");
            // 
            // SensYTextbox
            // 
            this.SensYTextbox.Location = new System.Drawing.Point(85, 33);
            this.SensYTextbox.Name = "SensYTextbox";
            this.SensYTextbox.Size = new System.Drawing.Size(92, 20);
            this.SensYTextbox.TabIndex = 4;
            this.Tooltip.SetToolTip(this.SensYTextbox, "Indicate your desired Vertical Axis sensitivity");
            // 
            // SetBtn
            // 
            this.SetBtn.Location = new System.Drawing.Point(102, 82);
            this.SetBtn.Name = "SetBtn";
            this.SetBtn.Size = new System.Drawing.Size(75, 23);
            this.SetBtn.TabIndex = 5;
            this.SetBtn.Text = "Set";
            this.Tooltip.SetToolTip(this.SetBtn, "Commit your desired settings to the registry.");
            this.SetBtn.UseVisualStyleBackColor = true;
            this.SetBtn.Click += new System.EventHandler(this.SetBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(15, 82);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 6;
            this.CloseBtn.Text = "Close";
            this.Tooltip.SetToolTip(this.CloseBtn, "Close the utility.");
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // Tooltip
            // 
            this.Tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tooltip.ToolTipTitle = "About";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 115);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SetBtn);
            this.Controls.Add(this.SensYTextbox);
            this.Controls.Add(this.SensXTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MouseAccelCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(207, 154);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(207, 154);
            this.Name = "Mainform";
            this.Text = "Halo Mouse Fix DLL Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox MouseAccelCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SensXTextbox;
        private System.Windows.Forms.TextBox SensYTextbox;
        private System.Windows.Forms.Button SetBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.ToolTip Tooltip;
    }
}

