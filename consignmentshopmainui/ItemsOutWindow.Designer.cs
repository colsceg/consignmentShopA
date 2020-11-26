namespace ConsignmentShopMainUI
{
    partial class ItemsOutWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsOutWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.SalesPriceTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.InDateLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MarginTextBox = new System.Windows.Forms.TextBox();
            this.ItemsNotSoldTextBox = new System.Windows.Forms.TextBox();
            this.PhonenumberTextBox = new System.Windows.Forms.TextBox();
            this.FirstnameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LastnameTextBox = new System.Windows.Forms.TextBox();
            this.ItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.ItemDataContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SoldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotSoldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ToPaySumTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PayoutBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.VendorNameComboBox = new ConsignmentShopLibrary.ComboBoxEnter();
            this.AccountIDComboBox = new ConsignmentShopLibrary.NumComboBox();
            this.itemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soldDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
            this.ItemDataContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.SalesPriceTextBox);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.InDateLbl);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MarginTextBox);
            this.panel1.Controls.Add(this.ItemsNotSoldTextBox);
            this.panel1.Controls.Add(this.PhonenumberTextBox);
            this.panel1.Controls.Add(this.FirstnameTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LastnameTextBox);
            this.panel1.Location = new System.Drawing.Point(767, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 276);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::ConsignmentShopMainUI.Properties.Resources.strip;
            this.pictureBox4.Location = new System.Drawing.Point(24, 183);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(199, 10);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // SalesPriceTextBox
            // 
            this.SalesPriceTextBox.Location = new System.Drawing.Point(131, 227);
            this.SalesPriceTextBox.Name = "SalesPriceTextBox";
            this.SalesPriceTextBox.Size = new System.Drawing.Size(68, 20);
            this.SalesPriceTextBox.TabIndex = 3;
            this.SalesPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SalesPriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SalesPriceTextBox_KeyPress);
            this.SalesPriceTextBox.Leave += new System.EventHandler(this.SalesPriceTextBox_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::ConsignmentShopMainUI.Properties.Resources.strip;
            this.pictureBox3.Location = new System.Drawing.Point(23, 115);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(199, 10);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "eingestellt am:";
            // 
            // InDateLbl
            // 
            this.InDateLbl.AutoSize = true;
            this.InDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InDateLbl.Location = new System.Drawing.Point(21, 227);
            this.InDateLbl.Name = "InDateLbl";
            this.InDateLbl.Size = new System.Drawing.Size(47, 16);
            this.InDateLbl.TabIndex = 10;
            this.InDateLbl.Text = "Datum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Verkaufspreis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kommission";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "nicht verkauft";
            // 
            // MarginTextBox
            // 
            this.MarginTextBox.Location = new System.Drawing.Point(131, 147);
            this.MarginTextBox.Name = "MarginTextBox";
            this.MarginTextBox.ReadOnly = true;
            this.MarginTextBox.Size = new System.Drawing.Size(59, 20);
            this.MarginTextBox.TabIndex = 5;
            this.MarginTextBox.TabStop = false;
            this.MarginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemsNotSoldTextBox
            // 
            this.ItemsNotSoldTextBox.Location = new System.Drawing.Point(23, 147);
            this.ItemsNotSoldTextBox.Name = "ItemsNotSoldTextBox";
            this.ItemsNotSoldTextBox.ReadOnly = true;
            this.ItemsNotSoldTextBox.Size = new System.Drawing.Size(69, 20);
            this.ItemsNotSoldTextBox.TabIndex = 4;
            this.ItemsNotSoldTextBox.TabStop = false;
            this.ItemsNotSoldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PhonenumberTextBox
            // 
            this.PhonenumberTextBox.Location = new System.Drawing.Point(23, 84);
            this.PhonenumberTextBox.Name = "PhonenumberTextBox";
            this.PhonenumberTextBox.ReadOnly = true;
            this.PhonenumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.PhonenumberTextBox.TabIndex = 3;
            this.PhonenumberTextBox.TabStop = false;
            // 
            // FirstnameTextBox
            // 
            this.FirstnameTextBox.Location = new System.Drawing.Point(23, 58);
            this.FirstnameTextBox.Name = "FirstnameTextBox";
            this.FirstnameTextBox.ReadOnly = true;
            this.FirstnameTextBox.Size = new System.Drawing.Size(200, 20);
            this.FirstnameTextBox.TabIndex = 2;
            this.FirstnameTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lieferant";
            // 
            // LastnameTextBox
            // 
            this.LastnameTextBox.Location = new System.Drawing.Point(23, 32);
            this.LastnameTextBox.Name = "LastnameTextBox";
            this.LastnameTextBox.ReadOnly = true;
            this.LastnameTextBox.Size = new System.Drawing.Size(200, 20);
            this.LastnameTextBox.TabIndex = 0;
            this.LastnameTextBox.TabStop = false;
            // 
            // ItemsDataGridView
            // 
            this.ItemsDataGridView.AllowUserToAddRows = false;
            this.ItemsDataGridView.AllowUserToDeleteRows = false;
            this.ItemsDataGridView.AllowUserToOrderColumns = true;
            this.ItemsDataGridView.AllowUserToResizeColumns = false;
            this.ItemsDataGridView.AllowUserToResizeRows = false;
            this.ItemsDataGridView.AutoGenerateColumns = false;
            this.ItemsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ItemsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemNumber,
            this.itemDescription,
            this.brand,
            this.color,
            this.size,
            this.prop,
            this.soldDate,
            this.soldPrice,
            this.beginDate,
            this.CostPrice});
            this.ItemsDataGridView.ContextMenuStrip = this.ItemDataContextMenuStrip;
            this.ItemsDataGridView.DataSource = this.itemBindingSource;
            this.ItemsDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ItemsDataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ItemsDataGridView.Location = new System.Drawing.Point(21, 116);
            this.ItemsDataGridView.Name = "ItemsDataGridView";
            this.ItemsDataGridView.ReadOnly = true;
            this.ItemsDataGridView.RowHeadersVisible = false;
            this.ItemsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsDataGridView.ShowEditingIcon = false;
            this.ItemsDataGridView.Size = new System.Drawing.Size(725, 525);
            this.ItemsDataGridView.TabIndex = 2;
            this.ItemsDataGridView.TabStop = false;
            this.ItemsDataGridView.DataSourceChanged += new System.EventHandler(this.ItemsDataGridView_DataSourceChanged);
            this.ItemsDataGridView.SelectionChanged += new System.EventHandler(this.ItemsDataGridView_SelectionChanged);
            // 
            // ItemDataContextMenuStrip
            // 
            this.ItemDataContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SoldToolStripMenuItem,
            this.NotSoldToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.ItemDataContextMenuStrip.Name = "ItemDataContextMenuStrip";
            this.ItemDataContextMenuStrip.Size = new System.Drawing.Size(148, 70);
            this.ItemDataContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ItemDataContextMenuStrip_Opening);
            // 
            // SoldToolStripMenuItem
            // 
            this.SoldToolStripMenuItem.Name = "SoldToolStripMenuItem";
            this.SoldToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.SoldToolStripMenuItem.Text = "verkauft";
            this.SoldToolStripMenuItem.Click += new System.EventHandler(this.SoldToolStripMenuItem_Click);
            // 
            // NotSoldToolStripMenuItem
            // 
            this.NotSoldToolStripMenuItem.Name = "NotSoldToolStripMenuItem";
            this.NotSoldToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.NotSoldToolStripMenuItem.Text = "nicht verkauft";
            this.NotSoldToolStripMenuItem.Click += new System.EventHandler(this.NotSoldToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.DeleteToolStripMenuItem.Text = "löschen";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(ConsignmentShopLibrary.Item);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ConsignmentShopMainUI.Properties.Resources.strip;
            this.pictureBox1.Location = new System.Drawing.Point(21, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 10);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ConsignmentShopMainUI.Properties.Resources.strip;
            this.pictureBox2.Location = new System.Drawing.Point(21, 98);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(725, 10);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Lieferant";
            // 
            // ToPaySumTextBox
            // 
            this.ToPaySumTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToPaySumTextBox.Location = new System.Drawing.Point(817, 355);
            this.ToPaySumTextBox.Name = "ToPaySumTextBox";
            this.ToPaySumTextBox.ReadOnly = true;
            this.ToPaySumTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ToPaySumTextBox.Size = new System.Drawing.Size(108, 20);
            this.ToPaySumTextBox.TabIndex = 13;
            this.ToPaySumTextBox.TabStop = false;
            this.ToPaySumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToPaySumTextBox.TextChanged += new System.EventHandler(this.ToPaySumTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(816, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "noch auszuzahlen";
            // 
            // PayoutBtn
            // 
            this.PayoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayoutBtn.Location = new System.Drawing.Point(791, 390);
            this.PayoutBtn.Name = "PayoutBtn";
            this.PayoutBtn.Size = new System.Drawing.Size(164, 45);
            this.PayoutBtn.TabIndex = 15;
            this.PayoutBtn.Text = "Betrag auszahlen";
            this.PayoutBtn.UseVisualStyleBackColor = true;
            this.PayoutBtn.Click += new System.EventHandler(this.PayoutBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Kundennummer";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(916, 618);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 18;
            this.CloseBtn.Text = "Schliessen";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // VendorNameComboBox
            // 
            this.VendorNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.VendorNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.VendorNameComboBox.FormattingEnabled = true;
            this.VendorNameComboBox.Location = new System.Drawing.Point(21, 62);
            this.VendorNameComboBox.Name = "VendorNameComboBox";
            this.VendorNameComboBox.Size = new System.Drawing.Size(158, 21);
            this.VendorNameComboBox.TabIndex = 1;
            this.VendorNameComboBox.SelectedIndexChanged += new System.EventHandler(this.VendorNameComboBox_SelectedIndexChanged);
            this.VendorNameComboBox.Leave += new System.EventHandler(this.VendorNameComboBox_Leave);
            // 
            // AccountIDComboBox
            // 
            this.AccountIDComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AccountIDComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AccountIDComboBox.FormattingEnabled = true;
            this.AccountIDComboBox.Location = new System.Drawing.Point(185, 62);
            this.AccountIDComboBox.Name = "AccountIDComboBox";
            this.AccountIDComboBox.Size = new System.Drawing.Size(66, 21);
            this.AccountIDComboBox.TabIndex = 19;
            this.AccountIDComboBox.SelectedIndexChanged += new System.EventHandler(this.AccountIDComboBox_SelectedIndexChanged);
            this.AccountIDComboBox.Leave += new System.EventHandler(this.AccountIDComboBox_Leave);
            // 
            // itemNumber
            // 
            this.itemNumber.DataPropertyName = "ItemNumber";
            this.itemNumber.HeaderText = "ArtNr";
            this.itemNumber.Name = "itemNumber";
            this.itemNumber.ReadOnly = true;
            this.itemNumber.Width = 50;
            // 
            // itemDescription
            // 
            this.itemDescription.DataPropertyName = "ItemDescription";
            this.itemDescription.HeaderText = "Beschreibung";
            this.itemDescription.Name = "itemDescription";
            this.itemDescription.ReadOnly = true;
            this.itemDescription.Width = 130;
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "Marke";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            this.brand.Width = 120;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Farbe";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Width = 90;
            // 
            // size
            // 
            this.size.DataPropertyName = "size";
            this.size.HeaderText = "Grösse";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 60;
            // 
            // prop
            // 
            this.prop.DataPropertyName = "Prop";
            this.prop.HeaderText = "Sonstiges";
            this.prop.Name = "prop";
            this.prop.ReadOnly = true;
            this.prop.Width = 95;
            // 
            // soldDate
            // 
            this.soldDate.DataPropertyName = "SoldDate";
            this.soldDate.HeaderText = "verkauft";
            this.soldDate.Name = "soldDate";
            this.soldDate.ReadOnly = true;
            this.soldDate.Width = 80;
            // 
            // soldPrice
            // 
            this.soldPrice.DataPropertyName = "SalesPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.soldPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.soldPrice.HeaderText = "Preis";
            this.soldPrice.Name = "soldPrice";
            this.soldPrice.ReadOnly = true;
            // 
            // beginDate
            // 
            this.beginDate.DataPropertyName = "BeginDate";
            this.beginDate.HeaderText = "BeginDate";
            this.beginDate.Name = "beginDate";
            this.beginDate.ReadOnly = true;
            // 
            // CostPrice
            // 
            this.CostPrice.DataPropertyName = "CostPrice";
            this.CostPrice.HeaderText = "CostPrice";
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.ReadOnly = true;
            this.CostPrice.Width = 80;
            // 
            // ItemsOutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 650);
            this.Controls.Add(this.AccountIDComboBox);
            this.Controls.Add(this.VendorNameComboBox);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PayoutBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ToPaySumTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ItemsDataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemsOutWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warenausgang";
            this.Shown += new System.EventHandler(this.ItemsOutWindow_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
            this.ItemDataContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label InDateLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MarginTextBox;
        private System.Windows.Forms.TextBox ItemsNotSoldTextBox;
        private System.Windows.Forms.TextBox PhonenumberTextBox;
        private System.Windows.Forms.TextBox FirstnameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LastnameTextBox;
        private System.Windows.Forms.DataGridView ItemsDataGridView;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox ToPaySumTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button PayoutBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.ContextMenuStrip ItemDataContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SoldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NotSoldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.Button CloseBtn;
        private ConsignmentShopLibrary.ComboBoxEnter VendorNameComboBox;
        private ConsignmentShopLibrary.TextBoxEnter SalesPriceTextBox;
        private ConsignmentShopLibrary.NumComboBox AccountIDComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn prop;
        private System.Windows.Forms.DataGridViewTextBoxColumn soldDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn soldPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostPrice;
    }
}