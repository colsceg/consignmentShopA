namespace ConsignmentShopMainUI
{
    partial class DocumentSalesVolume
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
            this.myRichTextBoxEx = new ConsignmentShopLibrary.RichTextBoxEx();
            this.PrintButton = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myRichTextBoxEx
            // 
            this.myRichTextBoxEx.Location = new System.Drawing.Point(8, 41);
            this.myRichTextBoxEx.Name = "myRichTextBoxEx";
            this.myRichTextBoxEx.Size = new System.Drawing.Size(752, 790);
            this.myRichTextBoxEx.TabIndex = 0;
            this.myRichTextBoxEx.Text = "";
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(682, 12);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 23);
            this.PrintButton.TabIndex = 1;
            this.PrintButton.Text = "Drucken";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Speichern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DocumentSalesVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 651);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.myRichTextBoxEx);
            this.Name = "DocumentSalesVolume";
            this.Text = "DocumentSalesVolume";
            this.Load += new System.EventHandler(this.DocumentSalesVolume_Load);
            this.Shown += new System.EventHandler(this.DocumentSalesVolume_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private ConsignmentShopLibrary.RichTextBoxEx myRichTextBoxEx;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button1;
    }
}