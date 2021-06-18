using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            foreach (var item in refunds)
            {
                if (String.IsNullOrEmpty(item.Output))
                {
                    // Prüfen ob item bereits in Tabelle Rückgaben vorhanden
                    if (!DBRefunds.FindRefund(item.AccountID, item.Place)) // Record nicht vorhanden
                    {
                        DBRefunds.InsertRefund(item); //Tabelle Rueckgaben AccountID, Name, Ort, Eingabe, Ausgabe
                    }
                }
                else
                {
                    DBRefunds.UpdateRefund(item);
                }
            }

            OKBtn.Visible = false;
            ClearAllFields();
            AblageOrtCB.Enabled = false;
            isEditMode = false;
            isNewRecord = true;
            AblageOrtCB.Text = "";
            Close();
        }

        #endregion

        #region Combobox Reaction

        private void VendorNameCB_Leave(object sender, EventArgs e)
        {
            //ClearDS();
            ComboBoxEnter comboBoxEnter =  (ComboBoxEnter)sender;
            if (!_ignoreEvents && comboBoxTextHasChanged)
            {
                //if (RefundDataGridView.Rows.Count > 0 && !isEditMode)
                //    for (int i = 0; i < RefundDataGridView.Rows.Count; i++)
                //    {
                //        RefundDataGridView.Rows.RemoveAt(0);
                //    }

                // Test if vendor fillinfo OK
                if (!String.IsNullOrEmpty(VendorNameCB.Text))
                {
                    String value = VendorNameCB.Text.ToString();
                    if (!String.IsNullOrEmpty(value))
                    {
                        char delimiter = ';';
                        String[] substrings = value.Split(delimiter);


                        if ((substrings.Count() == 3))
                        {
                            String myAccountID = substrings[2].Trim();
                            //int index = AccountIDCB.FindString(myAccountID);
                            //_ignoreEvents = true;
                            //AccountIDCB.SelectedIndex = index;
                            FillAllFields(myAccountID);
                            _ignoreEvents = false;
                        }
                        else
                        {
                            // AccountIDCB.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        //AccountIDCB.SelectedIndex = -1;
                    }
                }
            }
            else
                _ignoreEvents = false;
        }

        private void VendorNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            VendorNameCB_Leave(sender, e);

        }

        //private void AccountIDCB_Leave(object sender, EventArgs e)
        //{
        //    //ClearDS();
        //    if (!_ignoreEvents)
        //    {
        //        if (RefundDataGridView.Rows.Count > 0 && !isEditMode)
        //            for (int i = 0; i < RefundDataGridView.Rows.Count; i++)
        //            {
        //                RefundDataGridView.Rows.RemoveAt(0);
        //            }
        //        String value = AccountIDCB.Text.ToString();
        //        if (value.Length == 4 && !String.IsNullOrEmpty(value))
        //        {
        //            //VendorNameComboBox mit aktuellem Namen selektieren
        //            List<Vendor> myAktVendorList = DbVendors.GetVendorWithAccountID(value);
        //            if (myAktVendorList.Count > 0)
        //            {
        //                string myAktVendor = myAktVendorList[0].FullInfo;
        //                int index = VendorNameCB.FindString(myAktVendor);
        //                _ignoreEvents = true;
        //                VendorNameCB.SelectedIndex = index;

        //                //Formularfelder füllen
        //                FillAllFields(value);
        //                _ignoreEvents = false;

        //            }
        //            else
        //            {
        //                AccountIDCB.Text = "";
        //                MessageBox.Show("Kundennummer nicht vorhanden");
        //            }
        //        }
        //        else
        //        {
        //            ClearAllFields();
        //        }
        //    }
        //    else
        //        _ignoreEvents = false;
        //}

        //private void AccountIDCB_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    AccountIDCB_Leave(sender, e);

        //}

        private void AblageOrtCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                AblageOrtCB_Leave(sender, e);
                _ignoreEvents = true;
            }
        }

        private void AblageOrtCB_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AblageOrtCB.Text) && !_ignoreEvents)
            {
                string myAktDate = DateTime.Today.ToShortDateString();
                //myAktDate = myAktDate.Replace('.', '_');
                //Lastname aus Text extrahieren
                char delimiter = ';';
                String name = VendorNameCB.Text;
                String[] substrings = name.Split(delimiter);
                Refund refund = new Refund();
                if ((substrings.Count() == 3))
                {
                    refund.AccountID = substrings[2].Trim();
                    refund.LastName = substrings[0].Trim();
                }

                refund.Place = AblageOrtCB.Text;
                refund.Input = myAktDate; //aktuelles Datum
                refund.Output = "";
                // Test ob Lastname and Place bereits in refunds und Output empty
                // 2. Query creation.
                // numQuery is an IEnumerable<int>
                var refundsQuery =
                    from item in refunds
                    where item.LastName == refund.LastName && item.Place == refund.Place && item.Output == ""
                    select item;

                // when query nicht null oder count == 0 record noch nicht in Tabelle
                if (refundsQuery.Count() <= 1)
                {

                    refunds.Add(refund);
                    //in Tabelle RefundsDataGridView eintragen

                    RefundDataGridView.Rows.Add(
                    refund.LastName,
                    refund.Place,
                    refund.Input, //aktuelles Datum
                    refund.Output);
                    _ignoreEvents = true;
                }

                OKBtn.Visible = true;
                AblageOrtCB.SelectionLength = 0;

                OKBtn.Focus();
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Clear refund data when no Input and output empty
        /// </summary>
        //private void ClearDS()
        //{

        //    if (!String.IsNullOrEmpty(refund.Input) && !String.IsNullOrEmpty(refund.Output))
        //    {

        //        refund.AccountID = "";
        //        refund.LastName = "";
        //        refund.Place = "";
        //        refund.Input = ""; //aktuelles Datum
        //        refund.Output = "";
        //        AblageOrtCB.Enabled = true;
        //    }
        //}

        private void FillAllFields(string anAccountID)
        {
            List<Vendor> myVendorList = new List<Vendor>();
            Vendor myVendor = new Vendor();
            List<ItemAllGrouped> myItemsGrouped = new List<ItemAllGrouped>();

            myVendorList = DbVendors.GetVendorWithAccountID(anAccountID);
            if (myVendorList.Count > 0)
            {
                //Vendor wurde gefunden in vendor list
                myVendor = myVendorList[0];

                dt = DBRefunds.GetRefund(anAccountID);

                //Allow change all fields in DataTable
                if (dt.Rows.Count > 0)
                {
                    Refund refund = new Refund();
                    //der vendor hat eine Rückgabe ohne ausgabe datum
                    //in datagrid eintragen
                    // ablageort disablen
                    // newRecord is false
                    isNewRecord = false;
                    if (!isEditMode)
                    {
                        AblageOrtCB.Enabled = false;
                        //there is arefund record found
                        foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            object[] array = dt.Rows[0].ItemArray;
                            //in Tabelle RefundsDataGridView eintragen
                            if (!isEditMode)
                            {
                                RefundDataGridView.Rows.Add(
                                   array[1],
                                   array[2],
                                   array[3],
                                   array[4]);
                                refund.AccountID = (string)array[0];
                                refund.LastName = (string)array[1];
                                refund.Place = (string)array[2];
                                refund.Input = (string)array[3];
                            }
                            else
                            {
                                RefundDataGridView.Rows[0].Cells[2].Value= (string)array[2];
                                refund.Place = (string)array[2];
                                isEditMode = false;
                            }
                            refunds.Add(refund);
                        }
                    }
                    else
                    {
                        // is in EditMode
                        AblageOrtCB.Enabled = true;
                    }

                }
                else
                {
                    //there is no refund record found
                    isNewRecord = true;
                    AblageOrtCB.Enabled = true;
                }

            }
            else
            {
                // there is no vendor found
                // RefundDataGridView.Rows.Clear();
            }
            _ignoreEvents = false;
            comboBoxTextHasChanged = false;
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
                if (String.IsNullOrEmpty(RefundDataGridView.SelectedRows[0].Cells[3].Value.ToString()) )
                {
                    //there is one Article selected and not zurückgegeben and edit is possible
                    //menuitem verkauft
                    RefundContextMenuStrip.Items[0].Visible = true;
                    //MenuItem delete
                    RefundContextMenuStrip.Items[1].Visible = true;
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
                //Heutiges Datum in DataGridview  eintragen
                RefundDataGridView.SelectedRows[0].Cells[3].Value = myDate;

                // DBRefunds.UpdateRefund(refund);
                int index = RefundDataGridView.SelectedRows[0].Index;
                refunds[index].Output = myDate;

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
            //Datensatz in Datenbank löschen

            isNewRecord = false;
            isEditMode = true;

            AblageOrtCB.Enabled = true;
            VendorNameCB.Enabled = false;
            //AccountIDCB.Enabled = false;
            OKBtn.Visible = true;

        }



        #endregion

        private void VendorNameCB_TextChanged(object sender, EventArgs e)
        {
            comboBoxTextHasChanged = true;
        }
    }
}
