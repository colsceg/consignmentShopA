using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class CheckoutWindow : Form
    {

        private DataAccessItems DBItems = new DataAccessItems();

        private List<ConfigData> configDataList = new List<ConfigData>();
        private List<CashCloseSoldItem> soldItemsList = new List<CashCloseSoldItem>();
        private List<CashClosePayedItem> payedItemsList = new List<CashClosePayedItem>();
        private CashClosePrintItem myCashClosePrintItem = new CashClosePrintItem();
        private Store store = new Store();

        private double mySumSalesPrice = 0;
        private double mySumCostPrice = 0;
        private double mySumPayedPrice = 0;
        private double mySumExpected = 0;
        private double mySumDiff = 0;

        public CheckoutWindow()
        {
            InitializeComponent();
        }

        private void Setup()
        {

            soldItemsList = DBItems.GetItemsCashCloseSold();
            payedItemsList = DBItems.GetItemsCashClosePayed();

            configDataList = DBItems.GetConfigData();
            CashSumStartTB.Text= String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", configDataList[0].KassenBestand);
            CashSumTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", 0);


            foreach (var item in soldItemsList)
            {
                mySumSalesPrice += Convert.ToDouble( item.SalesPrice);
                mySumCostPrice += Convert.ToDouble(item.CostPrice);
            }
            foreach (var item in payedItemsList)
            {
                mySumPayedPrice += Convert.ToDouble(item.CostPrice);
            }

            SoldSumTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", mySumSalesPrice);
            PayedSumTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", mySumPayedPrice);
            List<Item> mySoldItems = DBItems.GetAllItemsSold();
            string myToday = DateTime.Now.ToShortDateString();

            decimal myTotalSumToPayList = DBItems.GetItemsTotalSumToPay();
            SumCommissionTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", mySumSalesPrice - mySumCostPrice);
            SumToPayTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", myTotalSumToPayList);
            fillWindowTB();

        }

        private void fillWindowTB()
        {
            mySumExpected = Convert.ToDouble(store.ConvertCurrencyToDecimal( CashSumStartTB.Text)) + mySumSalesPrice - mySumPayedPrice;
            mySumDiff = Convert.ToDouble(store.ConvertCurrencyToDecimal(CashSumTB.Text)) - mySumExpected;
            if (mySumDiff < 0)
            {
                CashDiffTB.BackColor = Color.Red;
                CashDiffTB.ForeColor = Color.White;
                SumDiffLabel.ForeColor = Color.Red;
            }
            else
            {
                CashDiffTB.BackColor = Color.LightGray;
                CashDiffTB.ForeColor = Color.Black;
                SumDiffLabel.ForeColor = Color.Black;
            }
            CashExpectedTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", mySumExpected);
            CashDiffTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", mySumDiff);
            myCashClosePrintItem.IstSum = Convert.ToDouble(store.ConvertCurrencyToDecimal(CashSumTB.Text));
            myCashClosePrintItem.PayedSum = mySumPayedPrice;
            myCashClosePrintItem.SoldSum = mySumSalesPrice;
            myCashClosePrintItem.StartSum = Convert.ToDouble(store.ConvertCurrencyToDecimal(CashSumStartTB.Text));
            AktDatumLabel.Text = DateTime.Today.ToShortDateString();
        }

        //reaction to Buttons
        private void CheckoutWindow_Load(object sender, EventArgs e)
        {
            Setup();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Drucken not implemented yet");
            DocumentCashClose CashCloseDocumentWindow = new DocumentCashClose();
            CashCloseDocumentWindow.FormClosed += new FormClosedEventHandler(CashCloseDocumentWindow_Closed);
            CashCloseDocumentWindow.MySoldItemsList = soldItemsList;
            CashCloseDocumentWindow.MyPayedItemsList = payedItemsList;
            CashCloseDocumentWindow.MyCashClosePrintItem = myCashClosePrintItem;
            CashCloseDocumentWindow.Show();
        }

        private void ListSoldBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Sold List not implemented yet");
            string [] myListBoxList = new string[soldItemsList.Count];

            for (int i = 0; i < soldItemsList.Count; i++)
            {
                myListBoxList[i] = soldItemsList[i].FullInfo;
            }
            CashCloseSoldListWindow myCashCloseListWin = new CashCloseSoldListWindow();
            myCashCloseListWin.MyCashCloseSoldList = myListBoxList;
            myCashCloseListWin.Show();
        }

        private void ListPayedBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Payed List not implemented yet");
            string[] myListBoxList = new string[payedItemsList.Count];

            for (int i = 0; i < payedItemsList.Count; i++)
            {
                myListBoxList[i] = payedItemsList[i].FullInfo;
            }
            CashClosePayedListWindow myCashCloseListWin = new CashClosePayedListWindow();
            myCashCloseListWin.MyCashClosePayedList = myListBoxList;
            myCashCloseListWin.Show();
        }

        //Reaktion auf Eingabe
        private void CashSumTB_Leave(object sender, EventArgs e)
        {
            double value;
            if (Double.TryParse((CashSumTB.Text.Split(' ')[0]), out value))
                CashSumTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            else
                CashSumTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0);
            fillWindowTB();
        }
        private void CashSumStartTB_Leave(object sender, EventArgs e)
        { double value;
            if (Double.TryParse((CashSumStartTB.Text.Split(' ')[0]), out value))
                CashSumStartTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            else
                CashSumStartTB.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", 0);
            fillWindowTB();
        }

        //ENTER as TAB
        private void CashSumStartTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void CashSumTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        //Nur Ziffern zulassen
        private void CashSumStartTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        private void CashSumTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        
        //Feldinhalt selektieren
        private void CashSumStartTB_Click(object sender, EventArgs e)
        {
            CashSumStartTB.SelectAll();
        }
        private void CashSumTB_Click(object sender, EventArgs e)
        {
            CashSumTB.SelectAll();
        }

        private void CashCloseDocumentWindow_Closed(object sender, EventArgs e)
        {
            DocumentCashClose CashCloseDocumentWindow = sender as DocumentCashClose;
            if (CashCloseDocumentWindow != null)
            {
                //bool mySalesVolumeDocumentPrinted = false;
                //mySalesVolumeDocumentPrinted = CashCloseDocumentWindow.MyContractPrinted;
                CashCloseDocumentWindow.FormClosed -= new FormClosedEventHandler(CashCloseDocumentWindow_Closed);
            }
            this.Close();
        }
    }
}
