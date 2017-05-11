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
            this.label2 = new System.Windows.Forms.Label();
            this.Sens = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.GithubLink = new System.Windows.Forms.LinkLabel();
            this.RedditLink = new System.Windows.Forms.LinkLabel();
            this.EnableBtnTimer = new System.Windows.Forms.Timer(this.components);
            this.ActivateBtnTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mouse Sensitivity:";
            // 
            // Sens
            // 
            this.Sens.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Sens.Location = new System.Drawing.Point(104, 6);
            this.Sens.MaxLength = 10;
            this.Sens.Name = "Sens";
            this.Sens.Size = new System.Drawing.Size(148, 20);
            this.Sens.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusLabel.Location = new System.Drawing.Point(92, 68);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(150, 13);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "Waiting for Halo CE Process...";
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.Enabled = false;
            this.ActivateBtn.Location = new System.Drawing.Point(12, 32);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(237, 33);
            this.ActivateBtn.TabIndex = 6;
            this.ActivateBtn.Text = "Activate(PGUP)";
            this.ActivateBtnTip.SetToolTip(this.ActivateBtn, "Sets the sensitivites to the values above + disables mouse acceleration.");
            this.ActivateBtn.UseVisualStyleBackColor = true;
            this.ActivateBtn.Click += new System.EventHandler(this.ActivateBtn_Click);
            // 
            // GithubLink
            // 
            this.GithubLink.AutoSize = true;
            this.GithubLink.Location = new System.Drawing.Point(9, 86);
            this.GithubLink.Name = "GithubLink";
            this.GithubLink.Size = new System.Drawing.Size(38, 13);
            this.GithubLink.TabIndex = 8;
            this.GithubLink.TabStop = true;
            this.GithubLink.Text = "Github";
            this.GithubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLink_LinkClicked);
            // 
            // RedditLink
            // 
            this.RedditLink.AutoSize = true;
            this.RedditLink.Location = new System.Drawing.Point(175, 86);
            this.RedditLink.Name = "RedditLink";
            this.RedditLink.Size = new System.Drawing.Size(75, 13);
            this.RedditLink.TabIndex = 9;
            this.RedditLink.TabStop = true;
            this.RedditLink.Text = "Reddit Thread";
            this.RedditLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedditLink_LinkClicked);
            // 
            // EnableBtnTimer
            // 
            this.EnableBtnTimer.Enabled = true;
            this.EnableBtnTimer.Tick += new System.EventHandler(this.EnableBtnTimer_Tick);
            // 
            // ActivateBtnTip
            // 
            this.ActivateBtnTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ActivateBtnTip.ToolTipTitle = "Activate the tool using the values above.";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-8, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 2);
            this.label1.TabIndex = 13;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(264, 101);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RedditLink);
            this.Controls.Add(this.GithubLink);
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Sens);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 140);
            this.MinimumSize = new System.Drawing.Size(280, 140);
            this.Name = "Mainform";
            this.Text = "Halo CE Mouse Tool";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Sens;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button ActivateBtn;
        private System.Windows.Forms.LinkLabel GithubLink;
        private System.Windows.Forms.LinkLabel RedditLink;
        private System.Windows.Forms.Timer EnableBtnTimer;
        private System.Windows.Forms.ToolTip ActivateBtnTip;
        private System.Windows.Forms.Label label1;
    }
}

