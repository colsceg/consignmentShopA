using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ConsignmentShopLibrary;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ConsignmentShopMainUI
{
    public partial class ContractUI : Form
    {
        private BindingSource source1 = new BindingSource();
        private DataView view1;
        private DataTable dt = new DataTable();

        private Store Store = new Store();
        private DataAccessItems DbItems = new DataAccessItems();
        private BindingList<Item> itemListItemNumber = new BindingList<Item>();
        private enum Status { alle, Laden, verkauft, ausbezahlt }

        private bool _ignoreEvents = true;
        private bool _deletedItems = false;
        private bool _SalesVolume = true;
        private string myFilter;

        #region Constructor
        public ContractUI()
        {
            InitializeComponent();
        }
        #endregion


        /// <summary>
        /// Was ist Form2 ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            Setup();
        }

        private void Setup()
        {
            //Get all items in a DataTable
            dt = DbItems.GetAllItemsContract();

            if (dt.Rows.Count > 0)
            {
                //Allow change all fields in DataTable
                foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;

                //Bind all items in a DataTable to a DataView
                view1 = new DataView(dt);
                //Bind the DataView to a DataSource
                source1.DataSource = view1;
                //Bind a DataSource to a DataGridView  (ds.Tables[0]);
                ReportItemsDataGridView.DataSource = source1;

                //query the DataView for the itemDescription ordered and get the Min date
                var queryMin = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Min();

                //query the DataView for the itemDescription ordered and get the Max date
                var queryMax = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Max();

                //Set the column header style.
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.Beige,
                    Font = new Font("Helvetica", 9, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new System.Windows.Forms.Padding(0)
                };
                ReportItemsDataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                //All Cells Property
                ReportItemsDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ReportItemsDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ReportItemsDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ReportItemsDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ReportItemsDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ReportItemsDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ReportItemsDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ReportItemsDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ReportItemsDataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ReportItemsDataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Automatically resize the visible columns.
                ReportItemsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set the Format property on the "Last Prepared" column to cause
                // the DateTime to be formatted as "Month, Year".
                ReportItemsDataGridView.Columns[7].DefaultCellStyle.Format = "C2";
                ReportItemsDataGridView.Columns[8].DefaultCellStyle.Format = "C2";
                ReportItemsDataGridView.Columns[0].Width = 50;
                ReportItemsDataGridView.Columns[1].Width = 50;
                ReportItemsDataGridView.Columns[5].Width = 35;
                ReportItemsDataGridView.Columns[7].Width = 70;
                ReportItemsDataGridView.Columns[8].Width = 60;
                ReportItemsDataGridView.Columns[9].Width = 60;

                //Set the Min Max date to the DateTimePicker Component
                _ignoreEvents = true;
                dtFrom.Value = queryMin;
                _ignoreEvents = true;
                dtTo.Value = queryMax;

                //Disable the DateTimePickker and the Status ComboBox 
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                CBPeriod.Enabled = false;

                _ignoreEvents = true;
                CBPeriod.SelectedIndex = 0;
                FillAttributeTables();
                FillAllFields();
                ClearAttributesText();
            }
            else
            {
                MessageBox.Show("Keine Daten vorhanden! ");
                Close();
            }
        }

        private void ClearAttributesText()
        {
            CBContractID.Text = "";
            CBAccountID.Text = "";
        }

        /// <summary>
        /// Comboboxes filter with items fill
        /// </summary>
        private void FillAttributeTables()
        {
            //Alle Artikeleigenschaften einlesen; 

            //Vertragsnummern
            _ignoreEvents = true;
            try
            {
                //query the DataView for the AccountID ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<string>("ContractID")
                            group rowView by rowView.Row.Field<string>("ContractID") into newDescription
                            select newDescription.Key;

                CBContractID.DataSource = query.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }

            //Kundennummern
            _ignoreEvents = true;
            try
            {
                //query the DataView for the AccountID ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<string>("AccountID")
                            group rowView by rowView.Row.Field<string>("AccountID") into newDescription
                            select newDescription.Key;

                CBAccountID.DataSource = query.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }
        }

        private string GetFilter()
        {
            string myDateQuery = "";
            int mySelectedPeriod = CBPeriod.SelectedIndex;
            string myToday = DateTime.Now.ToShortDateString();
            string myFromDate, myToDate;
            int myYear = DateTime.Today.Year;
            int myMonth = DateTime.Today.Month;
            string myContractID = CBContractID.Text;
            string myFilter = null;

            
            if (String.IsNullOrEmpty(myContractID))
            {
                myFilter = "AccountID LIKE '" + CBAccountID.Text.Trim() + "%' " +
                             myDateQuery;
            }
            else
            {
                myFilter = "AccountID LIKE '" + CBAccountID.Text.Trim() + "%' " +
                            " AND ContractID = '" + Convert.ToInt16(CBContractID.Text.Trim()) + " ' " +
                         myDateQuery;
            }
            return myFilter;

        }

        private void ChangeFilter()
        {

            string myItemDescription = CBContractID.Text;
            string myAccountID = CBAccountID.Text;
            string myContractID = CBContractID.Text;

            myFilter = GetFilter();
            view1.RowFilter = myFilter;
            source1.DataSource = view1;
            FillAttributeTables();
            FillAllFields();

            if (source1.Count > 0)
            {
                //query the DataView for the itemDescription ordered
                var queryMin = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Min();

                //query the DataView for the Brand ordered
                var queryMax = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Max();

                //Date for from to Datefields ermitteln
                _ignoreEvents = true;
                dtFrom.Value = queryMin;
                _ignoreEvents = true;
                dtTo.Value = queryMax;
            }

            CBContractID.Text = myItemDescription;
            CBAccountID.Text = myAccountID;
        }

        private void FillAllFields()
        {
            int myItemSoldCount = 0;
            int myCurrentItems = 0;
            double mySumPayed = 0;
            double mySumSalesVolume = 0.0;
            double mySumCost = 0.0;

            mySumSalesVolume = (from DataRowView rowView in view1
                                where rowView.Row.Field<object>("SoldDate") != null
                                select rowView.Row.Field<double>("SalesPrice")).Sum();

            mySumCost= (from DataRowView rowView in view1
                          where rowView.Row.Field<object>("SoldDate") != null
                          select rowView.Row.Field<double>("CostPrice")).Sum();

            mySumPayed = (from DataRowView rowView in view1
                          where rowView.Row.Field<object>("PayoutDate") != null
                          select rowView.Row.Field<double>("CostPrice")).Sum();



            myItemSoldCount = ReportItemsDataGridView.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells[11].Value)
                .Where(value => value != DBNull.Value)
                .Count();

            myCurrentItems = ReportItemsDataGridView.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells[11].Value)
                .Where(value => value == DBNull.Value)
                .Count();


            ItemsFoundTB.Text = Convert.ToString(ReportItemsDataGridView.RowCount);

            //ConvertToCurrency(anItemsList);
        }

 

        //Events Action
        private void CBAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBAccountID_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }


        private void CBContractID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBContractID_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                if (!String.IsNullOrWhiteSpace(CBContractID.Text))
                {
                    string myContractID = "ContractID = " + CBContractID.Text;
                    view1.RowFilter = myContractID;
                    source1.DataSource = view1;
                    FillAttributeTables();
                    FillAllFields();
                }
            }
            _ignoreEvents = false;
        }


        private void CBPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
                ChangeFilter();
            _ignoreEvents = false;
        }

        private void CBStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!_ignoreEvents)
                ChangeFilter();
            _ignoreEvents = false;
        }

        private void DtTo_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
                ChangeFilter();
            _ignoreEvents = false;
        }

        private void DtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
                ChangeFilter();
            _ignoreEvents = false;
        }

        private void DtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

        private void DtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

        //Button Click
        #region ButtonClick



        private void BtnClear_Click(object sender, EventArgs e)
        {
            _ignoreEvents = true;
            CBContractID.Text = "";
            _ignoreEvents = true;
            CBAccountID.Text = "";
            view1.RowFilter = GetFilter(); ;
            source1.DataSource = view1;
            FillAttributeTables();
            FillAllFields();
            ClearAttributesText();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SalesVolumePrintBtn_Click(object sender, EventArgs e)
        {
            if (_SalesVolume)
            {
                //DocumentContract aufrufen Umsatzliste ausdrucken
                DocumentSalesVolume SalesVolumeDocumentWindow = new DocumentSalesVolume();
                SalesVolumeDocumentWindow.FormClosed += new FormClosedEventHandler(SalesVolumeDocumentWindow_Closed);

                //Datumsfelder von bis im Dokument setzen
                SalesVolumeDocumentWindow.MyFromDate = dtFrom.Text;
                SalesVolumeDocumentWindow.MyToDate = dtTo.Text;

                //Inhalt des DataGridView in eine Liste schreiben
                List<ItemReport> myCurrentItemsList = view1.ToTable().Rows.Cast<DataRow>()
                        .Select(r => new ItemReport()
                        {
                            AccountID = r.Field<string>("AccountID"),
                            ItemNumber = Convert.ToString(r.Field<Int32>("ItemNumber")),
                            ItemDescription = r.Field<string>("ItemDescription"),
                            Color = r.Field<string>("Color"),
                            Brand = r.Field<string>("Brand"),
                            Size = r.Field<string>("Size"),
                            Prop = r.Field<string>("Prop"),
                            SalesPrice = r.Field<double>("SalesPrice").ToString(),
                            CostPrice = r.Field<double>("CostPrice").ToString(),
                            SoldDate = (r.Field<object>("SoldDate") == DBNull.Value ? "" : r.Field<DateTime>("SoldDate").ToShortDateString()),
                            PayoutDate = (r.Field<object>("PayoutDate") == DBNull.Value ? "" : r.Field<DateTime>("PayoutDate").ToShortDateString()),
                            BeginDate = (r.Field<object>("BeginDate") == DBNull.Value ? "" : r.Field<DateTime>("PayoutDate").ToShortDateString()),
                            EndDate = (r.Field<object>("EndDate") == DBNull.Value ? "" : r.Field<DateTime>("PayoutDate").ToShortDateString())
                        }).ToList();

                //Itemsliste an Dokument übergeben
                SalesVolumeDocumentWindow.MyItemsList = myCurrentItemsList;
                SalesVolumeDocumentWindow.ShowDialog();
            }
            else
            {
                //Artikelliste ausdrucken

                //Inhalt des DataGridView in eine Liste schreiben
                string myContractID ="0000";
                List<Item> myCurrentItemsList = view1.ToTable().Rows.Cast<DataRow>()
                        .Select(r => new Item()
                        {
                            AccountID = r.Field<string>("AccountID"),
                            ItemNumber = Convert.ToString(r.Field<Int32>("ItemNumber")),
                            ItemDescription = r.Field<string>("ItemDescription"),
                            Color = r.Field<string>("Color"),
                            Brand = r.Field<string>("Brand"),
                            Size = r.Field<string>("Size"),
                            Prop = r.Field<string>("Prop"),
                            SalesPrice = r.Field<double>("SalesPrice").ToString(),
                            CostPrice = r.Field<double>("CostPrice").ToString(),
                            BeginDate =  r.Field<DateTime>("BeginDate").ToShortDateString(),
                            EndDate = r.Field<DateTime>("EndDate").ToShortDateString(),
                        }).ToList();
                List<Contract> myContractList = DbItems.GetContractWithAccountID(Store.ConvertContractNumberToContractID(myCurrentItemsList[0].AccountID));
                if (myContractList.Count > 0)
                    myContractID = myContractList[0].ContractID;
                else
                //ContractID festlegen
                {
                    List<ConfigData> myConfigData = DbItems.GetConfigData();
                    if (myConfigData.Count > 0)
                    {
                        myContractID = myConfigData[0].LastContractID;
                        myContractID = Store.IncrementContractID(myContractID);
                    }
                }

                for (int i = 0; i < myCurrentItemsList.Count; i++)
                {
                    myCurrentItemsList[i].ContractID = myContractID;
                }

                //ruft neues Fenster auf zur Anzeige der Artikel
                DocumentContract documentWindow = new DocumentContract();
                documentWindow.FormClosed += new FormClosedEventHandler(DocumentContractWindow_Closed);
                documentWindow.ContractItemList = myCurrentItemsList;
                documentWindow.ShowDialog();                
            }
        }

        private void DocumentContractWindow_Closed(object sender, EventArgs e)
        {
            if (sender is DocumentContract documentContractWindow)
            {
                documentContractWindow.FormClosed -= new FormClosedEventHandler(DocumentContractWindow_Closed);
            }
            _ignoreEvents = true;

        }

        private void ExportBtn_Click(object sender, EventArgs e)
            {
                ExportBtn.UseWaitCursor = true;
                //Stopwatch watch = new Stopwatch();

                //Build the CSV file data as a Comma separated string.
                StringBuilder csv = new StringBuilder();
                StringBuilder myCsvLine = new StringBuilder();
                // Create a SaveFileDialog to request a path and file name to save to.
                SaveFileDialog saveFile1 = new SaveFileDialog();

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in ReportItemsDataGridView.Columns)
                    csv.Append(column.HeaderText + ';');

                //Add new line.
                csv.Append("\r\n");
                char[] myStr = { ' ' };
                //Adding the Rows
                //watch.Start();
                foreach (DataGridViewRow row in ReportItemsDataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //Add the Data rows.

                        string myCell = (cell.Value != null) ? cell.Value.ToString().Replace("€", "") + ';' : "" + ';';
                        csv.Append(myCell);
                    }
                    //Add new line.               
                    csv.Append("\r\n");
                }
                //watch.Stop();
                //MessageBox.Show("verbrauchte Zeit{0}", watch.ElapsedMilliseconds.ToString());
                saveFile1.DefaultExt = "*.csv";
                saveFile1.Filter = "CSV Files|*.csv";
                ExportBtn.UseWaitCursor = false;
                //Exporting to CSV.
                string folderPath = Store.GetPersonalFolder() + "\\2ndHandWare";

                // Determine if the user selected a file name from the saveFileDialog.
                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                   saveFile1.FileName.Length > 0)
                {
                    // Save the contents of the RichTextBox into the file.
                    File.WriteAllText(saveFile1.FileName, csv.ToString());
                }

            }

        #endregion

        private void UpdateRow(Item anItem)
        {
            int mySelectedIndex;
            int count = ReportItemsDataGridView.SelectedRows.Count;
            if (count > 0)
            {
                mySelectedIndex = ReportItemsDataGridView.SelectedRows[0].Index;
                ReportItemsDataGridView.SelectedRows[0].Cells[2].Value = anItem.ItemDescription;
                ReportItemsDataGridView.SelectedRows[0].Cells[3].Value = anItem.Brand;
                ReportItemsDataGridView.SelectedRows[0].Cells[4].Value = anItem.Color;
                ReportItemsDataGridView.SelectedRows[0].Cells[5].Value = anItem.Size;
                ReportItemsDataGridView.SelectedRows[0].Cells[6].Value = anItem.Prop;
                ReportItemsDataGridView.SelectedRows[0].Cells[7].Value = anItem.SalesPrice.Replace(".", ",");
                ReportItemsDataGridView.SelectedRows[0].Cells[8].Value = anItem.CostPrice.Replace(".", ","); 
            }
            else
            {
                mySelectedIndex = GetIndexForAccountID(anItem.AccountID);
            }
            //ReportItemsDataGridView.FirstDisplayedScrollingRowIndex = mySelectedIndex;
        }

        /// <summary>
        /// get the row index for a specified accountID
        /// </summary>
        /// <param name="anAccountID"></param>
        /// <returns></returns>
        private int GetIndexForAccountID(string anAccountID)
        {
            String searchValue = anAccountID;
            int rowIndex = -1;
            foreach (DataGridViewRow row in ReportItemsDataGridView.Rows)
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

        //Menu Click action
        //On Menu open
        /// <summary>
        /// select the menu items that are shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool couldDelete = true;
            if (ReportItemsDataGridView.SelectedRows.Count > 0)
            {
                if (ReportItemsDataGridView.SelectedRows.Count > 1)
                {    //multiple rows selected test if there is an article that is not sold
                    for (int i = 0; i < ReportItemsDataGridView.SelectedRows.Count; i++)
                    {

                        if ((!String.IsNullOrEmpty(ReportItemsDataGridView.SelectedRows[i].Cells[11].Value.ToString())) &&
                            (!String.IsNullOrEmpty(ReportItemsDataGridView.SelectedRows[i].Cells[12].Value.ToString())) ||
                            (_deletedItems))
                        {
                            couldDelete = false;
                        }
                    }
                    //all items sold or deleted
                    if (!couldDelete)
                    {
                        //delete
                        contextMenuStrip1.Items[0].Visible = false;
                        //edit
                        contextMenuStrip1.Items[1].Visible = false;
                        //undelete
                        contextMenuStrip1.Items[2].Visible = false;
                    }
                    else
                    {
                        //delete
                        contextMenuStrip1.Items[0].Visible = true;
                        //edit
                        contextMenuStrip1.Items[1].Visible = false;
                        //undelete
                        contextMenuStrip1.Items[2].Visible = false;
                    }
                }
                else
                {// one Item selected Menu item delete nur anzeigen wenn nicht verkauft, nicht ausbezahlt und nicht gelöscht
                    if ((!String.IsNullOrEmpty(ReportItemsDataGridView.SelectedRows[0].Cells[11].Value.ToString())) &&
                        (!String.IsNullOrEmpty(ReportItemsDataGridView.SelectedRows[0].Cells[12].Value.ToString())) ||
                        (_deletedItems))
                    {
                        //delete
                        contextMenuStrip1.Items[0].Visible = false;
                        //edit
                        contextMenuStrip1.Items[1].Visible = true;
                        //undelete
                        contextMenuStrip1.Items[2].Visible = false;
                    }
                    else
                    {
                        //delete
                        contextMenuStrip1.Items[0].Visible = true;
                        //edit
                        contextMenuStrip1.Items[1].Visible = true;
                        //undelete
                        contextMenuStrip1.Items[2].Visible = false;
                    }
                }

                //only deleted articles are shon
                if (_deletedItems)
                {
                    //delete
                    contextMenuStrip1.Items[0].Visible = false;
                    //edit
                    contextMenuStrip1.Items[1].Visible = false;
                    //undelete
                    contextMenuStrip1.Items[2].Visible = true;
                }
            }
            else
            {
                //delete
                contextMenuStrip1.Items[0].Visible = false;
                //edit
                contextMenuStrip1.Items[1].Visible = false;
                //undelete
                contextMenuStrip1.Items[2].Visible = false;
            }
        }
       
        /// <summary>
        /// set deleteDate = today to an article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Selektierte Artikel löschen?",
                                  "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (var item in ReportItemsDataGridView.SelectedRows)
                {
                    if (String.IsNullOrEmpty(ReportItemsDataGridView.SelectedRows[0].Cells[11].Value.ToString()))
                    {

                        int myIndex = ReportItemsDataGridView.SelectedRows[0].Index;
                        string anItemNumber = ReportItemsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                        //aktuelles Datum 
                        string aDeleteDate = DateTime.Today.ToShortDateString();
                        //Löschdatum  Datenbank eintragen
                        ReportItemsDataGridView.Rows.RemoveAt(myIndex);
                        DbItems.UpdateItemDeletedWithItemNumber(anItemNumber, aDeleteDate);
                    }
                }
            }
        }

        /// <summary>
        /// edit an article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemEditUI ItemEditWindow = new ItemEditUI();
            //ItemEditWindow.MySelectedItem = ReportItemsDataGridView.SelectedRows[0];
            string myAccountID = ReportItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString();

            Item myItem = new Item();
            myItem.AccountID = ReportItemsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            myItem.ItemNumber = ReportItemsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            myItem.ItemDescription = ReportItemsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            myItem.Brand = ReportItemsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            myItem.Color = ReportItemsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            myItem.Size = ReportItemsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            myItem.Prop = ReportItemsDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            myItem.SalesPrice = ReportItemsDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            myItem.CostPrice = ReportItemsDataGridView.SelectedRows[0].Cells[8].Value.ToString();

            myItem.BeginDate = (ReportItemsDataGridView.SelectedRows[0].Cells[9].Value.ToString() == "" ?
                "" : ReportItemsDataGridView.SelectedRows[0].Cells[9].Value.ToString().Substring(0, 10));
            myItem.EndDate = (ReportItemsDataGridView.SelectedRows[0].Cells[10].Value.ToString() == "" ?
                "" : ReportItemsDataGridView.SelectedRows[0].Cells[10].Value.ToString().Substring(0, 10));
            myItem.SoldDate = (ReportItemsDataGridView.SelectedRows[0].Cells[11].Value.ToString() == "" ?
                "" : ReportItemsDataGridView.SelectedRows[0].Cells[11].Value.ToString().Substring(0, 10));
            myItem.PayoutDate = (ReportItemsDataGridView.SelectedRows[0].Cells[12].Value.ToString() == "" ?
                "" : ReportItemsDataGridView.SelectedRows[0].Cells[12].Value.ToString().Substring(0, 10));
            ItemEditWindow.MySelectedItem = myItem;
            ItemEditWindow.FormClosed += new FormClosedEventHandler(ItemEditWindow_Closed);
            ItemEditWindow.ShowDialog();
        }

        /// <summary>
        /// option to undelete a deleted article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Für selektierte Artikel Löschung aufheben?",
                      "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (var item in ReportItemsDataGridView.SelectedRows)
                {
                    if (String.IsNullOrEmpty(ReportItemsDataGridView.SelectedRows[0].Cells[11].Value.ToString()))
                    {

                        int myIndex = ReportItemsDataGridView.SelectedRows[0].Index;
                        string anItemNumber = ReportItemsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                        //aktuelles Datum 
                        string aDeleteDate = DateTime.Today.ToShortDateString();
                        //Löschdatum in Datenbank löschen
                        ReportItemsDataGridView.Rows.RemoveAt(myIndex);
                        DbItems.UpdateItemDeletedWithItemNumber(anItemNumber, "");
                    }
                }
            }
        }

        //Windows schliessen
        /// <summary>
        /// after printing the Umsatzliste the Document window is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesVolumeDocumentWindow_Closed(object sender, EventArgs e)
        {
            if (sender is DocumentSalesVolume SalesVolumeDocumentWindow)
            {
                bool mySalesVolumeDocumentPrinted = false;
                mySalesVolumeDocumentPrinted = SalesVolumeDocumentWindow.MyContractPrinted;
                SalesVolumeDocumentWindow.FormClosed -= new FormClosedEventHandler(SalesVolumeDocumentWindow_Closed);
            }
        }

        /// <summary>
        /// after edit an article close the edit window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemEditWindow_Closed(object sender, FormClosedEventArgs e)
        {
            if (sender is ItemEditUI ItemEditWindow)
            {
                bool myItemEdited = false;
                myItemEdited = ItemEditWindow.MyItemEdited;
                Item myEditedItem = ItemEditWindow.MySelectedItem;
                if (myItemEdited)
                {
                    UpdateRow(myEditedItem);
                }
                ItemEditWindow.FormClosed -= new FormClosedEventHandler(ItemEditWindow_Closed);
            }

        }

        private void ReportItemsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void itemBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

    }
}
