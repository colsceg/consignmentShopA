using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ConsignmentShopLibrary;
using VendorEditUI;
using System.Linq;
using System.Data;

namespace ConsignmentShopMainUI
{
    public partial class VendorTableUI : Form
    {
        private BindingSource source1 = new BindingSource();
        private DataView view1;
        private DataTable dt = new DataTable();

        private List<Vendor> vendorsList = new List<Vendor>();
        private List<string> vendorsListStrings = new List<string>();
        private Vendor newVendor = new Vendor();

        private DataAccessVendors dbVendors = new DataAccessVendors();
        private DataAccessItems dbItems = new DataAccessItems();
        private bool _ignoreEvents = true;

        public string FullInfo { get; set; }

        private bool loaded = false;
        private string myFilter;

        public VendorTableUI()
        {
            InitializeComponent();
            Load += new EventHandler(VendorTableUI_Load);
        }

        private void VendorTableUI_Load(object sender, EventArgs e)
        {
            if (!loaded)
            {
                //PopulateDataGridView();
                // lädt die Tabelle customers aus der SQLite DB
                //Disp();

                //Get all items in a DataTable
                dt = dbVendors.GetAllVendors();
                //Allow change all fields in DataTable
                foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;

                //Bind all items in a DataTable to a DataView
                view1 = new DataView(dt);
                //Bind the DataView to a DataSource
                source1.DataSource = view1;
                //Bind a DataSource to a DataGridView  (ds.Tables[0]);
                VendorDataGridView.DataSource = source1;

                //Set the column header style.
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Helvetica", 9, FontStyle.Bold);
                columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                columnHeaderStyle.Padding = new System.Windows.Forms.Padding(0);
                VendorDataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                // Set the column header names.
                VendorDataGridView.Columns[0].HeaderText = "KdNr";
                VendorDataGridView.Columns[1].HeaderText = "Nachname";
                VendorDataGridView.Columns[2].HeaderText = "Vorname";
                VendorDataGridView.Columns[3].HeaderText = "Strasse";
                VendorDataGridView.Columns[4].HeaderText = "PLZ";
                VendorDataGridView.Columns[5].HeaderText = "Wohnort";
                VendorDataGridView.Columns[6].HeaderText = "Telefon";
                VendorDataGridView.Columns[7].HeaderText = "Mobil";
                VendorDataGridView.Columns[8].HeaderText = "Email";
                VendorDataGridView.Columns[9].HeaderText = "Marge";
                VendorDataGridView.Columns[10].HeaderText = "Dauer";
                VendorDataGridView.Columns[11].HeaderText = "Annex1";
                VendorDataGridView.Columns[12].HeaderText = "Annex2"; ;

                //All Cells Property
                VendorDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                VendorDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                VendorDataGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                VendorDataGridView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                VendorDataGridView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Automatically resize the visible columns.
                VendorDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                VendorDataGridView.Columns[0].Width = 50;
                VendorDataGridView.Columns[1].Width = 80;
                VendorDataGridView.Columns[2].Width = 80;
                VendorDataGridView.Columns[3].Width = 80;
                VendorDataGridView.Columns[4].Width = 40;
                VendorDataGridView.Columns[5].Width = 80;
                VendorDataGridView.Columns[6].Width = 80;
                VendorDataGridView.Columns[7].Width = 80;
                VendorDataGridView.Columns[8].Width = 80;
                VendorDataGridView.Columns[9].Width = 40;
                VendorDataGridView.Columns[10].Width = 40;
                VendorDataGridView.Columns[11].Width = 70;
                VendorDataGridView.Columns[12].Width = 70;

                FillAttributeTables();

                ClearAttributesText();
                loaded = true;
            }
        }

        private void ClearAttributesText()
        {
            AccountIDCB.Text = "";
            LastNameCB.Text = "";
            PlzCB.Text = "";
            TownCB.Text = "";
        }

        private void FillAttributeTables()
        {

            //Beschreibung 
            _ignoreEvents = true;
            try
            {
                //LastName ComboBox mit Lastname füllen aus der Tabelle lesen
                // Set RowStateFilter to display the current rows.
                view1.RowStateFilter = DataViewRowState.CurrentRows;
                //query the DataView for the itemDescription ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<string>("LastName")
                            group rowView by rowView.Row.Field<string>("LastName") into newDescription
                            select newDescription.Key;

                LastNameCB.DataSource = query.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }

            //Marken 
            _ignoreEvents = true;
            try
            {
                //query the DataView for the Brand ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<string>("Plz")
                            group rowView by rowView.Row.Field<string>("Plz") into newDescription
                            select newDescription.Key;

                PlzCB.DataSource = query.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }


            //Farben
            _ignoreEvents = true;
            try
            {
                //query the DataView for the Color ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<string>("Town")
                            group rowView by rowView.Row.Field<string>("Town") into newDescription
                            select newDescription.Key;

                TownCB.DataSource = query.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }


            //Größen
            _ignoreEvents = true;
            try
            {
                //query the DataView for the Size ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<string>("AccountID")
                            group rowView by rowView.Row.Field<string>("AccountID") into newDescription
                            select newDescription.Key;

                AccountIDCB.DataSource = query.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }
        }

