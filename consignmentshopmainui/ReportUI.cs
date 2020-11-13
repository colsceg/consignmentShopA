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
    public partial class ReportUI : Form
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

        public ReportUI()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Setup();
        }

        private void Setup()
        {
            //Get all items in a DataTable
            dt = DbItems.GetAllItemsReport();

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

                // Set the column header names.
                //ReportItemsDataGridView.Columns[0].HeaderText = "KdNr";
                //ReportItemsDataGridView.Columns[1].HeaderText = "ArtNr";
                //ReportItemsDataGridView.Columns[2].HeaderText = "Artikel";
                //ReportItemsDataGridView.Columns[3].HeaderText = "Marke";
                //ReportItemsDataGridView.Columns[4].HeaderText = "Farbe";
                //ReportItemsDataGridView.Columns[5].HeaderText = "Gr.";
                //ReportItemsDataGridView.Columns[6].HeaderText = "Sonst.";
                //ReportItemsDataGridView.Columns[7].HeaderText = "Vk-Preis";
                //ReportItemsDataGridView.Columns[8].HeaderText = "Auszahl.";
                //ReportItemsDataGridView.Columns[9].HeaderText = "Annahme";
                //ReportItemsDataGridView.Columns[10].HeaderText = "Ablauf";
                //ReportItemsDataGridView.Columns[11].HeaderText = "verk.";
                //ReportItemsDataGridView.Columns[12].HeaderText = "ausgez";

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
                ReportItemsDataGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ReportItemsDataGridView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ReportItemsDataGridView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                ReportItemsDataGridView.Columns[10].Width = 70;
                ReportItemsDataGridView.Columns[11].Width = 70;
                ReportItemsDataGridView.Columns[12].Width = 70;

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
                CBStatus.SelectedIndex = 0;
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
            CBItemDescription.Text = "";
            CBBrand.Text = "";
            CBColor.Text = "";
            CBSize.Text = "";
            CBItemNumber.Text = "";
            CBAccountID.Text = "";
        }

        private void FillAttributeTables()
        {
            //Alle Artikeleigenschaften einlesen; 
            //Beschreibung 

            _ignoreEvents = true;
            try
            {
                //ItemsList alle items mit gruppiert nach itemDescription
                // Set RowStateFilter to display the current rows.
                view1.RowStateFilter = DataViewRowState.CurrentRows;
                //query the DataView for the itemDescription ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<string>("ItemDescription")
                            group rowView by rowView.Row.Field<string>("ItemDescription") into newDescription
                            select newDescription.Key;

                CBItemDescription.DataSource = query.ToList();
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
                            orderby rowView.Row.Field<string>("Brand")
                            group rowView by rowView.Row.Field<string>("Brand") into newDescription
                            select newDescription.Key;

                CBBrand.DataSource = query.ToList();
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
                            orderby rowView.Row.Field<string>("Color")
                            group rowView by rowView.Row.Field<string>("Color") into newDescription
                            select newDescription.Key;

                CBColor.DataSource = query.ToList();
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
                            orderby rowView.Row.Field<string>("Size")
                            group rowView by rowView.Row.Field<string>("Size") into newDescription
                            select newDescription.Key;

                CBSize.DataSource = query.ToList();
            }
            finally
            {
                _ignoreEvents = false;
            }


            //ItemNumber
            _ignoreEvents = true;
            try
            {
                //query the DataView for the ItemNumber ordered
                var query = from DataRowView rowView in view1
                            orderby rowView.Row.Field<int>("ItemNumber")
                            group rowView by rowView.Row.Field<int>("ItemNumber") into newDescription
                            select newDescription.Key;

                CBItemNumber.DataSource = query.ToList();
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
            string mySelectedStatus = CBStatus.SelectedItem.ToString();
            int mySelectedPeriod = CBPeriod.SelectedIndex;
            string myToday = DateTime.Now.ToShortDateString();
            string myFromDate, myToDate;
            int myYear = DateTime.Today.Year;
            int myMonth = DateTime.Today.Month;
            string myItemNumber = CBItemNumber.Text;
            string myFilter = null;

            //CBItemNumber.Text = "";

            if (mySelectedStatus == "alle")
            {
                CBPeriod.Enabled = false;
                _ignoreEvents = true;
                CBPeriod.SelectedIndex = 0;
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                myDateQuery = "";
            }
            if (mySelectedStatus == "im Laden")
            {
                CBPeriod.Enabled = false;
                CBPeriod.SelectedIndex = 0;
                _ignoreEvents = true;
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                myDateQuery = " AND SoldDate IS NULL";
            }

            if (mySelectedStatus == "verkauft")
            {
                CBPeriod.Enabled = true;
                switch (mySelectedPeriod)
                {
                    //Gesamt
                    case 0:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myDateQuery = " AND SoldDate IS NOT NULL";
                        break;
                    //Heute
                    case 1:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myDateQuery = " AND SoldDate = '" + myToday + "' ";
                        break;
                    //Monat
                    case 2:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myFromDate = Convert.ToDateTime("01." + myMonth + "." + myYear).ToShortDateString();
                        myToDate = Convert.ToDateTime(DateTime.DaysInMonth(myYear, myMonth) + "." + myMonth + "." + myYear).ToShortDateString();
                        myDateQuery = " AND SoldDate >= '" + myFromDate + "' AND SoldDate <= '" + myToDate + "' ";
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
                        myDateQuery = " AND SoldDate >= '" + myFromDate + "' AND SoldDate <= '" + myToDate + "' ";
                        break;
                    //Jahr
                    case 4:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myFromDate = "01.01." + myYear;
                        myToDate = "31.12." + myYear;
                        myDateQuery = " AND SoldDate >= '" + myFromDate + "' AND SoldDate <= '" + myToDate + "' ";
                        break;
                    //Benutzerdefiniert
                    case 5:
                        dtFrom.Enabled = true;
                        dtTo.Enabled = true;
                        myFromDate = dtFrom.Value.ToShortDateString();
                        myToDate = dtTo.Value.ToShortTimeString();
                        myDateQuery = " AND SoldDate >= '" + myFromDate + "' AND SoldDate <= '" + myToDate + "' ";
                        break;
                    default:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myFromDate = dtFrom.Value.ToShortDateString();
                        myToDate = dtTo.Value.ToShortTimeString();
                        myDateQuery = " AND SoldDate >= '" + myFromDate + "' AND SoldDate <= '" + myToDate + "' ";
                        break;
                }
            }

            if (mySelectedStatus == "ausbezahlt")
            {
                CBPeriod.Enabled = true;
                switch (mySelectedPeriod)
                {
                    //Gesamt
                    case 0:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myDateQuery = " AND PayoutDate IS NOT NULL";
                        break;
                    //Heute
                    case 1:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myDateQuery = " AND PayoutDate = '" + myToday + "' ";
                        break;
                    //Monat
                    case 2:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myFromDate = Convert.ToDateTime("01." + myMonth + "." + myYear).ToShortDateString();
                        myToDate = Convert.ToDateTime(DateTime.DaysInMonth(myYear, myMonth) + "." + myMonth + "." + myYear).ToShortDateString();
                        myDateQuery = " AND PayoutDate >= '" + myFromDate + "' AND PayoutDate <= '" + myToDate + "' ";
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
                        myDateQuery = " AND PayoutDate >= '" + myFromDate + "' AND PayoutDate <= '" + myToDate + "' ";
                        break;
                    //Jahr
                    case 4:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myFromDate = "01.01." + myYear;
                        myToDate = "31.12." + myYear;
                        myDateQuery = " AND PayoutDate >= '" + myFromDate + "' AND PayoutDate <= '" + myToDate + "' ";
                        break;
                    //Benutzerdefiniert
                    case 5:
                        dtFrom.Enabled = true;
                        dtTo.Enabled = true;
                        myFromDate = dtFrom.Value.ToShortDateString();
                        myToDate = dtTo.Value.ToShortTimeString();
                        myDateQuery = " AND PayoutDate >= '" + myFromDate + "' AND PayoutDate <= '" + myToDate + "' ";
                        break;
                    default:
                        dtFrom.Enabled = false;
                        dtTo.Enabled = false;
                        myFromDate = dtFrom.Value.ToShortDateString();
                        myToDate = dtTo.Value.ToShortTimeString();
                        myDateQuery = " AND PayoutDate >= '" + myFromDate + "' AND PayoutDate <= '" + myToDate + "' ";
                        break;
                }
            }

            string newBrand, newDescription, newColor, newSize = "";

            newBrand = Store.DataViewEscape(CBBrand.Text.Trim());
            newDescription = Store.DataViewEscape(CBItemDescription.Text.Trim());
            newColor = Store.DataViewEscape(CBColor.Text.Trim());
            newSize = Store.DataViewEscape(CBSize.Text.Trim());


            if (String.IsNullOrEmpty(myItemNumber))
            {
                myFilter = "AccountID LIKE '" + CBAccountID.Text.Trim() + "%' " +
                             " AND ItemDescription LIKE '" + newDescription + "%' " +
                             " AND Brand LIKE '" + newBrand + "%' " +
                             " AND Color LIKE '" + newColor + "%' " +
                             " AND Size LIKE '" + newSize + "%' " +
                             myDateQuery;
            }
            else
            {
                myFilter = "AccountID LIKE '" + CBAccountID.Text.Trim() + "%' " +
                            " AND ItemNumber = '" + Convert.ToInt16(CBItemNumber.Text.Trim()) + " ' " +
                            " AND ItemDescription LIKE '" + newDescription + "%' " +
                            " AND Brand LIKE '" + newBrand + "%' " +
                            " AND Color LIKE '" + newColor + "%' " +
                            " AND Size LIKE '" + newSize + "%' " +
                         myDateQuery;
            }
            return myFilter;
        }

        private void ChangeFilter()
        {

            string myItemDescription = CBItemDescription.Text;
            string myBrand = CBBrand.Text;
            string myColor = CBColor.Text;
            string mySize = CBSize.Text;
            string myAccountID = CBAccountID.Text;
            string myItemNumber = CBItemNumber.Text;

            myFilter = GetFilter();
            view1.RowFilter = myFilter;
            source1.DataSource = view1;
            FillAttributeTables();
            FillAllFields();

            if (source1.Count > 0)
            {
                int myIndex = CBStatus.SelectedIndex;
                //query the DataView for the itemDescription ordered
                var queryMin = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Min();

                //query the DataView for the Brand ordered
                var queryMax = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Max();

                //Date for from to Datefields ermitteln
                switch (myIndex)
                {
                    //Alle und im Laden BeginDatum Min und Max
                    case 0:
                    case 1:
                        break;

                    //verkauft SoldDate Min un Max
                    case 2:
                        //query the DataView for the itemDescription ordered
                        queryMin = (from DataRowView rowView in view1
                                    select rowView.Row.Field<DateTime>("SoldDate")).Min();

                        //query the DataView for the Brand ordered
                        queryMax = (from DataRowView rowView in view1
                                    select rowView.Row.Field<DateTime>("SoldDate")).Max();
                        break;

                    //ausbezahlt PayoutDate Min und Max
                    case 3:
                        //query the DataView for the itemDescription ordered
                        queryMin = (from DataRowView rowView in view1
                                    select rowView.Row.Field<DateTime>("PayoutDate")).Min();

                        //query the DataView for the Brand ordered
                        queryMax = (from DataRowView rowView in view1
                                    select rowView.Row.Field<DateTime>("PayoutDate")).Max();
                        break;

                    default:
                        //query the DataView for the itemDescription ordered
                        queryMin = (from DataRowView rowView in view1
                                    select rowView.Row.Field<DateTime>("BeginDate")).Min();

                        //query the DataView for the Brand ordered
                        queryMax = (from DataRowView rowView in view1
                                    select rowView.Row.Field<DateTime>("BeginDate")).Max();
                        break;
                }
                _ignoreEvents = true;
                dtFrom.Value = queryMin;
                _ignoreEvents = true;
                dtTo.Value = queryMax;
            }

            CBItemDescription.Text = myItemDescription;
            CBBrand.Text = myBrand;
            CBColor.Text = myColor;
            CBSize.Text = mySize;
            CBAccountID.Text = myAccountID;
            CBItemNumber.Text = myItemNumber;
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
            SoldItemsTB.Text = Convert.ToString(myItemSoldCount);
            CurrentItemsTB.Text = Convert.ToString(myCurrentItems);

            SumPayedTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", mySumPayed);          
            SumToPayTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", mySumCost - mySumPayed);
            SumComissionTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", mySumSalesVolume - mySumCost);
            SumSalesVolumeTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", mySumSalesVolume);
            SetFieldsForStatus();
            //ConvertToCurrency(anItemsList);
        }

        private void SetFieldsForStatus()
        {
            if (!_deletedItems)
            {
                int myStatusIndex = CBStatus.SelectedIndex;
                if (myStatusIndex != -1)
                {
                    switch (myStatusIndex)
                    {
                        case 0: //Alle
                                //PeriodCB auf Gesamt setzen
                            CurrentItemsLbl.Visible = true;
                            CurrentItemsTB.Visible = true;
                            SoldItemsTB.Visible = true;
                            SoldItemsLbl.Visible = true;
                            SumPayedTB.Visible = true;
                            SumPayedLbl.Visible = true;
                            SumToPayTB.Visible = true;
                            SumToPayLbl.Visible = true;
                            SumComissionTB.Visible = true;
                            SumComissionLbl.Visible = true;
                            SumSalesVolumeLbl.Visible = true;
                            SumSalesVolumeTB.Visible = true;
                            SalesVolumePrintBtn.Visible=false;
                            _SalesVolume = false;
                            CBPeriod.Enabled = false;
                            break;
                        case 1: // im Laden
                            CurrentItemsLbl.Visible = true;
                            CurrentItemsTB.Visible = true;
                            SoldItemsTB.Visible = false;
                            SoldItemsLbl.Visible = false;
                            SumPayedTB.Visible = false;
                            SumPayedLbl.Visible = false;
                            SumToPayTB.Visible = false;
                            SumToPayLbl.Visible = false;
                            SumComissionTB.Visible = false;
                            SumComissionLbl.Visible = false;
                            SumSalesVolumeLbl.Visible = false;
                            SumSalesVolumeTB.Visible = false;
                            SalesVolumePrintBtn.Visible = true;
                            SalesVolumePrintBtn.Text = "Artikelliste drucken";
                            _SalesVolume = false;
                            CBPeriod.Enabled = false;
                            break;
                        case 2: //verkauft
                            CurrentItemsLbl.Visible = false;
                            CurrentItemsTB.Visible = false;
                            SoldItemsTB.Visible = true;
                            SoldItemsLbl.Visible = true;
                            SumPayedTB.Visible = false;
                            SumPayedLbl.Visible = false;
                            SumToPayTB.Visible = false;
                            SumToPayLbl.Visible = false;
                            SumComissionTB.Visible = true;
                            SumComissionLbl.Visible = true;
                            SumSalesVolumeLbl.Visible = true;
                            SumSalesVolumeTB.Visible = true;
                            SalesVolumePrintBtn.Visible = true;
                            SalesVolumePrintBtn.Text = "Umsatzliste drucken";
                            _SalesVolume = true;
                            CBPeriod.Enabled = true;
                            break;
                        case 3:  //ausbezahlt
                            CurrentItemsLbl.Visible = false;
                            CurrentItemsTB.Visible = false;
                            SoldItemsTB.Visible = false;
                            SoldItemsLbl.Visible = false;
                            SumPayedTB.Visible = true;
                            SumPayedLbl.Visible = true;
                            SumToPayTB.Visible = false;
                            SumToPayLbl.Visible = false;
                            SumComissionTB.Visible = false;
                            SumComissionLbl.Visible = false;
                            SumSalesVolumeLbl.Visible = false;
                            SumSalesVolumeTB.Visible = false;
                            _SalesVolume = true;
                            CBPeriod.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                CurrentItemsLbl.Visible = false;
                CurrentItemsTB.Visible = false;
                SoldItemsTB.Visible = false;
                SoldItemsLbl.Visible = false;
                SumPayedTB.Visible = false;
                SumPayedLbl.Visible = false;
                SumToPayTB.Visible = false;
                SumToPayLbl.Visible = false;
                SumComissionTB.Visible = false;
                SumComissionLbl.Visible = false;
                SumSalesVolumeLbl.Visible = false;
                SumSalesVolumeTB.Visible = false;
                SalesVolumePrintBtn.Text = "Artikelliste drucken";
                _SalesVolume = false;
                CBPeriod.Enabled = false;
            }
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

        private void CBItemNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                if (!String.IsNullOrWhiteSpace(CBItemNumber.Text))
                {
                    string myAccountID = "ItemNumber = " + CBItemNumber.Text;
                    view1.RowFilter = myAccountID;
                    source1.DataSource = view1;
                    FillAttributeTables();
                }
            }
            _ignoreEvents = false;
        }

        private void CBItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBSize_SelectedIndexChanged(object sender, EventArgs e)
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

        private void CBItemNumber_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                if (!String.IsNullOrWhiteSpace(CBItemNumber.Text))
                {
                    string myAccountID = "ItemNumber = " + CBItemNumber.Text;
                    view1.RowFilter = myAccountID;
                    source1.DataSource = view1;
                    FillAttributeTables();
                    FillAllFields();

                    //CBItemDescription.Text = "";
                    //CBBrand.Text = "";
                    //CBColor.Text = "";
                    //CBSize.Text = "";
                    //CBAccountID.Text = "";
                }
            }
            _ignoreEvents = false;
        }

        private void CBItemDescription_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBBrand_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBColor_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
            }
            _ignoreEvents = false;
        }

        private void CBSize_Leave(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ChangeFilter();
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
        private void BtnDeletedItems_Click(object sender, EventArgs e)
        {
            if (_deletedItems)
            {
                //Aktuelle Artikel anzeigen
                _deletedItems = false;
                BtnDeletedItems.Text = "Gelöschte Artikel anzeigen";
                //Get all actual items in a DataTable
                dt = DbItems.GetAllItemsReport();
                //Bind all items in a DataTable to a DataView
                view1 = new DataView(dt);
                //Bind the DataView to a DataSource
                source1.DataSource = view1;
                //Bind a DataSource to a DataGridView  (ds.Tables[0]);
                ReportItemsDataGridView.DataSource = source1;
                ItemsFoundTB.Text = view1.Count.ToString();
                //query the DataView for the itemDescription ordered and get the Min date
                var queryMin = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Min();

                //query the DataView for the itemDescription ordered and get the Max date
                var queryMax = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Max();

                FillAttributeTables();
                FillAllFields();
                ClearAttributesText();

                CBPeriod.Visible = true;
                CBStatus.Visible = true;
                lblPeriod.Visible = true;
                lblStatus.Visible = true;
                SalesVolumePrintBtn.Visible = true;
                CurrentItemsLbl.Visible = true;
                CurrentItemsTB.Visible = true;
                SoldItemsTB.Visible = true;
                SoldItemsLbl.Visible = true;
                SumPayedTB.Visible = true;
                SumPayedLbl.Visible = true;
                SumToPayTB.Visible = true;
                SumToPayLbl.Visible = true;
                SumComissionTB.Visible = true;
                SumComissionLbl.Visible = true;
                SumSalesVolumeLbl.Visible = true;
                SumSalesVolumeTB.Visible = true;
                SalesVolumePrintBtn.Visible = true;
                SalesVolumePrintBtn.Enabled = true;
                lblFilter.Text = "Aktuelle Artikel";
            }
            else
            {
                //gelöschte Artikel anzeigen
                _deletedItems = true;

                //Get all deleted items in a DataTable
                dt = DbItems.GetAllItemsReportDeleted();
                //Bind all items in a DataTable to a DataView
                view1 = new DataView(dt);
                //Bind the DataView to a DataSource
                source1.DataSource = view1;
                //Bind a DataSource to a DataGridView  (ds.Tables[0]);
                ReportItemsDataGridView.DataSource = source1;
                ItemsFoundTB.Text = view1.Count.ToString();
                //query the DataView for the itemDescription ordered and get the Min date
                var queryMin = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Min();

                //query the DataView for the itemDescription ordered and get the Max date
                var queryMax = (from DataRowView rowView in view1
                                select rowView.Row.Field<DateTime>("BeginDate")).Max();
                //Set the Min Max date to the DateTimePicker Component
                //_ignoreEvents = true;
                //dtFrom.Value = queryMin;
                //_ignoreEvents = true;
                //dtTo.Value = queryMax;

                FillAttributeTables();
                FillAllFields();
                ClearAttributesText();
                BtnDeletedItems.Text = "Aktuelle Artikel anzeigen";
                CBPeriod.Visible = false;
                CBStatus.Visible = false;
                lblPeriod.Visible = false;
                lblStatus.Visible = false;
                SalesVolumePrintBtn.Visible = false;
                CurrentItemsLbl.Visible = false;
                CurrentItemsTB.Visible = false;
                SoldItemsTB.Visible = false;
                SoldItemsLbl.Visible = false;
                SumPayedTB.Visible = false;
                SumPayedLbl.Visible = false;
                SumToPayTB.Visible = false;
                SumToPayLbl.Visible = false;
                SumComissionTB.Visible = false;
                SumComissionLbl.Visible = false;
                SumSalesVolumeLbl.Visible = false;
                SumSalesVolumeTB.Visible = false;
                SalesVolumePrintBtn.Visible = false;
                SalesVolumePrintBtn.Enabled = false;
                lblFilter.Text = "gelöschte Artikel";

            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _ignoreEvents = true;
            CBItemDescription.Text = "";
            _ignoreEvents = true;
            CBBrand.Text = "";
            _ignoreEvents = true;
            CBColor.Text = "";
            _ignoreEvents = true;
            CBSize.Text = "";
            _ignoreEvents = true;
            CBItemNumber.Text = "";
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
    }
}
