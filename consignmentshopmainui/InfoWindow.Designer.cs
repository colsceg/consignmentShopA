namespace ConsignmentShopMainUI
{
    partial class InfoWindow
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
            this.OKBtn = new System.Windows.Forms.Button();
            this.ComissionLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.SerNoLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(104, 107);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(38, 23);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // ComissionLabel
            // 
            this.ComissionLabel.AutoSize = true;
            this.ComissionLabel.Location = new System.Drawing.Point(12, 9);
            this.ComissionLabel.Name = "ComissionLabel";
            this.ComissionLabel.Size = new System.Drawing.Size(204, 13);
            this.ComissionLabel.TabIndex = 1;
            this.ComissionLabel.Text = "Vertragsverwaltung für Kommissionsartikel";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(12, 55);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(113, 13);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "EMail: info@chairfit.de";
            // 
            // SerNoLabel
            // 
            this.SerNoLabel.AutoSize = true;
            this.SerNoLabel.Location = new System.Drawing.Point(12, 79);
            this.SerNoLabel.Name = "SerNoLabel";
            this.SerNoLabel.Size = new System.Drawing.Size(115, 13);
            this.SerNoLabel.TabIndex = 3;
            this.SerNoLabel.Text = "SerNo: 000000000000";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(12, 33);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(155, 13);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "VersNr 1.0.0.0 vom 18.07.2017";
            // 
            // InfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(243, 142);
            this.ControlBox = false;
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.SerNoLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.ComissionLabel);
            this.Controls.Add(this.OKBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoWindow";
            this.Text = "Info";
            this.Shown += new System.EventHandler(this.InfoWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Label ComissionLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label SerNoLabel;
        private System.Windows.Forms.Label VersionLabel;
    }
}