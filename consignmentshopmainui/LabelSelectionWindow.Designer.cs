namespace ConsignmentShopMainUI
{
    partial class LabelSelectionWindow
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.LastLabelNumberTB = new System.Windows.Forms.TextBox();
            this.PosNumberFromTB = new System.Windows.Forms.TextBox();
            this.PosNumberToTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(12, 169);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 0;
            this.PrintBtn.Text = "Drucken";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(195, 171);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Abbrechen";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LastLabelNumberTB
            // 
            this.LastLabelNumberTB.Location = new System.Drawing.Point(124, 46);
            this.LastLabelNumberTB.Name = "LastLabelNumberTB";
            this.LastLabelNumberTB.Size = new System.Drawing.Size(34, 20);
            this.LastLabelNumberTB.TabIndex = 2;
            this.LastLabelNumberTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LastLabelNumberTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastLabelNumberTB_KeyDown);
            this.LastLabelNumberTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastLabelNumberTB_KeyPress);
            // 
            // PosNumberFromTB
            // 
            this.PosNumberFromTB.Location = new System.Drawing.Point(66, 129);
            this.PosNumberFromTB.Name = "PosNumberFromTB";
            this.PosNumberFromTB.Size = new System.Drawing.Size(34, 20);
            this.PosNumberFromTB.TabIndex = 3;
            this.PosNumberFromTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PosNumberFromTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemNumberFromTB_KeyDown);
            this.PosNumberFromTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemNumberFromTB_KeyPress);
            this.PosNumberFromTB.Leave += new System.EventHandler(this.PosNumberFromTB_Leave);
            // 
            // PosNumberToTB
            // 
            this.PosNumberToTB.Location = new System.Drawing.Point(188, 129);
            this.PosNumberToTB.Name = "PosNumberToTB";
            this.PosNumberToTB.Size = new System.Drawing.Size(34, 20);
            this.PosNumberToTB.TabIndex = 4;
            this.PosNumberToTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PosNumberToTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemNumberToTB_KeyDown);
            this.PosNumberToTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemNumberToTB_KeyPress);
            this.PosNumberToTB.Leave += new System.EventHandler(this.PosNumberToTB_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Aktuelle Etikettennummer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "ArtikelNr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "von:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "bis:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "(für neuen Bogen 0 eingeben)";
            // 
            // LabelSelectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(281, 209);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PosNumberToTB);
            this.Controls.Add(this.PosNumberFromTB);
            this.Controls.Add(this.LastLabelNumberTB);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.PrintBtn);
            this.Name = "LabelSelectionWindow";
            this.Text = "EtikettenDruck";
            this.Load += new System.EventHandler(this.LabelSelectionWindow_Load);
            this.Shown += new System.EventHandler(this.LabelSelectionWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox LastLabelNumberTB;
        private System.Windows.Forms.TextBox PosNumberFromTB;
        private System.Windows.Forms.TextBox PosNumberToTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}