using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentShopLibrary;

namespace ConsignmentShopMainUI
{
    public partial class ItemsEditUI : Form
    {
        //private Panel buttonPanel = new Panel();
        //private Panel inputPanel = new Panel();
        //private DataGridView itemsDataGridView = new DataGridView();
        //private Button addNewRowButton = new Button();
        //private Button deleteRowButton = new Button();
        //private Button closeButton = new Button();

        private sqliteDB consignmentDB = new sqliteDB();
        private string dbName = @"G:\Users\NBC\Documents\Visual Studio 2015\Projects\ConsignmentShopA\sqlite\ConsignmentDB.sqlite";
        private string table = "main.Vendors";
        private List<string> vendorsListStrings = new List<string>();
        private List<Vendor> vendorsList = new List<Vendor>();
        private Vendor newVendor = new Vendor();
        private Store store = new Store();

        public ItemsEditUI()
        {
            InitializeComponent();
            this.Load += new EventHandler(ItemsEditUI_Load);
        }

        private void ItemsEditUI_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "consignmentDBDataSet.Vendors". Sie können sie bei Bedarf verschieben oder entfernen.
            //            this.vendorsTableAdapter.Fill(this.consignmentDBDataSet.Vendors);
            SetupDataGridView();
            getVendorsList();
            PopulateDataGridView();

        }

        private void SetupDataGridView()
        {
            Controls.Add(itemsDataGridView);
            itemsDataGridView.ColumnCount = 14;
            itemsDataGridView.EnableHeadersVisualStyles = false;
            itemsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Green; //funktioniert nur mit EnableHeadersVisualStyles = false
            itemsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; //funktioniert nur mit EnableHeadersVisualStyles = false
            itemsDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(itemsDataGridView.Font, FontStyle.Bold);  //funktioniert
            itemsDataGridView.Columns[0].Name = "ID";
            itemsDataGridView.Columns[1].Name = "Name";
            itemsDataGridView.Columns[2].Name = "Vorname";
            itemsDataGridView.Columns[3].Name = "Zusatz1";
            itemsDataGridView.Columns[4].Name = "Zusatz2";
            itemsDataGridView.Columns[2].DefaultCellStyle.Font =
                new Font(itemsDataGridView.DefaultCellStyle.Font, FontStyle.Italic); //funktioniert
            itemsDataGridView.Columns[5].Name = "Strasse";
            itemsDataGridView.Columns[6].Name = "Postleitzahl";
            itemsDataGridView.Columns[7].Name = "Wohnort";
            itemsDataGridView.Columns[8].Name = "Telefon";
            itemsDataGridView.Columns[9].Name = "Mobiltelefon";
            itemsDataGridView.Columns[10].Name = "E-Mail";
            itemsDataGridView.Columns[11].Name = "Kommission [%]";
            itemsDataGridView.Columns[12].Name = "Ablauf [Tagen]";
            itemsDataGridView.Columns[13].Name = "Auszahlung";
            itemsDataGridView.Columns[13].Name = "ausgezahlt";
            itemsDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect; //funktioniert
            itemsDataGridView.MultiSelect = false;     //funktioniert
            itemsDataGridView.Dock = DockStyle.None; //funktioniert


            //itemsDataGridView.CellFormatting += new
            //    DataGridViewCellFormattingEventHandler(
            //    itemsDataGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            foreach (var item in vendorsListStrings)
            {
                String[] substr = item.Split(',');
                itemsDataGridView.Rows.Add(substr);
            }

            itemsDataGridView.Columns[3].DisplayIndex = 9;
            itemsDataGridView.Columns[4].DisplayIndex = 10;
            itemsDataGridView.Columns[5].DisplayIndex = 3;
            itemsDataGridView.Columns[6].DisplayIndex = 4;
            itemsDataGridView.Columns[7].DisplayIndex = 5;
            itemsDataGridView.Columns[8].DisplayIndex = 6;
            itemsDataGridView.Columns[9].DisplayIndex = 7;
            itemsDataGridView.Columns[10].DisplayIndex = 8;

        }

        private void getVendorsList()
        {
            try
            {
                consignmentDB.connectDB(dbName);
            }
            catch (Exception)
            {
                consignmentDB.createDB(dbName);
                consignmentDB.connectDB(dbName);
            }

            vendorsListStrings = consignmentDB.readRecord(table);
            consignmentDB.closeDB();
        }


    }
}
