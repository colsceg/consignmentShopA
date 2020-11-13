using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class ItemEditUI : Form
    {

        private List<ItemReport> ItemsList = new List<ItemReport>();
        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessAttributes DbAttribs = new DataAccessAttributes();
        private DataAccessVendors DbVendors = new DataAccessVendors();
        private Store Store = new Store();

        private BindingList<string> bindinglistColor = new BindingList<string>();
        private BindingSource bSourceColor = new BindingSource();

        private BindingList<string> bindinglistBrand = new BindingList<string>();
        private BindingSource bSourceBrand = new BindingSource();

        private BindingList<string> bindinglistSize = new BindingList<string>();
        private BindingSource bSourceSize = new BindingSource();

        private BindingList<string> bindinglistAccountID = new BindingList<string>();
        private BindingSource bSourceAccountID = new BindingSource();

        private BindingList<string> bindinglistProperties = new BindingList<string>();
        private BindingSource bSourceProperties = new BindingSource();

        public Item MySelectedItem { get; set; }
        public bool MyItemEdited { get; set; }
        private Item mySelectedItem = new Item();
        private bool _ignoreEvents = false;


        public ItemEditUI()
        {
            InitializeComponent();
        }

        private void ItemEditUI_Shown_1(object sender, EventArgs e)
        {
            Setup();
        }

        private void Setup()
        {
            MyItemEdited = false;

            CultureInfo culture = new System.Globalization.CultureInfo("de-DE");
            ItemNumberTB.Text = MySelectedItem.ItemNumber;
            AccountIDTB.Text = MySelectedItem.AccountID;
            BeginDateTB.Text = MySelectedItem.BeginDate;
            EndDateTB.Text = MySelectedItem.EndDate;
            SoldDateTB.Text = MySelectedItem.SoldDate;
            PayoutDateTB.Text = MySelectedItem.PayoutDate;
            ItemDescriptionTB.Text = MySelectedItem.ItemDescription;
            if (Double.TryParse((MySelectedItem.SalesPrice), out double value))
                SalesPriceTB.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
            if (Double.TryParse((MySelectedItem.CostPrice), out double value1))
                PayoutPriceTB.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", value1);


            //Daten zum Reset speichern
            mySelectedItem.ItemNumber = MySelectedItem.ItemNumber;
            mySelectedItem.AccountID = MySelectedItem.AccountID;
            mySelectedItem.BeginDate = MySelectedItem.BeginDate;
            mySelectedItem.EndDate = MySelectedItem.EndDate;
            mySelectedItem.SoldDate = MySelectedItem.SoldDate;
            mySelectedItem.PayoutDate = MySelectedItem.PayoutDate;
            mySelectedItem.ItemDescription = MySelectedItem.ItemDescription;
            mySelectedItem.SalesPrice = MySelectedItem.SalesPrice;
            mySelectedItem.CostPrice = MySelectedItem.CostPrice;
            mySelectedItem.Brand = MySelectedItem.Brand;
            mySelectedItem.Color = MySelectedItem.Color;
            mySelectedItem.Size = MySelectedItem.Size;
            mySelectedItem.Prop = MySelectedItem.Prop;

            List<Vendor> myVendorList = new List<Vendor>();
            myVendorList = DbVendors.GetVendorWithAccountID(MySelectedItem.AccountID);

            LastnameTB.Text = myVendorList[0].LastName;
            FirstnameTB.Text = myVendorList[0].FirstName;

            PeriodTB.Text = myVendorList[0].Period.ToString();
            MarginTB.Text = string.Format("{0} %", Convert.ToString(myVendorList[0].Margin));
            FillAttributeTables();

            BrandCB.Text = mySelectedItem.Brand;
            ColorCB.Text = mySelectedItem.Color;
            SizeCB.Text = mySelectedItem.Size;
            PropertyTB.Text = mySelectedItem.Prop;

            CancelBtn.Visible = false;
            SaveBtn.Visible = false;


            if (String.IsNullOrEmpty(MySelectedItem.SoldDate) && String.IsNullOrEmpty(MySelectedItem.PayoutDate))
            {
                ItemStatusTB.Text = "im Laden";
                SalesPriceTB.ReadOnly = false;
                return;
            }

            if (!String.IsNullOrEmpty(MySelectedItem.SoldDate) && String.IsNullOrEmpty(MySelectedItem.PayoutDate))
            {
                ItemStatusTB.Text = "verkauft";
                SalesPriceTB.ReadOnly = true;
                return;
            }

            if (!String.IsNullOrEmpty(MySelectedItem.SoldDate) && !String.IsNullOrEmpty(MySelectedItem.PayoutDate))
            {
                ItemStatusTB.Text = "ausbezahlt";
                SalesPriceTB.ReadOnly = true;
                return;
            }
        }

        //Komboboxen initialisieren
        private void FillAttributeTables()
        {
            //Alle Artikeleigenschaften einlesen
            //Marken 
            bindinglistBrand = DbAttribs.GetAllBrands();
            //ComboBoxBrand.DataSource = labels;
            bSourceBrand.DataSource = bindinglistBrand;
            BrandCB.DataSource = bSourceBrand;

            //Farben
            bindinglistColor = DbAttribs.GetAllColors();
            //ComboBoxColor.DataSource = colors;
            bSourceColor.DataSource = bindinglistColor;
            ColorCB.DataSource = bSourceColor;

            //Größen
            bindinglistSize = DbAttribs.GetAllSizes();
            bSourceSize.DataSource = bindinglistSize;
            SizeCB.DataSource = bSourceSize;
        }


        //Button Reaction
        private void LabelPrintBtn_Click(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            //Alle Änderungen rückgängig machen
            //
            MyItemEdited = false;
            ItemDescriptionTB.Text = mySelectedItem.ItemDescription;
            SalesPriceTB.Text = mySelectedItem.SalesPrice;
            PayoutPriceTB.Text = mySelectedItem.CostPrice;
            BrandCB.Text = mySelectedItem.Brand;
            ColorCB.Text = mySelectedItem.Color;
            SizeCB.Text = mySelectedItem.Size;
            PropertyTB.Text = mySelectedItem.Prop;
            CancelBtn.Visible = false;
            SaveBtn.Visible = false;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            MyItemEdited = true;
            DbItems.UpdateItem(MySelectedItem);
            Close();
        }

        //Fields Input reaction
        private void ItemDescriptionTB_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.ItemDescription = ItemDescriptionTB.Text.Replace(";", ",");
        }

        private void ColorCB_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.Color = ColorCB.Text.Replace("'", "''");
        }

        private void ColorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.Color = ColorCB.Text.Replace("'", "''");
        }

        private void BrandCB_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.Brand = BrandCB.Text.Replace("'", "''");
        }

        private void BrandCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.Brand = BrandCB.Text.Replace("'", "''");
        }

        private void SizeCB_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.Size = SizeCB.Text.Replace("'", "''");
        }

        private void SizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.Size = SizeCB.Text.Replace("'", "''");
        }

        private void PropertyTB_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            MySelectedItem.Prop = PropertyTB.Text.Replace("'", "''");
        }

        private void SalesPriceTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemEditUI_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void SalesPriceTB_Leave(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            if (!_ignoreEvents)
            {
                if (!String.IsNullOrEmpty(MarginTB.Text))
                {
                    decimal mySalesPrice = Store.ConvertCurrencyToDecimal(SalesPriceTB.Text);
                    double myMargin = Convert.ToDouble((MarginTB.Text.Split(' ')[0]));
                    double myCostPrice = (double)mySalesPrice - ((double)mySalesPrice * myMargin) / 100; //wird in items gespeichert
                    MySelectedItem.SalesPrice = Store.ConvertCurrencyToNumber(SalesPriceTB.Text);
                    MySelectedItem.CostPrice = Convert.ToString(myCostPrice).Replace(",", ".");

                    if (Double.TryParse((SalesPriceTB.Text.Split(' ')[0]), out double value))
                        if (value > 0)
                            SalesPriceTB.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
                        else
                            SalesPriceTB.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);

                    if (myCostPrice > 0)
                        PayoutPriceTB.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", myCostPrice);
                    else
                        PayoutPriceTB.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);

                }
            }
            else
                _ignoreEvents = false;
        }


    }
}
