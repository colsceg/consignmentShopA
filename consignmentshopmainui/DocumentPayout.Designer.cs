namespace ConsignmentShopMainUI
{
    partial class DocumentPayout
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
            this.ContractRichTextPrintBox = new System.Windows.Forms.RichTextBox();
            this.PayAndPrintBtn = new System.Windows.Forms.Button();
            this.richTextBoxEx2 = new ConsignmentShopLibrary.RichTextBoxEx();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.PayNotPrintBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ContractRichTextPrintBox
            // 
            this.ContractRichTextPrintBox.Location = new System.Drawing.Point(12, 41);
            this.ContractRichTextPrintBox.Name = "ContractRichTextPrintBox";
            this.ContractRichTextPrintBox.Size = new System.Drawing.Size(559, 790);
            this.ContractRichTextPrintBox.TabIndex = 0;
            this.ContractRichTextPrintBox.Text = "";
            // 
            // PayAndPrintBtn
            // 
            this.PayAndPrintBtn.Location = new System.Drawing.Point(12, 12);
            this.PayAndPrintBtn.Name = "PayAndPrintBtn";
            this.PayAndPrintBtn.Size = new System.Drawing.Size(128, 23);
            this.PayAndPrintBtn.TabIndex = 1;
            this.PayAndPrintBtn.Text = "Auszahlung und Druck";
            this.PayAndPrintBtn.UseVisualStyleBackColor = true;
            this.PayAndPrintBtn.Click += new System.EventHandler(this.PayAndPrintBtn_Click);
            // 
            // richTextBoxEx2
            // 
            this.richTextBoxEx2.Location = new System.Drawing.Point(11, 41);
            this.richTextBoxEx2.Name = "richTextBoxEx2";
            this.richTextBoxEx2.Size = new System.Drawing.Size(645, 790);
            this.richTextBoxEx2.TabIndex = 2;
            this.richTextBoxEx2.Text = "";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // PayNotPrintBtn
            // 
            this.PayNotPrintBtn.Location = new System.Drawing.Point(241, 12);
            this.PayNotPrintBtn.Name = "PayNotPrintBtn";
            this.PayNotPrintBtn.Size = new System.Drawing.Size(143, 23);
            this.PayNotPrintBtn.TabIndex = 3;
            this.PayNotPrintBtn.Text = "Auszahlung ohne Druck";
            this.PayNotPrintBtn.UseVisualStyleBackColor = true;
            this.PayNotPrintBtn.Click += new System.EventHandler(this.PayNotPrintBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(525, 12);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(128, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Abbrechen";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // DocumentPayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 651);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.PayNotPrintBtn);
            this.Controls.Add(this.richTextBoxEx2);
            this.Controls.Add(this.PayAndPrintBtn);
            this.Controls.Add(this.ContractRichTextPrintBox);
            this.Name = "DocumentPayout";
            this.Text = "DocumentPayout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DocumentPayout_FormClosed);
            this.Load += new System.EventHandler(this.DocumentPayout_Load);
            this.Shown += new System.EventHandler(this.DocumentPayout_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ContractRichTextPrintBox;
        private System.Windows.Forms.Button PayAndPrintBtn;
        private ConsignmentShopLibrary.RichTextBoxEx richTextBoxEx2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button PayNotPrintBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}