﻿using ConsignmentShopLibrary;
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

        private Refund refund = new Refund();
        private Store Store = new Store();

        private BindingSource source1 = new BindingSource();
        private DataTable dt = new DataTable();

        private DataAccessVendors DbVendors = new DataAccessVendors();
        private DataAccessRefunds DBRefunds = new DataAccessRefunds();
        private DataAccessItems DbItems = new DataAccessItems();

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
            AccountIDCB.DataSource = accountIDs;

            _ignoreEvents = true;
            //Combobox fill with vendor fullinfo
            VendorNameCB.DataSource = vendors;
            _ignoreEvents = true;

            AccountIDCB.SelectedIndex = -1;
            VendorNameCB.SelectedItem = -1;

            VendorNameCB.Text = " ";
            AccountIDCB.Focus();
            _ignoreEvents = false;
        }


        #region Buttons clicks

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
            //Object der Rueckgabe in DB speichern 

            //decide if new record or update an existing reccord

            if (isNewRecord)
                DBRefunds.InsertRefund(refund); //Tabelle Rueckgaben AccountID, Name, Ort, Eingabe, Ausgabe
            else
                DBRefunds.UpdateRefund(refund);
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
            if (!_ignoreEvents)
            {
                // Test if vendor fillinfo OK
                String value = VendorNameCB.Text.ToString();
                if (!String.IsNullOrEmpty(value))
                {
                    char delimiter = ';';
                    String[] substrings = value.Split(delimiter);


                    if ((substrings.Count() == 3))
                    {
                        String myAccountID = substrings[2].Trim();
                        int index = AccountIDCB.FindString(myAccountID);
                        _ignoreEvents = false;
                        AccountIDCB.SelectedIndex = index;
                    }
                    else
                        AccountIDCB.SelectedIndex = -1;
                }
                else
                {
                    AccountIDCB.SelectedIndex = -1;
                }
            }
                else
                    _ignoreEvents = false;
            }

        private void VendorNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClearDS();
            string myAccountID;
            if (!_ignoreEvents)
            {
                if (VendorNameCB.SelectedIndex >= 0)
                {
                    String value = VendorNameCB.Text.ToString();

                    char delimiter = ';';
                    String[] substrings = value.Split(delimiter);
                    myAccountID = substrings[2].Trim();
                    _ignoreEvents = true;
                    AccountIDCB.Text = myAccountID;
                    FillAllFields(myAccountID);
                }
            }
            else
                _ignoreEvents = false;
        }

        private void AccountIDCB_Leave(object sender, EventArgs e)
        {
            //ClearDS();
            if (!_ignoreEvents)
            {
                String value = AccountIDCB.Text.ToString();
                if (value.Length == 4 && !String.IsNullOrEmpty(value))
                {
                    //VendorNameComboBox mit aktuellem Namen selektieren
                    List<Vendor> myAktVendorList = DbVendors.GetVendorWithAccountID(value);
                    if (myAktVendorList.Count > 0)
                    {
                        string myAktVendor = myAktVendorList[0].FullInfo;
                        int index = VendorNameCB.FindString(myAktVendor);
                        _ignoreEvents = true;
                        VendorNameCB.SelectedIndex = index;

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
                        AccountIDCB.Text = "";
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

        private void AccountIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClearDS();
            if (!_ignoreEvents)
            {
                if (AccountIDCB.SelectedIndex >= 0)
                {
                    String value = AccountIDCB.Text.ToString();

                    //VendorNameComboBox mit aktuellem Namen selektieren
                    List<Vendor> myAktVendorList = DbVendors.GetVendorWithAccountID(value);
                    string myAktVendor = myAktVendorList[0].FullInfo;
                    int index = VendorNameCB.FindString(myAktVendor);
                    _ignoreEvents = true;
                    VendorNameCB.SelectedIndex = index;

                    //Formularfelder füllen
                    _ignoreEvents = true;
                    FillAllFields(value);
                }
            }
            else
                _ignoreEvents = false;
        }

        private void AblageOrtCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            AblageOrtCB_Leave(sender, e);
        }

        private void AblageOrtCB_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AblageOrtCB.Text))
            {
                string myAktDate = DateTime.Today.ToShortDateString();
                //myAktDate = myAktDate.Replace('.', '_');
                //Lastname aus Text extrahieren
                char delimiter = ';';
                String name = VendorNameCB.Text;
                String[] substrings = name.Split(delimiter);

                if ((substrings.Count() == 3))
                {
                    refund.AccountID = substrings[2].Trim();
                    refund.LastName = substrings[0].Trim();
                }

                refund.Place = AblageOrtCB.Text;
                refund.Input = myAktDate; //aktuelles Datum
                refund.Output = "";
                OKBtn.Visible = true;

                //in Tabelle RefundsDataGridView eintragen
                if (RefundDataGridView.RowCount == 0)
                {
                    RefundDataGridView.Rows.Add(
                        refund.LastName,
                        refund.Place,
                        refund.Input, //aktuelles Datum
                        refund.Output);
                }
                else
                {
                    RefundDataGridView.Rows.RemoveAt(0);
                    RefundDataGridView.Rows.Add(
                        refund.LastName,
                        refund.Place,
                        refund.Input, //aktuelles Datum
                        refund.Output);
                }

                //AblageOrtCB.Enabled = false;

                OKBtn.Focus();
            }
        }

        #endregion




        #region Methods

        /// <summary>
        /// Clear refund data when no Input and output empty
        /// </summary>
        private void ClearDS()
        {

            if (!String.IsNullOrEmpty(refund.Input) && !String.IsNullOrEmpty(refund.Output))
            {
                RefundDataGridView.Rows.RemoveAt(0);
                refund.AccountID = "";
                refund.LastName = "";
                refund.Place = "";
                refund.Input = ""; //aktuelles Datum
                refund.Output = "";
                AblageOrtCB.Enabled = true;
            }
        }

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
                if (dt.Rows.Count > 0 )
                {
                    //der vendor hat eine Rückgabe ohne ausgabe datum
                    //in datagrid eintrgaen
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
                //there is no vendor found
                RefundDataGridView.Rows.Clear();
            }
            _ignoreEvents = false;

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
                if (String.IsNullOrEmpty(RefundDataGridView.SelectedRows[0].Cells[3].Value.ToString()) && OKBtn.Visible == false)
                {
                    //there is one Article selected and not sold, sold and edit is possible
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

            if (RefundDataGridView.SelectedRows.Count > 0 )
            {
                //Heutiges Datum in DataGridview  eintragen
                RefundDataGridView.SelectedRows[0].Cells[3].Value = myDate;

                refund.Output = myDate;

                // DBRefunds.UpdateRefund(refund);
                int index = RefundDataGridView.SelectedRows[0].Index;

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
            refund.Place = RefundDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            AblageOrtCB.Enabled = true;
            VendorNameCB.Enabled = false;
            AccountIDCB.Enabled = false;
            OKBtn.Visible = true;

        }


        #endregion


    }
}
