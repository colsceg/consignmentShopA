using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class ItemsOutWindow : Form

    {
        private Store Store = new Store();

        private BindingSource source1 = new BindingSource();
        private DataView view1;
        private DataTable dt = new DataTable();

        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();

        private List<Item> ItemsList = new List<Item>();
        private List<Vendor> CustomersList = new List<Vendor>();
        private TransactionItem transactionItem = new TransactionItem();

        private bool _ignoreEvents = true;

        public ItemsOutWindow()
        {
            InitializeComponent();
            Setup();
        }

        private void ItemsOutWindow_Shown(object sender, EventArgs e)
        {
            AccountIDComboBox.Text = "";
            VendorNameComboBox.Text = "";
            VendorNameComboBox.Focus();
            _ignoreEvents = false;
        }

        private void Setup()
        {
            //Vendors Combobox füllen
            List<string> vendors = new List<string>();
            List<string> accountIDs = new List<string>();
            _ignoreEvents = true;
            CustomersList = DbVendors.GetAllVendorsNameNotSold();
            foreach (var item in CustomersList)
            {
                vendors.Add(item.FullInfo);
                accountIDs.Add(item.AccountID);
            }
            VendorNameComboBox.DataSource = vendors;
            _ignoreEvents = true;
            accountIDs.Sort();
            AccountIDComboBox.DataSource = accountIDs;
            PayoutBtn.Visible = false;
            SalesPriceTextBox.ReadOnly = true;
        }

        private void SelectAnItem()
        {
            //Verkaufspreis aus Tabelle lesen
            if (ItemsDataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    //Annahmedatum aus Tabelle lesen
                    String value = ItemsDataGridView.SelectedRows[0].Cells[8].Value.ToString();
                    String[] substrings = value.Split(' ');
                    InDateLbl.Text = substrings[0].Trim();
                    //Eingabe in DataGridView ändern

                    // Get topaysum
                }
                catch (Exception ex)
                {
                    int myLastIndex = ItemsDataGridView.RowCount - 1;
                    ItemsDataGridView.Rows[myLastIndex].Selected = true;
                    SalesPriceTextBox.Text = ItemsDataGridView.SelectedRows[0].Cells[7].Value.ToString();
                    //Annahmedatum aus Tabelle lesen
                    InDateLbl.Text = ItemsDataGridView.SelectedRows[0].Cells[8].Value.ToString();
                }
            }
            else
            {
                if (ItemsDataGridView.RowCount > 0)
                {
                    _ignoreEvents = true;
                    ItemsDataGridView.Rows[0].Selected = true;
                }
                else
                    SalesPriceTextBox.Text = "";
            }
        }

        private void ClearAllFields()
        {
            LastnameTextBox.Text = "";
            FirstnameTextBox.Text = "";
            MarginTextBox.Text = "";
            PhonenumberTextBox.Text = "";
            ItemsNotSoldTextBox.Text = "";
            InDateLbl.Text = "";
            SalesPriceTextBox.Text = "";
            ItemsDataGridView.DataSource = new List<Item>();
            ToPaySumTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0.0);
            PayoutBtn.Visible = false;
        }

        private void FillAllFields(string anAccountID)
        {
            List<Vendor> myVendorList = new List<Vendor>();
            Vendor myVendor = new Vendor();
            List<ItemAllGrouped> myItemsGrouped = new List<ItemAllGrouped>();

            myVendorList = DbVendors.GetVendorWithAccountID(anAccountID);
            if (myVendorList.Count > 0)
            {
                myVendor = myVendorList[0];
                LastnameTextBox.Text = myVendor.LastName;
                FirstnameTextBox.Text = myVendor.FirstName;
                MarginTextBox.Text = string.Format("{0} %", myVendor.Margin.ToString());

                if (myVendor.PhoneNumber1 != "")
                    PhonenumberTextBox.Text = myVendor.PhoneNumber1;
                else
                    PhonenumberTextBox.Text = myVendor.PhoneNumber2;
                //Alle Artikel einlesen, die nicht ausgezahlt sind 
                //Get all items in a DataTable not payed
                dt = DbItems.GetItemsWithAccountIDNotPayedToDT(anAccountID);

                if (dt.Rows.Count > 0)
                {
                    //Allow change all fields in DataTable
                    foreach (DataColumn col in dt.Columns) col.ReadOnly = false;

                    //Bind all items in a DataTable to a DataView
                    view1 = new DataView(dt);
                    //Bind the DataView to a DataSource
                    source1.DataSource = view1;
                    //Bind a DataSource to a DataGridView  (ds.Tables[0]);
                    ItemsDataGridView.DataSource = source1;


                    //Column width einstellen abhängig ob Srollbar angezeigt wird oder nicht
                    if (source1.Count > 25)
                        ItemsDataGridView.Columns[2].Width = 100;
                    else
                        ItemsDataGridView.Columns[2].Width = 120;
                    //ItemsDataGridView.DataSource = ItemsList;


                    myItemsGrouped = DbItems.GetAllItemsGroupedSoldNotPayed(anAccountID);
                    if (myItemsGrouped.Count > 0)
                    {
                        ToPaySumTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myItemsGrouped[0].SumCost);
                        PayoutBtn.Visible = true;
                    }
                    else
                    {
                        ToPaySumTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0.0);
                    }

                    int myItemNotSoldCount = ItemsDataGridView.Rows
                        .Cast<DataGridViewRow>()
                        .Select(row => row.Cells[6].Value)
                        .Where(value => value == DBNull.Value)
                        .Count();

                    ItemsNotSoldTextBox.Text = myItemNotSoldCount.ToString();
                    //the first item in grid is selected seems to be impossible to unselect all

                    ItemsDataGridView.ClearSelection(); //clear select first row
                    SalesPriceTextBox.Text = "";
                    SalesPriceTextBox.ReadOnly = true;
                }
                else
                {
                    //var w = new Form() { Size = new Size(0, 0) };
                    //Task.Delay(TimeSpan.FromSeconds(10))
                    //    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                    MessageBox.Show("Keine Artikel für diesen Kunden", "Information");
                }//MessageBox.Show($"Keine Artikel für diesen Kunden");
            }
        }

        //reaction when leave
        private void VendorNameComboBox_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                String value = VendorNameComboBox.Text.ToString();
                if (!String.IsNullOrEmpty(value))
                {                    
                    char delimiter = ';';
                    String[] substrings = value.Split(delimiter);

                    if ((substrings.Count()== 3))
                        AccountIDComboBox.Text = substrings[2].Trim();
                    else
                        AccountIDComboBox.Text = "";
                    //Formularfelder füllen werden bereits durch AccountIDComboBox_Leave gefüllt
                    //FillAllFields(myAccountID);
                }
                else
                {
                    AccountIDComboBox.Text = "";
                    ClearAllFields();
                }
            }
            else
                _ignoreEvents = false;
        }

        private void VendorNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myAccountID;
            if (!_ignoreEvents)
            {
                if (VendorNameComboBox.SelectedIndex >= 0)
                {
                    String value = VendorNameComboBox.Text.ToString();

                    char delimiter = ';';
                    String[] substrings =  value.Split(delimiter);
                    myAccountID = substrings[2].Trim();
                    _ignoreEvents = true;
                    AccountIDComboBox.Text = myAccountID;
                    //Formularfelder füllen werden bereits durch AccountIDChanged gefüllt
                    ClearAllFields();
                    FillAllFields(myAccountID);
                }
            }
            else
                _ignoreEvents = false;
        }

        private void AccountIDComboBox_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                String value = AccountIDComboBox.Text.ToString();
                if (value.Length == 4 && !String.IsNullOrEmpty(value))
                {
                    //VendorNameComboBox mit aktuellem Namen selektieren
                    List<Vendor> myAktVendorList = DbVendors.GetVendorWithAccountID(value);
                    if (myAktVendorList.Count > 0)
                    {
                        string myAktVendor = myAktVendorList[0].FullInfo;
                        int index = VendorNameComboBox.FindString(myAktVendor);
                        _ignoreEvents = true;
                        VendorNameComboBox.SelectedIndex = index;

                        //Formularfelder füllen
                        FillAllFields(value);

                        //Eintrag in SQLITE transactionprotocoll table
                        //timestamp mAktVendor value
                        String timeStamp = Store.GetTimestamp(DateTime.Now);
                        transactionItem.Timestamp = timeStamp;
                        transactionItem.AccountID = value;
                        transactionItem.CustomerFullInfo = myAktVendor;
                        DbItems.InsertTransaction(transactionItem);
                    }
                    else
                    {
                        AccountIDComboBox.Text = "";
                        MessageBox.Show("Kundennummer nicht vorhanden");
                    }
                }
                else
                {
                    ClearAllFields();
                }
            }
            else
                _ignoreEvents = false;
        }

        private void AccountIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                if (AccountIDComboBox.SelectedIndex >= 0 )
                {
                    String value = AccountIDComboBox.Text.ToString();

                    //VendorNameComboBox mit aktuellem Namen selektieren
                    List<Vendor> myAktVendorList = DbVendors.GetVendorWithAccountID(value);
                    string myAktVendor = myAktVendorList[0].FullInfo;
                    int index = VendorNameComboBox.FindString(myAktVendor);
                    _ignoreEvents = true;
                    VendorNameComboBox.SelectedIndex = index;

                    //Formularfelder füllen
                    _ignoreEvents = true;
                    ClearAllFields();
                    FillAllFields(value);
                }                
            }
            else
                _ignoreEvents = false;
        }


        private void SalesPriceTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count > 0)
            {
                if (!String.IsNullOrEmpty(SalesPriceTextBox.Text))
                {
                    if (!_ignoreEvents && !SalesPriceTextBox.ReadOnly)
                    {
                        try
                        {
                            //Eingabe formatieren
                            decimal mySalesPrice = Store.ConvertCurrencyToDecimal(SalesPriceTextBox.Text);
                            //mySalesPrice = Store.ConvertCurrencyToDecimal(ItemsDataGridView.SelectedRows[0].Cells[9].Value.ToString());
                            SalesPriceTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", mySalesPrice);
                            //CostPrice mit Marge ermitteln
                            decimal myCostPrice = mySalesPrice - mySalesPrice * Convert.ToDecimal(MarginTextBox.Text.Split(' ')[0]) / 100;
                            //Eingabe formatieren
                            //ItemsDataGridView.SelectedRows[0].Cells[7].Value = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", mySalesPrice);
                            //ItemsDataGridView.SelectedRows[0].Cells[9].Value = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myCostPrice);

                            ItemsDataGridView.SelectedRows[0].Cells[7].Value = mySalesPrice;
                            ItemsDataGridView.SelectedRows[0].Cells[9].Value = myCostPrice;
                            //SalesPrice und Costprice in Datenbank ändern
                            DbItems.UpdateItemWithItemNumber(ItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString(), Store.ConvertCurrencyToNumber(mySalesPrice.ToString()), Store.ConvertCurrencyToNumber(myCostPrice.ToString()));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Fehlercode: {ex}");
                            throw;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// An item in DatagridView is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                if (ItemsDataGridView.SelectedRows.Count == 1)
                {
                    //Annahmedatum aus Tabelle lesen
                    String value = ItemsDataGridView.SelectedRows[0].Cells[8].Value.ToString();
                    String[] substrings = value.Split(' ');
                    InDateLbl.Text = substrings[0].Trim();

                    //Verkaufsdatum aus Tabelle lesen
                    value = ItemsDataGridView.SelectedRows[0].Cells[6].Value.ToString();
                    substrings = value.Split(' ');
                    string myDate = substrings[0].Trim();

                    //Verkaufspreis aus Tabelle lesen
                    decimal mySalesPrice = Store.ConvertCurrencyToDecimal(ItemsDataGridView.SelectedRows[0].Cells[7].Value.ToString());
                    //Verkaufspreis in Feld eintragen
                    SalesPriceTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", mySalesPrice);
                    SalesPriceTextBox.ReadOnly = true;
                    //wenn Artikel verkauft Verkaufspreis Textbox readonly
                    if (String.IsNullOrEmpty(myDate))
                        //Eingabe formatieren
                        SalesPriceTextBox.ReadOnly = false;
                    else
                        SalesPriceTextBox.ReadOnly = true;
                }

            }
            else
                _ignoreEvents = false;
        }


        /// <summary>
        /// Sets datagridview context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDataContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //there is at least one article in Gridview selected
            if (ItemsDataGridView.SelectedRows.Count > 0)
            {
                bool anItemNotSold = false;
                if (ItemsDataGridView.SelectedRows.Count == 1)
                {
                    if (String.IsNullOrEmpty(ItemsDataGridView.SelectedRows[0].Cells[6].Value.ToString()))
                    {
                        //there is one Article selected and not sold, sold and delete is possible
                        //menuitem verkauft
                        ItemDataContextMenuStrip.Items[0].Visible = true;
                        //menuitem nicht verkauft
                        ItemDataContextMenuStrip.Items[1].Visible = false;
                        //MenuItem delete
                        ItemDataContextMenuStrip.Items[2].Visible = true;
                    }
                    else
                    {   //there is one article selected and sold; unsold is possible
                        //menuitem verkauft
                        ItemDataContextMenuStrip.Items[0].Visible = false;
                        //menuitem nicht verkauft
                        ItemDataContextMenuStrip.Items[1].Visible = true;
                        //MenuItem delete
                        ItemDataContextMenuStrip.Items[2].Visible = false;
                        //Textbox mit Verkaufspreis
                        SalesPriceTextBox.ReadOnly = true;
                    }
                }
                else //there is more than one article selected
                {
                    //test if there is an article that is not sold
                    for (int i = 0; i < ItemsDataGridView.SelectedRows.Count; i++)
                    {
                        if (String.IsNullOrEmpty(ItemsDataGridView.SelectedRows[i].Cells[6].Value.ToString()))
                        {
                            anItemNotSold = true;
                        }
                    }
                    if (anItemNotSold)
                    {
                        //multiple rows are selected
                        //at least one article is not sold show deleted only
                        //menuitem verkauft
                        ItemDataContextMenuStrip.Items[0].Visible = false;
                        //menuitem nicht verkauft
                        ItemDataContextMenuStrip.Items[1].Visible = false;
                        //MenuItem delete
                        ItemDataContextMenuStrip.Items[2].Visible = true;
                        //Textbox mit Verkaufspreis
                        SalesPriceTextBox.ReadOnly = true;
                    }
                    else
                    {
                        //multiple rows are selected all are sold nothing possible
                        //menuitem verkauft
                        ItemDataContextMenuStrip.Items[0].Visible = false;
                        //menuitem nicht verkauft
                        ItemDataContextMenuStrip.Items[1].Visible = false;
                        //MenuItem delete
                        ItemDataContextMenuStrip.Items[2].Visible = false;
                    }
                }
            }
            else
            {   //there are no articels in the gridview
                //menuitem verkauft
                ItemDataContextMenuStrip.Items[0].Visible = false;
                //menuitem nicht verkauft
                ItemDataContextMenuStrip.Items[1].Visible = false;
                //MenuItem delete
                ItemDataContextMenuStrip.Items[2].Visible = false; ;
            }
        }

        // Menuitems Reaktion
        /// <summary>
        /// meniitem verkauft is clicked sets solddate to today
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string myDate = DateTime.Today.ToShortDateString();
            List<ItemAllGrouped> myItemsGrouped = new List<ItemAllGrouped>();
            //Heutiges Datum in DataGridview  eintragen
            ItemsDataGridView.SelectedRows[0].Cells[6].Value = myDate;

            //Heutiges Datum in Datenbank speichern
            myDate = Item.ConvertDateStringToSQLiteTimeString(myDate);
            DbItems.UpdateItemSoldWithItemNumber(ItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString(), myDate);

            //ToPaySumTextBox aktualisieren
            decimal myToPaySum = Store.ConvertCurrencyToDecimal( ToPaySumTextBox.Text);
            myToPaySum += Store.ConvertCurrencyToDecimal(ItemsDataGridView.SelectedRows[0].Cells[9].Value.ToString());
            ToPaySumTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myToPaySum);


            PayoutBtn.Visible = true;
            SalesPriceTextBox.ReadOnly = true;
            //Anzahl nicht verkaufter Artikel anzeigen
            int myItemsCountNotSold = Convert.ToInt32(ItemsNotSoldTextBox.Text) - 1;
            ItemsNotSoldTextBox.Text = myItemsCountNotSold.ToString();
        }

        /// <summary>
        /// Mark the selected articel as not sold when menuItem not sold is clicked
        /// sets the field soldDate in items to ""
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotSoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nur reagieren wenn Artikel als verkauft markiert
            if (!String.IsNullOrEmpty(ItemsDataGridView.SelectedRows[0].Cells[6].Value.ToString()))
            {
                List<ItemAllGrouped> myItemsGrouped = new List<ItemAllGrouped>();

                //Heutiges Datum in DataGridview  eintragen
                ItemsDataGridView.SelectedRows[0].Cells[6].Value = DBNull.Value;

                //Heutiges Datum in Datenbank speichern
                DbItems.UpdateItemSoldWithItemNumber(ItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString(), "");
                //ToPaySumTextBox aktualisieren
                decimal myToPaySum = Store.ConvertCurrencyToDecimal(ToPaySumTextBox.Text);
                myToPaySum -= Store.ConvertCurrencyToDecimal(ItemsDataGridView.SelectedRows[0].Cells[9].Value.ToString());
                ToPaySumTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myToPaySum);
                if (myToPaySum == 0)
                    PayoutBtn.Visible = false;
                SalesPriceTextBox.ReadOnly = false;

                int myItemsCountNotSold = Convert.ToInt32(ItemsNotSoldTextBox.Text) + 1;
                ItemsNotSoldTextBox.Text = myItemsCountNotSold.ToString();
            }
        }

        private void ShowItemsNotSoldCount(List<Item> anItemsList)
        {
            //Anzahl nicht verkaufter Artikel anzeigen
            int myItemsCountNotSold = 0;
            var items = from rec in anItemsList
                        where rec.SoldDate == ""
                        select new { rec.SalesPrice, rec.CostPrice };
            foreach (var item in items)
            {
                myItemsCountNotSold++;
            }
            ItemsNotSoldTextBox.Text = myItemsCountNotSold.ToString();
        }
        
        /// <summary>
        /// there are one or more articles to delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Datensatz in ItemsDataGridView löschen
            //test again if the article is not sold

            DialogResult result = MessageBox.Show("alle selektierten Artikel löschen?", "Warnung",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (var item in ItemsDataGridView.SelectedRows)
                {
                    //Datensatz in ItemsDataGridView löschen
                    //test if the article is not sold delete only not solded items
                    if (String.IsNullOrWhiteSpace(ItemsDataGridView.SelectedRows[0].Cells[6].Value.ToString()))
                    {
                        int myIndex = ItemsDataGridView.SelectedRows[0].Index;
                        string myItemNumber = ItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString();

                        //aktuelles Datum 
                        string aDeleteDate = DateTime.Today.ToShortDateString();
                        //Löschdatum in Tabelle und Datenbank eintragen
                        DbItems.UpdateItemDeletedWithItemNumber(myItemNumber, aDeleteDate);

                        ItemsDataGridView.Rows.RemoveAt(myIndex);

                        int myItemsCountNotSold = Convert.ToInt32(ItemsNotSoldTextBox.Text) - 1;

                        ItemsNotSoldTextBox.Text = myItemsCountNotSold.ToString();
                    }
                }
            }

        }

        //Button reaction
        private void PayoutBtn_Click(object sender, EventArgs e)
        {
                //Ausdruck Formular öffnen
                OpenDocumentPayout_Window(AccountIDComboBox.SelectedItem.ToString());
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Store.ShowErrors(ex);
            }

        }

        //Open Window
        private void OpenDocumentPayout_Window(string anAccountID)
        {
            //ruft neues Fenster auf zur anzeige der Artikel
            DocumentPayout documentWindow = new DocumentPayout();
            documentWindow.FormClosed += new FormClosedEventHandler(DocumentPayout_Closed);
            documentWindow.MyAccountID = anAccountID;
            documentWindow.ShowDialog();
        }
        
        //close Window
        private void DocumentPayout_Closed(object sender, EventArgs e)
        {
            DocumentPayout payoutDocument = sender as DocumentPayout;

            if (payoutDocument.MyContractPrinted)
            {
                //Auszahlung, alle verkauften items mit datum payoutDate füllen
                string myDate = DateTime.Today.ToShortDateString();
                //Heutiges Datum in Datenbank speichern
                myDate = Item.ConvertDateStringToSQLiteTimeString(myDate);
                DbItems.UpdateItemsPayedWithAccountID(AccountIDComboBox.SelectedItem.ToString(), myDate);
                //Tabelle aktualisieren
                ItemsList = DbItems.GetItemsWithAccountIDNotPayed(AccountIDComboBox.SelectedItem.ToString());
                ItemsDataGridView.DataSource = ItemsList;
                ToPaySumTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0.0);
                PayoutBtn.Visible = false;
                if (ItemsList.Count == 0)
                {
                    InDateLbl.Text = "";
                    SalesPriceTextBox.Text = "";
                }

            }
            payoutDocument.FormClosed -= new FormClosedEventHandler(DocumentPayout_Closed);
        }

        //nur Eingabe von Zahlen erlaubt
        private void SalesPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void ItemsDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("DataSourcechanged");
        }

        private void ToPaySumTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(ToPaySumTextBox.Text) && Store.ConvertCurrencyToDecimal(ToPaySumTextBox.Text)>0)
            {
                ToPaySumTextBox.Visible = true;
            }
            else
            {
                ToPaySumTextBox.Visible = false;
            }
        }
    }
}

