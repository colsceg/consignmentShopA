namespace ConsignmentShopMainUI
{
    partial class ContractUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.contractIDDataGridViewTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.lblKdNr = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.SalesVolumePrintBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ItemsFoundTB = new System.Windows.Forms.TextBox();
            this.ItemsFoundLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CBAccountID = new ConsignmentShopLibrary.ComboBoxEnter();
            this.CBContractID = new ConsignmentShopLibrary.ComboBoxEnter();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.CBPeriod = new System.Windows.Forms.ComboBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReportItemsDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.contractIDDataGridViewTextBox,
            this.accountID,
            this.itemNumberDataGridViewTextBoxColumn,
            this.itemDescriptionDataGridViewTextBoxColumn,
            this.brandDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.propDataGridViewTextBoxColumn,
            this.salesPriceDataGridViewTextBoxColumn,
            this.beginDateDataGridViewTextBoxColumn});
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
            // contractIDDataGridViewTextBox
            // 
            this.contractIDDataGridViewTextBox.DataPropertyName = "ContractID";
            this.contractIDDataGridViewTextBox.HeaderText = "VertrNr";
            this.contractIDDataGridViewTextBox.Name = "contractIDDataGridViewTextBox";
            this.contractIDDataGridViewTextBox.ReadOnly = true;
            this.contractIDDataGridViewTextBox.Width = 65;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.salesPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.salesPriceDataGridViewTextBoxColumn.HeaderText = "VK-Preis";
            this.salesPriceDataGridViewTextBoxColumn.Name = "salesPriceDataGridViewTextBoxColumn";
            this.salesPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesPriceDataGridViewTextBoxColumn.Width = 72;
            // 
            // beginDateDataGridViewTextBoxColumn
            // 
            this.beginDateDataGridViewTextBoxColumn.DataPropertyName = "BeginDate";
            this.beginDateDataGridViewTextBoxColumn.HeaderText = "Annahme";
            this.beginDateDataGridViewTextBoxColumn.Name = "beginDateDataGridViewTextBoxColumn";
            this.beginDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.beginDateDataGridViewTextBoxColumn.Width = 77;
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
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(ConsignmentShopLibrary.Item);
            this.itemBindingSource.CurrentChanged += new System.EventHandler(this.itemBindingSource_CurrentChanged);
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
            this.lblKdNr.Location = new System.Drawing.Point(101, 3);
            this.lblKdNr.Name = "lblKdNr";
            this.lblKdNr.Size = new System.Drawing.Size(31, 13);
            this.lblKdNr.TabIndex = 10;
            this.lblKdNr.Text = "KdNr";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblItemDescription.Location = new System.Drawing.Point(11, 4);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(57, 13);
            this.lblItemDescription.TabIndex = 12;
            this.lblItemDescription.Text = "VertragsNr";
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
            this.panel1.Controls.Add(this.ItemsFoundLbl);
            this.panel1.Controls.Add(this.ItemsFoundTB);
            this.panel1.Location = new System.Drawing.Point(4, 549);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 61);
            this.panel1.TabIndex = 100;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.CBAccountID);
            this.panel2.Controls.Add(this.CBContractID);
            this.panel2.Controls.Add(this.lblItemDescription);
            this.panel2.Controls.Add(this.lblKdNr);
            this.panel2.Controls.Add(this.dtTo);
            this.panel2.Controls.Add(this.lblPeriod);
            this.panel2.Controls.Add(this.dtFrom);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.lblDateFrom);
            this.panel2.Controls.Add(this.lblDateTo);
            this.panel2.Controls.Add(this.CBPeriod);
            this.panel2.Location = new System.Drawing.Point(4, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 45);
            this.panel2.TabIndex = 103;
            // 
            // CBAccountID
            // 
            this.CBAccountID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBAccountID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBAccountID.FormattingEnabled = true;
            this.CBAccountID.Location = new System.Drawing.Point(104, 19);
            this.CBAccountID.Name = "CBAccountID";
            this.CBAccountID.Size = new System.Drawing.Size(74, 21);
            this.CBAccountID.TabIndex = 0;
            this.CBAccountID.SelectedIndexChanged += new System.EventHandler(this.CBAccountID_SelectedIndexChanged);
            this.CBAccountID.Leave += new System.EventHandler(this.CBAccountID_Leave);
            // 
            // CBContractID
            // 
            this.CBContractID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBContractID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBContractID.FormattingEnabled = true;
            this.CBContractID.Location = new System.Drawing.Point(8, 19);
            this.CBContractID.Name = "CBContractID";
            this.CBContractID.Size = new System.Drawing.Size(90, 21);
            this.CBContractID.TabIndex = 105;
            this.CBContractID.SelectedIndexChanged += new System.EventHandler(this.CBContractID_SelectedIndexChanged);
            this.CBContractID.Leave += new System.EventHandler(this.CBContractID_Leave);
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
            // lblDateFrom
            // 
            this.lblDateFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblDateFrom.Location = new System.Drawing.Point(241, 5);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(59, 13);
            this.lblDateFrom.TabIndex = 19;
            this.lblDateFrom.Text = "Datum von";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblStatus.Location = new System.Drawing.Point(517, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Artikelstatus";
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
            this.CBPeriod.Location = new System.Drawing.Point(401, 21);
            this.CBPeriod.Name = "CBPeriod";
            this.CBPeriod.Size = new System.Drawing.Size(107, 21);
            this.CBPeriod.TabIndex = 21;
            this.CBPeriod.TabStop = false;
            this.CBPeriod.SelectedIndexChanged += new System.EventHandler(this.CBPeriod_SelectedIndexChanged);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblPeriod.Location = new System.Drawing.Point(404, 5);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(48, 13);
            this.lblPeriod.TabIndex = 25;
            this.lblPeriod.Text = "Zeitraum";
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(301, -1);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(94, 20);
            this.dtFrom.TabIndex = 6;
            this.dtFrom.ValueChanged += new System.EventHandler(this.DtFrom_ValueChanged);
            this.dtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtFrom_KeyDown);
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(301, 22);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(94, 20);
            this.dtTo.TabIndex = 7;
            this.dtTo.ValueChanged += new System.EventHandler(this.DtTo_ValueChanged);
            this.dtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtTo_KeyDown);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblDateTo.Location = new System.Drawing.Point(241, 24);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(54, 13);
            this.lblDateTo.TabIndex = 20;
            this.lblDateTo.Text = "Datum bis";
            // 
            // ContractUI
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
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.ReportItemsDataGridView);
            this.Controls.Add(this.panel2);
            this.Name = "ContractUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auswertung";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportItemsDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReportItemsDataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblKdNr;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button SalesVolumePrintBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox ItemsFoundTB;
        private System.Windows.Forms.Label ItemsFoundLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private ConsignmentShopLibrary.ComboBoxEnter CBAccountID;
        private ConsignmentShopLibrary.ComboBoxEnter CBContractID;
        private System.Windows.Forms.ToolStripMenuItem UndeleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractIDDataGridViewTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.ComboBox CBPeriod;
    }
}