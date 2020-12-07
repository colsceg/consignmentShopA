namespace ConsignmentShopMainUI
{
    partial class PopUpWindow
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
            this.components = new System.ComponentModel.Container();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(393, 231);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(8, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(200, 150);
            this.RichTextBox1.TabIndex = 2;
            this.RichTextBox1.Text = "";
            // 
            // PopUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 161);
            this.ControlBox = false;
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.maskedTextBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(220, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(220, 200);
            this.Name = "PopUpWindow";
            this.ShowInTaskbar = false;
            this.Text = "PopUpWindow";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox RichTextBox1;
    }
}