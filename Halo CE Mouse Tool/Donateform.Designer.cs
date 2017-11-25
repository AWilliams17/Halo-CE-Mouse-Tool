namespace Halo_CE_Mouse_Tool
{
    partial class Donateform
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
            this.BTCQR = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTCAddr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BTCQR)).BeginInit();
            this.SuspendLayout();
            // 
            // BTCQR
            // 
            this.BTCQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BTCQR.Image = global::Halo_CE_Mouse_Tool.Properties.Resources.x9cRL6m;
            this.BTCQR.Location = new System.Drawing.Point(12, 27);
            this.BTCQR.Name = "BTCQR";
            this.BTCQR.Size = new System.Drawing.Size(250, 250);
            this.BTCQR.TabIndex = 0;
            this.BTCQR.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "You REALLY don\'t have to, but I appreciate it...";
            // 
            // BTCAddr
            // 
            this.BTCAddr.Location = new System.Drawing.Point(12, 283);
            this.BTCAddr.MaxLength = 35;
            this.BTCAddr.Name = "BTCAddr";
            this.BTCAddr.ReadOnly = true;
            this.BTCAddr.Size = new System.Drawing.Size(250, 20);
            this.BTCAddr.TabIndex = 2;
            this.BTCAddr.Text = "1HXoT5Zjf6vMZqSN411ybpQ3YXaBgun6j2";
            // 
            // Donateform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 311);
            this.Controls.Add(this.BTCAddr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTCQR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Donateform";
            this.Text = "Donate BTC";
            ((System.ComponentModel.ISupportInitialize)(this.BTCQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BTCQR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BTCAddr;
    }
}