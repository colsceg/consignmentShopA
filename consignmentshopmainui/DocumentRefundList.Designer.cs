
namespace ConsignmentShopMainUI
{
    partial class DocumentRefundList
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
            this.PrintBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.MyRichTextBoxEx = new ConsignmentShopLibrary.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(36, 29);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 1;
            this.PrintBtn.Text = "Drucken";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PrintBtn_MouseClick);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(684, 29);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Schliessen";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseBtn_MouseClick);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // MyRichTextBoxEx
            // 
            this.MyRichTextBoxEx.Location = new System.Drawing.Point(36, 58);
            this.MyRichTextBoxEx.Name = "MyRichTextBoxEx";
            this.MyRichTextBoxEx.Size = new System.Drawing.Size(723, 547);
            this.MyRichTextBoxEx.TabIndex = 0;
            this.MyRichTextBoxEx.Text = "";
            // 
            // DocumentRefundList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 633);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.MyRichTextBoxEx);
            this.Name = "DocumentRefundList";
            this.Text = "DocumentRefundList";
            this.Load += new System.EventHandler(this.DocumentRefundList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ConsignmentShopLibrary.RichTextBoxEx MyRichTextBoxEx;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}