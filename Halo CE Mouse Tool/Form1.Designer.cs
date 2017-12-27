namespace Halo_CE_Mouse_Tool
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
            this.SensX = new System.Windows.Forms.TextBox();
            this.SensY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.HotkeyStatus = new System.Windows.Forms.Label();
            this.RedditLink = new System.Windows.Forms.LinkLabel();
            this.GithubLink = new System.Windows.Forms.LinkLabel();
            this.DonateLink = new System.Windows.Forms.LinkLabel();
            this.StatusLabelTimer = new System.Windows.Forms.Timer(this.components);
            this.HotkeyLabelTimer = new System.Windows.Forms.Timer(this.components);
            this.HotkeyTimer = new System.Windows.Forms.Timer(this.components);
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.DeployDllBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SensX
            // 
            this.SensX.Location = new System.Drawing.Point(86, 6);
            this.SensX.MaxLength = 32;
            this.SensX.Name = "SensX";
            this.SensX.Size = new System.Drawing.Size(138, 20);
            this.SensX.TabIndex = 0;
            this.Tooltip.SetToolTip(this.SensX, "This textbox controls your Horizontal sensitivity.\r\nOnly integers/decimals are al" +
        "lowed in this field.\r\nEG: 1.5.");
            this.SensX.TextChanged += new System.EventHandler(this.SensX_TextChanged);
            this.SensX.Leave += new System.EventHandler(this.SensX_Leave);
            // 
            // SensY
            // 
            this.SensY.Location = new System.Drawing.Point(86, 32);
            this.SensY.MaxLength = 32;
            this.SensY.Name = "SensY";
            this.SensY.Size = new System.Drawing.Size(138, 20);
            this.SensY.TabIndex = 1;
            this.Tooltip.SetToolTip(this.SensY, "This textbox controls your Vertical sensitivity.\r\nOnly integers/decimals are allo" +
        "wed in this field.\r\nEG: 1.5.\r\n");
            this.SensY.TextChanged += new System.EventHandler(this.SensY_TextChanged);
            this.SensY.Leave += new System.EventHandler(this.SensY_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "H Sensitivity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "V Sensitivity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(58, 58);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(16, 13);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "---";
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.Location = new System.Drawing.Point(121, 94);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(103, 23);
            this.ActivateBtn.TabIndex = 6;
            this.ActivateBtn.Text = "Activate";
            this.Tooltip.SetToolTip(this.ActivateBtn, resources.GetString("ActivateBtn.ToolTip"));
            this.ActivateBtn.UseVisualStyleBackColor = true;
            this.ActivateBtn.Click += new System.EventHandler(this.ActivateBtn_Click_1);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Location = new System.Drawing.Point(121, 123);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(103, 23);
            this.SettingsBtn.TabIndex = 7;
            this.SettingsBtn.Text = "Settings";
            this.Tooltip.SetToolTip(this.SettingsBtn, resources.GetString("SettingsBtn.ToolTip"));
            this.SettingsBtn.UseVisualStyleBackColor = true;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hotkey:";
            // 
            // HotkeyStatus
            // 
            this.HotkeyStatus.AutoSize = true;
            this.HotkeyStatus.Location = new System.Drawing.Point(58, 74);
            this.HotkeyStatus.Name = "HotkeyStatus";
            this.HotkeyStatus.Size = new System.Drawing.Size(16, 13);
            this.HotkeyStatus.TabIndex = 9;
            this.HotkeyStatus.Text = "---";
            // 
            // RedditLink
            // 
            this.RedditLink.AutoSize = true;
            this.RedditLink.Location = new System.Drawing.Point(13, 159);
            this.RedditLink.Name = "RedditLink";
            this.RedditLink.Size = new System.Drawing.Size(75, 13);
            this.RedditLink.TabIndex = 10;
            this.RedditLink.TabStop = true;
            this.RedditLink.Text = "Reddit Thread";
            this.RedditLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedditLink_LinkClicked_1);
            // 
            // GithubLink
            // 
            this.GithubLink.AutoSize = true;
            this.GithubLink.Location = new System.Drawing.Point(180, 159);
            this.GithubLink.Name = "GithubLink";
            this.GithubLink.Size = new System.Drawing.Size(38, 13);
            this.GithubLink.TabIndex = 11;
            this.GithubLink.TabStop = true;
            this.GithubLink.Text = "Github";
            this.GithubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLink_LinkClicked_1);
            // 
            // DonateLink
            // 
            this.DonateLink.AutoSize = true;
            this.DonateLink.Location = new System.Drawing.Point(110, 159);
            this.DonateLink.Name = "DonateLink";
            this.DonateLink.Size = new System.Drawing.Size(42, 13);
            this.DonateLink.TabIndex = 12;
            this.DonateLink.TabStop = true;
            this.DonateLink.Text = "Donate";
            this.DonateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DonateLink_LinkClicked_1);
            // 
            // StatusLabelTimer
            // 
            this.StatusLabelTimer.Enabled = true;
            this.StatusLabelTimer.Tick += new System.EventHandler(this.StatusLabelTimer_Tick);
            // 
            // HotkeyLabelTimer
            // 
            this.HotkeyLabelTimer.Enabled = true;
            this.HotkeyLabelTimer.Tick += new System.EventHandler(this.HotkeyLabelTimer_Tick);
            // 
            // HotkeyTimer
            // 
            this.HotkeyTimer.Enabled = true;
            this.HotkeyTimer.Tick += new System.EventHandler(this.HotkeyTimer_Tick);
            // 
            // Tooltip
            // 
            this.Tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tooltip.ToolTipTitle = "About";
            // 
            // DeployDllBtn
            // 
            this.DeployDllBtn.Location = new System.Drawing.Point(12, 94);
            this.DeployDllBtn.Name = "DeployDllBtn";
            this.DeployDllBtn.Size = new System.Drawing.Size(103, 23);
            this.DeployDllBtn.TabIndex = 13;
            this.DeployDllBtn.Text = "Deploy DLL";
            this.Tooltip.SetToolTip(this.DeployDllBtn, resources.GetString("DeployDllBtn.ToolTip"));
            this.DeployDllBtn.UseVisualStyleBackColor = true;
            this.DeployDllBtn.Click += new System.EventHandler(this.DeployDllBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(12, 123);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(103, 23);
            this.ExitBtn.TabIndex = 14;
            this.ExitBtn.Text = "Exit";
            this.Tooltip.SetToolTip(this.ExitBtn, resources.GetString("ExitBtn.ToolTip"));
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(239, 181);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.DeployDllBtn);
            this.Controls.Add(this.DonateLink);
            this.Controls.Add(this.GithubLink);
            this.Controls.Add(this.RedditLink);
            this.Controls.Add(this.HotkeyStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SensY);
            this.Controls.Add(this.SensX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(255, 220);
            this.MinimumSize = new System.Drawing.Size(255, 220);
            this.Name = "Mainform";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SensX;
        private System.Windows.Forms.TextBox SensY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button ActivateBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label HotkeyStatus;
        private System.Windows.Forms.LinkLabel RedditLink;
        private System.Windows.Forms.LinkLabel GithubLink;
        private System.Windows.Forms.LinkLabel DonateLink;
        private System.Windows.Forms.Timer StatusLabelTimer;
        private System.Windows.Forms.Timer HotkeyLabelTimer;
        private System.Windows.Forms.Timer HotkeyTimer;
        private System.Windows.Forms.ToolTip Tooltip;
        private System.Windows.Forms.Button DeployDllBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}

