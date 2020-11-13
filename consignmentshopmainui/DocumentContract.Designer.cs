namespace ConsignmentShopMainUI
{
    partial class DocumentContract
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
            this.PrintButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.myRichTextBoxEx = new ConsignmentShopLibrary.RichTextBoxEx();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(12, 8);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(84, 24);
            this.PrintButton.TabIndex = 0;
            this.PrintButton.Text = "drucken";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // myRichTextBoxEx
            // 
            this.myRichTextBoxEx.Location = new System.Drawing.Point(7, 38);
            this.myRichTextBoxEx.Name = "myRichTextBoxEx";
            this.myRichTextBoxEx.Size = new System.Drawing.Size(645, 790);
            this.myRichTextBoxEx.TabIndex = 2;
            this.myRichTextBoxEx.Text = "";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(559, 8);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(93, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "nicht drucken";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // DocumentContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 651);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.myRichTextBoxEx);
            this.Controls.Add(this.PrintButton);
            this.Name = "DocumentContract";
            this.Text = "DocumentContract";
            this.Load += new System.EventHandler(this.DocumentContract_Load);
            this.Shown += new System.EventHandler(this.DocumentContract_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private ConsignmentShopLibrary.RichTextBoxEx myRichTextBoxEx;
        private System.Windows.Forms.Button CancelBtn;
    }
}