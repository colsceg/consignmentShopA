using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ConsignmentShopLibrary.SqlQueries;

namespace ConsignmentShopMainUI
{
    public partial class RueckgabeEingabeWindow : Form
    {
        private bool _ignoreEvents = true;

        private List<Refund> refunds = new List<Refund>();

        private bool comboBoxTextHasChanged = false;

        private DataTable dt = new DataTable();

        private DataAccessVendors DbVendors = new DataAccessVendors();
        private DataAccessRefunds DBRefunds = new DataAccessRefunds();
        private DataAccessItems DBItems = new DataAccessItems();

        private List<Refund> ContractsList = new List<Refund>();
        private List<Vendor> CustomersList = new List<Vendor>();
        private TransactionItem transactionItem = new TransactionItem();

        private bool isNewRecord = false;
        private bool isEditMode = false;


        public RueckgabeEingabeWindow()
        {
            //Rueckgabeliste einlesen ?
            InitializeComponent();
            // Setup();
        }

        private void RueckgabeEingabeWindow_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        /// <summary>
        /// Fill all Comboboxes
        /// </summary>
        private void Setup()
        {
            //Vendors Combobox füllen
            List<string> vendors = new List<string>();
            List<string> accountIDs = new List<string>();

            //Ablageort combobax disablen
            AblageOrtCB.Enabled = false;

            //Get all customers from database
            CustomersList = DbVendors.GetAllVendorsName();
            // Fill a list with all accountIDs
            foreach (var item in CustomersList)
            {
                vendors.Add(item.FullInfo);
                accountIDs.Add(item.AccountID);
            }

            _ignoreEvents = true;
            //List with accountIDs sort
            accountIDs.Sort();
            // Combobox with accountIds fill
            //AccountIDCB.DataSource = accountIDs;

            _ignoreEvents = true;
            //Combobox fill with vendor fullinfo
            VendorNameCB.DataSource = vendors;
            _ignoreEvents = true;

            //AccountIDCB.SelectedIndex = -1;
            _ignoreEvents = true;
            VendorNameCB.Text = " ";
            _ignoreEvents = true;
            VendorNameCB.Focus();
            _ignoreEvents = false;
        }

        #region Buttons clicks

