namespace ConsignmentShopMainUI
{
    partial class KeyInputWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyInputWindow));
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBSerNo = new ConsignmentShopLibrary.TextBoxEnter();
            this.TBKey = new ConsignmentShopLibrary.NumTextBox();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(145, 114);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "Abbrechen";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.BackColor = System.Drawing.SystemColors.Control;
            this.BtnOK.Location = new System.Drawing.Point(48, 114);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = false;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SerNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Schlüssel";
            // 
            // TBSerNo
            // 
            this.TBSerNo.BackColor = System.Drawing.SystemColors.Control;
            this.TBSerNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TBSerNo.Location = new System.Drawing.Point(94, 27);
            this.TBSerNo.Name = "TBSerNo";
            this.TBSerNo.ReadOnly = true;
            this.TBSerNo.Size = new System.Drawing.Size(100, 20);
            this.TBSerNo.TabIndex = 1;
            this.TBSerNo.TabStop = false;
            this.TBSerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBKey
            // 
            this.TBKey.BackColor = System.Drawing.SystemColors.Control;
            this.TBKey.Location = new System.Drawing.Point(94, 64);
            this.TBKey.Name = "TBKey";
            this.TBKey.Size = new System.Drawing.Size(100, 20);
            this.TBKey.TabIndex = 6;
            // 
            // KeyInputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(259, 149);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.TBSerNo);
            this.Controls.Add(this.TBKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeyInputWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volversion freischalten";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConsignmentShopLibrary.NumTextBox TBKey;
        private ConsignmentShopLibrary.TextBoxEnter TBSerNo;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}