namespace ConsignmentShopMainUI
{
    partial class DocumentMonthlyVolumes
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
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.MyRichTextBoxEx = new ConsignmentShopLibrary.RichTextBoxEx();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // MyRichTextBoxEx
            // 
            this.MyRichTextBoxEx.Location = new System.Drawing.Point(10, 57);
            this.MyRichTextBoxEx.Name = "MyRichTextBoxEx";
            this.MyRichTextBoxEx.Size = new System.Drawing.Size(638, 790);
            this.MyRichTextBoxEx.TabIndex = 0;
            this.MyRichTextBoxEx.Text = "";
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(12, 28);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 1;
            this.PrintBtn.Text = "Drucken";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(570, 28);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Schliessen";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DocumentMonthlyVolumes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 651);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.MyRichTextBoxEx);
            this.Name = "DocumentMonthlyVolumes";
            this.Text = "DocumentMonthlyVolumes";
            this.Load += new System.EventHandler(this.DocumentMonthlyVolumes_Load);
            this.Shown += new System.EventHandler(this.DocumentMonthlyVolumes_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog1;
        private ConsignmentShopLibrary.RichTextBoxEx MyRichTextBoxEx;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}