        /// <summary>
        /// Close refund window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _ignoreEvents = true;
                ClearAllFields();
                OKBtn.Visible = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehlercode: {ex}");
                throw;
            }
        }

        /// <summary>
        /// Object der Rueckgabe in DB speichern 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKBtn_Click(object sender, EventArgs e)
        {
            // Object der Rueckgabe in DB speichern 
            // decide if new record or update an existing reccord

            foreach(var item in refunds)
            {
                // Test if place and input date is not empty
                if(!string.IsNullOrEmpty(item.Place) && !string.IsNullOrEmpty(item.Input))
                {
                    // Prüfen ob item bereits in Tabelle Rückgaben vorhanden
                    if (!DBRefunds.FindRefund(item.AccountID, item.Place)) // Record nicht vorhanden
                    {
                        DBRefunds.InsertRefund(item); //Tabelle Rueckgaben AccountID, Name, Ort, Eingabe, Ausgabe
                    }
                    else
                    {
                        DBRefunds.UpdateRefund(item);
                    }
                }

            }

            OKBtn.Visible = false;
            ClearAllFields();
            AblageOrtCB.Enabled = false;
            isEditMode = false;
            AblageOrtCB.Text = "";
            Close();
        }

        #endregion

        #region Combobox Reaction

        /// <summary>
        /// React if a new VendorName is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VendorNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClearDS();
            ComboBoxEnter comboBoxEnter = (ComboBoxEnter)sender;
            if (!_ignoreEvents && comboBoxTextHasChanged)
            {
                if (RefundDataGridView.Rows.Count > 0)
                {
                    // Test ob Lastname and Place bereits in refunds und Output empty
                    Refund refund = new Refund();
                    var refundsQuery =
                        from item in refunds
                        where item.LastName == refund.LastName && item.Place == refund.Place && item.Output == ""
                        select item;
                    if (refundsQuery.Count() > 0)
                        return;
                }

                // Test if vendor fillinfo OK
                if (!string.IsNullOrEmpty(VendorNameCB.Text))
                {
                    string value = VendorNameCB.Text.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        char delimiter = ';';
                        string[] substrings = value.Split(delimiter);

                        if ((substrings.Count() == 3))
                        {
                            string myAccountID = substrings[2].Trim();
                            isNewRecord = true;
                            _ignoreEvents = false;
                            FillAllFields(myAccountID);
                            AblageOrtCB.Enabled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// React for a new AblageOrt selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AblageOrtCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                string myDate = DateTime.Today.ToShortDateString();
                // Ist Ablageort nicht leer 
                if (!string.IsNullOrEmpty(AblageOrtCB.Text))
                {
                    Refund refund = new Refund();
                    // Ist ein Datensatz selektiert
                    if (RefundDataGridView.SelectedRows.Count > 0)
                    {
                        refund.LastName = RefundDataGridView.SelectedRows[0].Cells[0].Value != null ? RefundDataGridView.SelectedRows[0].Cells[0].Value.ToString() : "";
                        refund.Place = AblageOrtCB.Text;
                        refund.Input = string.IsNullOrEmpty(refunds[RefundDataGridView.SelectedRows[0].Index].Input) ? myDate : refunds[RefundDataGridView.SelectedRows[0].Index].Input;
                        refund.Output =RefundDataGridView.SelectedRows[0].Cells[3].Value != null ? RefundDataGridView.SelectedRows[0].Cells[3].Value.ToString() : "";
                        
                        // Liste aller refunds aktualisieren
                        refunds[RefundDataGridView.SelectedRows[0].Index].Place = refund.Place;
                        refunds[RefundDataGridView.SelectedRows[0].Index].Input = refund.Input;
                        refunds[RefundDataGridView.SelectedRows[0].Index].Output = refund.Output;

                        // Data GridView aktualisieren
                        RefundDataGridView.SelectedRows[0].Cells[0].Value = refund.LastName;
                        RefundDataGridView.SelectedRows[0].Cells[1].Value = refund.Place;
                        RefundDataGridView.SelectedRows[0].Cells[2].Value = refund.Input;
                        RefundDataGridView.SelectedRows[0].Cells[3].Value = refund.Output;

                        OKBtn.Visible = true;
                        AblageOrtCB.SelectionLength = 0;
                        OKBtn.Focus();
                    }

                }
            }
        }

        #endregion


        #region Methods


        private void FillAllFields(string anAccountID)
        {
            List<Vendor> myVendorList = new List<Vendor>();
            Vendor myVendor = new Vendor();
            List<ItemAllGrouped> myItemsGrouped = new List<ItemAllGrouped>();

            // Look in Refunds table
            dt = DBRefunds.GetRefund(anAccountID);
            // Make all columns writeable
            foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;
            if (dt.Rows.Count > 0) // Name in Refund table found
            {
                // Test if Lastname in refunds already

                Refund refund = new Refund();
                // Write founded receord to DatagridView

                object[] array = dt.Rows[0].ItemArray;

                refund.AccountID = (string)array[0];
                refund.LastName = (string)array[1];
                refund.Place = (string)array[2];
                refund.Input = (string)array[3];
                refund.Output = "";

                InsertDSToDatagrid(refund);

                return;
            }

            // Vendor wurde nicht in Refund table gefunden 
            // Look in in vendor table
            myVendorList = DbVendors.GetVendorWithAccountID(anAccountID);
            if (myVendorList.Count > 0)
            {
                Refund refund = new Refund();

                refund.AccountID = anAccountID;
                refund.LastName = myVendorList[0].LastName;
                refund.Place = "";
                refund.Input = "";
                refund.Output ="";

                InsertDSToDatagrid(refund);
            }
            _ignoreEvents = false;
            comboBoxTextHasChanged = false;
            AblageOrtCB.Enabled = true;
        }

        private void InsertDSToDatagrid(Refund refund)
        {
            bool test = false;
            foreach (var item in refunds)
            {
                test = item.Equals(refund);
                if (test)
                    break;
            }

            if (!test)
            {
                refunds.Add(refund);
                isNewRecord = true; // New record to put into Refund table
                RefundDataGridView.Rows.Add(
                    refund.LastName,
                    refund.Place,
                    refund.Input,
                    refund.Output);

                if (RefundDataGridView.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < RefundDataGridView.Rows.Count; i++)
                    {
                        RefundDataGridView.Rows[i].Selected = false;
                    }
                }
                int index = RefundDataGridView.Rows.Count > 0 ? RefundDataGridView.Rows.Count - 1 : 0;
                RefundDataGridView.Rows[index].Selected = true;
            }
        }

        /// <summary>
        /// Clear fields in window
        /// </summary>
        private void ClearAllFields()
        {
            AccountIDCB.SelectedIndex = -1;
            VendorNameCB.SelectedIndex = -1;
            AblageOrtCB.SelectedIndex = -1;
            AccountIDCB.SelectedItem = "";
            RefundDataGridView.Rows.Clear();
            refunds.Clear();
            RefundDataGridView.ClearSelection(); //clear select first row
            VendorNameCB.Focus();
        }

        #endregion


        #region Context menu

        /// <summary>
        /// Set context menu for RefundDatagrid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefundContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (RefundDataGridView.SelectedRows.Count == 1)
            {
                if (string.IsNullOrEmpty(RefundDataGridView.SelectedRows[0].Cells[3].Value.ToString()) && !string.IsNullOrEmpty(RefundDataGridView.SelectedRows[0].Cells[2].Value.ToString()))
                {
                    //there is one Article selected and not zurückgegeben and edit is possible
                    //menuitem verkauft
                    RefundContextMenuStrip.Items[0].Visible = true;
                    //MenuItem delete
                    RefundContextMenuStrip.Items[1].Visible = false;
                }
                else
                {
                    //menuitem verkauft
                    RefundContextMenuStrip.Items[0].Visible = false;
                    //MenuItem delete
                    RefundContextMenuStrip.Items[1].Visible = false;
                }
            }
            else
            {
                //menuitem verkauft
                RefundContextMenuStrip.Items[0].Visible = false;
                //MenuItem delete
                RefundContextMenuStrip.Items[1].Visible = false;
            }
        }


        /// <summary>
        /// Rückgabe action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RückgabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string myDate = DateTime.Today.ToShortDateString();
            List<ItemAllGrouped> myItemsGrouped = new List<ItemAllGrouped>();

            if (RefundDataGridView.SelectedRows.Count > 0)
            {
                // Heutiges Datum in DataGridview  eintragen
                RefundDataGridView.SelectedRows[0].Cells[3].Value = myDate;
                // Heutiges Datum in refunds liste  eintragen
                refunds[RefundDataGridView.SelectedRows[0].Index].Output = myDate;
                string myAccountID = refunds[RefundDataGridView.SelectedRows[0].Index].AccountID.ToString();
                DBItems.UpdateItemsDeletedWithAccountID(myAccountID);

                OKBtn.Visible = true;
            }
        }

        /// <summary>
        /// Edit change the Ablageort is possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Die selektierte Row in die Eingabefelder eintragen
            //updateRecord = true
            if (RefundDataGridView.SelectedRows.Count > 0 &&
                 RefundDataGridView.SelectedRows[0].Index <= RefundDataGridView.Rows.Count - 1)
            {
                OKBtn.Visible = true;
                _ignoreEvents = true;
                AblageOrtCB.Text = RefundDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                isEditMode = true;

                AblageOrtCB.Enabled = true;
                VendorNameCB.Enabled = false;
                AccountIDCB.Enabled = false;
                _ignoreEvents = false;
            }
        }

        #endregion

        private void VendorNameCB_TextChanged(object sender, EventArgs e)
        {
            comboBoxTextHasChanged = true;
        }

        private void RefundDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RefundDataGridView.SelectedRows.Count > 0)
            {
                // Ist Eingabedatum belegt
                if (!string.IsNullOrEmpty(RefundDataGridView.SelectedRows[0].Cells[2].Value.ToString()))
                {
                    // Get list of all items from deleted with date == input.
                    DocumentRefundList RefundListWin = new DocumentRefundList();
                    string myAccountID = refunds[RefundDataGridView.SelectedRows[0].Index].AccountID.ToString();
                    string myInDate = refunds[RefundDataGridView.SelectedRows[0].Index].Input.ToString();

                    Vendor vendor = DbVendors.GetVendorWithAccountID(myAccountID)[0];

                    // Get list of all items from DeletedItems table with myAccountId and InputDate
                    List<Item> itemsList = DBItems.GetAllDeletedItemsWithAccountID(myAccountID, myInDate);
                    RefundListWin.RefundItemsList = itemsList;
                    RefundListWin.VendorInfo = vendor;
                    RefundListWin.Show();
                    //MessageBox.Show("Liste alle artikel für Rückgabe");
                }
            }
        }
    }
}
