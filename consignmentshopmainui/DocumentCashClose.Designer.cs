﻿namespace ConsignmentShopMainUI
{
    partial class DocumentCashClose
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
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PrintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myRichTextBoxEx
            // 
            this.myRichTextBoxEx.Location = new System.Drawing.Point(9, 30);
            this.myRichTextBoxEx.Name = "myRichTextBoxEx";
            this.myRichTextBoxEx.Size = new System.Drawing.Size(638, 790);
            this.myRichTextBoxEx.TabIndex = 0;
            this.myRichTextBoxEx.Text = "";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(570, 3);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 23);
            this.PrintButton.TabIndex = 1;
            this.PrintButton.Text = "Drucken";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // DocumentCashClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 651);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.myRichTextBoxEx);
            this.Name = "DocumentCashClose";
            this.Text = "DocumentCashClose";
            this.Shown += new System.EventHandler(this.DocumentCashClose_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private ConsignmentShopLibrary.RichTextBoxEx myRichTextBoxEx;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button PrintButton;
    }
}