namespace ConsignmentShopMainUI
{
    partial class RueckgabeEingabeWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VendorNameCB = new ConsignmentShopLibrary.ComboBoxEnter();
            this.AblageOrtCB = new ConsignmentShopLibrary.ComboBoxEnter();
            this.NameLbl = new System.Windows.Forms.Label();
            this.OrtLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RefundContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rückgabeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefundDataGridView = new System.Windows.Forms.DataGridView();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Input = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountIDCB = new ConsignmentShopLibrary.ComboBoxEnter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.RefundContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefundDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VendorNameCB
            // 
            this.VendorNameCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.VendorNameCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.VendorNameCB.CausesValidation = false;
            this.VendorNameCB.FormattingEnabled = true;
            this.VendorNameCB.Location = new System.Drawing.Point(26, 42);
            this.VendorNameCB.Name = "VendorNameCB";
            this.VendorNameCB.Size = new System.Drawing.Size(180, 21);
            this.VendorNameCB.TabIndex = 0;
            this.VendorNameCB.SelectedIndexChanged += new System.EventHandler(this.VendorNameCB_SelectedIndexChanged);
            this.VendorNameCB.TextChanged += new System.EventHandler(this.VendorNameCB_TextChanged);
            this.VendorNameCB.Leave += new System.EventHandler(this.VendorNameCB_Leave);
            // 
            // AblageOrtCB
            // 
            this.AblageOrtCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AblageOrtCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AblageOrtCB.FormattingEnabled = true;
            this.AblageOrtCB.Items.AddRange(new object[] {
            "MA1",
            "MB1",
            "MA2",
            "MB2",
            "MA3",
            "MB3",
            "LA1",
            "LB1",
            "LA2",
            "LB2",
            "LA3",
            "LB3",
            "XA1",
            "XB1",
            "XA2",
            "XB2",
            "XA3",
            "XB3",
            "RO1",
            "RO2",
            "RO3",
            "RO4",
            "RO5",
            "RA1",
            "RA2",
            "RA3",
            "RA4",
            "RA5",
            "RB1",
            "RB2",
            "RB3",
            "RB4",
            "RB5",
            "RC1",
            "RC2",
            "RC3",
            "RC4",
            "RC5",
            "RD1",
            "RD2",
            "RD3",
            "RD4",
            "RD5",
            "RE1",
            "RE2",
            "RE3",
            "RE4",
            "RE5"});
            this.AblageOrtCB.Location = new System.Drawing.Point(348, 42);
            this.AblageOrtCB.Name = "AblageOrtCB";
            this.AblageOrtCB.Size = new System.Drawing.Size(121, 21);
            this.AblageOrtCB.TabIndex = 2;
            this.AblageOrtCB.SelectedIndexChanged += new System.EventHandler(this.AblageOrtCB_SelectedIndexChanged);
            this.AblageOrtCB.Leave += new System.EventHandler(this.AblageOrtCB_Leave);
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(23, 26);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(48, 13);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Lieferant";
            // 
            // OrtLbl
            // 
            this.OrtLbl.AutoSize = true;
            this.OrtLbl.Location = new System.Drawing.Point(345, 25);
            this.OrtLbl.Name = "OrtLbl";
            this.OrtLbl.Size = new System.Drawing.Size(52, 13);
            this.OrtLbl.TabIndex = 0;
            this.OrtLbl.Text = "Ablageort";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(26, 241);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Abbrechen";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(379, 241);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(90, 23);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Visible = false;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ConsignmentShopMainUI.Properties.Resources.strip;
            this.pictureBox1.Location = new System.Drawing.Point(26, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(443, 10);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ConsignmentShopMainUI.Properties.Resources.strip;
            this.pictureBox2.Location = new System.Drawing.Point(26, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(443, 10);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "KdNummer";
            // 
            // RefundContextMenuStrip
            // 
            this.RefundContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rückgabeToolStripMenuItem,
            this.editToolStripMenuItem});
            this.RefundContextMenuStrip.Name = "RefundContextMenuStrip";
            this.RefundContextMenuStrip.Size = new System.Drawing.Size(127, 48);
            this.RefundContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.RefundContextMenuStrip_Opening);
            // 
            // rückgabeToolStripMenuItem
            // 
            this.rückgabeToolStripMenuItem.Name = "rückgabeToolStripMenuItem";
            this.rückgabeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rückgabeToolStripMenuItem.Text = "Rückgabe";
            this.rückgabeToolStripMenuItem.Click += new System.EventHandler(this.RückgabeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.editToolStripMenuItem.Text = "Editieren";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // RefundDataGridView
            // 
            this.RefundDataGridView.AllowUserToAddRows = false;
            this.RefundDataGridView.AllowUserToDeleteRows = false;
            this.RefundDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RefundDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RefundDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefundDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LastName,
            this.Place,
            this.Input,
            this.Output});
            this.RefundDataGridView.ContextMenuStrip = this.RefundContextMenuStrip;
            this.RefundDataGridView.Location = new System.Drawing.Point(26, 85);
            this.RefundDataGridView.Name = "RefundDataGridView";
            this.RefundDataGridView.ReadOnly = true;
            this.RefundDataGridView.RowHeadersVisible = false;
            this.RefundDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RefundDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RefundDataGridView.Size = new System.Drawing.Size(443, 150);
            this.RefundDataGridView.TabIndex = 8;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 130;
            // 
            // Place
            // 
            this.Place.HeaderText = "Ablageort";
            this.Place.Name = "Place";
            this.Place.ReadOnly = true;
            this.Place.Width = 80;
            // 
            // Input
            // 
            this.Input.HeaderText = "Eingabe Datum";
            this.Input.Name = "Input";
            this.Input.ReadOnly = true;
            this.Input.Width = 120;
            // 
            // Output
            // 
            this.Output.HeaderText = "Ausgabe Datum";
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Width = 120;
            // 
            // AccountIDCB
            // 
            this.AccountIDCB.Enabled = false;
            this.AccountIDCB.FormattingEnabled = true;
            this.AccountIDCB.Location = new System.Drawing.Point(212, 42);
            this.AccountIDCB.Name = "AccountIDCB";
            this.AccountIDCB.Size = new System.Drawing.Size(81, 21);
            this.AccountIDCB.TabIndex = 10;
            this.AccountIDCB.Visible = false;
            // 
            // RueckgabeEingabeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(495, 276);
            this.Controls.Add(this.AccountIDCB);
            this.Controls.Add(this.RefundDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OrtLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.AblageOrtCB);
            this.Controls.Add(this.VendorNameCB);
            this.Name = "RueckgabeEingabeWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rückgaben";
            this.Shown += new System.EventHandler(this.RueckgabeEingabeWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.RefundContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefundDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConsignmentShopLibrary.ComboBoxEnter VendorNameCB;
        private ConsignmentShopLibrary.ComboBoxEnter AblageOrtCB;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label OrtLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip RefundContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rückgabeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.DataGridView RefundDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn Input;
        private System.Windows.Forms.DataGridViewTextBoxColumn Output;
        private ConsignmentShopLibrary.ComboBoxEnter AccountIDCB;
    }
}