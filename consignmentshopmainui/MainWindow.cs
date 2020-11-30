using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConsignmentShopLibrary;
using System.IO;
using VendorEditUI;
using System.Collections;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.Threading.Tasks;


namespace ConsignmentShopMainUI
{
    public partial class MainWindow : Form, ISharpUpdatable
    {

        private Store Store = new Store();
        private VendorTableUI VendorTable = new VendorTableUI();
        private VendorTableUI VendorsTable = new VendorTableUI();
        private OwnerEditUI OwnerEdit = new OwnerEditUI();

        private Vendor newVendor = new Vendor();
        private string WorkingDirectory;
        private string BackupDirectory;
        private string AppDataDirectory;

        private List<Vendor> VendorsList = new List<Vendor>();

        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();
        private DataAccessAttributes DbAttribs = new DataAccessAttributes();
        private DataAccessZipCode DbZipCode = new DataAccessZipCode();

        private List<Contract> ContractsList = new List<Contract>();
        private List<Item> ItemsList = new List<Item>();
        private List<Vendor> CustomersList = new List<Vendor>();
        private string CurrentUsername = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        private string LastContractID = null;
        private string LastItemNumber = null;
        private bool loaded = false;
        private bool Licensed = false;
        private string LicenseFile;
        private string LicenseNo = "";
        private string SerNo = "";
        private int ItemsCount = 0;
        private bool NewContract = false;

        private string myTotalPriceString = string.Format("{0,00} €", 0);
        private string myAccountID = "";
        private string myContractID = "";
        private string myItemNumber = "";
        private List<ConfigData> myConfigData = new List<ConfigData>();
        public Boolean updateRecord = false;
        private Item myItem = new Item();
        private Contract myContract = new Contract();
        private bool myContractChanged = false;
        private bool myBrandTextChanged = false;
        private bool myColorTextChanged = false;
        private bool mySizeTextChanged = false;
        private bool myItemdescriptionTextChanged = false;

        private BindingList<string> bindinglistColor = new BindingList<string>();
        private BindingSource bSourceColor = new BindingSource();

        private BindingList<string> bindinglistBrand = new BindingList<string>();
        private BindingSource bSourceBrand = new BindingSource();

        private BindingList<string> bindinglistItemdescription = new BindingList<string>();
        private BindingSource bSourceItemdescription = new BindingSource();

        private BindingList<string> bindinglistProperties = new BindingList<string>();
        private BindingSource bSourceProperties = new BindingSource();

        private BindingList<string> bindinglistSize = new BindingList<string>();
        private BindingSource bSourceSize = new BindingSource();

        private bool _ignoreEvents = true;

        List<string> labels = new List<string>();
        List<string> colors = new List<string>();
        List<string> properties = new List<string>();
        List<string> sizes = new List<string>();
        List<string> vendors = new List<string>();

        #region Public Properties SharpUpdate
        private SharpUpdater updater;

        public string ApplicationName => "ConsignmentShopApp";

        public string ApplicationID => "ConsignmentShopApp";

        public Assembly ApplicationAssembly => Assembly.GetExecutingAssembly();

        public Icon ApplicationIcon => this.Icon;

        public Uri UpdateXmlLocation => new Uri("https://www.chairfit.de/Software/update.xml");

        public Form Context => this;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            updater = new SharpUpdater(this);

            KeyPreview = true;
            KeyDown +=
                new KeyEventHandler(MainWindow_KeyDown);
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            Setup();
            Load += new EventHandler(MainWindow_Load);

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (!loaded)
            {
                //PopulateDataGridView();
                // lädt die Tabelle customers aus der SQLite DB
                Disp();
                loaded = true;
                this.Text += " Vers." + Store.AddVersionNumber();
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            List<Vendor> vendorList = DbVendors.GetOwner();
            warenlisteEinlesenToolStripMenuItem.Visible = false;
            KundenlisteEinlesenToolStripMenuItem.Visible = false;
            DeletedEinlesenToolStripMenuItem.Visible = false;
            if (vendorList.Count < 1)
            {
                MessageBox.Show("Zuerst die Stammdaten eingeben");
                OpenOwnerEdit_Window();
            }
            _ignoreEvents = false;
            ComboBoxVendorName.Focus();
        }



