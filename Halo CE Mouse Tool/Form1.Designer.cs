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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SensY = new System.Windows.Forms.TextBox();
            this.SensX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.PatchBtn = new System.Windows.Forms.Button();
            this.GithubLink = new System.Windows.Forms.LinkLabel();
            this.RedditLink = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.EnableBtnTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vertical Sensitivity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Horizontal Sensitivity:";
            // 
            // SensY
            // 
            this.SensY.Location = new System.Drawing.Point(125, 6);
            this.SensY.Name = "SensY";
            this.SensY.Size = new System.Drawing.Size(100, 20);
            this.SensY.TabIndex = 2;
            // 
            // SensX
            // 
            this.SensX.Location = new System.Drawing.Point(125, 28);
            this.SensX.Name = "SensX";
            this.SensX.Size = new System.Drawing.Size(100, 20);
            this.SensX.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusLabel.Location = new System.Drawing.Point(60, 80);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(150, 13);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "Waiting for Halo CE Process...";
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.Enabled = false;
            this.ActivateBtn.Location = new System.Drawing.Point(125, 54);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(100, 23);
            this.ActivateBtn.TabIndex = 6;
            this.ActivateBtn.Text = "Activate(PGUP)";
            this.ActivateBtn.UseVisualStyleBackColor = true;
            // 
            // PatchBtn
            // 
            this.PatchBtn.Location = new System.Drawing.Point(15, 54);
            this.PatchBtn.Name = "PatchBtn";
            this.PatchBtn.Size = new System.Drawing.Size(100, 23);
            this.PatchBtn.TabIndex = 7;
            this.PatchBtn.Text = "Patch...";
            this.PatchBtn.UseVisualStyleBackColor = true;
            // 
            // GithubLink
            // 
            this.GithubLink.AutoSize = true;
            this.GithubLink.Location = new System.Drawing.Point(12, 99);
            this.GithubLink.Name = "GithubLink";
            this.GithubLink.Size = new System.Drawing.Size(38, 13);
            this.GithubLink.TabIndex = 8;
            this.GithubLink.TabStop = true;
            this.GithubLink.Text = "Github";
            // 
            // RedditLink
            // 
            this.RedditLink.AutoSize = true;
            this.RedditLink.Location = new System.Drawing.Point(150, 99);
            this.RedditLink.Name = "RedditLink";
            this.RedditLink.Size = new System.Drawing.Size(75, 13);
            this.RedditLink.TabIndex = 9;
            this.RedditLink.TabStop = true;
            this.RedditLink.Text = "Reddit Thread";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.WindowText;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(0, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 2);
            this.label5.TabIndex = 10;
            // 
            // EnableBtnTimer
            // 
            this.EnableBtnTimer.Enabled = true;
            this.EnableBtnTimer.Tick += new System.EventHandler(this.EnableBtnTimer_Tick);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(244, 116);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RedditLink);
            this.Controls.Add(this.GithubLink);
            this.Controls.Add(this.PatchBtn);
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SensX);
            this.Controls.Add(this.SensY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 155);
            this.MinimumSize = new System.Drawing.Size(260, 155);
            this.Name = "Mainform";
            this.Text = "Halo CE Mouse Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SensY;
        private System.Windows.Forms.TextBox SensX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button ActivateBtn;
        private System.Windows.Forms.Button PatchBtn;
        private System.Windows.Forms.LinkLabel GithubLink;
        private System.Windows.Forms.LinkLabel RedditLink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer EnableBtnTimer;
    }
}

