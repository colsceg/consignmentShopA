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
        private void ContractUI_Load(object sender, EventArgs e)
        {
            Setup();
        }

        /// <summary>
        /// Get all items grouped by ContractID
        /// </summary>
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
                ReportItemsDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //ContractID
                ReportItemsDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //AccountID
                ReportItemsDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //ItemNumber
                ReportItemsDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //ItemDescription
                ReportItemsDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //Brand
                ReportItemsDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //color
                ReportItemsDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //size
                ReportItemsDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //prop
                ReportItemsDataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //CostPrice
                ReportItemsDataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //SalesPrice
                ReportItemsDataGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //BeginDate
                ReportItemsDataGridView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //EndDate

                // Automatically resize the visible columns.
                ReportItemsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set the Format property on the "Last Prepared" column to cause
                // the DateTime to be formatted as "Month, Year".

                ReportItemsDataGridView.Columns[0].Width = 70; //ContractID
                ReportItemsDataGridView.Columns[1].Width = 60; //AccountID
                ReportItemsDataGridView.Columns[2].Width = 60; //ItemNumber
                ReportItemsDataGridView.Columns[3].Width = 130; //ItemDescription
                ReportItemsDataGridView.Columns[4].Width = 120;  //Brannd
                ReportItemsDataGridView.Columns[5].Width = 90;  //Color/
                ReportItemsDataGridView.Columns[6].Width = 45;  //Size
                ReportItemsDataGridView.Columns[7].Width = 120; //prop
                ReportItemsDataGridView.Columns[8].Width = 60; //CostPrice
                ReportItemsDataGridView.Columns[9].Width = 60;  //SalesPrice
                ReportItemsDataGridView.Columns[10].Width = 80; //BeginDate
                ReportItemsDataGridView.Columns[11].Width = 80; //EndDate

                //Set the Min Max date to the DateTimePicker Component
                _ignoreEvents = true;
                dtFrom.Value = queryMin;
                _ignoreEvents = true;
                dtTo.Value = queryMax;

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

            _ignoreEvents = false;
        }

        /// <summary>
        /// Clear filter comboboxes 
        /// </summary>
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
                if (CBContractID.Items.Count == 1)
                    ContractIDPrintBtn.Enabled = true;
                else
                    ContractIDPrintBtn.Enabled = false;

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

        /// <summary>
        /// Reads the filter controls and builds the filter string
        /// </summary>
        /// <returns> The filter string </returns>
        private string GetFilter()
        {
            string myDateQuery = "";
            int mySelectedPeriod = CBPeriod.SelectedIndex;
            string myToday = DateTime.Now.ToShortDateString();
            string myFromDate, myToDate;
            int myYear = DateTime.Today.Year;
            int myMonth = DateTime.Today.Month;
            string myContractID = CBContractID.Text;
            string myAccountID = CBAccountID.Text;
            string myFilter = null;
            CBPeriod.Enabled = true;

            switch (mySelectedPeriod)
            {
                //Gesamt
                case 0:
                    dtFrom.Enabled = false;
                    dtTo.Enabled = false;
                    myDateQuery = " AND BeginDate IS NOT NULL";
                    break;
                //Heute
                case 1:
                    dtFrom.Enabled = false;
                    dtTo.Enabled = false;
                    myDateQuery = " AND BeginDate = '" + myToday + "' ";
                    break;
                //Monat
                case 2:
                    dtFrom.Enabled = false;
                    dtTo.Enabled = false;
                    myFromDate = Convert.ToDateTime("01." + myMonth + "." + myYear).ToShortDateString();
                    myToDate = Convert.ToDateTime(DateTime.DaysInMonth(myYear, myMonth) + "." + myMonth + "." + myYear).ToShortDateString();
                    myDateQuery = " AND BeginDate >= '" + myFromDate + "' AND BeginDate <= '" + myToDate + "' ";
                    break;
                //Quartal
                case 3:
                    dtFrom.Enabled = false;
                    dtTo.Enabled = false;
                    int myQuartal = 0;
                    int myDays = 0;
                    switch (myMonth)
                    {
                        case 1:
                        case 2:
                        case 3:
                            myQuartal = 1;
                            break;
                        case 4:
                        case 5:
                        case 6:
                            myQuartal = 2;
                            break;
                        case 7:
                        case 8:
                        case 9:
                            myQuartal = 3;
                            break;
                        case 10:
                        case 11:
                        case 12:
                            myQuartal = 4;
                            break;
                    }
                    switch (myQuartal)
                    {
                        case 1:
                            for (int i = 0; i < 3; i++)
                            {
                                myDays += DateTime.DaysInMonth(myYear, 1 + i);
                            }
                            myFromDate = "01.01." + myYear;
                            myToDate = "31.03." + myYear;
                            break;

                        case 2:
                            for (int i = 0; i < 3; i++)
                            {
                                myDays += DateTime.DaysInMonth(myYear, 4 + i);
                            }
                            myFromDate = "01.04." + myYear;
                            myToDate = "30.06." + myYear;
                            break;

                        case 3:
                            for (int i = 0; i < 3; i++)
                            {
                                myDays += DateTime.DaysInMonth(myYear, 7 + i);
                            }
                            myFromDate = "01.07." + myYear;
                            myToDate = "30.09." + myYear;
                            break;
                        case 4:
                            for (int i = 0; i < 3; i++)
                            {
                                myDays += DateTime.DaysInMonth(myYear, 10 + i);
                            }
                            myFromDate = "01.10." + myYear;
                            myToDate = "31.12." + myYear;
                            break;
                        default:
                            myFromDate = "01.10." + myYear;
                            myToDate = "31.12." + myYear;
                            break;
                    }
                    myDateQuery = " AND BeginDate >= '" + myFromDate + "' AND BeginDate <= '" + myToDate + "' ";
                    break;
                //Jahr
                case 4:
                    dtFrom.Enabled = false;
                    dtTo.Enabled = false;
                    myFromDate = "01.01." + myYear;
                    myToDate = "31.12." + myYear;
                    myDateQuery = " AND BeginDate >= '" + myFromDate + "' AND BeginDate <= '" + myToDate + "' ";
                    break;
                //Benutzerdefiniert
                case 5:
                    dtFrom.Enabled = true;
                    dtTo.Enabled = true;
                    myFromDate = dtFrom.Value.ToShortDateString();
                    myToDate = dtTo.Value.ToShortDateString();
                    myDateQuery = " AND BeginDate >= '" + myFromDate + "' AND BeginDate <= '" + myToDate + "' ";
                    break;
                default:
                    dtFrom.Enabled = false;
                    dtTo.Enabled = false;
                    myFromDate = dtFrom.Value.ToShortDateString();
                    myToDate = dtTo.Value.ToShortDateString();
                    myDateQuery = " AND BeginDate >= '" + myFromDate + "' AND BeginDate <= '" + myToDate + "' ";
                    break;
            }


            myFilter = "ContractID LIKE '" + CBContractID.Text.Trim() + "%' " +
                 " AND AccountID LIKE '" + CBAccountID.Text.Trim() + "%' " +
                    myDateQuery;

            return myFilter;

        }

        /// <summary>
        /// A filter control has changed
        /// </summary>
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

        /// <summary>
        /// Gets the count of items in the DataGridView
        /// </summary>
        private void FillAllFields()
        {
            int myCurrentItems = 0;

            myCurrentItems = ReportItemsDataGridView.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells[1].Value)
                .Where(value => value == DBNull.Value)
                .Count();

            ItemsFoundTB.Text = Convert.ToString(ReportItemsDataGridView.RowCount);
        }

        //Events Action
        #region Events Action methods
        
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
        
        #endregion

        //Button Click
        #region ButtonClick

        /// <summary>
        /// Clears all filter controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _ignoreEvents = true;
            CBContractID.Text = "";
            _ignoreEvents = true;
            CBAccountID.Text = "";
            CBPeriod.SelectedIndex = 0;
            view1.RowFilter = GetFilter(); ;
            source1.DataSource = view1;
            FillAttributeTables();
            FillAllFields();
            ClearAttributesText();
        }

        /// <summary>
        /// Closes the ContractUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractPrintBtn_Click(object sender, EventArgs e)
        {
                //Artikelliste ausdrucken

                //Inhalt des DataGridView in eine Liste schreiben
                string myContractID ="0000";
                List<Item> myCurrentItemsList = view1.ToTable().Rows.Cast<DataRow>()
                        .Select(r => new Item()
                        {
                            ContractID = r.Field<string>("ContractID"),
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

                myContractID =  myCurrentItemsList[0].ContractID;

                //ruft neues Fenster auf zur Anzeige der Artikel
                DocumentContract documentWindow = new DocumentContract();
                documentWindow.FormClosed += new FormClosedEventHandler(DocumentContractWindow_Closed);
                documentWindow.ContractItemList = myCurrentItemsList;
                documentWindow.ShowDialog();                       
        }

        /// <summary>
        /// Clears the document event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentContractWindow_Closed(object sender, EventArgs e)
        {
            if (sender is DocumentContract documentContractWindow)
            {
                documentContractWindow.FormClosed -= new FormClosedEventHandler(DocumentContractWindow_Closed);
            }
            _ignoreEvents = true;

        }

        /// <summary>
        /// Exports the DataGridView content to a .csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        private void itemBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }


    }
}