        private string GetFilter()
        {
            string myFilter = "AccountID LIKE '" + AccountIDCB.Text.Trim() + "%' " +
                " AND LastName LIKE '" + LastNameCB.Text.Trim() + "%' " +
                " AND Plz LIKE '" + PlzCB.Text.Trim() + "%' " +
                " AND Town LIKE '" + TownCB.Text.Trim() + "%' " ;
            return myFilter;
        }

        private void ChangeFilter()
        {
            string myLastname = LastNameCB.Text;
            string myPlz = PlzCB.Text;
            string myTown = TownCB.Text;
            string myAccountID = AccountIDCB.Text;

            myFilter = GetFilter();
            view1.RowFilter = myFilter;
            source1.DataSource = view1;
            FillAttributeTables();

            LastNameCB.Text = myLastname;
            PlzCB.Text = myPlz;
            TownCB.Text = myTown;
            AccountIDCB.Text = myAccountID;
        }

        private int GetIndexForAccountID(string anAccountID)
        {
            String searchValue = anAccountID;
            int rowIndex = -1;
            foreach (DataGridViewRow row in VendorDataGridView.Rows)
            {
                if (row.Cells[0].Value != null) // Need to check for null if new row is exposed
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
            }

            return rowIndex;
        }

        private void ShowSelectedRow(int anIndex)
        {
            if (VendorDataGridView.Rows.Count != 0)
            {


                if (anIndex >= VendorDataGridView.Rows.Count)
                {
                    VendorDataGridView.FirstDisplayedScrollingRowIndex = VendorDataGridView.Rows.Count - 1;
                    VendorDataGridView.Rows[VendorDataGridView.Rows.Count - 1].Selected = true;
                }
                else
                {
                    if (anIndex == -1)
                        anIndex = 0;
                    VendorDataGridView.FirstDisplayedScrollingRowIndex = anIndex;
                    VendorDataGridView.Rows[anIndex].Selected = true;
                }
            }
        }

        private void EditRow()
        {
            //Ruft neues Fenster auf zur Eingabe der Kundendaten
            VendorEdit vendorEditWindow = new VendorEdit();
            OwnerEditUI ownerEditWindow = new OwnerEditUI();

            string selectedAccountID;
            //Abhängig vom AccountID Owner-Edit oder customer-Edit window aufrufen
            if (VendorDataGridView.SelectedRows.Count > 0 && 
                VendorDataGridView.SelectedRows[0].Index <= VendorDataGridView.Rows.Count - 1)
            {
                selectedAccountID = VendorDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                if (selectedAccountID.Equals("1000"))
                {
                    ownerEditWindow.FormClosed += new FormClosedEventHandler(OwnerEditWindow_Closed);
                    ownerEditWindow.ShowDialog();
                }
                else
                {
                    vendorEditWindow.IDInVendorIDTextBox = selectedAccountID;
                    vendorEditWindow.FormClosed += new FormClosedEventHandler(VendorEditWindow_Closed);
                    vendorEditWindow.ShowDialog();
                }
            }
            else
                MessageBox.Show("Kein Kunde ausgewählt");
        }

        private void DeleteSelectedRow()
        {
            //Selektierte Reihe löschen
            if (VendorDataGridView.SelectedRows.Count > 0 &&
                    VendorDataGridView.SelectedRows[0].Index <= VendorDataGridView.Rows.Count - 1)
            {
                int index = VendorDataGridView.SelectedRows[0].Index;

                string selectedAccountID;
                selectedAccountID = VendorDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                List<Item> listOfContracts = dbItems.GetAllItemsWithAccountID(selectedAccountID);
                if (listOfContracts.Count > 0 || selectedAccountID == "1000")
                {
                    if (selectedAccountID == "1000")
                        MessageBox.Show("Inhaberdaten können nicht gelöscht werden");
                    else
                        MessageBox.Show("Lieferant kann nicht gelöscht werden (Verträge exitstieren)");
                }
                else
                {
                    DialogResult result = MessageBox.Show(VendorDataGridView.SelectedRows[0].Cells[1].Value.ToString() + "  " 
                        + VendorDataGridView.SelectedRows[0].Cells[2].Value.ToString() + " wirklich löschen?" ,
                        "Bestätigung", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        VendorDataGridView.Rows.RemoveAt(index);
                        dbVendors.DeletePerson(selectedAccountID);
                    }
                }
            }
            else
                MessageBox.Show("Kein Kunde ausgewählt");
        }

