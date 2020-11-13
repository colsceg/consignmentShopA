namespace ConsignmentShopMainUI
{
    partial class CheckoutWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.CashSumTB = new System.Windows.Forms.TextBox();
            this.HeaderLbl = new System.Windows.Forms.Label();
            this.PayedSumTB = new System.Windows.Forms.TextBox();
            this.SoldSumTB = new System.Windows.Forms.TextBox();
            this.CashExpectedTB = new System.Windows.Forms.TextBox();
            this.CashDiffTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SumDiffLabel = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.CashSumStartTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ListSoldBtn = new System.Windows.Forms.Button();
            this.ListPayedBtn = new System.Windows.Forms.Button();
            this.AktDatumLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SumToPayTB = new ConsignmentShopLibrary.TextBoxEnter();
            this.SumCommissionTB = new ConsignmentShopLibrary.TextBoxEnter();
            this.SuspendLayout();
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(12, 238);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 0;
            this.PrintBtn.Text = "Drucken";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kasse Ist";
            // 
            // CashSumTB
            // 
            this.CashSumTB.Location = new System.Drawing.Point(22, 138);
            this.CashSumTB.Name = "CashSumTB";
            this.CashSumTB.Size = new System.Drawing.Size(68, 20);
            this.CashSumTB.TabIndex = 2;
            this.CashSumTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CashSumTB.Click += new System.EventHandler(this.CashSumTB_Click);
            this.CashSumTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CashSumTB_KeyDown);
            this.CashSumTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CashSumTB_KeyPress);
            this.CashSumTB.Leave += new System.EventHandler(this.CashSumTB_Leave);
            // 
            // HeaderLbl
            // 
            this.HeaderLbl.AutoSize = true;
            this.HeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLbl.Location = new System.Drawing.Point(12, 9);
            this.HeaderLbl.Name = "HeaderLbl";
            this.HeaderLbl.Size = new System.Drawing.Size(184, 16);
            this.HeaderLbl.TabIndex = 3;
            this.HeaderLbl.Text = "Kassenabschluss für den ";
            // 
            // PayedSumTB
            // 
            this.PayedSumTB.Location = new System.Drawing.Point(20, 89);
            this.PayedSumTB.Name = "PayedSumTB";
            this.PayedSumTB.ReadOnly = true;
            this.PayedSumTB.Size = new System.Drawing.Size(70, 20);
            this.PayedSumTB.TabIndex = 4;
            this.PayedSumTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SoldSumTB
            // 
            this.SoldSumTB.Location = new System.Drawing.Point(219, 89);
            this.SoldSumTB.Name = "SoldSumTB";
            this.SoldSumTB.ReadOnly = true;
            this.SoldSumTB.Size = new System.Drawing.Size(55, 20);
            this.SoldSumTB.TabIndex = 5;
            this.SoldSumTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CashExpectedTB
            // 
            this.CashExpectedTB.Location = new System.Drawing.Point(151, 138);
            this.CashExpectedTB.Name = "CashExpectedTB";
            this.CashExpectedTB.ReadOnly = true;
            this.CashExpectedTB.Size = new System.Drawing.Size(69, 20);
            this.CashExpectedTB.TabIndex = 6;
            this.CashExpectedTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CashDiffTB
            // 
            this.CashDiffTB.Location = new System.Drawing.Point(277, 138);
            this.CashDiffTB.Name = "CashDiffTB";
            this.CashDiffTB.ReadOnly = true;
            this.CashDiffTB.Size = new System.Drawing.Size(63, 20);
            this.CashDiffTB.TabIndex = 7;
            this.CashDiffTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Auszahlung heute";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Verkaufsumme heute";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kasse Soll";
            // 
            // SumDiffLabel
            // 
            this.SumDiffLabel.AutoSize = true;
            this.SumDiffLabel.ForeColor = System.Drawing.Color.Red;
            this.SumDiffLabel.Location = new System.Drawing.Point(278, 122);
            this.SumDiffLabel.Name = "SumDiffLabel";
            this.SumDiffLabel.Size = new System.Drawing.Size(49, 13);
            this.SumDiffLabel.TabIndex = 11;
            this.SumDiffLabel.Text = "Differenz";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(284, 238);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 12;
            this.CloseBtn.Text = "Schliessen";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // CashSumStartTB
            // 
            this.CashSumStartTB.Location = new System.Drawing.Point(116, 34);
            this.CashSumStartTB.Name = "CashSumStartTB";
            this.CashSumStartTB.Size = new System.Drawing.Size(71, 20);
            this.CashSumStartTB.TabIndex = 14;
            this.CashSumStartTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CashSumStartTB.Click += new System.EventHandler(this.CashSumStartTB_Click);
            this.CashSumStartTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CashSumStartTB_KeyDown);
            this.CashSumStartTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CashSumStartTB_KeyPress);
            this.CashSumStartTB.Leave += new System.EventHandler(this.CashSumStartTB_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Anfangsbestand";
            // 
            // ListSoldBtn
            // 
            this.ListSoldBtn.Location = new System.Drawing.Point(280, 89);
            this.ListSoldBtn.Name = "ListSoldBtn";
            this.ListSoldBtn.Size = new System.Drawing.Size(48, 23);
            this.ListSoldBtn.TabIndex = 15;
            this.ListSoldBtn.Text = "Details";
            this.ListSoldBtn.UseVisualStyleBackColor = true;
            this.ListSoldBtn.Click += new System.EventHandler(this.ListSoldBtn_Click);
            // 
            // ListPayedBtn
            // 
            this.ListPayedBtn.Location = new System.Drawing.Point(96, 86);
            this.ListPayedBtn.Name = "ListPayedBtn";
            this.ListPayedBtn.Size = new System.Drawing.Size(48, 23);
            this.ListPayedBtn.TabIndex = 16;
            this.ListPayedBtn.Text = "Details";
            this.ListPayedBtn.UseVisualStyleBackColor = true;
            this.ListPayedBtn.Click += new System.EventHandler(this.ListPayedBtn_Click);
            // 
            // AktDatumLabel
            // 
            this.AktDatumLabel.AutoSize = true;
            this.AktDatumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AktDatumLabel.Location = new System.Drawing.Point(202, 9);
            this.AktDatumLabel.Name = "AktDatumLabel";
            this.AktDatumLabel.Size = new System.Drawing.Size(52, 16);
            this.AktDatumLabel.TabIndex = 17;
            this.AktDatumLabel.Text = "Datum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(202, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "auszuzahlen Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(60, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Gewinn heute";
            // 
            // SumToPayTB
            // 
            this.SumToPayTB.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SumToPayTB.ForeColor = System.Drawing.SystemColors.Window;
            this.SumToPayTB.Location = new System.Drawing.Point(205, 192);
            this.SumToPayTB.Name = "SumToPayTB";
            this.SumToPayTB.Size = new System.Drawing.Size(90, 20);
            this.SumToPayTB.TabIndex = 19;
            this.SumToPayTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SumCommissionTB
            // 
            this.SumCommissionTB.BackColor = System.Drawing.SystemColors.Highlight;
            this.SumCommissionTB.ForeColor = System.Drawing.SystemColors.Info;
            this.SumCommissionTB.Location = new System.Drawing.Point(57, 192);
            this.SumCommissionTB.Name = "SumCommissionTB";
            this.SumCommissionTB.Size = new System.Drawing.Size(76, 20);
            this.SumCommissionTB.TabIndex = 18;
            this.SumCommissionTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CheckoutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(371, 273);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SumToPayTB);
            this.Controls.Add(this.SumCommissionTB);
            this.Controls.Add(this.AktDatumLabel);
            this.Controls.Add(this.ListPayedBtn);
            this.Controls.Add(this.ListSoldBtn);
            this.Controls.Add(this.CashSumStartTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SumDiffLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CashDiffTB);
            this.Controls.Add(this.CashExpectedTB);
            this.Controls.Add(this.SoldSumTB);
            this.Controls.Add(this.PayedSumTB);
            this.Controls.Add(this.HeaderLbl);
            this.Controls.Add(this.CashSumTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrintBtn);
            this.Name = "CheckoutWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kassenabschluss";
            this.Load += new System.EventHandler(this.CheckoutWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CashSumTB;
        private System.Windows.Forms.Label HeaderLbl;
        private System.Windows.Forms.TextBox PayedSumTB;
        private System.Windows.Forms.TextBox SoldSumTB;
        private System.Windows.Forms.TextBox CashExpectedTB;
        private System.Windows.Forms.TextBox CashDiffTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SumDiffLabel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TextBox CashSumStartTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ListSoldBtn;
        private System.Windows.Forms.Button ListPayedBtn;
        private System.Windows.Forms.Label AktDatumLabel;
        private ConsignmentShopLibrary.TextBoxEnter SumCommissionTB;
        private ConsignmentShopLibrary.TextBoxEnter SumToPayTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}