        #region Read files from old Cincom version
        //Dient dem Einlesen der Waremliste aus dem Cincom Programm
        private void ReadAllItemsFromFile(string myFilename)
        {
            Char delimiter = ';';
            string[] substrings;
            //string myFilename = "\\Warenliste.dta";
            string myToday = DateTime.Today.ToShortDateString();
            string year = myToday.Substring(6, 4).Substring(2,2);
            string myContractID = year + "0000";
            if (File.Exists(myFilename))
            {
                string[] tempArray = File.ReadAllLines(myFilename, Encoding.Default);
                char[] charsToTrim = { '*', ' ', '\'', '"' };
                //Thread myThreadLabels = new Thread(() => DbAttribs.__insertLabels(labelArray));
                if (tempArray.Length > 0)
                {
                    substrings = tempArray[0].Split(delimiter);
                    if (substrings.LongCount() == 13)
                    {
                        try
                        {
                            Convert.ToInt32(substrings[1]);

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Keine gültige Warenliste Datei");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Keine gültige Warenliste Datei");
                        return;
                    }
                    List<Item> itemList = new List<Item>();
                    Cursor = Cursors.WaitCursor;
                    foreach (var item in tempArray)
                    {
                        Item myItem = new Item();

                        substrings = item.Split(delimiter);
                        string temp = substrings[0].Trim(charsToTrim);
                        myItem.ItemNumber = substrings[0];
                        myItem.AccountID = substrings[1];
                        temp = substrings[2];
                        temp = temp.Trim(charsToTrim);
                        myItem.ItemDescription = temp.Replace("'", "''");
                        temp = substrings[3];
                        temp = temp.Trim(charsToTrim);
                        myItem.Size = temp.Replace("'", "''"); //Size
                        temp = substrings[4];
                        temp = temp.Trim(charsToTrim);
                        myItem.Brand = temp.Replace("'", "''"); //brand
                        temp = substrings[5];
                        temp = temp.Trim(charsToTrim);
                        myItem.Prop = temp.Replace("'", "''");  //properties
                        temp = substrings[6];
                        temp = temp.Trim(charsToTrim);
                        myItem.Color = temp.Replace("'", "''"); //color
                        myItem.SalesPrice = substrings[7];
                        myItem.CostPrice = substrings[8];
                        myItem.BeginDate = substrings[9];
                        myItem.EndDate = substrings[10];
                        myItem.SoldDate = substrings[11];
                        myItem.PayoutDate = substrings[12];
                        myItem.ContractID = myContractID;
                        myItem.DeleteDate = "";

                        itemList.Add(myItem);
                    }

                    DbItems.InsertItems(itemList);
                    MessageBox.Show(" Artikel wurden eingefügt ");

                    List<ConfigData> myConfigData = new List<ConfigData>();
                    myConfigData = DbItems.GetConfigData();
                    List<Contract> contractList = DbItems.GetAllContracts();
                    Contract contract = new Contract();
                    List<int> myItemNumberList = new List<int>();
                    int val = 0;
                    foreach (var item in itemList)
                    {
                        if (Int32.TryParse(item.ItemNumber, out val))
                            myItemNumberList.Add(val);
                        else
                            MessageBox.Show("ItemNumber failed = " + item.ItemNumber);
                    }
                    myItemNumberList.Sort();
                    string aktItemNumber = myItemNumberList.Max().ToString();
                    List<Item> myLastItem = DbItems.GetItemsWithItemNumber(aktItemNumber);
                    if (myConfigData.Count > 0)
                    {
                        if (!(String.Compare(myConfigData[0].LastContractID, myContractID) > 0))
                        {
                            myConfigData[0].LastContractID = myContractID;
                            contract.AccountID = myLastItem[0].AccountID;
                            contract.ContractID = myContractID;
                            DbItems.InsertContract(contract);
                        }
                        if (String.Compare(myConfigData[0].LastItemNumber, aktItemNumber)<0)
                        {
                            myConfigData[0].LastItemNumber = aktItemNumber ; //neue eingelesene itemNumber
                            DbItems.UpdateConfigDat(myConfigData[0]);
                        }
                    }

                    if (contractList.Count <= 0)
                    {
                        contract.ContractID = myContractID;
                        DbItems.InsertContract(contract);
                    }
                    Cursor = Cursors.Default;

                    warenlisteEinlesenToolStripMenuItem.Visible = false;
                    KundenlisteEinlesenToolStripMenuItem.Visible = false;
                    DeletedEinlesenToolStripMenuItem.Visible = false;
                }
            }
        }
        //Dient dem Einlesen der gelöschten Liste aus dem Cincom Programm
        private void ReadAllDeletedItemsFromFile(string myFilename)
        {
            Char delimiter = ';';
            string[] substrings;
            //string myFilename = "\\Warenliste.dta";
            string myToday = DateTime.Today.ToShortDateString();
            string year = myToday.Substring(6, 4).Substring(2, 2);
            string myContractID = year + "0000";
            if (File.Exists(myFilename))
            {
                string[] tempArray = File.ReadAllLines(myFilename, Encoding.Default);
                char[] charsToTrim = { '*', ' ', '\'', '"' };
                //Thread myThreadLabels = new Thread(() => DbAttribs.__insertLabels(labelArray));
                if (tempArray.Length > 0)
                {
                    substrings = tempArray[0].Split(delimiter);
                    if (substrings.LongCount() == 13)
                    {
                        try
                        {
                            Convert.ToInt32(substrings[1]);

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Keine gültige Warenliste Datei");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Keine gültige Warenliste Datei");
                        return;
                    }
                    List<Item> itemList = new List<Item>();
                    Cursor = Cursors.WaitCursor;
                    foreach (var item in tempArray)
                    {
                        Item myItem = new Item();

                        substrings = item.Split(delimiter);
                        string temp = substrings[0].Trim(charsToTrim);
                        myItem.ItemNumber = substrings[0];
                        myItem.AccountID = substrings[1];
                        temp = substrings[2];
                        temp = temp.Trim(charsToTrim);
                        myItem.ItemDescription = temp.Replace("'", "''");
                        temp = substrings[3];
                        temp = temp.Trim(charsToTrim);
                        myItem.Size = temp.Replace("'", "''"); //Size
                        temp = substrings[4];
                        temp = temp.Trim(charsToTrim);
                        myItem.Brand = temp.Replace("'", "''"); //brand
                        temp = substrings[5];
                        temp = temp.Trim(charsToTrim);
                        myItem.Prop = temp.Replace("'", "''");  //properties
                        temp = substrings[6];
                        temp = temp.Trim(charsToTrim);
                        myItem.Color = temp.Replace("'", "''"); //color
                        myItem.SalesPrice = substrings[7];
                        myItem.CostPrice = substrings[8];
                        myItem.BeginDate = substrings[9];
                        myItem.EndDate = substrings[10];
                        myItem.SoldDate = "";
                        myItem.PayoutDate = "";
                        myItem.ContractID = myContractID;
                        temp = substrings[11];
                        if (temp != "nil")
                            myItem.DeleteDate = temp; 
                        else
                            myItem.DeleteDate = substrings[10];
                        itemList.Add(myItem);
                    }
                    DbItems.InsertItems(itemList);
                    Cursor = Cursors.Default;
                    MessageBox.Show(" Artikel wurden eingefügt ");

                    warenlisteEinlesenToolStripMenuItem.Visible = false;
                    KundenlisteEinlesenToolStripMenuItem.Visible = false;
                    DeletedEinlesenToolStripMenuItem.Visible = false;
                }
            }
        }
        //Dient dem Einlesen der Kundenliste aus dem Cincom Programm
        private void ReadAllVendorsFromFile(string myFilename)
        {
            Char delimiter = ';';
            string[] substrings;

            if (File.Exists(myFilename))
            {
                string[] tempArray = File.ReadAllLines(myFilename, Encoding.Default);
                char[] charsToTrim = { '*', ' ', '\'', '"' };
                
                if (tempArray.Length > 0)
                {
                    substrings = tempArray[0].Split(delimiter);
                    if (substrings.LongCount() == 13)
                    {
                        try
                        {
                            Convert.ToInt32(substrings[1]);
                            MessageBox.Show("Keine gültige Kundendatei");
                            return;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("Keine gültige Kundendatei");
                        return;
                    }
                    List<Vendor> vendorList = new List<Vendor>();
                    Cursor = Cursors.WaitCursor;
                    foreach (var item in tempArray)
                    {
                        Vendor myVendor = new Vendor();
                        int temp1;

                        substrings = item.Split(delimiter);

                        string temp = substrings[0].Trim(charsToTrim);
                        myVendor.AccountID = temp;

                        temp = substrings[1].Trim(charsToTrim);
                        myVendor.LastName = temp;

                        temp = substrings[2].Trim(charsToTrim);
                        myVendor.FirstName = temp;

                        temp = substrings[3].Trim(charsToTrim);
                        myVendor.Annex1 = temp;

                        temp = substrings[4].Trim(charsToTrim);
                        myVendor.Annex2 = temp;

                        temp = substrings[5].Trim(charsToTrim);
                        myVendor.Street = temp;

                        temp = substrings[6].Trim(charsToTrim);
                        myVendor.Plz = temp;

                        temp = substrings[7].Trim(charsToTrim);
                        myVendor.Town = temp;

                        temp = substrings[8].Trim(charsToTrim);
                        myVendor.PhoneNumber1 = temp;

                        temp = substrings[9].Trim(charsToTrim);
                        myVendor.PhoneNumber2 = temp;

                        temp = substrings[10].Trim(charsToTrim);;
                        myVendor.EmailAccount = temp;

                        try
                        {
                            temp1 = Convert.ToInt32(substrings[11]);
                        }
                        catch (Exception)
                        {

                            temp1 = 50;
                        }
                        myVendor.Margin = temp1;

                        try
                        {
                            temp1 = Convert.ToInt32(substrings[12]);
                        }
                        catch (Exception)
                        {

                            temp1 = 90;
                        }
                        myVendor.Period = temp1;

                        vendorList.Add(myVendor);
                    }
                    Cursor = Cursors.Default;
                    DbVendors.InsertPersons(vendorList);
                    //Vendors Combobox füllen
                    CustomersList = DbVendors.GetAllVendorsName();
                    foreach (var item in CustomersList)
                    {
                        vendors.Add(item.FullInfo);
                    }
                    ComboBoxVendorName.DataSource = vendors;
                    ComboBoxVendorName.Text = "";
                    MessageBox.Show(" Kunden wurden eingefügt ");
                    warenlisteEinlesenToolStripMenuItem.Visible = false;
                    KundenlisteEinlesenToolStripMenuItem.Visible = false;
                    DeletedEinlesenToolStripMenuItem.Visible = false;
                }
            }
        }
        //Liest alle Postleitzahlen aus einer TextDatei in AppData/Roaming
        private void ReadAllPlzFromFile(string myFilename)
        {
            Char delimiter = ',';
            string[] substrings;

            if (File.Exists(myFilename))
            {
                string[] tempArray = File.ReadAllLines(myFilename, Encoding.UTF8);
                char[] charsToTrim = { '*', ' ', '\'', '"' };

                if (tempArray.Length > 0)
                {
                    substrings = tempArray[1].Split(delimiter);
                    if (substrings.LongCount() == 4)
                    {
                        try
                        {
                            int test = Convert.ToInt32(substrings[0]);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Keine gültige PLZ Datei");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Keine gültige PLZ Datei");
                        return;
                    }
                    List<ZIPCode> zipCodeListList = new List<ZIPCode>();
                    Cursor = Cursors.WaitCursor;
                    int index = 0;
                    foreach (var item in tempArray)
                    {
                        if (index > 0)
                        {
                            ZIPCode myZipCode = new ZIPCode();

                            substrings = item.Split(delimiter);

                            string temp = substrings[0].Trim(charsToTrim);
                            myZipCode.osm_id = temp;

                            temp = substrings[1].Trim(charsToTrim);
                            myZipCode.Ort = temp;

                            temp = substrings[2].Trim(charsToTrim);
                            myZipCode.PLZ = temp;

                            temp = substrings[3].Trim(charsToTrim);
                            myZipCode.Bundesland = temp;

                            zipCodeListList.Add(myZipCode);
                        }
                        index++;
                    }
                   
                    DbZipCode.InsertZipCodes(zipCodeListList);
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Methods after application loaded
        /// <summary>
        /// Called as a Teil des Mainwindow Constructors 
        /// </summary>
        private void Setup()
        {
            string aktItemNumber = null;
            string myBackupFileName;
            //string connectionStringName = "SecondHandCollection";


            AppDataDirectory = Helper.AppDataDirectory;
            if (!Directory.Exists(AppDataDirectory))
            {
                Directory.CreateDirectory(AppDataDirectory);
            }

            WorkingDirectory = Helper.WorkingDirectory;
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            BackupDirectory = Helper.BackupDirectory;
            if (!Directory.Exists(BackupDirectory))
            {
                Directory.CreateDirectory(BackupDirectory);
            }

            //string ConnectionString = "Data Source=" + WorkingDirectory + Helper.MyDBFilename + "; version=3;";
            //Helper.AddUpdateConnectionStringSettings(connectionStringName, ConnectionString);

            AccountIDTextBox.Text = "";
            SalesPriceTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0.0);
            MarginTextBox.Text = string.Format("{0} %", 0);
            ComboBoxVendorName.Focus();
            ComboBoxItemDescription.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SalesPriceTextBox.ReadOnly = true;

            //Kundeneingabe Buttons enablen
            ComboBoxVendorName.Enabled = true;
            NewCustomerButton.Enabled = true;
            ItemsDataGridView.ScrollBars = ScrollBars.Vertical;
            ContractSaveBtn.Enabled = false;
            ClearBtn.Enabled = false;
            GoodsInOKButton.Enabled = false;

            //Lizensierung überprüfen
            LicenseFile = AppDataDirectory + "\\2nd.dta";
            if (File.Exists(LicenseFile))
            {
                SerNo = Store.ReadSerNoFromFile(LicenseFile);
                LicenseNo = Store.ReadLicenseNoFromFile(LicenseFile);
                if (!String.IsNullOrEmpty(LicenseNo))
                {   //License File vorhanden
                    //Schlüsselnummern in Array einlesen
                    Hashtable keys = Store.GetKeyList();
                    //Die letzten beiden Ziffern der Seriennummer extrahieren ist key
                    int key = Convert.ToInt32(SerNo.Substring(SerNo.Length - 2, 2));
                    if (keys.ContainsKey(key))
                    {
                        //keyValue ist der zugehörige Wert in der Schlüsselliste
                        string keyValue = keys[key].ToString();

                        //Prüfen ob md5 Wert von value in Datei gespeichert
                        if (LicenseNo == Store.StringtoMD5(keyValue))
                        {
                            Licensed = true;
                            SchlüsselEingebenToolStripMenuItem.Enabled = false;
                            this.Text = "Kommissionswaren Secondhand Kleidung (Lizensiert)";
                            this.Invalidate();
                        }
                        else
                        {
                            Licensed = false;
                            SchlüsselEingebenToolStripMenuItem.Enabled = true;
                            this.Text = "Kommissionswaren Secondhand Kleidung (Demo)";
                        }
                    }
                }
            }
            else
            {
                //Erste Installation des Programms keine Dataie vorhanden
                Guid myGUID;
                // Create GUID.
                myGUID = Guid.NewGuid();
                //Eine Seriennummer anhand des Datums bilden
                SerNo = Convert.ToString(Store.DateTimeToUnixTimestamp(DateTime.Now));
                //Seriennummer in Datei speichenrn
                Store.WriteSernoToFile(SerNo, LicenseFile);
            }


            //Neues Backup anlegen Ein Backup pro Tag max 7
            string myAktDate = DateTime.Today.ToShortDateString();
            myAktDate = myAktDate.Replace('.', '_');
            myBackupFileName = "\\SecondHandCollection_" + myAktDate + ".db";

            if (!File.Exists(Helper.WorkingDirectory + Helper.MyDBFilename))
            {
                Directory.CreateDirectory(Helper.WorkingDirectory);
                Directory.CreateDirectory(BackupDirectory);
                DbItems.CreateDataBase(Helper.WorkingDirectory + Helper.MyDBFilename);
                File.Copy((Helper.WorkingDirectory + Helper.MyDBFilename), (BackupDirectory + myBackupFileName), true);

            }
            else
            {
                int myBackupFilesCount = Store.GetFilesCount(BackupDirectory, "*.db");
                if (myBackupFilesCount > 0)
                {
                    string myNewestBackupFileName = Store.GetNewestFileName(BackupDirectory, "*.db");
                    if (myNewestBackupFileName != myBackupFileName)
                    {
                        if (!File.Exists(BackupDirectory + myBackupFileName))
                        {
                            File.Copy(Helper.WorkingDirectory + Helper.MyDBFilename, BackupDirectory + myBackupFileName);
                        }

                        if (myBackupFilesCount > 7)
                        {
                            string myOldestBackupFileName = Store.GetOldestFileName(BackupDirectory, "*.db");
                            if (File.Exists(BackupDirectory + myBackupFileName))
                            {
                                File.Delete(BackupDirectory + "\\" + myOldestBackupFileName);
                            }
                        }
                    }
                }
            }

            //List<Contract> myContractsList = DbItems.GetAllTotalNumberOfContracts();
            //Artikelliste einlesen
            ItemsList = DbItems.GetAllItems();
            ItemsCount = ItemsList.Count;

            //Kundendaten einlesen
            DbVendors.GetAllVendors();

            //Postleitzahlen
            List<ZIPCode> myZipCodes = DbZipCode.GetAllZIPCodes();

            //Programmabbruch wenn 1000 Artikel und keine Lizenz
            if (ItemsCount >= 1000 && !Licensed)
            {
                MessageBox.Show("Senden Sie die Seriennummer: " + SerNo + " für eine Lizensierung an info@chairfit.de \n Lebenslange Lizenz € 150,- (auf bis zu 3 Geräten)");
                //Automatisch mail senden ? über WEB ? Mail Programm öffnen
            }
            else  //Datenkonsistenz überprüfen
            {
                if (ItemsCount > 0)
                {
                    List<int> myItemNumberList = new List<int>();
                    List<Item> myItemsList = new List<Item>();
                    //myItemsList = DbItems.GetAllItems();
                    int val = 0;
                    foreach (var item in ItemsList)
                    {
                        if (Int32.TryParse(item.ItemNumber, out val))
                            myItemNumberList.Add(val);
                    }
                    myItemNumberList.Sort();
                    aktItemNumber = myItemNumberList.LastOrDefault().ToString();
                    //List<ItemAllGroupedByItemNumber> myGroupedItemList1 = DbItems.GetAllItemsGroupedByItemNumber();
                    //aktItemNumber = myGroupedItemList1.Last().ItemNumber;
                    ////Für den Fall, dass Fehler in ConfigData
                    LastItemNumber = DbItems.GetLastItemNumber(); //aus configData

                    if (LastItemNumber != aktItemNumber)
                    {
                        //LastItemNumber in items ungleich LastItemNumber in configData
                        MessageBox.Show("Achtung Dateninkonsistenz, LastItemNumber = " + LastItemNumber + " aktItemNumber = " + aktItemNumber + "  Wiederherstellung mit letztem Backup empfohlen");
                        return;
                    }

                }

                //Test ob Jahreswechsel
                if (Store.YearChanged(LastContractID))
                {
                    List<ConfigData> myConfigData = DbItems.GetConfigData();
                    myConfigData[0].LastContractID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                    myConfigData[0].LastInvoiceID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                    myConfigData[0].LastItemNumber = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                    DbItems.UpdateConfigDat(myConfigData[0]);
                }
                //Aufträge mit Abrechnungsdatum alter als 12 Monate archivieren.
                string myTestString = DateTime.Today.AddMonths(-12).ToShortDateString();
                //MessageBox.Show("Datum vor 12 Monaten " + myTestString);

            }
            //Die Listen mit Artikeleigenschaften füllen (Comboboxen)
            FillAttributeTables();
        }

        private void Disp()
        {
            AktDateTextBox.Text = DateTime.Today.ToShortDateString();
            _ignoreEvents = true;
            ComboBoxVendorName.Text = "";
        }

        //Markieren einer bestimmten Zeile im DataGridView
        private void ShowSelectedRow(int anIndex)
        {
            if (anIndex >= ItemsDataGridView.Rows.Count)
            {
                ItemsDataGridView.FirstDisplayedScrollingRowIndex = ItemsDataGridView.Rows.Count - 1;
                ItemsDataGridView.Rows[ItemsDataGridView.Rows.Count - 1].Selected = true;
            }
            else
            {
                ItemsDataGridView.FirstDisplayedScrollingRowIndex = anIndex;
                ItemsDataGridView.Rows[anIndex].Selected = true;
            }
        }

        /// <summary>
        /// Alle Comboboxen initialisieren
        /// </summary>
        private void FillAttributeTables()
        {
            //Alle Artikeleigenschaften einlesen; Beim ersten Aufruf des Programms Tabellen anlegen aus TextFiles
            //Textfiles wurden in AppData/Chairfit kopiert
            //Attribute tables from Files fill
           
            
            //Marken 
            bindinglistBrand = DbAttribs.GetAllBrands();

            //ComboBoxBrand.DataSource = labels;
            _ignoreEvents = true;
            try
            {
                bSourceBrand.DataSource = bindinglistBrand;
                ComboBoxBrand.DataSource = bSourceBrand;
            }
            finally
            {
                _ignoreEvents = false;
            }

            // Update List with all Itemdescription for Itemdescription ComboBox
            bindinglistItemdescription = DbAttribs.GetAllItemDescriptionFromItems();
            _ignoreEvents = true;
            try
            {
                bindinglistItemdescription.Add("");
                bSourceItemdescription.DataSource = bindinglistItemdescription;
                ComboBoxItemDescription.DataSource = bSourceItemdescription;
            }
            finally
            {
                _ignoreEvents = false;
            }

            //Farben
            bindinglistColor = DbAttribs.GetAllColors();

            //ComboBoxColor.DataSource = colors;
            _ignoreEvents = true;
            try
            {
                bSourceColor.DataSource = bindinglistColor;
                ComboBoxColor.DataSource = bSourceColor;
            }
            finally
            {
                _ignoreEvents = false;
            }


            //Größen
            bindinglistSize = DbAttribs.GetAllSizes();

            _ignoreEvents = true;
            try
            {
                bSourceSize.DataSource = bindinglistSize;
                ComboBoxSize.DataSource = bSourceSize;
            }
            finally
            {
                _ignoreEvents = false;
            }

            _ignoreEvents = true;

            //Vendors Combobox füllen
            CustomersList = DbVendors.GetAllVendorsName();
            List<string> myFullInfoList = new List<string>();
            foreach (var item in CustomersList)
            {
                myFullInfoList.Add(item.FullInfo);
            }
            _ignoreEvents = true;
            try
            {
                //bSourceVendors.DataSource = myFullInfoList;
                ComboBoxVendorName.DataSource = myFullInfoList.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }

        }

        #endregion

        /// <summary>
        /// Creates a new Contract after selecting a vendor
        /// </summary>
        private void CreateNewContract()
        {
            string myAktYear = Convert.ToString(DateTime.Today.Year).Substring(2, 2);
            myAccountID = AccountIDTextBox.Text; //wird von VendorSearchWindow_Closed oder ComboboxCustomerName gefüllt
            CustomersList = DbVendors.GetVendorWithAccountID(myAccountID);
            Contract newContract = new Contract() { AccountID = myAccountID };
            if ((!Licensed && ItemsCount < 1000) || Licensed)
            {
                if (!String.IsNullOrWhiteSpace(AccountIDTextBox.Text) && CustomersList.Count > 0)
                {
                    if (!String.IsNullOrEmpty(CustomersList[0].AccountID))
                    {
                        //ContractID festlegen
                        myConfigData = DbItems.GetConfigData();
                        if (myConfigData.Count > 0)
                        {
                            myContractID = myConfigData[0].LastContractID;
                            myItemNumber = myConfigData[0].LastItemNumber;

                        }
                        //Neue Vertragsnummer und Itemnummer erzeugen
                        myContractID = Store.IncrementContractID(myContractID);
                        myItemNumber = Store.IncrementItemNumber(myItemNumber);
                        ItemsNumberTextBox.Text = myItemNumber;

                        if (!String.IsNullOrEmpty(myContractID))
                        {
                            //Felder mit Daten füllen
                            _ignoreEvents = true;

                            FullNameTextBox.Text = CustomersList[0].LastName + " " + CustomersList[0].FirstName;
                            FullNameTextBox.Visible = true;
                            ComboBoxVendorName.Visible = false;

                            MarginTextBox.Text = string.Format("{0} %", Convert.ToString(CustomersList[0].Margin));
                            PeriodTextBox.Text = CustomersList[0].Period.ToString();
                            ContractNumberTextBox.Text = Item.ConvertContractIDToContractNumber(myContractID);
                            ComboBoxBrand.Text = "";
                            //ItemNumber festlegen


                            ExpirationDateTextBox.Text = DateTime.Today.AddDays(Convert.ToInt32(PeriodTextBox.Text)).ToShortDateString();
                            //now create new contract Data and save it in contracts

                            newContract = new Contract(myContractID, myAccountID, Convert.ToInt32(MarginTextBox.Text.Split(' ')[0]));

                            newContract.BeginDate = AktDateTextBox.Text;
                            newContract.EndDate = ExpirationDateTextBox.Text;

                            //neuen Vertrag eintragen
                            DbItems.InsertContract(newContract);

                            //contract Number in configData eintragen
                            myConfigData[0].LastContractID = myContractID;
                            DbItems.UpdateConfigDat(myConfigData[0]);

                            //now create item Data 
                            myItem.ContractID = Store.ConvertContractNumberToContractID(ContractNumberTextBox.Text);
                            //myItem.AccountID = AccountIDTextBox.Text;
                            myItem.BeginDate = AktDateTextBox.Text;
                            myItem.EndDate = ExpirationDateTextBox.Text;
                            //Kundeneingabe Buttons disable
                            ComboBoxVendorName.Enabled = false;
                            NewCustomerButton.Enabled = false;

                            ComboBoxColor.Enabled = true;
                            ComboBoxBrand.Enabled = true;
                            TextBoxProperties.Enabled = true;
                            ComboBoxSize.Enabled = true;


                            SalesPriceTextBox.Enabled = true;
                            SalesPriceTextBox.ReadOnly = false;
                            myContractChanged = true;
                            ClearBtn.Enabled = true;
                            GoodsInOKButton.Enabled = true;
                            MarginTextBox.ReadOnly = false;
                            PeriodTextBox.ReadOnly = false;
                            ComboBoxItemDescription.Enabled = true;
                            ComboBoxItemDescription.Focus();
                            _ignoreEvents = false;

                        }
                    }
                    myContract = newContract;
                }
            }
            else
            {
                MessageBox.Show("Dies ist eine Demo Version, bitte Senden Sie die Seriennummer: " + SerNo + " für eine kostenlose Lizensierung an info@chairfit.de");
            }
        }

        #region Button Reaktionen

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            OpenVendorEditWindow();
            if (NewContract)
            {
                ComboBoxVendorName.Focus();
            }
        }

        private void GoodsInOKButton_Click(object sender, EventArgs e)
        {
            decimal mySalesPrice = 0, myMargin = 0, myCostPrice = 0;
            int myIndex;
            string mySalesPriceString;

            if (!String.IsNullOrEmpty(AccountIDTextBox.Text)) //Prüfen ob AccountID vorhanden
            {
                if (!String.IsNullOrEmpty(ComboBoxItemDescription.Text)) //Prüfen ob ItemBeschreibung eingegeben 
                {
                    if (!String.IsNullOrEmpty(SalesPriceTextBox.Text)) //Prüfen ob SalesPrice eingegeben - nur Zahlen erlaubt
                    {
                        mySalesPrice = Convert.ToDecimal((SalesPriceTextBox.Text).Split(' ')[0]); //Text in Dezimalzahl umwandeln

                        if (mySalesPrice > 0)
                        {
                            //Anzahl der Items (Einträge in Tabelle PosNumber)

                            myMargin = Convert.ToDecimal((MarginTextBox.Text.Split(' ')[0]));
                            myCostPrice = mySalesPrice - (mySalesPrice * myMargin) / 100; //wird in items gespeichert
                            mySalesPriceString = string.Format("{0,00} €", Convert.ToString(mySalesPrice));

                            //updaten der Itemsdaten
                            myItem.AccountID = myAccountID;
                            myItem.ContractID = Store.ConvertContractNumberToContractID(ContractNumberTextBox.Text);
                            myItem.ItemDescription = ComboBoxItemDescription.Text;
                            myItem.SalesPrice = Convert.ToString(mySalesPrice).Replace(",", ".");
                            myItem.CostPrice = Convert.ToString(myCostPrice).Replace(",", ".");
                            myItem.Color = ComboBoxColor.Text;
                            myItem.Brand = ComboBoxBrand.Text;
                            myItem.Prop = TextBoxProperties.Text;
                            myItem.Size = ComboBoxSize.Text; 
                            

                            if (!updateRecord) //Neues Item 
                            {   // Item in Tabelle einfügen
                                ItemsDataGridView.Rows.Add(
                                    ItemsNumberTextBox.Text,
                                    ComboBoxItemDescription.Text,
                                    ComboBoxBrand.Text,
                                    ComboBoxColor.Text,
                                    ComboBoxSize.Text,
                                    TextBoxProperties.Text,
                                    SalesPriceTextBox.Text);

                                myItem.ItemNumber = Store.BuildNumberToString(ItemsNumberTextBox.Text);
                                DbItems.InsertItem(myItem);
                                myConfigData[0].LastItemNumber = myItem.ItemNumber;
                                DbItems.UpdateConfigDat(myConfigData[0]);
                                //Neue ItemNumer erzeugen
                                ItemsNumberTextBox.Text = Store.IncrementItemNumber(ItemsNumberTextBox.Text);
                                MarginTextBox.ReadOnly = true;
                                PeriodTextBox.ReadOnly = true;
                                PhoneNumberTextBox.ReadOnly = true;
                                ComboBoxVendorName.Enabled = false;
                            }
                            else //vorhandenes Item wurde editiert
                            {
                                //ItemsDataGridView.SelectedRows[0].Cells[0].Value = ItemsNumberTextBox.Text;
                                ItemsDataGridView.SelectedRows[0].Cells[1].Value = ComboBoxItemDescription.Text;                                
                                ItemsDataGridView.SelectedRows[0].Cells[2].Value = ComboBoxBrand.Text;
                                ItemsDataGridView.SelectedRows[0].Cells[3].Value = ComboBoxColor.Text;
                                ItemsDataGridView.SelectedRows[0].Cells[4].Value = ComboBoxSize.Text;
                                ItemsDataGridView.SelectedRows[0].Cells[5].Value = TextBoxProperties.Text;
                                ItemsDataGridView.SelectedRows[0].Cells[6].Value = mySalesPriceString;

                                myItem.PayoutDate = AccountIDTextBox.Text;
                                myItem.ItemNumber = ItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                                DbItems.UpdateItem(myItem);
                                ComboBoxBrand.Text = "";
                                updateRecord = false;
                            }

                            myIndex = ItemsDataGridView.Rows.Count - 1;
                            int myIntIndex = myIndex / 17;
                            if (myIntIndex > 0)
                                ItemsDataGridView.FirstDisplayedScrollingRowIndex = 17 * myIntIndex;
                            myContract.NumberOfItems += 1;
                            DbItems.UpdateContract(myContract);
                            ComboBoxItemDescription.Text = "";
                            SalesPriceTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0.0);
                            ComboBoxBrand.SelectedIndex = 0;
                            ComboBoxColor.SelectedIndex = 0;
                            ComboBoxColor.Text = "";
                            TextBoxProperties.Text = "";
                            ComboBoxSize.SelectedIndex = 0;
                            ComboBoxSize.Text = "";
                            ContractSaveBtn.Enabled = true;
                            ComboBoxItemDescription.Focus();
                            PremiumLbl.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Bitte Verkaufspreis eingeben");
                            SalesPriceTextBox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bitte Verkaufspreis eingeben");
                        SalesPriceTextBox.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Bitte Artikelbeschreibung eingeben");
                    ComboBoxItemDescription.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bitte Lieferanten auswählen");
                ComboBoxVendorName.Focus();
            }
            GoodsInOKButton.Text = "Hinzufügen";
        }

        private void ContractCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContractPrintBtn_Click(object sender, EventArgs e)
        {
            //DocumentContract aufrufen
            OpenDocumentContract_Window();
            myContractChanged = false;
            //Egal ob gedruckt oder nicht, Vertrag bleibt mit Items gespeichert
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            //Vendorname enablen auf 0 setzen
            _ignoreEvents = true;

            NewCustomerButton.Enabled = true;
            ContractSaveBtn.Enabled = false;
            ComboBoxColor.Text = "";
            ComboBoxBrand.Text = "";
            TextBoxProperties.Text = "";
            ComboBoxSize.Text = "";
            ComboBoxColor.Enabled = false;
            ComboBoxBrand.Enabled = false;
            TextBoxProperties.Enabled = false;
            ComboBoxSize.Enabled = false;
            ComboBoxVendorName.Text = "";

            //Alle Textboxen inititalisieren
            AccountIDTextBox.Text = "";
            ItemsNumberTextBox.Text = "";
            ContractNumberTextBox.Text = "";
            SalesPriceTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0.0);
            MarginTextBox.Text = string.Format("{0} %", 0);
            PeriodTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
            ComboBoxItemDescription.Enabled = false;

            SalesPriceTextBox.ReadOnly = true;
            ComboBoxItemDescription.Text = "";

            //tabelle leeren
            int itemsCount = ItemsDataGridView.Rows.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                ItemsDataGridView.Rows.RemoveAt(0);
            }

            //alle Eingabefelder zurücksetzen
            //configdata updaten ContractId - 1, itemsnumber - tabelle.count

            //contract in contracts löschen
            DbItems.DeleteContract(myContractID);
            //alle item mit contractID löschen
            DbItems.DeleteAllItemsWithContractID(myContractID);
            //ConfigData updaten
            if (myConfigData.Count > 0) //Neuer Vertrag 
            {
                myContractID = Convert.ToString((Convert.ToInt32(myContractID) - 1));
                myConfigData[0].LastContractID = myContractID;
                myItemNumber = Convert.ToString((Convert.ToInt32(myItemNumber) - 1));
                myConfigData[0].LastItemNumber = myItemNumber;
                DbItems.UpdateConfigDat(myConfigData[0]);
            }
            myContractChanged = false;
            ClearBtn.Enabled = false;
            FullNameTextBox.Visible = false;
            ComboBoxVendorName.Enabled = true;
            ComboBoxVendorName.Visible = true;
            ComboBoxVendorName.SelectedIndex = -1;
            ComboBoxVendorName.Focus();

            //CustomerNameLeft = false;
        }

        private void ContractSaveBtn_Click(object sender, EventArgs e)
        {
            //Da alle items bereits gespeichert wurden nur alle Felder leeren

            _ignoreEvents = true;

            if (ComboBoxColor.Items.Count >= 0)
                ComboBoxColor.SelectedIndex = 0;
            if (ComboBoxBrand.Items.Count >= 0)
                ComboBoxBrand.SelectedIndex = 0;
            //if (TextBoxProperties.Items.Count >= 0)
            //    TextBoxProperties.SelectedIndex = 0;
            if (ComboBoxSize.Items.Count >= 0)
                ComboBoxSize.SelectedIndex = 0;
            if (ComboBoxVendorName.Items.Count >= 0)
                ComboBoxVendorName.SelectedIndex = 0;

            ComboBoxColor.Text = "";
            ComboBoxBrand.Text = "";
            TextBoxProperties.Text = "";
            ComboBoxSize.Text = "";
            myContractChanged = false;

            ClearBtn.Enabled = false;
            //CustomerNameLeft = false;
            MarginTextBox.ReadOnly = true;
            PeriodTextBox.ReadOnly = true;
            //Ausdruck Formular öffnen
            OpenDocumentContract_Window();

            //Alle Textboxen inititalisieren
            AccountIDTextBox.Text = "";
            ItemsNumberTextBox.Text = "";
            ContractNumberTextBox.Text = "";
            SalesPriceTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0.0);
            MarginTextBox.Text = string.Format("{0} %", 0);
            PeriodTextBox.Text = "";
            PhoneNumberTextBox.Text = "";

            //Tabelle leeren
            int itemsCount = ItemsDataGridView.Rows.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                ItemsDataGridView.Rows.RemoveAt(0);
            }

            //Kundeneingabe Buttons enablen
            ComboBoxVendorName.SelectedIndex = -1;
            FullNameTextBox.Visible = false;
            ComboBoxVendorName.Visible = true;
            ComboBoxVendorName.Enabled = true;
            ComboBoxItemDescription.Enabled = false;
            ComboBoxColor.Enabled = false;
            ComboBoxBrand.Enabled = false;
            TextBoxProperties.Enabled = false;
            ComboBoxSize.Enabled = false;
            SalesPriceTextBox.ReadOnly = true;
            NewCustomerButton.Enabled = true;
            ContractSaveBtn.Enabled = false;
            ComboBoxVendorName.Focus();
        }

