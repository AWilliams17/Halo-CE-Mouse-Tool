namespace Halo_Mouse_Tool
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSettingsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DonateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeployDllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HaloCustomEditionBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.HaloCombatEvolvedBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SensXTextBox = new System.Windows.Forms.TextBox();
            this.SensYTextBox = new System.Windows.Forms.TextBox();
            this.WriteBtn = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.HaloStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpdateStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.HotkeyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miscToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(384, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveSettingsBtn,
            this.HelpBtn,
            this.AboutBtn,
            this.DonateBtn,
            this.toolStripSeparator1,
            this.ExitBtn});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.miscToolStripMenuItem.Text = "File";
            // 
            // SaveSettingsBtn
            // 
            this.SaveSettingsBtn.Name = "SaveSettingsBtn";
            this.SaveSettingsBtn.Size = new System.Drawing.Size(143, 22);
            this.SaveSettingsBtn.Text = "Save Settings";
            this.SaveSettingsBtn.Click += new System.EventHandler(this.SaveSettingsBtn_Click);
            // 
            // HelpBtn
            // 
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(143, 22);
            this.HelpBtn.Text = "Help";
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(143, 22);
            this.AboutBtn.Text = "About";
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // DonateBtn
            // 
            this.DonateBtn.Name = "DonateBtn";
            this.DonateBtn.Size = new System.Drawing.Size(143, 22);
            this.DonateBtn.Text = "Donate";
            this.DonateBtn.Click += new System.EventHandler(this.DonateBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(143, 22);
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeployDllBtn,
            this.CheckForUpdateBtn,
            this.OptionsBtn});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // DeployDllBtn
            // 
            this.DeployDllBtn.Name = "DeployDllBtn";
            this.DeployDllBtn.Size = new System.Drawing.Size(166, 22);
            this.DeployDllBtn.Text = "Deploy DLL";
            this.DeployDllBtn.Click += new System.EventHandler(this.DeployDllBtn_Click);
            // 
            // CheckForUpdateBtn
            // 
            this.CheckForUpdateBtn.Name = "CheckForUpdateBtn";
            this.CheckForUpdateBtn.Size = new System.Drawing.Size(166, 22);
            this.CheckForUpdateBtn.Text = "Check for Update";
            this.CheckForUpdateBtn.Click += new System.EventHandler(this.CheckForUpdateBtn_Click);
            // 
            // OptionsBtn
            // 
            this.OptionsBtn.Name = "OptionsBtn";
            this.OptionsBtn.Size = new System.Drawing.Size(166, 22);
            this.OptionsBtn.Text = "Options";
            this.OptionsBtn.Click += new System.EventHandler(this.OptionsBtn_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HaloCustomEditionBtn,
            this.HaloCombatEvolvedBtn});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // HaloCustomEditionBtn
            // 
            this.HaloCustomEditionBtn.Name = "HaloCustomEditionBtn";
            this.HaloCustomEditionBtn.Size = new System.Drawing.Size(189, 22);
            this.HaloCustomEditionBtn.Text = "Halo Custom Edition";
            this.HaloCustomEditionBtn.Click += new System.EventHandler(this.HaloCustomEditionBtn_Click);
            // 
            // HaloCombatEvolvedBtn
            // 
            this.HaloCombatEvolvedBtn.Name = "HaloCombatEvolvedBtn";
            this.HaloCombatEvolvedBtn.Size = new System.Drawing.Size(189, 22);
            this.HaloCombatEvolvedBtn.Text = "Halo Combat Evolved";
            this.HaloCombatEvolvedBtn.Click += new System.EventHandler(this.HaloCombatEvolvedBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sensitivity X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sensitivity Y:";
            // 
            // SensXTextBox
            // 
            this.SensXTextBox.Location = new System.Drawing.Point(106, 29);
            this.SensXTextBox.Name = "SensXTextBox";
            this.SensXTextBox.Size = new System.Drawing.Size(82, 20);
            this.SensXTextBox.TabIndex = 3;
            // 
            // SensYTextBox
            // 
            this.SensYTextBox.Location = new System.Drawing.Point(266, 29);
            this.SensYTextBox.Name = "SensYTextBox";
            this.SensYTextBox.Size = new System.Drawing.Size(82, 20);
            this.SensYTextBox.TabIndex = 4;
            // 
            // WriteBtn
            // 
            this.WriteBtn.Location = new System.Drawing.Point(12, 55);
            this.WriteBtn.Name = "WriteBtn";
            this.WriteBtn.Size = new System.Drawing.Size(360, 30);
            this.WriteBtn.TabIndex = 5;
            this.WriteBtn.Text = "Write to Memory";
            this.WriteBtn.UseVisualStyleBackColor = true;
            this.WriteBtn.Click += new System.EventHandler(this.WriteBtn_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // HaloStatusLabel
            // 
            this.HaloStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.HaloStatusLabel.Name = "HaloStatusLabel";
            this.HaloStatusLabel.Size = new System.Drawing.Size(94, 17);
            this.HaloStatusLabel.Text = "Waiting for Halo";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel3.Text = "Updates:";
            // 
            // UpdateStatusLabel
            // 
            this.UpdateStatusLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.UpdateStatusLabel.Name = "UpdateStatusLabel";
            this.UpdateStatusLabel.Size = new System.Drawing.Size(36, 17);
            this.UpdateStatusLabel.Text = "None";
            this.UpdateStatusLabel.Click += new System.EventHandler(this.UpdateStatusLabel_Click);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel5.Text = "Hotkey:";
            // 
            // HotkeyLabel
            // 
            this.HotkeyLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HotkeyLabel.Name = "HotkeyLabel";
            this.HotkeyLabel.Size = new System.Drawing.Size(52, 17);
            this.HotkeyLabel.Text = "Disabled";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.HaloStatusLabel,
            this.toolStripStatusLabel3,
            this.UpdateStatusLabel,
            this.toolStripStatusLabel5,
            this.HotkeyLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 95);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(384, 22);
            this.StatusBar.TabIndex = 6;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 20000;
            this.ToolTip.InitialDelay = 250;
            this.ToolTip.ReshowDelay = 100;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Help";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 117);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.WriteBtn);
            this.Controls.Add(this.SensYTextBox);
            this.Controls.Add(this.SensXTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "-";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HaloCustomEditionBtn;
        private System.Windows.Forms.ToolStripMenuItem HaloCombatEvolvedBtn;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeployDllBtn;
        private System.Windows.Forms.ToolStripMenuItem OptionsBtn;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpBtn;
        private System.Windows.Forms.ToolStripMenuItem DonateBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SensXTextBox;
        private System.Windows.Forms.TextBox SensYTextBox;
        private System.Windows.Forms.Button WriteBtn;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdateBtn;
        private System.Windows.Forms.ToolStripMenuItem AboutBtn;
        private System.Windows.Forms.ToolStripMenuItem SaveSettingsBtn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel HaloStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel UpdateStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel HotkeyLabel;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}

