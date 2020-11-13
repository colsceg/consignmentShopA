namespace ConsignmentShopMainUI
{
    partial class ReportUI
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
            this.ReportItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblKdNr = new System.Windows.Forms.Label();
            this.lblArtNr = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.CBPeriod = new System.Windows.Forms.ComboBox();
            this.CBStatus = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.BtnDeletedItems = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.SalesVolumePrintBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ItemsFoundTB = new System.Windows.Forms.TextBox();
            this.SumComissionTB = new System.Windows.Forms.TextBox();
            this.SumSalesVolumeTB = new System.Windows.Forms.TextBox();
            this.SumPayedTB = new System.Windows.Forms.TextBox();
            this.SumToPayTB = new System.Windows.Forms.TextBox();
            this.SoldItemsTB = new System.Windows.Forms.TextBox();
            this.CurrentItemsTB = new System.Windows.Forms.TextBox();
            this.ItemsFoundLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SumSalesVolumeLbl = new System.Windows.Forms.Label();
            this.SumComissionLbl = new System.Windows.Forms.Label();
            this.SumPayedLbl = new System.Windows.Forms.Label();
            this.SumToPayLbl = new System.Windows.Forms.Label();
            this.SoldItemsLbl = new System.Windows.Forms.Label();
            this.CurrentItemsLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CBSize = new ConsignmentShopLibrary.ComboBoxEnter();
            this.CBColor = new ConsignmentShopLibrary.ComboBoxEnter();
            this.CBAccountID = new ConsignmentShopLibrary.ComboBoxEnter();
            this.CBBrand = new ConsignmentShopLibrary.ComboBoxEnter();
            this.CBItemNumber = new ConsignmentShopLibrary.ComboBoxEnter();
            this.CBItemDescription = new ConsignmentShopLibrary.ComboBoxEnter();
            this.lblDatum = new System.Windows.Forms.Label();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soldDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payoutDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ReportItemsDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportItemsDataGridView
            // 
            this.ReportItemsDataGridView.AllowUserToAddRows = false;
            this.ReportItemsDataGridView.AllowUserToDeleteRows = false;
            this.ReportItemsDataGridView.AllowUserToOrderColumns = true;
            this.ReportItemsDataGridView.AllowUserToResizeRows = false;
            this.ReportItemsDataGridView.AutoGenerateColumns = false;
            this.ReportItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ReportItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportItemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountID,
            this.itemNumberDataGridViewTextBoxColumn,
            this.itemDescriptionDataGridViewTextBoxColumn,
            this.brandDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.propDataGridViewTextBoxColumn,
            this.salesPriceDataGridViewTextBoxColumn,
            this.costPriceDataGridViewTextBoxColumn,
            this.beginDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.soldDateDataGridViewTextBoxColumn,
            this.payoutDateDataGridViewTextBoxColumn});
            this.ReportItemsDataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.ReportItemsDataGridView.DataSource = this.itemBindingSource;
            this.ReportItemsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ReportItemsDataGridView.Location = new System.Drawing.Point(4, 84);
            this.ReportItemsDataGridView.Name = "ReportItemsDataGridView";
            this.ReportItemsDataGridView.ReadOnly = true;
            this.ReportItemsDataGridView.RowHeadersVisible = false;
            this.ReportItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReportItemsDataGridView.Size = new System.Drawing.Size(996, 459);
            this.ReportItemsDataGridView.TabIndex = 0;
            this.ReportItemsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReportItemsDataGridView_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.UndeleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            this.bearbeitenToolStripMenuItem.Click += new System.EventHandler(this.BearbeitenToolStripMenuItem_Click);
            // 
            // UndeleteToolStripMenuItem
            // 
            this.UndeleteToolStripMenuItem.Name = "UndeleteToolStripMenuItem";
            this.UndeleteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.UndeleteToolStripMenuItem.Text = "Undelete";
            this.UndeleteToolStripMenuItem.Visible = false;
            this.UndeleteToolStripMenuItem.Click += new System.EventHandler(this.UndeleteToolStripMenuItem_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
            this.btnClear.TabIndex = 99;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Filter löschen";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // lblKdNr
            // 
            this.lblKdNr.AutoSize = true;
            this.lblKdNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblKdNr.Location = new System.Drawing.Point(10, 41);
            this.lblKdNr.Name = "lblKdNr";
            this.lblKdNr.Size = new System.Drawing.Size(31, 13);
            this.lblKdNr.TabIndex = 10;
            this.lblKdNr.Text = "KdNr";
            // 
            // lblArtNr
            // 
            this.lblArtNr.AutoSize = true;
            this.lblArtNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblArtNr.Location = new System.Drawing.Point(87, 8);
            this.lblArtNr.Name = "lblArtNr";
            this.lblArtNr.Size = new System.Drawing.Size(31, 13);
            this.lblArtNr.TabIndex = 11;
            this.lblArtNr.Text = "ArtNr";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblItemDescription.Location = new System.Drawing.Point(170, 8);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(100, 13);
            this.lblItemDescription.TabIndex = 12;
            this.lblItemDescription.Text = "Artikelbeschreibung";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblBrand.Location = new System.Drawing.Point(284, 8);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(37, 13);
            this.lblBrand.TabIndex = 13;
            this.lblBrand.Text = "Marke";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblColor.Location = new System.Drawing.Point(382, 8);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 14;
            this.lblColor.Text = "Farbe";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblSize.Location = new System.Drawing.Point(480, 8);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(40, 13);
            this.lblSize.TabIndex = 15;
            this.lblSize.Text = "Grösse";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(692, 58);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(94, 20);
            this.dtTo.TabIndex = 7;
            this.dtTo.ValueChanged += new System.EventHandler(this.DtTo_ValueChanged);
            this.dtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtTo_KeyDown);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(692, 35);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(94, 20);
            this.dtFrom.TabIndex = 6;
            this.dtFrom.ValueChanged += new System.EventHandler(this.DtFrom_ValueChanged);
            this.dtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtFrom_KeyDown);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblDateFrom.Location = new System.Drawing.Point(632, 41);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(59, 13);
            this.lblDateFrom.TabIndex = 19;
            this.lblDateFrom.Text = "Datum von";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblDateTo.Location = new System.Drawing.Point(632, 60);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(54, 13);
            this.lblDateTo.TabIndex = 20;
            this.lblDateTo.Text = "Datum bis";
            // 
            // CBPeriod
            // 
            this.CBPeriod.FormattingEnabled = true;
            this.CBPeriod.Items.AddRange(new object[] {
            "Gesamt",
            "Heute",
            "Monat",
            "Quartal",
            "Jahr",
            "Benutzerdefiniert"});
            this.CBPeriod.Location = new System.Drawing.Point(792, 57);
            this.CBPeriod.Name = "CBPeriod";
            this.CBPeriod.Size = new System.Drawing.Size(107, 21);
            this.CBPeriod.TabIndex = 21;
            this.CBPeriod.TabStop = false;
            this.CBPeriod.SelectedIndexChanged += new System.EventHandler(this.CBPeriod_SelectedIndexChanged);
            // 
            // CBStatus
            // 
            this.CBStatus.FormattingEnabled = true;
            this.CBStatus.Items.AddRange(new object[] {
            "alle",
            "im Laden",
            "verkauft",
            "ausbezahlt"});
            this.CBStatus.Location = new System.Drawing.Point(905, 57);
            this.CBStatus.Name = "CBStatus";
            this.CBStatus.Size = new System.Drawing.Size(95, 21);
            this.CBStatus.TabIndex = 22;
            this.CBStatus.TabStop = false;
            this.CBStatus.SelectedIndexChanged += new System.EventHandler(this.CBStatus_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(438, 11);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(112, 16);
            this.lblFilter.TabIndex = 23;
            this.lblFilter.Text = "Aktuelle Artikel";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblStatus.Location = new System.Drawing.Point(908, 41);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Artikelstatus";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblPeriod.Location = new System.Drawing.Point(795, 41);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(48, 13);
            this.lblPeriod.TabIndex = 25;
            this.lblPeriod.Text = "Zeitraum";
            // 
            // BtnDeletedItems
            // 
            this.BtnDeletedItems.Location = new System.Drawing.Point(851, 4);
            this.BtnDeletedItems.Name = "BtnDeletedItems";
            this.BtnDeletedItems.Size = new System.Drawing.Size(149, 23);
            this.BtnDeletedItems.TabIndex = 99;
            this.BtnDeletedItems.TabStop = false;
            this.BtnDeletedItems.Text = "gelöschte Artikel anzeigen";
            this.BtnDeletedItems.UseVisualStyleBackColor = true;
            this.BtnDeletedItems.Click += new System.EventHandler(this.BtnDeletedItems_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(2, 618);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(113, 23);
            this.ExportBtn.TabIndex = 0;
            this.ExportBtn.Text = "Exportieren (*.csv)";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // SalesVolumePrintBtn
            // 
            this.SalesVolumePrintBtn.Location = new System.Drawing.Point(121, 618);
            this.SalesVolumePrintBtn.Name = "SalesVolumePrintBtn";
            this.SalesVolumePrintBtn.Size = new System.Drawing.Size(110, 23);
            this.SalesVolumePrintBtn.TabIndex = 101;
            this.SalesVolumePrintBtn.Text = "Umsatzliste drucken";
            this.SalesVolumePrintBtn.UseVisualStyleBackColor = true;
            this.SalesVolumePrintBtn.Click += new System.EventHandler(this.SalesVolumePrintBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(923, 618);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 102;
            this.CancelBtn.Text = "Schliessen";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ItemsFoundTB
            // 
            this.ItemsFoundTB.Location = new System.Drawing.Point(4, 34);
            this.ItemsFoundTB.Name = "ItemsFoundTB";
            this.ItemsFoundTB.Size = new System.Drawing.Size(74, 20);
            this.ItemsFoundTB.TabIndex = 0;
            this.ItemsFoundTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SumComissionTB
            // 
            this.SumComissionTB.Location = new System.Drawing.Point(920, 8);
            this.SumComissionTB.Name = "SumComissionTB";
            this.SumComissionTB.Size = new System.Drawing.Size(74, 20);
            this.SumComissionTB.TabIndex = 1;
            this.SumComissionTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SumSalesVolumeTB
            // 
            this.SumSalesVolumeTB.Location = new System.Drawing.Point(920, 34);
            this.SumSalesVolumeTB.Name = "SumSalesVolumeTB";
            this.SumSalesVolumeTB.Size = new System.Drawing.Size(74, 20);
            this.SumSalesVolumeTB.TabIndex = 2;
            this.SumSalesVolumeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SumPayedTB
            // 
            this.SumPayedTB.Location = new System.Drawing.Point(774, 8);
            this.SumPayedTB.Name = "SumPayedTB";
            this.SumPayedTB.Size = new System.Drawing.Size(74, 20);
            this.SumPayedTB.TabIndex = 3;
            this.SumPayedTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SumToPayTB
            // 
            this.SumToPayTB.Location = new System.Drawing.Point(774, 34);
            this.SumToPayTB.Name = "SumToPayTB";
            this.SumToPayTB.Size = new System.Drawing.Size(74, 20);
            this.SumToPayTB.TabIndex = 4;
            this.SumToPayTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SoldItemsTB
            // 
            this.SoldItemsTB.Location = new System.Drawing.Point(590, 8);
            this.SoldItemsTB.Name = "SoldItemsTB";
            this.SoldItemsTB.Size = new System.Drawing.Size(74, 20);
            this.SoldItemsTB.TabIndex = 5;
            this.SoldItemsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CurrentItemsTB
            // 
            this.CurrentItemsTB.Location = new System.Drawing.Point(591, 34);
            this.CurrentItemsTB.Name = "CurrentItemsTB";
            this.CurrentItemsTB.Size = new System.Drawing.Size(74, 20);
            this.CurrentItemsTB.TabIndex = 6;
            this.CurrentItemsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemsFoundLbl
            // 
            this.ItemsFoundLbl.AutoSize = true;
            this.ItemsFoundLbl.Location = new System.Drawing.Point(4, 18);
            this.ItemsFoundLbl.Name = "ItemsFoundLbl";
            this.ItemsFoundLbl.Size = new System.Drawing.Size(84, 13);
            this.ItemsFoundLbl.TabIndex = 7;
            this.ItemsFoundLbl.Text = "Artikel gefunden";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.SumSalesVolumeLbl);
            this.panel1.Controls.Add(this.SumComissionLbl);
            this.panel1.Controls.Add(this.SumPayedLbl);
            this.panel1.Controls.Add(this.SumToPayLbl);
            this.panel1.Controls.Add(this.SoldItemsLbl);
            this.panel1.Controls.Add(this.CurrentItemsLbl);
            this.panel1.Controls.Add(this.ItemsFoundLbl);
            this.panel1.Controls.Add(this.CurrentItemsTB);
            this.panel1.Controls.Add(this.SoldItemsTB);
            this.panel1.Controls.Add(this.SumToPayTB);
            this.panel1.Controls.Add(this.SumPayedTB);
            this.panel1.Controls.Add(this.SumSalesVolumeTB);
            this.panel1.Controls.Add(this.SumComissionTB);
            this.panel1.Controls.Add(this.ItemsFoundTB);
            this.panel1.Location = new System.Drawing.Point(4, 549);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 61);
            this.panel1.TabIndex = 100;
            // 
            // SumSalesVolumeLbl
            // 
            this.SumSalesVolumeLbl.AutoSize = true;
            this.SumSalesVolumeLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.SumSalesVolumeLbl.Location = new System.Drawing.Point(854, 41);
            this.SumSalesVolumeLbl.Name = "SumSalesVolumeLbl";
            this.SumSalesVolumeLbl.Size = new System.Drawing.Size(42, 13);
            this.SumSalesVolumeLbl.TabIndex = 32;
            this.SumSalesVolumeLbl.Text = "Umsatz";
            // 
            // SumComissionLbl
            // 
            this.SumComissionLbl.AutoSize = true;
            this.SumComissionLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.SumComissionLbl.Location = new System.Drawing.Point(854, 13);
            this.SumComissionLbl.Name = "SumComissionLbl";
            this.SumComissionLbl.Size = new System.Drawing.Size(62, 13);
            this.SumComissionLbl.TabIndex = 31;
            this.SumComissionLbl.Text = "Kommission";
            // 
            // SumPayedLbl
            // 
            this.SumPayedLbl.AutoSize = true;
            this.SumPayedLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.SumPayedLbl.Location = new System.Drawing.Point(671, 13);
            this.SumPayedLbl.Name = "SumPayedLbl";
            this.SumPayedLbl.Size = new System.Drawing.Size(96, 13);
            this.SumPayedLbl.TabIndex = 30;
            this.SumPayedLbl.Text = "Summe ausbezahlt";
            // 
            // SumToPayLbl
            // 
            this.SumToPayLbl.AutoSize = true;
            this.SumToPayLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.SumToPayLbl.Location = new System.Drawing.Point(671, 41);
            this.SumToPayLbl.Name = "SumToPayLbl";
            this.SumToPayLbl.Size = new System.Drawing.Size(90, 13);
            this.SumToPayLbl.TabIndex = 29;
            this.SumToPayLbl.Text = "Summe zu zahlen";
            // 
            // SoldItemsLbl
            // 
            this.SoldItemsLbl.AutoSize = true;
            this.SoldItemsLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.SoldItemsLbl.Location = new System.Drawing.Point(499, 13);
            this.SoldItemsLbl.Name = "SoldItemsLbl";
            this.SoldItemsLbl.Size = new System.Drawing.Size(78, 13);
            this.SoldItemsLbl.TabIndex = 28;
            this.SoldItemsLbl.Text = "Artikel verkauft";
            // 
            // CurrentItemsLbl
            // 
            this.CurrentItemsLbl.AutoSize = true;
            this.CurrentItemsLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.CurrentItemsLbl.Location = new System.Drawing.Point(499, 41);
            this.CurrentItemsLbl.Name = "CurrentItemsLbl";
            this.CurrentItemsLbl.Size = new System.Drawing.Size(82, 13);
            this.CurrentItemsLbl.TabIndex = 27;
            this.CurrentItemsLbl.Text = "Artikel im Laden";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.CBSize);
            this.panel2.Controls.Add(this.CBColor);
            this.panel2.Controls.Add(this.CBAccountID);
            this.panel2.Controls.Add(this.CBBrand);
            this.panel2.Controls.Add(this.CBItemNumber);
            this.panel2.Controls.Add(this.CBItemDescription);
            this.panel2.Controls.Add(this.lblArtNr);
            this.panel2.Controls.Add(this.lblItemDescription);
            this.panel2.Controls.Add(this.lblBrand);
            this.panel2.Controls.Add(this.lblColor);
            this.panel2.Controls.Add(this.lblSize);
            this.panel2.Location = new System.Drawing.Point(4, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 45);
            this.panel2.TabIndex = 103;
            // 
            // CBSize
            // 
            this.CBSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBSize.FormattingEnabled = true;
            this.CBSize.Location = new System.Drawing.Point(477, 23);
            this.CBSize.Name = "CBSize";
            this.CBSize.Size = new System.Drawing.Size(69, 21);
            this.CBSize.TabIndex = 108;
            this.CBSize.SelectedIndexChanged += new System.EventHandler(this.CBSize_SelectedIndexChanged);
            this.CBSize.Leave += new System.EventHandler(this.CBSize_Leave);
            // 
            // CBColor
            // 
            this.CBColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBColor.FormattingEnabled = true;
            this.CBColor.Location = new System.Drawing.Point(379, 23);
            this.CBColor.Name = "CBColor";
            this.CBColor.Size = new System.Drawing.Size(92, 21);
            this.CBColor.TabIndex = 107;
            this.CBColor.SelectedIndexChanged += new System.EventHandler(this.CBColor_SelectedIndexChanged);
            this.CBColor.Leave += new System.EventHandler(this.CBColor_Leave);
            // 
            // CBAccountID
            // 
            this.CBAccountID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBAccountID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBAccountID.FormattingEnabled = true;
            this.CBAccountID.Location = new System.Drawing.Point(3, 23);
            this.CBAccountID.Name = "CBAccountID";
            this.CBAccountID.Size = new System.Drawing.Size(74, 21);
            this.CBAccountID.TabIndex = 0;
            this.CBAccountID.SelectedIndexChanged += new System.EventHandler(this.CBAccountID_SelectedIndexChanged);
            this.CBAccountID.Leave += new System.EventHandler(this.CBAccountID_Leave);
            // 
            // CBBrand
            // 
            this.CBBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBBrand.FormattingEnabled = true;
            this.CBBrand.Location = new System.Drawing.Point(281, 23);
            this.CBBrand.Name = "CBBrand";
            this.CBBrand.Size = new System.Drawing.Size(92, 21);
            this.CBBrand.TabIndex = 106;
            this.CBBrand.SelectedIndexChanged += new System.EventHandler(this.CBBrand_SelectedIndexChanged);
            this.CBBrand.Leave += new System.EventHandler(this.CBBrand_Leave);
            // 
            // CBItemNumber
            // 
            this.CBItemNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBItemNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBItemNumber.FormattingEnabled = true;
            this.CBItemNumber.Location = new System.Drawing.Point(83, 23);
            this.CBItemNumber.Name = "CBItemNumber";
            this.CBItemNumber.Size = new System.Drawing.Size(78, 21);
            this.CBItemNumber.TabIndex = 104;
            this.CBItemNumber.SelectedIndexChanged += new System.EventHandler(this.CBItemNumber_SelectedIndexChanged);
            this.CBItemNumber.Leave += new System.EventHandler(this.CBItemNumber_Leave);
            // 
            // CBItemDescription
            // 
            this.CBItemDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBItemDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBItemDescription.FormattingEnabled = true;
            this.CBItemDescription.Location = new System.Drawing.Point(167, 23);
            this.CBItemDescription.Name = "CBItemDescription";
            this.CBItemDescription.Size = new System.Drawing.Size(111, 21);
            this.CBItemDescription.TabIndex = 105;
            this.CBItemDescription.SelectedIndexChanged += new System.EventHandler(this.CBItemDescription_SelectedIndexChanged);
            this.CBItemDescription.Leave += new System.EventHandler(this.CBItemDescription_Leave);
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(702, 14);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(81, 13);
            this.lblDatum.TabIndex = 33;
            this.lblDatum.Text = "Annahmedatum";
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(ConsignmentShopLibrary.Item);
            // 
            // accountID
            // 
            this.accountID.DataPropertyName = "AccountID";
            this.accountID.HeaderText = "KdNr";
            this.accountID.Name = "accountID";
            this.accountID.ReadOnly = true;
            this.accountID.Width = 56;
            // 
            // itemNumberDataGridViewTextBoxColumn
            // 
            this.itemNumberDataGridViewTextBoxColumn.DataPropertyName = "ItemNumber";
            this.itemNumberDataGridViewTextBoxColumn.HeaderText = "ArtNr";
            this.itemNumberDataGridViewTextBoxColumn.Name = "itemNumberDataGridViewTextBoxColumn";
            this.itemNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNumberDataGridViewTextBoxColumn.Width = 56;
            // 
            // itemDescriptionDataGridViewTextBoxColumn
            // 
            this.itemDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ItemDescription";
            this.itemDescriptionDataGridViewTextBoxColumn.HeaderText = "Artikel";
            this.itemDescriptionDataGridViewTextBoxColumn.MinimumWidth = 80;
            this.itemDescriptionDataGridViewTextBoxColumn.Name = "itemDescriptionDataGridViewTextBoxColumn";
            this.itemDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDescriptionDataGridViewTextBoxColumn.Width = 80;
            // 
            // brandDataGridViewTextBoxColumn
            // 
            this.brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
            this.brandDataGridViewTextBoxColumn.HeaderText = "Marke";
            this.brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
            this.brandDataGridViewTextBoxColumn.ReadOnly = true;
            this.brandDataGridViewTextBoxColumn.Width = 62;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Farbe";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            this.colorDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorDataGridViewTextBoxColumn.Width = 59;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Gr.";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeDataGridViewTextBoxColumn.Width = 46;
            // 
            // propDataGridViewTextBoxColumn
            // 
            this.propDataGridViewTextBoxColumn.DataPropertyName = "Prop";
            this.propDataGridViewTextBoxColumn.HeaderText = "Sonst.";
            this.propDataGridViewTextBoxColumn.Name = "propDataGridViewTextBoxColumn";
            this.propDataGridViewTextBoxColumn.ReadOnly = true;
            this.propDataGridViewTextBoxColumn.Width = 62;
            // 
            // salesPriceDataGridViewTextBoxColumn
            // 
            this.salesPriceDataGridViewTextBoxColumn.DataPropertyName = "SalesPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.salesPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.salesPriceDataGridViewTextBoxColumn.HeaderText = "VK-Preis";
            this.salesPriceDataGridViewTextBoxColumn.Name = "salesPriceDataGridViewTextBoxColumn";
            this.salesPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesPriceDataGridViewTextBoxColumn.Width = 72;
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.costPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.costPriceDataGridViewTextBoxColumn.HeaderText = "Auszahl.";
            this.costPriceDataGridViewTextBoxColumn.Name = "costPriceDataGridViewTextBoxColumn";
            this.costPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.costPriceDataGridViewTextBoxColumn.Width = 72;
            // 
            // beginDateDataGridViewTextBoxColumn
            // 
            this.beginDateDataGridViewTextBoxColumn.DataPropertyName = "BeginDate";
            this.beginDateDataGridViewTextBoxColumn.HeaderText = "Annahme";
            this.beginDateDataGridViewTextBoxColumn.Name = "beginDateDataGridViewTextBoxColumn";
            this.beginDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.beginDateDataGridViewTextBoxColumn.Width = 77;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Ablauf";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.endDateDataGridViewTextBoxColumn.Width = 62;
            // 
            // soldDateDataGridViewTextBoxColumn
            // 
            this.soldDateDataGridViewTextBoxColumn.DataPropertyName = "SoldDate";
            this.soldDateDataGridViewTextBoxColumn.HeaderText = "verk.";
            this.soldDateDataGridViewTextBoxColumn.Name = "soldDateDataGridViewTextBoxColumn";
            this.soldDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.soldDateDataGridViewTextBoxColumn.Width = 56;
            // 
            // payoutDateDataGridViewTextBoxColumn
            // 
            this.payoutDateDataGridViewTextBoxColumn.DataPropertyName = "PayoutDate";
            this.payoutDateDataGridViewTextBoxColumn.HeaderText = "ausgez.";
            this.payoutDateDataGridViewTextBoxColumn.Name = "payoutDateDataGridViewTextBoxColumn";
            this.payoutDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.payoutDateDataGridViewTextBoxColumn.Width = 69;
            // 
            // ReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 650);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SalesVolumePrintBtn);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnDeletedItems);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.CBStatus);
            this.Controls.Add(this.CBPeriod);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.lblKdNr);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.ReportItemsDataGridView);
            this.Controls.Add(this.panel2);
            this.Name = "ReportUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auswertung";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportItemsDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReportItemsDataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblKdNr;
        private System.Windows.Forms.Label lblArtNr;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.ComboBox CBPeriod;
        private System.Windows.Forms.ComboBox CBStatus;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Button BtnDeletedItems;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button SalesVolumePrintBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox ItemsFoundTB;
        private System.Windows.Forms.TextBox SumComissionTB;
        private System.Windows.Forms.TextBox SumSalesVolumeTB;
        private System.Windows.Forms.TextBox SumPayedTB;
        private System.Windows.Forms.TextBox SumToPayTB;
        private System.Windows.Forms.TextBox SoldItemsTB;
        private System.Windows.Forms.TextBox CurrentItemsTB;
        private System.Windows.Forms.Label ItemsFoundLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SumSalesVolumeLbl;
        private System.Windows.Forms.Label SumComissionLbl;
        private System.Windows.Forms.Label SumPayedLbl;
        private System.Windows.Forms.Label SumToPayLbl;
        private System.Windows.Forms.Label SoldItemsLbl;
        private System.Windows.Forms.Label CurrentItemsLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private ConsignmentShopLibrary.ComboBoxEnter CBAccountID;
        private ConsignmentShopLibrary.ComboBoxEnter CBBrand;
        private ConsignmentShopLibrary.ComboBoxEnter CBColor;
        private ConsignmentShopLibrary.ComboBoxEnter CBSize;
        private ConsignmentShopLibrary.ComboBoxEnter CBItemNumber;
        private ConsignmentShopLibrary.ComboBoxEnter CBItemDescription;
        private System.Windows.Forms.ToolStripMenuItem UndeleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soldDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn payoutDateDataGridViewTextBoxColumn;
    }
}