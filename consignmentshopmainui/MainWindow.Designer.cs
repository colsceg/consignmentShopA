namespace ConsignmentShopMainUI
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupAutomatischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warenlisteEinlesenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KundenlisteEinlesenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletedEinlesenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laufwerkFürBackupFestlegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdressenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lieferantenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StammdatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funktionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AuswertungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KassenabschlussToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UmsätzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HandbuchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SchlüsselEingebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContractsGridcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.etikettDruckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artikelHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vertragAbrechnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rücklieferscheinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vertragArchivierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vertragÜbernehmenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artikelVerkauftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artikelNichtVerkauftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etikettAusdruckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.LblSize = new System.Windows.Forms.Label();
            this.LblBrand = new System.Windows.Forms.Label();
            this.LblProperty = new System.Windows.Forms.Label();
            this.LblColour = new System.Windows.Forms.Label();
            this.ContractSaveBtn = new System.Windows.Forms.Button();
            this.ExpirationDateTextBox = new System.Windows.Forms.TextBox();
            this.AktDateTextBox = new System.Windows.Forms.TextBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.ExpirationDateLabel = new System.Windows.Forms.Label();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.MarginLabel = new System.Windows.Forms.Label();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.GoodsInOKButton = new System.Windows.Forms.Button();
            this.SalesPriceLabel = new System.Windows.Forms.Label();
            this.ItemDescriptionLabel = new System.Windows.Forms.Label();
            this.ContractNumberTextBox = new System.Windows.Forms.TextBox();
            this.ItemDataContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ItemsDataGridView = new ConsignmentShopMainUI.DataGridViewEx();
            this.PosNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemInputGroupBox = new System.Windows.Forms.GroupBox();
            this.TextBoxProperties = new ConsignmentShopLibrary.TextBoxEnter();
            this.ComboBoxColor = new ConsignmentShopLibrary.ComboBoxEnter();
            this.ComboBoxSize = new ConsignmentShopLibrary.ComboBoxEnter();
            this.ComboBoxBrand = new ConsignmentShopLibrary.ComboBoxEnter();
            this.KeyTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.SalesPriceTextBox = new ConsignmentShopLibrary.NumTextBox();
            this.PremiumLbl = new System.Windows.Forms.Label();
            this.contractIDLabel = new System.Windows.Forms.Label();
            this.ItemsNumberTextBox = new System.Windows.Forms.TextBox();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.AccountIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NewCustomerButton = new System.Windows.Forms.Button();
            this.VendorGroupBox = new System.Windows.Forms.GroupBox();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.ComboBoxVendorName = new ConsignmentShopLibrary.ComboBoxEnter();
            this.PeriodTextBox = new ConsignmentShopLibrary.NumTextBox();
            this.MarginTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.PeriodLabel = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.BtnItemsOut = new System.Windows.Forms.Button();
            this.BtnReporting = new System.Windows.Forms.Button();
            this.BtnCashCount = new System.Windows.Forms.Button();
            this.ContractBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipVendorNameCB = new System.Windows.Forms.ToolTip(this.components);
            this.ItemDescriptionTextBox = new ConsignmentShopLibrary.ComboBoxEnter();
            this.menuStrip1.SuspendLayout();
            this.ItemDataContextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
            this.ItemInputGroupBox.SuspendLayout();
            this.VendorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContractBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Thistle;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DateiToolStripMenuItem,
            this.AdressenToolStripMenuItem,
            this.funktionenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DateiToolStripMenuItem
            // 
            this.DateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupAutomatischToolStripMenuItem,
            this.BackupToolStripMenuItem,
            this.RestoreToolStripMenuItem,
            this.toolStripSeparator1,
            this.BeendenToolStripMenuItem,
            this.warenlisteEinlesenToolStripMenuItem,
            this.KundenlisteEinlesenToolStripMenuItem,
            this.DeletedEinlesenToolStripMenuItem,
            this.laufwerkFürBackupFestlegenToolStripMenuItem});
            this.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem";
            this.DateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.DateiToolStripMenuItem.Text = "Datei";
            // 
            // backupAutomatischToolStripMenuItem
            // 
            this.backupAutomatischToolStripMenuItem.Name = "backupAutomatischToolStripMenuItem";
            this.backupAutomatischToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.backupAutomatischToolStripMenuItem.Text = "Backup automatisch";
            this.backupAutomatischToolStripMenuItem.Click += new System.EventHandler(this.BackupAutomatischToolStripMenuItem_Click);
            // 
            // BackupToolStripMenuItem
            // 
            this.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem";
            this.BackupToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.BackupToolStripMenuItem.Text = "externe Sicherung";
            this.BackupToolStripMenuItem.Click += new System.EventHandler(this.BackupToolStripMenuItem_Click);
            // 
            // RestoreToolStripMenuItem
            // 
            this.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
            this.RestoreToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.RestoreToolStripMenuItem.Text = "Wiederherstellen";
            this.RestoreToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // BeendenToolStripMenuItem
            // 
            this.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem";
            this.BeendenToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.BeendenToolStripMenuItem.Text = "Beenden";
            this.BeendenToolStripMenuItem.Click += new System.EventHandler(this.BeendenToolStripMenuItem_Click);
            // 
            // warenlisteEinlesenToolStripMenuItem
            // 
            this.warenlisteEinlesenToolStripMenuItem.Name = "warenlisteEinlesenToolStripMenuItem";
            this.warenlisteEinlesenToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.warenlisteEinlesenToolStripMenuItem.Text = "Warenliste einlesen";
            this.warenlisteEinlesenToolStripMenuItem.Visible = false;
            this.warenlisteEinlesenToolStripMenuItem.Click += new System.EventHandler(this.WarenlisteEinlesenToolStripMenuItem_Click);
            // 
            // KundenlisteEinlesenToolStripMenuItem
            // 
            this.KundenlisteEinlesenToolStripMenuItem.Name = "KundenlisteEinlesenToolStripMenuItem";
            this.KundenlisteEinlesenToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.KundenlisteEinlesenToolStripMenuItem.Text = "Kundenliste einlesen";
            this.KundenlisteEinlesenToolStripMenuItem.Click += new System.EventHandler(this.KundenlisteEinlesenToolStripMenuItem_Click);
            // 
            // DeletedEinlesenToolStripMenuItem
            // 
            this.DeletedEinlesenToolStripMenuItem.Name = "DeletedEinlesenToolStripMenuItem";
            this.DeletedEinlesenToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.DeletedEinlesenToolStripMenuItem.Text = "Gelöschte einlesen";
            this.DeletedEinlesenToolStripMenuItem.Click += new System.EventHandler(this.DeletedEinlesenToolStripMenuItem_Click);
            // 
            // laufwerkFürBackupFestlegenToolStripMenuItem
            // 
            this.laufwerkFürBackupFestlegenToolStripMenuItem.Name = "laufwerkFürBackupFestlegenToolStripMenuItem";
            this.laufwerkFürBackupFestlegenToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.laufwerkFürBackupFestlegenToolStripMenuItem.Text = "Laufwerk für Backup festlegen";
            this.laufwerkFürBackupFestlegenToolStripMenuItem.Click += new System.EventHandler(this.LaufwerkFürBackupFestlegenToolStripMenuItem_Click);
            // 
            // AdressenToolStripMenuItem
            // 
            this.AdressenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lieferantenToolStripMenuItem,
            this.StammdatenToolStripMenuItem});
            this.AdressenToolStripMenuItem.Name = "AdressenToolStripMenuItem";
            this.AdressenToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.AdressenToolStripMenuItem.Text = "Adressen";
            // 
            // lieferantenToolStripMenuItem
            // 
            this.lieferantenToolStripMenuItem.Name = "lieferantenToolStripMenuItem";
            this.lieferantenToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.lieferantenToolStripMenuItem.Text = "Lieferanten";
            this.lieferantenToolStripMenuItem.Click += new System.EventHandler(this.LieferantenToolStripMenuItem_Click);
            // 
            // StammdatenToolStripMenuItem
            // 
            this.StammdatenToolStripMenuItem.Name = "StammdatenToolStripMenuItem";
            this.StammdatenToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.StammdatenToolStripMenuItem.Text = "Stammdaten";
            this.StammdatenToolStripMenuItem.Click += new System.EventHandler(this.StammdatenToolStripMenuItem_Click);
            // 
            // funktionenToolStripMenuItem
            // 
            this.funktionenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.AuswertungToolStripMenuItem,
            this.KassenabschlussToolStripMenuItem,
            this.UmsätzeToolStripMenuItem,
            this.RefundToolStripMenuItem});
            this.funktionenToolStripMenuItem.Name = "funktionenToolStripMenuItem";
            this.funktionenToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.funktionenToolStripMenuItem.Text = "Funktionen";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // AuswertungToolStripMenuItem
            // 
            this.AuswertungToolStripMenuItem.Name = "AuswertungToolStripMenuItem";
            this.AuswertungToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.AuswertungToolStripMenuItem.Text = "Auswertung";
            this.AuswertungToolStripMenuItem.Click += new System.EventHandler(this.AuswertungToolStripMenuItem_Click);
            // 
            // KassenabschlussToolStripMenuItem
            // 
            this.KassenabschlussToolStripMenuItem.Name = "KassenabschlussToolStripMenuItem";
            this.KassenabschlussToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.KassenabschlussToolStripMenuItem.Text = "Kassenabschluss";
            this.KassenabschlussToolStripMenuItem.Click += new System.EventHandler(this.KassenabschlussToolStripMenuItem_Click);
            // 
            // UmsätzeToolStripMenuItem
            // 
            this.UmsätzeToolStripMenuItem.Name = "UmsätzeToolStripMenuItem";
            this.UmsätzeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.UmsätzeToolStripMenuItem.Text = "Umsätze";
            this.UmsätzeToolStripMenuItem.Click += new System.EventHandler(this.UmsätzeToolStripMenuItem_Click);
            // 
            // RefundToolStripMenuItem
            // 
            this.RefundToolStripMenuItem.Name = "RefundToolStripMenuItem";
            this.RefundToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.RefundToolStripMenuItem.Text = "Rückgabe";
            this.RefundToolStripMenuItem.Click += new System.EventHandler(this.RefundToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HandbuchToolStripMenuItem,
            this.SchlüsselEingebenToolStripMenuItem,
            this.InfoToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // HandbuchToolStripMenuItem
            // 
            this.HandbuchToolStripMenuItem.Enabled = false;
            this.HandbuchToolStripMenuItem.Name = "HandbuchToolStripMenuItem";
            this.HandbuchToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.HandbuchToolStripMenuItem.Text = "Handbuch";
            // 
            // SchlüsselEingebenToolStripMenuItem
            // 
            this.SchlüsselEingebenToolStripMenuItem.Name = "SchlüsselEingebenToolStripMenuItem";
            this.SchlüsselEingebenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.SchlüsselEingebenToolStripMenuItem.Text = "Schlüssel eingeben";
            this.SchlüsselEingebenToolStripMenuItem.Click += new System.EventHandler(this.SchlüsselEingebenToolStripMenuItem_Click);
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.InfoToolStripMenuItem.Text = "Info";
            this.InfoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // ContractsGridcontextMenuStrip
            // 
            this.ContractsGridcontextMenuStrip.Name = "ContractsGridcontextMenuStrip";
            this.ContractsGridcontextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // etikettDruckenToolStripMenuItem
            // 
            this.etikettDruckenToolStripMenuItem.Name = "etikettDruckenToolStripMenuItem";
            this.etikettDruckenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // artikelHinzufügenToolStripMenuItem
            // 
            this.artikelHinzufügenToolStripMenuItem.Name = "artikelHinzufügenToolStripMenuItem";
            this.artikelHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // vertragAbrechnenToolStripMenuItem
            // 
            this.vertragAbrechnenToolStripMenuItem.Name = "vertragAbrechnenToolStripMenuItem";
            this.vertragAbrechnenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // rücklieferscheinToolStripMenuItem
            // 
            this.rücklieferscheinToolStripMenuItem.Name = "rücklieferscheinToolStripMenuItem";
            this.rücklieferscheinToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // vertragArchivierenToolStripMenuItem
            // 
            this.vertragArchivierenToolStripMenuItem.Name = "vertragArchivierenToolStripMenuItem";
            this.vertragArchivierenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // vertragÜbernehmenToolStripMenuItem
            // 
            this.vertragÜbernehmenToolStripMenuItem.Name = "vertragÜbernehmenToolStripMenuItem";
            this.vertragÜbernehmenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // artikelVerkauftToolStripMenuItem
            // 
            this.artikelVerkauftToolStripMenuItem.Name = "artikelVerkauftToolStripMenuItem";
            this.artikelVerkauftToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // artikelNichtVerkauftToolStripMenuItem
            // 
            this.artikelNichtVerkauftToolStripMenuItem.Name = "artikelNichtVerkauftToolStripMenuItem";
            this.artikelNichtVerkauftToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // etikettAusdruckenToolStripMenuItem
            // 
            this.etikettAusdruckenToolStripMenuItem.Name = "etikettAusdruckenToolStripMenuItem";
            this.etikettAusdruckenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyLabel.Location = new System.Drawing.Point(523, 68);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(115, 15);
            this.KeyLabel.TabIndex = 25;
            this.KeyLabel.Text = "Schlüssel eingeben";
            this.KeyLabel.Visible = false;
            // 
            // LblSize
            // 
            this.LblSize.AutoSize = true;
            this.LblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSize.Location = new System.Drawing.Point(152, 112);
            this.LblSize.Name = "LblSize";
            this.LblSize.Size = new System.Drawing.Size(46, 15);
            this.LblSize.TabIndex = 31;
            this.LblSize.Text = "Grösse";
            // 
            // LblBrand
            // 
            this.LblBrand.AutoSize = true;
            this.LblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBrand.Location = new System.Drawing.Point(152, 66);
            this.LblBrand.Name = "LblBrand";
            this.LblBrand.Size = new System.Drawing.Size(42, 15);
            this.LblBrand.TabIndex = 30;
            this.LblBrand.Text = "Marke";
            // 
            // LblProperty
            // 
            this.LblProperty.AutoSize = true;
            this.LblProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProperty.Location = new System.Drawing.Point(11, 112);
            this.LblProperty.Name = "LblProperty";
            this.LblProperty.Size = new System.Drawing.Size(71, 15);
            this.LblProperty.TabIndex = 29;
            this.LblProperty.Text = "Eigenschaft";
            // 
            // LblColour
            // 
            this.LblColour.AutoSize = true;
            this.LblColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblColour.Location = new System.Drawing.Point(11, 66);
            this.LblColour.Name = "LblColour";
            this.LblColour.Size = new System.Drawing.Size(39, 15);
            this.LblColour.TabIndex = 28;
            this.LblColour.Text = "Farbe";
            // 
            // ContractSaveBtn
            // 
            this.ContractSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractSaveBtn.Location = new System.Drawing.Point(863, 622);
            this.ContractSaveBtn.Name = "ContractSaveBtn";
            this.ContractSaveBtn.Size = new System.Drawing.Size(134, 23);
            this.ContractSaveBtn.TabIndex = 0;
            this.ContractSaveBtn.TabStop = false;
            this.ContractSaveBtn.Text = "Alle Artikel speichern";
            this.ContractSaveBtn.UseVisualStyleBackColor = true;
            this.ContractSaveBtn.Click += new System.EventHandler(this.ContractSaveBtn_Click);
            // 
            // ExpirationDateTextBox
            // 
            this.ExpirationDateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpirationDateTextBox.Location = new System.Drawing.Point(581, 34);
            this.ExpirationDateTextBox.Name = "ExpirationDateTextBox";
            this.ExpirationDateTextBox.ReadOnly = true;
            this.ExpirationDateTextBox.Size = new System.Drawing.Size(86, 22);
            this.ExpirationDateTextBox.TabIndex = 0;
            this.ExpirationDateTextBox.TabStop = false;
            this.ExpirationDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AktDateTextBox
            // 
            this.AktDateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AktDateTextBox.Location = new System.Drawing.Point(482, 34);
            this.AktDateTextBox.Name = "AktDateTextBox";
            this.AktDateTextBox.ReadOnly = true;
            this.AktDateTextBox.Size = new System.Drawing.Size(86, 22);
            this.AktDateTextBox.TabIndex = 0;
            this.AktDateTextBox.TabStop = false;
            this.AktDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(485, 17);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(44, 15);
            this.DateLabel.TabIndex = 20;
            this.DateLabel.Text = "Datum";
            // 
            // ExpirationDateLabel
            // 
            this.ExpirationDateLabel.AutoSize = true;
            this.ExpirationDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpirationDateLabel.Location = new System.Drawing.Point(584, 16);
            this.ExpirationDateLabel.Name = "ExpirationDateLabel";
            this.ExpirationDateLabel.Size = new System.Drawing.Size(76, 15);
            this.ExpirationDateLabel.TabIndex = 19;
            this.ExpirationDateLabel.Text = "Ablaufdatum";
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumberLabel.Location = new System.Drawing.Point(17, 114);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(95, 15);
            this.PhoneNumberLabel.TabIndex = 3;
            this.PhoneNumberLabel.Text = "Telefonnummer";
            // 
            // MarginLabel
            // 
            this.MarginLabel.AutoSize = true;
            this.MarginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarginLabel.Location = new System.Drawing.Point(95, 69);
            this.MarginLabel.Name = "MarginLabel";
            this.MarginLabel.Size = new System.Drawing.Size(43, 15);
            this.MarginLabel.TabIndex = 1;
            this.MarginLabel.Text = "Marge";
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullNameLabel.Location = new System.Drawing.Point(11, 26);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(129, 15);
            this.FullNameLabel.TabIndex = 0;
            this.FullNameLabel.Text = "Name des Lieferanten";
            // 
            // PhoneNumberTextBox
            // 
            this.PhoneNumberTextBox.AcceptsReturn = true;
            this.PhoneNumberTextBox.Enabled = false;
            this.PhoneNumberTextBox.Location = new System.Drawing.Point(14, 134);
            this.PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            this.PhoneNumberTextBox.ReadOnly = true;
            this.PhoneNumberTextBox.Size = new System.Drawing.Size(146, 21);
            this.PhoneNumberTextBox.TabIndex = 0;
            this.PhoneNumberTextBox.TabStop = false;
            // 
            // GoodsInOKButton
            // 
            this.GoodsInOKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoodsInOKButton.Location = new System.Drawing.Point(399, 131);
            this.GoodsInOKButton.Name = "GoodsInOKButton";
            this.GoodsInOKButton.Size = new System.Drawing.Size(84, 23);
            this.GoodsInOKButton.TabIndex = 7;
            this.GoodsInOKButton.Text = "Hinzufügen";
            this.GoodsInOKButton.UseVisualStyleBackColor = true;
            this.GoodsInOKButton.Click += new System.EventHandler(this.GoodsInOKButton_Click);
            // 
            // SalesPriceLabel
            // 
            this.SalesPriceLabel.AutoSize = true;
            this.SalesPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesPriceLabel.Location = new System.Drawing.Point(294, 112);
            this.SalesPriceLabel.Name = "SalesPriceLabel";
            this.SalesPriceLabel.Size = new System.Drawing.Size(81, 15);
            this.SalesPriceLabel.TabIndex = 11;
            this.SalesPriceLabel.Text = "Verkaufspreis";
            // 
            // ItemDescriptionLabel
            // 
            this.ItemDescriptionLabel.AutoSize = true;
            this.ItemDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemDescriptionLabel.Location = new System.Drawing.Point(8, 23);
            this.ItemDescriptionLabel.Name = "ItemDescriptionLabel";
            this.ItemDescriptionLabel.Size = new System.Drawing.Size(111, 15);
            this.ItemDescriptionLabel.TabIndex = 7;
            this.ItemDescriptionLabel.Text = "Artikelbezeichnung";
            // 
            // ContractNumberTextBox
            // 
            this.ContractNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractNumberTextBox.Location = new System.Drawing.Point(593, 53);
            this.ContractNumberTextBox.Name = "ContractNumberTextBox";
            this.ContractNumberTextBox.ReadOnly = true;
            this.ContractNumberTextBox.Size = new System.Drawing.Size(65, 22);
            this.ContractNumberTextBox.TabIndex = 0;
            this.ContractNumberTextBox.TabStop = false;
            this.ContractNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemDataContextMenuStrip
            // 
            this.ItemDataContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditMenuItem,
            this.DeleteMenuItem});
            this.ItemDataContextMenuStrip.Name = "ItemDataContextMenuStrip";
            this.ItemDataContextMenuStrip.Size = new System.Drawing.Size(131, 48);
            this.ItemDataContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ItemDataContextMenuStrip_Opening);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.Size = new System.Drawing.Size(130, 22);
            this.EditMenuItem.Text = "Bearbeiten";
            this.EditMenuItem.Click += new System.EventHandler(this.EditMenuItem_Click);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(130, 22);
            this.DeleteMenuItem.Text = "Löschen";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.ItemsDataGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 364);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Positionen";
            // 
            // ItemsDataGridView
            // 
            this.ItemsDataGridView.AllowUserToAddRows = false;
            this.ItemsDataGridView.AllowUserToDeleteRows = false;
            this.ItemsDataGridView.AllowUserToResizeColumns = false;
            this.ItemsDataGridView.AllowUserToResizeRows = false;
            this.ItemsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PosNumber,
            this.itemDescription,
            this.attribute2,
            this.attribute1,
            this.attribute4,
            this.attribute3,
            this.SalesPrice});
            this.ItemsDataGridView.ContextMenuStrip = this.ItemDataContextMenuStrip;
            this.ItemsDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ItemsDataGridView.Location = new System.Drawing.Point(8, 20);
            this.ItemsDataGridView.MultiSelect = false;
            this.ItemsDataGridView.Name = "ItemsDataGridView";
            this.ItemsDataGridView.ReadOnly = true;
            this.ItemsDataGridView.RowHeadersVisible = false;
            this.ItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsDataGridView.Size = new System.Drawing.Size(972, 332);
            this.ItemsDataGridView.TabIndex = 0;
            this.ItemsDataGridView.TabStop = false;
            // 
            // PosNumber
            // 
            this.PosNumber.HeaderText = "ArtikelNr";
            this.PosNumber.Name = "PosNumber";
            this.PosNumber.ReadOnly = true;
            this.PosNumber.Width = 80;
            // 
            // itemDescription
            // 
            this.itemDescription.HeaderText = "ArtikelBeschreibung";
            this.itemDescription.Name = "itemDescription";
            this.itemDescription.ReadOnly = true;
            this.itemDescription.Width = 300;
            // 
            // attribute2
            // 
            this.attribute2.HeaderText = "Marke";
            this.attribute2.Name = "attribute2";
            this.attribute2.ReadOnly = true;
            this.attribute2.Width = 140;
            // 
            // attribute1
            // 
            this.attribute1.HeaderText = "Farbe";
            this.attribute1.Name = "attribute1";
            this.attribute1.ReadOnly = true;
            this.attribute1.Width = 80;
            // 
            // attribute4
            // 
            this.attribute4.HeaderText = "Grösse";
            this.attribute4.Name = "attribute4";
            this.attribute4.ReadOnly = true;
            this.attribute4.Width = 110;
            // 
            // attribute3
            // 
            this.attribute3.HeaderText = "Eigensch.";
            this.attribute3.Name = "attribute3";
            this.attribute3.ReadOnly = true;
            this.attribute3.Width = 140;
            // 
            // SalesPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.SalesPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.SalesPrice.HeaderText = "VK-Preis";
            this.SalesPrice.Name = "SalesPrice";
            this.SalesPrice.ReadOnly = true;
            // 
            // ItemInputGroupBox
            // 
            this.ItemInputGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.ItemInputGroupBox.Controls.Add(this.ItemDescriptionTextBox);
            this.ItemInputGroupBox.Controls.Add(this.TextBoxProperties);
            this.ItemInputGroupBox.Controls.Add(this.ComboBoxColor);
            this.ItemInputGroupBox.Controls.Add(this.ComboBoxSize);
            this.ItemInputGroupBox.Controls.Add(this.ComboBoxBrand);
            this.ItemInputGroupBox.Controls.Add(this.KeyTextBox);
            this.ItemInputGroupBox.Controls.Add(this.SalesPriceTextBox);
            this.ItemInputGroupBox.Controls.Add(this.PremiumLbl);
            this.ItemInputGroupBox.Controls.Add(this.LblSize);
            this.ItemInputGroupBox.Controls.Add(this.LblBrand);
            this.ItemInputGroupBox.Controls.Add(this.LblProperty);
            this.ItemInputGroupBox.Controls.Add(this.LblColour);
            this.ItemInputGroupBox.Controls.Add(this.KeyLabel);
            this.ItemInputGroupBox.Controls.Add(this.ExpirationDateTextBox);
            this.ItemInputGroupBox.Controls.Add(this.AktDateTextBox);
            this.ItemInputGroupBox.Controls.Add(this.DateLabel);
            this.ItemInputGroupBox.Controls.Add(this.ExpirationDateLabel);
            this.ItemInputGroupBox.Controls.Add(this.GoodsInOKButton);
            this.ItemInputGroupBox.Controls.Add(this.SalesPriceLabel);
            this.ItemInputGroupBox.Controls.Add(this.ItemDescriptionLabel);
            this.ItemInputGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemInputGroupBox.Location = new System.Drawing.Point(11, 81);
            this.ItemInputGroupBox.Name = "ItemInputGroupBox";
            this.ItemInputGroupBox.Size = new System.Drawing.Size(680, 167);
            this.ItemInputGroupBox.TabIndex = 29;
            this.ItemInputGroupBox.TabStop = false;
            this.ItemInputGroupBox.Text = "Artikeleingabe";
            // 
            // TextBoxProperties
            // 
            this.TextBoxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProperties.Location = new System.Drawing.Point(8, 133);
            this.TextBoxProperties.Name = "TextBoxProperties";
            this.TextBoxProperties.Size = new System.Drawing.Size(123, 21);
            this.TextBoxProperties.TabIndex = 4;
            this.TextBoxProperties.Leave += new System.EventHandler(this.TextBoxProperties_Leave);
            // 
            // ComboBoxColor
            // 
            this.ComboBoxColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxColor.Enabled = false;
            this.ComboBoxColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxColor.FormattingEnabled = true;
            this.ComboBoxColor.Location = new System.Drawing.Point(8, 84);
            this.ComboBoxColor.Name = "ComboBoxColor";
            this.ComboBoxColor.Size = new System.Drawing.Size(121, 23);
            this.ComboBoxColor.TabIndex = 2;
            this.ComboBoxColor.SelectedIndexChanged += new System.EventHandler(this.ComboBoxColor_SelectedIndexChanged);
            this.ComboBoxColor.TextChanged += new System.EventHandler(this.ComboBoxColor_TextChanged);
            this.ComboBoxColor.Leave += new System.EventHandler(this.ComboBoxColor_Leave);
            // 
            // ComboBoxSize
            // 
            this.ComboBoxSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxSize.Enabled = false;
            this.ComboBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxSize.FormattingEnabled = true;
            this.ComboBoxSize.Location = new System.Drawing.Point(149, 131);
            this.ComboBoxSize.Name = "ComboBoxSize";
            this.ComboBoxSize.Size = new System.Drawing.Size(121, 23);
            this.ComboBoxSize.TabIndex = 5;
            this.ComboBoxSize.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSize_SelectedIndexChanged);
            this.ComboBoxSize.TextChanged += new System.EventHandler(this.ComboBoxSize_TextChanged);
            this.ComboBoxSize.Leave += new System.EventHandler(this.ComboBoxSize_Leave);
            // 
            // ComboBoxBrand
            // 
            this.ComboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxBrand.Enabled = false;
            this.ComboBoxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxBrand.FormattingEnabled = true;
            this.ComboBoxBrand.Location = new System.Drawing.Point(149, 84);
            this.ComboBoxBrand.Name = "ComboBoxBrand";
            this.ComboBoxBrand.Size = new System.Drawing.Size(220, 23);
            this.ComboBoxBrand.TabIndex = 3;
            this.ComboBoxBrand.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBrand_SelectedIndexChanged);
            this.ComboBoxBrand.TextChanged += new System.EventHandler(this.ComboBoxBrand_TextChanged);
            this.ComboBoxBrand.Leave += new System.EventHandler(this.ComboBoxBrand_Leave);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyTextBox.Location = new System.Drawing.Point(520, 86);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(100, 21);
            this.KeyTextBox.TabIndex = 0;
            this.KeyTextBox.TabStop = false;
            this.KeyTextBox.Visible = false;
            this.KeyTextBox.Leave += new System.EventHandler(this.KeyTextBox_Leave);
            // 
            // SalesPriceTextBox
            // 
            this.SalesPriceTextBox.Enabled = false;
            this.SalesPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesPriceTextBox.Location = new System.Drawing.Point(291, 131);
            this.SalesPriceTextBox.Name = "SalesPriceTextBox";
            this.SalesPriceTextBox.Size = new System.Drawing.Size(78, 21);
            this.SalesPriceTextBox.TabIndex = 6;
            this.SalesPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SalesPriceTextBox.Leave += new System.EventHandler(this.SalesPriceTextBox_Leave);
            // 
            // PremiumLbl
            // 
            this.PremiumLbl.AutoSize = true;
            this.PremiumLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PremiumLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.PremiumLbl.Location = new System.Drawing.Point(372, 87);
            this.PremiumLbl.Name = "PremiumLbl";
            this.PremiumLbl.Size = new System.Drawing.Size(111, 16);
            this.PremiumLbl.TabIndex = 32;
            this.PremiumLbl.Text = "Premiummarke";
            this.PremiumLbl.Visible = false;
            // 
            // contractIDLabel
            // 
            this.contractIDLabel.AutoSize = true;
            this.contractIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contractIDLabel.Location = new System.Drawing.Point(596, 35);
            this.contractIDLabel.Name = "contractIDLabel";
            this.contractIDLabel.Size = new System.Drawing.Size(65, 15);
            this.contractIDLabel.TabIndex = 3;
            this.contractIDLabel.Text = "VertragsNr";
            // 
            // ItemsNumberTextBox
            // 
            this.ItemsNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsNumberTextBox.Location = new System.Drawing.Point(493, 53);
            this.ItemsNumberTextBox.Name = "ItemsNumberTextBox";
            this.ItemsNumberTextBox.ReadOnly = true;
            this.ItemsNumberTextBox.Size = new System.Drawing.Size(53, 22);
            this.ItemsNumberTextBox.TabIndex = 0;
            this.ItemsNumberTextBox.TabStop = false;
            this.ItemsNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLabel.Location = new System.Drawing.Point(496, 35);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(53, 15);
            this.ItemLabel.TabIndex = 0;
            this.ItemLabel.Text = "ArtikelNr";
            // 
            // AccountIDTextBox
            // 
            this.AccountIDTextBox.Location = new System.Drawing.Point(14, 87);
            this.AccountIDTextBox.Name = "AccountIDTextBox";
            this.AccountIDTextBox.ReadOnly = true;
            this.AccountIDTextBox.Size = new System.Drawing.Size(63, 21);
            this.AccountIDTextBox.TabIndex = 0;
            this.AccountIDTextBox.TabStop = false;
            this.AccountIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "KundenNr";
            // 
            // NewCustomerButton
            // 
            this.NewCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerButton.Location = new System.Drawing.Point(14, 168);
            this.NewCustomerButton.Name = "NewCustomerButton";
            this.NewCustomerButton.Size = new System.Drawing.Size(114, 39);
            this.NewCustomerButton.TabIndex = 0;
            this.NewCustomerButton.TabStop = false;
            this.NewCustomerButton.Text = "Neuer Lieferant";
            this.NewCustomerButton.UseVisualStyleBackColor = true;
            this.NewCustomerButton.Click += new System.EventHandler(this.NewCustomerButton_Click);
            // 
            // VendorGroupBox
            // 
            this.VendorGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.VendorGroupBox.Controls.Add(this.FullNameTextBox);
            this.VendorGroupBox.Controls.Add(this.ComboBoxVendorName);
            this.VendorGroupBox.Controls.Add(this.PeriodTextBox);
            this.VendorGroupBox.Controls.Add(this.MarginTextBox);
            this.VendorGroupBox.Controls.Add(this.PeriodLabel);
            this.VendorGroupBox.Controls.Add(this.PhoneNumberTextBox);
            this.VendorGroupBox.Controls.Add(this.PhoneNumberLabel);
            this.VendorGroupBox.Controls.Add(this.AccountIDTextBox);
            this.VendorGroupBox.Controls.Add(this.MarginLabel);
            this.VendorGroupBox.Controls.Add(this.FullNameLabel);
            this.VendorGroupBox.Controls.Add(this.label2);
            this.VendorGroupBox.Controls.Add(this.NewCustomerButton);
            this.VendorGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorGroupBox.Location = new System.Drawing.Point(697, 35);
            this.VendorGroupBox.Name = "VendorGroupBox";
            this.VendorGroupBox.Size = new System.Drawing.Size(299, 213);
            this.VendorGroupBox.TabIndex = 30;
            this.VendorGroupBox.TabStop = false;
            this.VendorGroupBox.Text = "Kundeninformationen";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(14, 26);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.ReadOnly = true;
            this.FullNameTextBox.Size = new System.Drawing.Size(256, 21);
            this.FullNameTextBox.TabIndex = 1;
            this.FullNameTextBox.Visible = false;
            // 
            // ComboBoxVendorName
            // 
            this.ComboBoxVendorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxVendorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxVendorName.FormattingEnabled = true;
            this.ComboBoxVendorName.Location = new System.Drawing.Point(14, 44);
            this.ComboBoxVendorName.Name = "ComboBoxVendorName";
            this.ComboBoxVendorName.Size = new System.Drawing.Size(256, 23);
            this.ComboBoxVendorName.TabIndex = 0;
            this.ComboBoxVendorName.TabStop = false;
            this.ComboBoxVendorName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVendorName_SelectedIndexChanged);
            this.ComboBoxVendorName.DataSourceChanged += new System.EventHandler(this.ComboBoxVendorName_DataSourceChanged);
            this.ComboBoxVendorName.Leave += new System.EventHandler(this.ComboBoxVendorName_Leave);
            // 
            // PeriodTextBox
            // 
            this.PeriodTextBox.Location = new System.Drawing.Point(159, 87);
            this.PeriodTextBox.Name = "PeriodTextBox";
            this.PeriodTextBox.ReadOnly = true;
            this.PeriodTextBox.Size = new System.Drawing.Size(47, 21);
            this.PeriodTextBox.TabIndex = 0;
            this.PeriodTextBox.TabStop = false;
            this.PeriodTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PeriodTextBox.Leave += new System.EventHandler(this.PeriodTextBox_Leave);
            // 
            // MarginTextBox
            // 
            this.MarginTextBox.Enabled = false;
            this.MarginTextBox.Location = new System.Drawing.Point(92, 87);
            this.MarginTextBox.Name = "MarginTextBox";
            this.MarginTextBox.ReadOnly = true;
            this.MarginTextBox.Size = new System.Drawing.Size(48, 21);
            this.MarginTextBox.TabIndex = 0;
            this.MarginTextBox.TabStop = false;
            this.MarginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MarginTextBox.TextChanged += new System.EventHandler(this.MarginTextBox_TextChanged);
            this.MarginTextBox.Leave += new System.EventHandler(this.MarginTextBox_Leave);
            this.MarginTextBox.Validated += new System.EventHandler(this.MarginTextBox_Validated);
            // 
            // PeriodLabel
            // 
            this.PeriodLabel.AutoSize = true;
            this.PeriodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodLabel.Location = new System.Drawing.Point(162, 69);
            this.PeriodLabel.Name = "PeriodLabel";
            this.PeriodLabel.Size = new System.Drawing.Size(50, 15);
            this.PeriodLabel.TabIndex = 8;
            this.PeriodLabel.Text = "Laufzeit";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(736, 622);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(124, 23);
            this.ClearBtn.TabIndex = 0;
            this.ClearBtn.TabStop = false;
            this.ClearBtn.Text = "Rückgängig";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // BtnItemsOut
            // 
            this.BtnItemsOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnItemsOut.Image = global::ConsignmentShopMainUI.Properties.Resources.warenausgang_b;
            this.BtnItemsOut.Location = new System.Drawing.Point(12, 26);
            this.BtnItemsOut.Name = "BtnItemsOut";
            this.BtnItemsOut.Size = new System.Drawing.Size(138, 50);
            this.BtnItemsOut.TabIndex = 0;
            this.BtnItemsOut.TabStop = false;
            this.BtnItemsOut.UseVisualStyleBackColor = true;
            this.BtnItemsOut.Click += new System.EventHandler(this.BtnItemsOut_Click);
            // 
            // BtnReporting
            // 
            this.BtnReporting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReporting.Image = global::ConsignmentShopMainUI.Properties.Resources.Auswertung;
            this.BtnReporting.Location = new System.Drawing.Point(152, 26);
            this.BtnReporting.Name = "BtnReporting";
            this.BtnReporting.Size = new System.Drawing.Size(138, 50);
            this.BtnReporting.TabIndex = 3;
            this.BtnReporting.TabStop = false;
            this.BtnReporting.UseVisualStyleBackColor = true;
            this.BtnReporting.Click += new System.EventHandler(this.BtnReporting_Click);
            // 
            // BtnCashCount
            // 
            this.BtnCashCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCashCount.Image = global::ConsignmentShopMainUI.Properties.Resources.Kassenabschluss;
            this.BtnCashCount.Location = new System.Drawing.Point(293, 26);
            this.BtnCashCount.Name = "BtnCashCount";
            this.BtnCashCount.Size = new System.Drawing.Size(138, 50);
            this.BtnCashCount.TabIndex = 0;
            this.BtnCashCount.TabStop = false;
            this.BtnCashCount.UseVisualStyleBackColor = true;
            this.BtnCashCount.Click += new System.EventHandler(this.BtnCashCount_Click);
            // 
            // toolTipVendorNameCB
            // 
            this.toolTipVendorNameCB.ToolTipTitle = "Falsche Eingabe";
            // 
            // ItemDescriptionTextBox
            // 
            this.ItemDescriptionTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ItemDescriptionTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ItemDescriptionTextBox.Enabled = false;
            this.ItemDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemDescriptionTextBox.FormattingEnabled = true;
            this.ItemDescriptionTextBox.Location = new System.Drawing.Point(8, 41);
            this.ItemDescriptionTextBox.Name = "ItemDescriptionTextBox";
            this.ItemDescriptionTextBox.Size = new System.Drawing.Size(361, 23);
            this.ItemDescriptionTextBox.TabIndex = 1;
            this.ItemDescriptionTextBox.EnabledChanged += new System.EventHandler(this.ItemDescriptionTextBox_EnabledChanged);
            this.ItemDescriptionTextBox.Leave += new System.EventHandler(this.ItemDescriptionTextBox_Leave);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 650);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.ContractSaveBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ItemInputGroupBox);
            this.Controls.Add(this.VendorGroupBox);
            this.Controls.Add(this.BtnItemsOut);
            this.Controls.Add(this.BtnReporting);
            this.Controls.Add(this.BtnCashCount);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ItemsNumberTextBox);
            this.Controls.Add(this.ItemLabel);
            this.Controls.Add(this.contractIDLabel);
            this.Controls.Add(this.ContractNumberTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kommissionwaren Secondhand Kleidung (Demo)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ItemDataContextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
            this.ItemInputGroupBox.ResumeLayout(false);
            this.ItemInputGroupBox.PerformLayout();
            this.VendorGroupBox.ResumeLayout(false);
            this.VendorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContractBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BeendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdressenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lieferantenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StammdatenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funktionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem KassenabschlussToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AuswertungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UmsätzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HandbuchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SchlüsselEingebenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.Button BtnCashCount;
        private System.Windows.Forms.Button BtnReporting;
        private System.Windows.Forms.Button BtnItemsOut;
        private System.Windows.Forms.BindingSource ContractBindingSource;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.ContextMenuStrip ContractsGridcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem etikettDruckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artikelHinzufügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vertragAbrechnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rücklieferscheinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vertragArchivierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vertragÜbernehmenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artikelVerkauftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artikelNichtVerkauftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etikettAusdruckenToolStripMenuItem;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Label LblSize;
        private System.Windows.Forms.Label LblBrand;
        private System.Windows.Forms.Label LblProperty;
        private System.Windows.Forms.Label LblColour;
        private System.Windows.Forms.Button ContractSaveBtn;
        private System.Windows.Forms.TextBox ExpirationDateTextBox;
        private System.Windows.Forms.TextBox AktDateTextBox;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label ExpirationDateLabel;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.Label MarginLabel;
        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.TextBox PhoneNumberTextBox;
        private System.Windows.Forms.Button GoodsInOKButton;
        private System.Windows.Forms.Label SalesPriceLabel;
        private System.Windows.Forms.Label ItemDescriptionLabel;
        private System.Windows.Forms.TextBox ContractNumberTextBox;
        private DataGridViewEx ItemsDataGridView;
        private System.Windows.Forms.ContextMenuStrip ItemDataContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ItemInputGroupBox;
        private System.Windows.Forms.Label contractIDLabel;
        private System.Windows.Forms.TextBox ItemsNumberTextBox;
        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.TextBox AccountIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NewCustomerButton;
        private System.Windows.Forms.GroupBox VendorGroupBox;
        private System.Windows.Forms.Label PeriodLabel;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label PremiumLbl;
        private ConsignmentShopLibrary.NumTextBox SalesPriceTextBox;
        private ConsignmentShopLibrary.TextBoxEnter MarginTextBox;
        private ConsignmentShopLibrary.NumTextBox PeriodTextBox;
        private System.Windows.Forms.ToolStripMenuItem warenlisteEinlesenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KundenlisteEinlesenToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipVendorNameCB;
        private ConsignmentShopLibrary.ComboBoxEnter ComboBoxSize;
        private ConsignmentShopLibrary.ComboBoxEnter ComboBoxBrand;
        private ConsignmentShopLibrary.TextBoxEnter KeyTextBox;
        private ConsignmentShopLibrary.ComboBoxEnter ComboBoxVendorName;
        private System.Windows.Forms.ToolStripMenuItem DeletedEinlesenToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute2;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute1;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute4;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesPrice;
        private ConsignmentShopLibrary.ComboBoxEnter ComboBoxColor;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.ToolStripMenuItem backupAutomatischToolStripMenuItem;
        private ConsignmentShopLibrary.TextBoxEnter TextBoxProperties;
        private System.Windows.Forms.ToolStripMenuItem laufwerkFürBackupFestlegenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefundToolStripMenuItem;
        private ConsignmentShopLibrary.ComboBoxEnter ItemDescriptionTextBox;
    }
}