        private void BtnReporting_Click(object sender, EventArgs e)
        {
            OpenReport_Window();
        }

        private void BtnCashCount_Click(object sender, EventArgs e)
        {
            CheckoutWindow CheckoutWin = new CheckoutWindow();
            CheckoutWin.Show();
        }

        private void BtnItemsOut_Click(object sender, EventArgs e)
        {
            //Call the Window to mark the sold Items and show Sum to pay for a specific vendor
            OpenItemOut_Window();
        }
        #endregion

        //MainMenu aufrufen
        #region MainMenu Buttons

        private void BackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.

            this.Cursor = Cursors.WaitCursor;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                RestoreDirectory = true,
                OverwritePrompt = true,
                // Initialize the SaveFileDialog to specify the SQlite extension for the file.
                InitialDirectory = "E:\\",
                FileName = "SecondHandCollection.db",
                DefaultExt = WorkingDirectory + ".db",
                Filter = "Datenbank Dateien|*.db"
            };

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK &&
               saveFileDialog1.FileName.Length > 0)
            {
                //Save das Database File
                File.Copy(WorkingDirectory + "\\SecondHandCollection.db", saveFileDialog1.FileName, true);
                MessageBox.Show($"Backup gespeichert in {saveFileDialog1.FileName} ");
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Backup Drive for automatic Backup define
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaufwerkFürBackupFestlegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Backup Laufwerk festlegen
            MessageBox.Show("BackupLaufwerk festlegen");
            //Backup Laufwerk festlegen
            //Konfigurationsdaten einlesen; letzte Auftragsnummer, letzte Artikelnummer
            List<ConfigData> myConfigData = DbItems.GetConfigData();
            string myBackupDrive = GetBackupDrive();
            string myBackupDirectory = "";
            myBackupDirectory = myBackupDrive + "PinkSecondHand\\Backup\\";
            myConfigData[0].BackupDirectory = myBackupDirectory;
            Directory.CreateDirectory(myBackupDirectory);
            DbItems.UpdateConfigDat(myConfigData[0]);
            //Backup Laufwerk festlegen
            MessageBox.Show($"BackupLaufwerk {myBackupDrive} festgelegt");
            ComboBoxVendorName.Focus();
        }

        private void BackupAutomatischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string FileName = "SecondHandCollection.db";
            //Konfigurationsdaten einlesen; letzte Auftragsnummer, letzte Artikelnummer
            List<ConfigData> myConfigData = DbItems.GetConfigData();

            string myBackupDirectory = myConfigData[0].BackupDirectory;
            
            try
            //Save das Database File
            {
                File.Copy(WorkingDirectory + "\\" + FileName, myBackupDirectory + FileName, true);
                MessageBox.Show($"Backup gespeichert in {myBackupDirectory}  {FileName} ");
            }
            catch
            {
                //Backup Laufwerk nicht gefunden
                MessageBox.Show("Noch kein Backup Laufwerk festgelegt oder Laufwerk nicht vorhanden \n BackupLaufwerk festlegen");
                //Backup Laufwerk festlegen
                string myBackupDrive = GetBackupDrive();
                myBackupDirectory = myBackupDrive + "PinkSecondHand\\Backup\\";
                myConfigData[0].BackupDirectory = myBackupDirectory;
                Directory.CreateDirectory(myBackupDirectory);
                File.Copy(WorkingDirectory + FileName, myBackupDirectory + FileName, true);
                MessageBox.Show($"Backup gespeichert in {myBackupDirectory}{FileName} ");
                DbItems.UpdateConfigDat(myConfigData[0]);
            }
            this.Cursor = Cursors.Default;
            ComboBoxVendorName.Focus();
        }

        private string GetBackupDrive()
        {
            string myBackupDrive="";
            SaveFileDialog mySaveFileDialog = new SaveFileDialog()
            {
                RestoreDirectory = true,
                OverwritePrompt = true,
                // Initialize the SaveFileDialog to specify the SQlite extension for the file.
                InitialDirectory = "E:\\",
                FileName = "SecondHandCollection.db",
                DefaultExt = ".db",
                Filter = "Datenbank Dateien|*.db"
            };

            if (mySaveFileDialog.ShowDialog() == DialogResult.OK &&
                mySaveFileDialog.FileName.Length > 0)
            {
                myBackupDrive = mySaveFileDialog.FileName;
                int myIndex = myBackupDrive.IndexOf("SecondHandCollection.db");
                myBackupDrive = myBackupDrive.Substring(0, myIndex);
            }

            return myBackupDrive;
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //eine sqliteDatei auswählen und die sqlite Datei im WorkingDirectory überschreiben
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                RestoreDirectory = true,
                OverwritePrompt = false,
                // Initialize the SaveFileDialog to specify the SQlite extension for the file.
                InitialDirectory = "D:\\",
                //FileName = "SecondHandCollection.sqlite",
                DefaultExt = WorkingDirectory + ".db",
                Filter = "Datenbank Dateien|*.db"
            };

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK &&
               saveFileDialog1.FileName.Length > 0)
            {
                //Save das Database File
                FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                if (fi.Length > 0)
                {
                    //prüfen ob Datei eine sqlite - Datei ist -

                    if (MessageBox.Show("Vorhandene Daten mit Wiederherstellungsdaten überschreiben?", "Achtung",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        File.Copy(saveFileDialog1.FileName, WorkingDirectory + "\\SecondHandCollection.db", true);
                        MessageBox.Show("Daten aus Backup wieder hergesetellt");
                        Disp();
                    }
                }
                else
                    MessageBox.Show("Datei enthält keine Daten");
            }
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nach Backup fragen
            Close();
        }

        private void StammdatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Eingabe der Eignerdaten
            //Aufrufen des Eingabefensters Owneredit

            OpenOwnerEdit_Window();

        }

        private void LieferantenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // VendorTable.ShowDialog();
            OpenVendorTableWindow();
        }

        private void UmsätzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashVolumeMonthlyWindow CashVolumeMonthlyWin = new CashVolumeMonthlyWindow();
            CashVolumeMonthlyWin.Show();
        }

        private void AuswertungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenReport_Window();
        }

        private void KassenabschlussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckoutWindow CheckoutWin = new CheckoutWindow();
            CheckoutWin.Show();
        }

        private void RefundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenRefund_Window();
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.SerNo = SerNo;
            infoWindow.ShowDialog();
        }

        private void SchlüsselEingebenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenKeyInput_Window();
        }

        private void WarenlisteEinlesenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //eine sqliteDatei auswählen und die sqlite Datei im WorkingDirectory überschreiben
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog openFileDialog1 = new SaveFileDialog()
            {
                RestoreDirectory = true,
                OverwritePrompt = false,
                // Initialize the SaveFileDialog to specify the SQlite extension for the file.
                InitialDirectory = "C:\\" + WorkingDirectory,
                //FileName = "SecondHandCollection.sqlite",
                DefaultExt = ".dat",
                Filter = "Daten Dateien|*.dta"
            };

            // Determine if the user selected a file name from the saveFileDialog.
            if (openFileDialog1.ShowDialog() == DialogResult.OK &&
               openFileDialog1.FileName.Length > 0)
            {
                //Save das Database File
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Length > 0)
                {
                    //prüfen ob Datei eine sqlite - Datei ist -
                    ReadAllItemsFromFile(openFileDialog1.FileName);
                    Disp();
                }
                else
                    MessageBox.Show("Datei enthält keine Daten");
            }
        }

        private void KundenlisteEinlesenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a OpenFileDialog to request a path and file name to open.
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                RestoreDirectory = true,
                // Initialize the SaveFileDialog to specify the SQlite extension for the file.
                InitialDirectory = "C:\\ + WorkingDirectory",
                //FileName = "SecondHandCollection.sqlite",
                DefaultExt = ".dat",
                Filter = "Daten Dateien|*.dta"
            };

            // Determine if the user selected a file name from the saveFileDialog.
            if (openFileDialog1.ShowDialog() == DialogResult.OK &&
               openFileDialog1.FileName.Length > 0)
            {
                //Save das Database File
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Length > 0)
                {
                    //prüfen ob Datei eine korrekte customer.dat - Datei ist -

                    ReadAllVendorsFromFile(openFileDialog1.FileName);
                    Disp();
                }
                else
                    MessageBox.Show("Datei enthält keine Daten");
            }
        }

        private void DeletedEinlesenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a OpenFileDialog to request a path and file name to open.
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                RestoreDirectory = true,
                // Initialize the SaveFileDialog to specify the SQlite extension for the file.
                InitialDirectory = "C:\\ + WorkingDirectory",
                //FileName = "SecondHandCollection.sqlite",
                DefaultExt = ".dat",
                Filter = "Daten Dateien|*.dta"
            };

            // Determine if the user selected a file name from the saveFileDialog.
            if (openFileDialog1.ShowDialog() == DialogResult.OK &&
               openFileDialog1.FileName.Length > 0)
            {
                //Save das Database File
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Length > 0)
                {
                    //prüfen ob Datei eine korrekte customer.dat - Datei ist -

                    ReadAllDeletedItemsFromFile(openFileDialog1.FileName);
                    Disp();
                }
                else
                    MessageBox.Show("Datei enthält keine Daten");
            }
        }

        private void EtikettDruckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Etiketten drucken für not implemented yet");
            //Aufrufen von LabelSelection Window
            LabelSelectionWindow MyLabelSelectionWindow = new LabelSelectionWindow()
            {
                // MyContractID = myContractID
            };
            MyLabelSelectionWindow.Show();
        }

        private void VertragDruckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractUI contractUI = new ContractUI();
            contractUI.Show();
        }
        #endregion


        //Kontextmenu Item aufrufen
        #region Kontextmenu Verträge aufrufen

        private void ItemDataContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (ItemsDataGridView.RowCount <= 0)
            {
                ItemDataContextMenuStrip.Items[0].Visible = false;
                ItemDataContextMenuStrip.Items[1].Visible = false;
            }
        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hier wird das Item gelöscht");
            //Die selectierte Row im ItemsDataGridView löschen
            //Die Contracts Tabelle updaten, (numberOfItems - 1, wenn numberOfItems 0 Datensatz in contracts löschen )
            //Selektierte Reihe löschen
            if (ItemsDataGridView.SelectedRows.Count > 0 &&
                    ItemsDataGridView.SelectedRows[0].Index <=
                     ItemsDataGridView.Rows.Count - 1)
            {
                if (ItemsDataGridView.Rows.Count > 1)
                {
                    int myIndex = 0;
                    DialogResult result = MessageBox.Show("Artikel wirklich löschen?",
                         "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    myIndex = ItemsDataGridView.SelectedRows[0].Index;
                    if (result == DialogResult.Yes)
                    {
                        //selektiertes Item löschen
                        //prüfen ob item noch nicht verkauft
                        bool myIsSold = false;
                        string myItemNumber = ItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                        ItemsList = DbItems.GetItemsWithItemNumber(myItemNumber);
                        if (ItemsList.Count == 1)
                        {
                            if (!String.IsNullOrEmpty(ItemsList[0].SoldDate))
                            {
                                myIsSold = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Fehler in Datenbasis, bitte letztes Backup aufrufen.");
                        }

                        if (!myIsSold)
                        {
                            //Artikel löschen
                            DbItems.DeleteItem(myItemNumber);
                            ItemsDataGridView.Rows.RemoveAt(myIndex);
                            //alle Items dieses Vertrages

                            //Update ContractData Anzahl der items dieser Position
                            myContract.NumberOfItems = myContract.NumberOfItems - 1;
                            DbItems.UpdateContract(myContract);

                            //vorheriges item selektieren und ScrollingRowIndex setzen
                            myIndex = myIndex > 0 ? myIndex - 1 : 0;
                            ItemsDataGridView.Rows[myIndex].Selected = true;
                            myIndex = ItemsDataGridView.Rows.Count - 1;
                            int myIntIndex = myIndex / 17;
                            if (myIntIndex > 0)
                                ItemsDataGridView.FirstDisplayedScrollingRowIndex = 17 * myIntIndex;

                            //itemNumber im Grid neu erstellen, damit keine Itemnummer fehlt
                            //Lies erste Itemnummer im DataGrid
                            int myFirstItemnumber;
                            myFirstItemnumber = Convert.ToInt32(ItemsDataGridView.Rows[0].Cells[0].Value);
                            for (int i = 1; i < ItemsDataGridView.RowCount; i++)
                            {
                                ItemsDataGridView.Rows[i].Cells[0].Value = Convert.ToString(myFirstItemnumber + 1);
                            }
                            // Letzte Artikelnummer + 1 in TextBox eintragen
                            ItemsNumberTextBox.Text = Store.IncrementPosNumber(Convert.ToString(myFirstItemnumber));

                            //Änderung in Datenbasis eintragen
                            for (int i = 0; i < ItemsDataGridView.RowCount; i++)
                            {
                                DbItems.UpdateItemItemNumber(ItemsDataGridView.Rows[i].Cells[0].Value.ToString());
                            }

                            //Neue ItemNumer erzeugen
                            ItemsNumberTextBox.Text = Store.IncrementItemNumber(ItemsNumberTextBox.Text);

                            //Neue letzte Itemnummer in configdaten eintragen
                            myConfigData[0].LastItemNumber = myItem.ItemNumber;
                            DbItems.UpdateConfigDat(myConfigData[0]);

                        }
                        else
                            MessageBox.Show("Der Artikel ist bereits verkauft");
                    }
                }
                else
                    MessageBox.Show("Der Vertrag muss mindestens einen Artikel enthalten");
            }
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hier wird das Item bearbeitet");
            // Die selektierte Row in die Eingabefelder eintragen
            //updateRecord = true
            if (ItemsDataGridView.SelectedRows.Count > 0 &&
                 ItemsDataGridView.SelectedRows[0].Index <= ItemsDataGridView.Rows.Count - 1)
            {
                GoodsInOKButton.Text = "Speichern";
                
                ComboBoxItemDescription.Text = ItemsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                ComboBoxBrand.Text = ItemsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                ComboBoxColor.Text = ItemsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                ComboBoxSize.Text = ItemsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                TextBoxProperties.Text = ItemsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
                SalesPriceTextBox.Text = ItemsDataGridView.SelectedRows[0].Cells[6].Value.ToString();
                updateRecord = true;
            }
        }
        #endregion

        //Reaction on leaving a Textbox
        //reagiert beim verlassen einer Textbox
        private void TextBoxProperties_Leave(object sender, EventArgs e)
        {
            if (_ignoreEvents) { return; }
        }


        #region Daten für neuen Kunden eingeben
        private void ComboBoxVendorName_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                String value = ComboBoxVendorName.Text.ToString();
                if (!String.IsNullOrEmpty(value) && ComboBoxVendorName.SelectedIndex >= 0)
                {
                    char delimiter = ';';
                    String[] substrings = value.Split(delimiter);
                    if (substrings.Count() == 3)
                    {
                        myAccountID = substrings[2].Trim();

                        AccountIDTextBox.Text = myAccountID;
                        AccountIDTextBox.Enabled = true;
                        CreateNewContract();
                    }
                }        
            }
            else
            {
                _ignoreEvents = false;
            }
           
        }

        private void ComboBoxVendorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myAccountID;
            if (!_ignoreEvents)
            {
                if (ComboBoxVendorName.SelectedIndex >= 0)
                {
                    string test = (string)ComboBoxVendorName.SelectedItem;
                    //String value = ComboBoxVendorName.SelectedValue.ToString();
                    //ComboBoxVendorName.Text = value;
                    //AccountID finden letztes item im String
                    char delimiter = ';';
                    String[] substrings = test.Split(delimiter);
                    if (substrings.Count() == 3)
                    {
                        myAccountID = substrings[2].Trim();

                        AccountIDTextBox.Text = myAccountID;
                        AccountIDTextBox.Enabled = false;
                        CreateNewContract();
                    }
                }
            }
            else
                _ignoreEvents = false;
        }

        private void KeyTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty( KeyTextBox.Text))
            {
                //License Nummer aus 
                Hashtable keys = Store.GetKeyList();
                //Get Last to digits of SerialNumber

                int key = Convert.ToInt32( SerNo.Substring(SerNo.Length - 2, 2));
                if (keys.ContainsKey(key))
                {
                    string keyValue = keys[key].ToString();
                    //Prüfen ob md5 Wert von value in Datei gespeichert
                    if (keyValue == KeyTextBox.Text)
                    {
                        Licensed = true;
                        SchlüsselEingebenToolStripMenuItem.Enabled = false;
                        //Schlüssel in Datei eintragen
                        try
                        {
                            FileStream bw = new FileStream(LicenseFile, FileMode.Append, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(bw);
                            sw.Write(Store.StringtoMD5(keyValue));
                            sw.Close();
                            bw.Close();
                            MessageBox.Show("Die Vollversion ist freigeschaltet");
                            //Titel im Mainwindow ändern
                            Licensed = true;
                            SchlüsselEingebenToolStripMenuItem.Enabled = false;
                            this.Text = "Kommissionswaren Secondhand Kleidung (Lizensiert)";
                            this.Invalidate();
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                    else
                    {
                        Licensed = false;
                        SchlüsselEingebenToolStripMenuItem.Enabled = true;
                        MessageBox.Show("Der eingegebene Schlüssel ist nicht korrekt");
                    }
                }
            }
            KeyTextBox.Visible = false;
            KeyLabel.Visible = false;
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void ItemNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            ComboBoxItemDescription.Select();
            ComboBoxItemDescription.Enabled = true;
            SalesPriceTextBox.ReadOnly = false;
        }

        private void ItemCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void MarginTextBox_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(MarginTextBox.Text))
            {
                Decimal myMargin = Convert.ToDecimal((MarginTextBox.Text.Split(' ')[0]));
                if (myMargin > 100 || myMargin < 0)
                {
                    MessageBox.Show("Wert muss zwischen 0 und 100 liegen");
                }
                else
                {
                    //im Vertrag die Margin updaten evtl. die Provisionsumme
                    //bei den Items die Costprice anpassen
                    // 
                    decimal myProvisionSum = 0;
                    List<Item> myItemsList = DbItems.GetItemsWithContractID(myContractID);
                    foreach (var item in myItemsList)
                    {
                        //CostPrice anpassen wenn Item verkauft ProvisionSum akumulieren
                        item.CostPrice = Store.ConvertCurrencyToNumber(Convert.ToString(Convert.ToDecimal(item.SalesPrice) * (1 - myMargin / 100)));
                        if (!String.IsNullOrEmpty(item.SoldDate))
                            myProvisionSum += Convert.ToDecimal(item.SalesPrice) - Convert.ToDecimal(item.CostPrice);
                        DbItems.UpdateItem(item);
                    }
                    if (myProvisionSum > 0)
                    {
                        myContract.ProvisionSum = Store.ConvertCurrencyToNumber(Convert.ToString(myProvisionSum));
                    }
                    myContract.Margin = Convert.ToInt32((MarginTextBox.Text.Split(' ')[0]));
                    DbItems.UpdateContract(myContract);
                }
            }
        }

        private void MarginTextBox_Leave(object sender, EventArgs e)
        {
            if (Int16.TryParse(MarginTextBox.Text.Split(' ')[0], out short value))
                MarginTextBox.Text = string.Format("{0} %", Convert.ToString(value));
            else
                MarginTextBox.Text = string.Format("{0} %", "0");
            ComboBoxItemDescription.Focus();
        }

        private void PeriodTextBox_Leave(object sender, EventArgs e)
        {
            string myPeriod = PeriodTextBox.Text;
            if (Int16.TryParse(PeriodTextBox.Text, out short value))
            {
                PeriodTextBox.Text = string.Format("{0}", value);
                ExpirationDateTextBox.Text = DateTime.Today.AddDays(Convert.ToInt32(value)).ToShortDateString();
            }
            else
                PeriodTextBox.Text = string.Format("{0}", myPeriod);
            ComboBoxItemDescription.Focus();
        }

        private void SalesPriceTextBox_Leave(object sender, EventArgs e)
        {
            if (Double.TryParse((SalesPriceTextBox.Text.Split(' ')[0]), out double value))
                if (value > 0)
                    SalesPriceTextBox.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
                else
                    SalesPriceTextBox.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);
        }

        private void MarginTextBox_TextChanged(object sender, EventArgs e)
        {
            ComboBoxVendorName.SelectionLength = 0;
        }
        #endregion

        #region ItemDescription Combobox

        /// <summary>
        /// Item description has changed test if new text then add to list
        /// </summary>
        private void ItemdescriptionChanged()
        {
            if (_ignoreEvents) { return; }
            string myItem = ComboBoxItemDescription.Text;

            if (!String.IsNullOrEmpty(myItem))
            {
                //Prüfen ob eingegebene Marke in Liste vorhanden
                bool itemFound = DbAttribs.FindItemdescription(myItem);
                if (!itemFound)
                {
                    var ret = true; // DbAttribs.InsertItemdscription(temp);
                    if (!ret)
                        MessageBox.Show("Speichern der Marke fehlgeschlagen ",
                           "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        // Update List with all Itemdescriptions
                        //bindinglistItemdescription = DbAttribs.GetAllItemDescriptionFromItems();

                        bindinglistItemdescription.Add(myItem);
                        bSourceItemdescription.DataSource = bindinglistItemdescription;
                        ComboBoxItemDescription.DataSource = bSourceItemdescription;
                        ComboBoxColor.Focus();
                        //ConboBoxItemDescription.SelectedText = myItem;
                        //select the new itemDescription in Combobox list
                        int index = bSourceItemdescription.IndexOf(myItem);
                        if (index > -1)
                            ComboBoxItemDescription.SelectedItem = myItem;
                    }

                }
            }
        }

        /// <summary>
        /// Called wehen leaving the text box for ItemDescription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxItemDescription_Leave(object sender, EventArgs e)
        {
            if (_ignoreEvents || updateRecord && !myItemdescriptionTextChanged) { return; }
            myItemdescriptionTextChanged = false;
            // Ungültige Zeichen entfernen
            ComboBoxItemDescription.Text = ComboBoxItemDescription.Text.Replace(';', ',');
            //Prüfen ob Itemname bereits vorhanden ohne Abfrage speichern
            ItemdescriptionChanged();
        }

        private void ComboBoxItemDescription_EnabledChanged(object sender, EventArgs e)
        {
            // Markierung des Kundennamen aufheben
            ComboBoxVendorName.SelectionLength = 0;
        }

        #endregion

        #region react to Attribute Comboboxes

        //Attribute eingeben
        // Farben ComboBox
        private void ColorChanged()
        {
            if (_ignoreEvents) { return; }
            Boolean colorFound = false;
            string myColor = ComboBoxColor.Text;
            string myColorOrigin = myColor;
            bool ret = false;

            if (!String.IsNullOrEmpty(myColor))
            {
                //Prüfen ob eingegebene Farbe in Liste vorhanden
                colorFound = DbAttribs.FindColor(myColor);
                if (colorFound == false)
                {
                    DialogResult result = MessageBox.Show("Möchten Sie die neue Farbe speichern? ",
                      "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //code for Yes
                        ret = DbAttribs.InsertColor(myColor);
                        if (!ret)
                            MessageBox.Show("Speichern der Farbe fehlgeschlagen ",
                               "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            bindinglistColor = DbAttribs.GetAllColors();
                            //ComboBoxColor.DataSource = colors;
                            bSourceColor.DataSource = bindinglistColor;
                            ComboBoxColor.DataSource = bSourceColor;

                            int index = bSourceColor.IndexOf(myColorOrigin);
                            if (index > -1)
                                ComboBoxColor.SelectedItem = myColorOrigin;
                            ComboBoxColor.Invalidate();
                        }
                    }
                }
            }
        }
        private void ComboBoxColor_Leave(object sender, EventArgs e)
        {
            if (_ignoreEvents || updateRecord && !myColorTextChanged) { return; }
            myColorTextChanged = false;
            ColorChanged();
        }
        private void ComboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) { return; }
            ColorChanged();
        }

        // Marken Marken ComboBox
        private void BrandChanged()
        {
            if (_ignoreEvents) { return; }
            List<Brand> brandFound;
            string myBrand = ComboBoxBrand.Text;
            string myBrandOrigin = myBrand;
            bool ret = false;
            DialogResult result = new DialogResult();

            if (!String.IsNullOrEmpty(myBrand))
            {
                //Prüfen ob eingegebene Marke in Liste vorhanden
                brandFound = DbAttribs.FindBrand(myBrand);
                if (brandFound.Count == 0)
                {
                    // Abfragen ob neue Marke gesoeichert werden soll, es werden auch alle Schreibfehler mitgespeichert
                    result = MessageBox.Show("Möchten Sie die neue Marke speichern? ",
                      "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //code for Yes
                        Brand temp = new Brand();
                        temp.Name = myBrand;
                        //result = MessageBox.Show("Handelt es sich um eine Premiummarke? ",
                        //    "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        //if (result == DialogResult.Yes)
                        //    temp.Premium = "1";
                        //else
                        temp.Premium = "0";
                        ret = DbAttribs.InsertBrand(temp);
                        if (!ret)
                            MessageBox.Show("Speichern der Marke fehlgeschlagen ",
                               "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            // Update List with all Brands
                            bindinglistBrand = DbAttribs.GetAllBrands();
                            bSourceBrand.DataSource = bindinglistBrand;
                            ComboBoxBrand.DataSource = bSourceBrand;
                            int index = bSourceBrand.IndexOf(myBrandOrigin);
                            if (index > -1)
                                ComboBoxBrand.SelectedItem = myBrandOrigin;
                        }
                    }
                }
                else //Brand wurde gefunden
                {
                    if (brandFound[0].Premium == "1")
                        PremiumLbl.Visible = true;
                    else
                        PremiumLbl.Visible = false;
                }
            }
        }
        private void ComboBoxBrand_Leave(object sender, EventArgs e)
        {
            if (_ignoreEvents || updateRecord && !myBrandTextChanged) { return; }
            myBrandTextChanged = false;
            BrandChanged();
        }
        private void ComboBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) { return; }
            BrandChanged();
        }


        // Grössen Combobox
        private new void SizeChanged()
        {
            if (_ignoreEvents) { return; }
            Boolean sizeFound = false;
            string mySize = ComboBoxSize.Text;
            string mySizeOrigin = mySize;
            bool ret = false;

            if (!String.IsNullOrEmpty(mySize))
            {
                //Prüfen ob eingegebene Grösse in Liste vorhanden
                sizeFound = DbAttribs.FindSize(mySize);
                if (!sizeFound)
                {
                    DialogResult result = MessageBox.Show("Möchten Sie die neue Größe speichern? ",
                      "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //code for Yes
                        ret = DbAttribs.InsertSize(mySize);
                        if (!ret)
                            MessageBox.Show("Speichern der Farbe fehlgeschlagen ",
                               "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            //sizes = DbAttribs.GetAllSizes();
                            bindinglistSize = DbAttribs.GetAllSizes();
                            bSourceSize.DataSource = bindinglistSize;
                            ComboBoxSize.DataSource = bindinglistSize;

                            int index = bSourceSize.IndexOf(mySizeOrigin);
                            if (index > -1)
                                ComboBoxSize.SelectedItem = mySizeOrigin;
                        }
                    }
                }
            }
        }
        private void ComboBoxSize_Leave(object sender, EventArgs e)
        {
            if (_ignoreEvents || updateRecord && !mySizeTextChanged) { return; }
            mySizeTextChanged = false;
            SizeChanged();
        }
        private void ComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) { return; }
            SizeChanged();
        }

        #endregion

        //Neuen Vertrag erstellen

        //Open other windows
        #region Open the windows
        private void OpenOwnerEdit_Window()
        {
            OwnerEditUI ownerEditWindow = new OwnerEditUI();
            ownerEditWindow.FormClosed += new FormClosedEventHandler(OwnerEditWindow_Closed);
            ownerEditWindow.ShowDialog();
        }

        private void OpenReport_Window()
        {
            //ruft neues Fenster auf zur anzeige der Artikel
            //ReportUI ReportWindow = new ReportUI();
            //ReportWindow.ShowDialog();
            ReportUI ReportWindow = new ReportUI();
            ReportWindow.ShowDialog();
        }

        private void OpenItemOut_Window()
        {
            ItemsOutWindow ItemsOutWindow = new ItemsOutWindow();
            ItemsOutWindow.ShowDialog();
        }

        private void OpenRefund_Window()
        {
            RueckgabeEingabeWindow RefundWindow = new RueckgabeEingabeWindow();
            RefundWindow.ShowDialog();
        }

        private void OpenCashVolume_Window()
        {
            //ruft neues Fenster auf zur anzeige der Artikel
            CashVolumeMonthlyWindow CashVolumeWindow = new CashVolumeMonthlyWindow();
            CashVolumeWindow.ShowDialog();
        }

        private void OpenDocumentContract_Window()
        {
            //Inhalt des DataGridView in eine Liste schreiben
            List<Item> myCurrentItemsList = new List<Item>();
            double myMargin = Convert.ToDouble((MarginTextBox.Text).Split(' ')[0]);

            for (int i = 0; ItemsDataGridView.RowCount > i; i++)
            {

                Item myNewItem = new Item();

                myNewItem.AccountID = AccountIDTextBox.Text;  //, // r.Field<string>("AccountID"),
                myNewItem.ItemNumber = ItemsDataGridView.Rows[i].Cells[0].Value.ToString();
                myNewItem.ItemDescription = ItemsDataGridView.Rows[i].Cells[1].Value.ToString();
                myNewItem.Brand = ItemsDataGridView.Rows[i].Cells[2].Value.ToString();
                myNewItem.Color = ItemsDataGridView.Rows[i].Cells[3].Value.ToString();
                myNewItem.Size = ItemsDataGridView.Rows[i].Cells[4].Value.ToString();
                myNewItem.Prop = ItemsDataGridView.Rows[i].Cells[5].Value.ToString();
                myNewItem.SalesPrice = ItemsDataGridView.Rows[i].Cells[6].Value.ToString().Split(' ')[0];

                myNewItem.CostPrice = (Convert.ToDouble(ItemsDataGridView.Rows[i].Cells[6].Value.ToString().Split(' ')[0]) * myMargin / 100).ToString(); ;

                myNewItem.ContractID = Store.ConvertContractNumberToContractID(ContractNumberTextBox.Text);

                myNewItem.BeginDate = AktDateTextBox.Text;
                myNewItem.EndDate = ExpirationDateTextBox.Text;
                myCurrentItemsList.Add(myNewItem);
            }
            //ruft neues Fenster auf zur anzeige der Artikel
            DocumentContract documentWindow = new DocumentContract();
            documentWindow.FormClosed += new FormClosedEventHandler(DocumentContractWindow_Closed);
            documentWindow.MyContractID =  myContractID;
            documentWindow.ContractItemList = myCurrentItemsList;
            documentWindow.ShowDialog();
        }

        private void OpenVendorEditWindow()
        {
            VendorEdit vendorEditWindow = new VendorEdit();
            vendorEditWindow.FormClosed += new FormClosedEventHandler(VendorEditWindow_Closed);
            vendorEditWindow.ShowDialog();
        }

        private void OpenVendorTableWindow()
        {
            VendorTableUI vendorTableWindow = new VendorTableUI();
            vendorTableWindow.FormClosed += new FormClosedEventHandler(VendorTableWindow_Closed);
            vendorTableWindow.ShowDialog();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //ruft neues Fenster auf zur anzeige der Artikel
            myContractID = "180069";
            //DocumentContract documentWindow = new DocumentContract();
            ////documentWindow.FormClosed += new FormClosedEventHandler(VendorEditWindow_Closed);
            //documentWindow.MyContractID = myContractID;
            //documentWindow.Show();

            ContractUI contractUI = new ContractUI();

            contractUI.Show();

        }

        private void OpenKeyInput_Window()
        {
            KeyInputWindow KeyInputWindow = new KeyInputWindow();
            KeyInputWindow.FormClosed += new FormClosedEventHandler(KeyInputWindow_Closed);
            KeyInputWindow.ShowDialog();
        }

        #endregion

        //Reaktion beim Schliessen der aufgerufenen Fenster
        #region Close the windows
        private void VendorEditWindow_Closed(object sender, EventArgs e)
        {

            if (sender is VendorEdit vendorEditWindow)
            {
                if (!String.IsNullOrWhiteSpace(vendorEditWindow.IDInVendorIDTextBox))
                {
                    //Kundendatenfelder füllen mit neuen Kundendaten
                    AccountIDTextBox.Text = vendorEditWindow.IDInVendorIDTextBox;
                    MarginTextBox.Text = vendorEditWindow.MarginInCommissionTextBox;
                    PeriodTextBox.Text = vendorEditWindow.PeriodInExpirationTimeTextBox;
                    PhoneNumberTextBox.Text = vendorEditWindow.PhoneNumberInTelefonTextBox;

                    //Vendor Combo in Liste schreiben
                    List<string> myLastnameList = (List<string>)ComboBoxVendorName.DataSource;

                    //Fullname vom Editfenster übernehmen
                    string myFullName = vendorEditWindow.FullNameInnameTextBox;

                    //neuen Kunden in Liste einfügen
                    myLastnameList.Add(myFullName);
                    //Liste neu sortieren
                    myLastnameList.Sort();

                    //Liste als DataSource an ComboBox übergeben
                    ComboBoxVendorName.DataSource = null;
                    ComboBoxVendorName.DataSource = myLastnameList;

                    //index in Liste für den neuen Kunden suchen 
                    int i = myLastnameList.IndexOf(myFullName);

                    //den neuen Kunden in ComboBox selektieren -- ruft ComboBoxVendorName_SelectedIndexChanged auf
                    ComboBoxVendorName.SelectedIndex = i;
                }
                vendorEditWindow.FormClosed -= new FormClosedEventHandler(VendorEditWindow_Closed);
            }

        }

        private void OwnerEditWindow_Closed(object sender, EventArgs e)
        {
            OwnerEditUI ownerEditWindow = sender as OwnerEditUI;
            if (ownerEditWindow != null)
            {
                //Not implemented
            }
        }

        private void VendorTableWindow_Closed(object sender, EventArgs e)
        {
            VendorTableUI vendorTableWindow = sender as VendorTableUI;
            if (vendorTableWindow != null)
            {
                //Vendors Combobox füllen
                CustomersList = DbVendors.GetAllVendorsName();
                List<string> myFullInfoList = new List<string>();
                foreach (var item in CustomersList)
                {
                    myFullInfoList.Add(item.FullInfo);
                }
                try
                {
                    _ignoreEvents = true;
                    ComboBoxVendorName.DataSource = myFullInfoList.ToList();
                    ComboBoxVendorName.SelectedIndex = -1;
                }
                finally
                {
                    _ignoreEvents = false;
                }

                _ignoreEvents = false;
                vendorTableWindow.FormClosed -= new FormClosedEventHandler(VendorTableWindow_Closed);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myContractChanged && ItemsDataGridView.RowCount == 0)
            {
                //Contract, ConfigData löschen noch keine Items eingegeben
               
                if (!String.IsNullOrEmpty(myContractID))
                {
                    DbItems.DeleteContract(myContractID);
                    myContractID = Convert.ToString((Convert.ToInt32(myContractID) - 1));
                }
                if (!String.IsNullOrEmpty(myItemNumber))
                    myItemNumber = Convert.ToString((Convert.ToInt32(myItemNumber) - 1));

                if (myConfigData.Count > 0) //Neuer Vertrag 
                {
                    myConfigData[0].LastContractID = myContractID;
                    myConfigData[0].LastItemNumber = myItemNumber;
                    DbItems.UpdateConfigDat(myConfigData[0]);
                }
                myContractChanged = false;
            }
            else //Bereits Items eingegeben
            {
                if (!string.IsNullOrEmpty(myContractID))
                {
                    if (myContractChanged)
                    {
                        DialogResult dr = MessageBox.Show("Diesen Vertrag mit allen Artikel löschen?", "Sicherung",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        //Alle eingegeben Artikel löschen
                        if (dr == DialogResult.Yes)
                        {
                            //Contract und items löschen 
                            DbItems.DeleteContract(myContractID);
                            if (ItemsDataGridView.RowCount != 0)
                            {
                                DbItems.DeleteAllItemsWithContractID(myContractID);
                                //Tabelle leeren
                                for (int i = 0; i < ItemsDataGridView.Rows.Count; i++)
                                {
                                    ItemsDataGridView.Rows.RemoveAt(i);
                                }
                            }
                            // ConfigData updaten 
                            if (myConfigData.Count > 0) //Neuer Vertrag 
                            {
                                myContractID = Convert.ToString((Convert.ToInt32(myContractID) - 1));
                                myConfigData[0].LastContractID = myContractID;
                                myItemNumber = Convert.ToString((Convert.ToInt32(myItemNumber) - 1));
                                myConfigData[0].LastItemNumber = myItemNumber;
                                DbItems.UpdateConfigDat(myConfigData[0]);
                            }
                            myContractChanged = false;
                        }

                        if(dr == DialogResult.Cancel)
                        {
                            // Cancel the Closing event from closing the form.
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void DocumentContractWindow_Closed(object sender, EventArgs e)
        {
            if (sender is DocumentContract documentContractWindow)
            {
                documentContractWindow.FormClosed -= new FormClosedEventHandler(DocumentContractWindow_Closed);
            }
            ComboBoxVendorName.Focus();
            _ignoreEvents = true;

        }

        private void DocumentLabelPrintWindow_Closed(object sender, EventArgs e)
        {
            DocumentLabelPrint DocumentLabelPrintWindow = sender as DocumentLabelPrint;
            if (DocumentLabelPrintWindow != null)
            {
                DocumentLabelPrintWindow.FormClosed -= new FormClosedEventHandler(DocumentLabelPrintWindow_Closed);
            }
        }

        private void KeyInputWindow_Closed(object sender, EventArgs e)
        {
            if (sender is KeyInputWindow keyInputWindow)
            {
                keyInputWindow.FormClosed -= new FormClosedEventHandler(KeyInputWindow_Closed);
                Licensed = keyInputWindow.Licensed;
                if (Licensed)
                {
                    SchlüsselEingebenToolStripMenuItem.Enabled = false;
                    this.Text = "Kommissionswaren Secondhand Kleidung (Lizensiert)  Vers." + Store.AddVersionNumber();
                    this.Invalidate();
                }
            }
        }

        #endregion

        /// <summary>
        /// //React on Key Down serves a special key combination to show a hidden menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Shift | Keys.Alt | Keys.F9))
            {
                //Menuitems warenlisteEinlesen, kundenlisteEinlesen sichtbar machen
                warenlisteEinlesenToolStripMenuItem.Visible = true;
                KundenlisteEinlesenToolStripMenuItem.Visible = true;
                DeletedEinlesenToolStripMenuItem.Visible = true;
            }
        }

        // TODO: change Datasource list
        private void ComboBoxVendorName_DataSourceChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Vendor Name DataSource changed");
            // ComboBoxVendorName.Cursor=Cursors.Cross;
        }

        #region Text changed in ComboBoxes Methods
        private void ComboBoxBrand_TextChanged(object sender, EventArgs e)
        {
            myBrandTextChanged = true;
        }

        private void ConboBoxItemDescription_TextChanged(object sender, EventArgs e)
        {
            myItemdescriptionTextChanged = true;
        }

        private void ComboBoxColor_TextChanged(object sender, EventArgs e)
        {
            myColorTextChanged = true;
        }

        private void ComboBoxSize_TextChanged(object sender, EventArgs e)
        {
            mySizeTextChanged = true;
        }



        #endregion
    }
}
