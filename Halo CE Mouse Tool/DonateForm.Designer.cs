namespace Halo_CE_Mouse_Tool {
    partial class DonateForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonateForm));
            this.label1 = new System.Windows.Forms.Label();
            this.PaypalLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Well if you insist...";
            // 
            // PaypalLink
            // 
            this.PaypalLink.AutoSize = true;
            this.PaypalLink.Location = new System.Drawing.Point(100, 9);
            this.PaypalLink.Name = "PaypalLink";
            this.PaypalLink.Size = new System.Drawing.Size(90, 13);
            this.PaypalLink.TabIndex = 1;
            this.PaypalLink.TabStop = true;
            this.PaypalLink.Text = "Here\'s my paypal.";
            this.PaypalLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PaypalLink_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Or, if you\'re into coins:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(285, 47);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "BTC: 1HXoT5Zjf6vMZqSN411ybpQ3YXaBgun6j2\r\nLTC: LXQzjGtUutfBy3YsuAM1k5C7iABnYBPy9U\r" +
    "\nETH: 0x0bc018c616adab4578e64469c127c9c633c9a93a";
            // 
            // DonateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 81);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PaypalLink);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(330, 120);
            this.MinimumSize = new System.Drawing.Size(330, 120);
            this.Name = "DonateForm";
            this.Text = "Donate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel PaypalLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}