        private void UpdateRow(Vendor aVendor)
        {
            int mySelectedIndex;
            int count = VendorDataGridView.SelectedRows.Count;
            if (count > 0)
            {
                mySelectedIndex = VendorDataGridView.SelectedRows[0].Index;
                VendorDataGridView.SelectedRows[0].Cells[0].Value = aVendor.AccountID;
                VendorDataGridView.SelectedRows[0].Cells[1].Value = aVendor.LastName;
                VendorDataGridView.SelectedRows[0].Cells[2].Value = aVendor.FirstName;
                VendorDataGridView.SelectedRows[0].Cells[3].Value = aVendor.Street;
                VendorDataGridView.SelectedRows[0].Cells[4].Value = aVendor.Plz;
                VendorDataGridView.SelectedRows[0].Cells[5].Value = aVendor.Town;
                VendorDataGridView.SelectedRows[0].Cells[6].Value = aVendor.PhoneNumber1;
                VendorDataGridView.SelectedRows[0].Cells[7].Value = aVendor.PhoneNumber2;
                VendorDataGridView.SelectedRows[0].Cells[8].Value = aVendor.EmailAccount;
                VendorDataGridView.SelectedRows[0].Cells[9].Value = aVendor.Margin;
                VendorDataGridView.SelectedRows[0].Cells[10].Value = aVendor.Period;
                VendorDataGridView.SelectedRows[0].Cells[11].Value = aVendor.Annex1;
                VendorDataGridView.SelectedRows[0].Cells[12].Value = aVendor.Annex2;
                
            }
            else
            {
                mySelectedIndex = GetIndexForAccountID(aVendor.AccountID);
            }
            VendorDataGridView.FirstDisplayedScrollingRowIndex = mySelectedIndex;
        }

        //ButtonClick Reaction
        private void AddNewVendorButton_Click(object sender, EventArgs e)
        {
            //Selection in DataGridView auf false setzen
            int count = VendorDataGridView.SelectedRows.Count;
            if (count > 0)
            {
                foreach (var item in VendorDataGridView.SelectedRows)
                {
                    VendorDataGridView.Rows[0].Selected = false;
                }
            }

            //Ruft neues Fenster auf zur Eingabe der Kundendaten
            VendorEdit vendorEditWindow = new VendorEdit();
            vendorEditWindow.FormClosed += new FormClosedEventHandler(VendorEditWindow_Closed);
            vendorEditWindow.ShowDialog();
        }

        private void EditRowButton_Click(object sender, EventArgs e)
        {
            EditRow();
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
            {
                DeleteSelectedRow();
            }

        private void SaveRecordButton_Click(object sender, EventArgs e)
        {
            //speichert den Inhalt der kompletten tabelle in Data Tablle
            MessageBox.Show("Not implemented yet");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {   
            //Fenster schliessen
            //vendorsListStrings in Tabelle speichern
            Close();
        }

        //Filter Reaktionen
        private void AccountIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void AccountIDCB_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void LastNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void LastNameCB_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void PlzCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void PlzCB_Leave(object sender, EventArgs e)
        {

        }

        private void TownCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TownCB_Leave(object sender, EventArgs e)
        {

        }

        private void BearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRow();
        }

        private void LöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        //Close Window
        private void VendorEditWindow_Closed(object sender, EventArgs e)
        {
            VendorEdit vendorEditWindow = sender as VendorEdit;
            if (vendorEditWindow != null)
            {
                Vendor myNewVendor = new Vendor();
                myNewVendor = vendorEditWindow.NewVendorFromVendorEdit;
                int mySelectedIndex;
                if (VendorDataGridView.SelectedRows.Count > 0)
                    mySelectedIndex = VendorDataGridView.SelectedRows[0].Index;
                else
                    mySelectedIndex = 0;

                if (myNewVendor.AccountID != null)
                {//neuen Kunden in Tabelle anzeigen
                    if (vendorEditWindow.VendorInserted)
                    {
                        //Get all items in a DataTable
                        dt = dbVendors.GetAllVendors();
                        //Bind all items in a DataTable to a DataView
                        view1 = new DataView(dt);
                        //Bind the DataView to a DataSource
                        source1.DataSource = view1;
                        //Bind a DataSource to a DataGridView  (ds.Tables[0]);
                        //VendorDataGridView.DataSource = source1;
                        //VendorDataGridView.Refresh();
                        VendorDataGridView.FirstDisplayedScrollingRowIndex = mySelectedIndex;
                    }
                    else
                        UpdateRow(myNewVendor);
                    //Änderungen in Datenbank werden in EditWindow gespeichert
                    this.FullInfo = myNewVendor.FullInfo;
                }
                ClearAttributesText();
            }
            vendorEditWindow.FormClosed -= new FormClosedEventHandler(VendorEditWindow_Closed);
        }

        private void OwnerEditWindow_Closed(object sender, EventArgs e)
        {
            OwnerEditUI ownerEditWindow = sender as OwnerEditUI;
            if (ownerEditWindow != null)
            {
                Vendor myNewVendor = new Vendor();
                myNewVendor = ownerEditWindow.NewVendorFromOwnerEdit;
                if (myNewVendor.AccountID != null)
                {//neue Kundendaten in Tabelle anzeigen
                    UpdateRow(myNewVendor);
                    //Änderungen in Datenbank werden in EditWindow gespeichert
                }
                ownerEditWindow.FormClosed -= new FormClosedEventHandler(OwnerEditWindow_Closed);
            }
        }



    }
}

