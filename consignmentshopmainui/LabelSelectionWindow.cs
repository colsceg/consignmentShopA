using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class LabelSelectionWindow : Form
    {
        private Store Store = new Store();
        private DataAccessItems DbItems = new DataAccessItems();
        private List<Contract> ContractsList = new List<Contract>();
        private List<Item> ItemsList = new List<Item>();
        private List<ConfigData> ConfigDataList = new List<ConfigData>();
        private List<ItemGrouped> MyGroupedItemList = new List<ItemGrouped>();

        private void LabelSelectionWindow_Load(object sender, EventArgs e)
        {
            Setup();
        }

        public LabelSelectionWindow()
        {
            InitializeComponent();
        }

        public string MyContractID { get; set; }


        private void Setup()
        {
            ContractsList = DbItems.GetContractWithContractID(MyContractID);
            ItemsList = DbItems.GetItemsWithContractID(MyContractID);
            MyGroupedItemList = DbItems.GetItemsWithContractIDGrouped(MyContractID);
            //Erste und letzte PosNumber bestimmen
            
            //PosNumberFromTB.Text = GetMinPosNumber(MyGroupedItemList);
            //PosNumberToTB.Text = GetMaxPosNumber(MyGroupedItemList);

            ConfigDataList = DbItems.GetConfigData();
        }

        private void LabelSelectionWindow_Shown(object sender, EventArgs e)
        {
            this.Text = "VertragNr " + Item.ConvertContractIDToContractNumber(MyContractID);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            //DocumentPrintLabel aufrufen
            //Übergabe contractId, ItemNumberFromTB, ItemNumberToTB
            DocumentLabelPrint DocumentLabelPrintWindow = new DocumentLabelPrint();
            DocumentLabelPrintWindow.FormClosed += new FormClosedEventHandler(DocumentLabelPrintWindow_Closed);

            DocumentLabelPrintWindow.MyContractID = MyContractID;
            DocumentLabelPrintWindow.MyPosNumberFrom = PosNumberFromTB.Text;
            DocumentLabelPrintWindow.MyPosNumberTo = PosNumberToTB.Text;
            DocumentLabelPrintWindow.MyLastLabelNumber =Convert.ToInt32( LastLabelNumberTB.Text);
            DocumentLabelPrintWindow.Show();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Nur Ziffern zulassen
        private void LastLabelNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void ItemNumberFromTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void ItemNumberToTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Enter als Abschluss
        private void ItemNumberFromTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void ItemNumberToTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void LastLabelNumberTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private string GetMaxPosNumber(List<ItemGrouped> aGroupedList)
        {
            var l = new List<int>();

            foreach (var item in aGroupedList)
            {
                l.Add(Convert.ToInt32( item.PosNumber));
            }
            var max = l.Max();
            return Store.SetStringLengthToFour(Convert.ToString(max));
        }

        private string GetMinPosNumber(List<ItemGrouped> aGroupedList)
        {
            var l = new List<int>();

            foreach (var item in aGroupedList)
            {
                l.Add(Convert.ToInt32(item.PosNumber));
            }
            var max = l.Min();
            return Store.SetStringLengthToFour(Convert.ToString(max));
        }

        private bool FindPosNumber(List<ItemGrouped> aGroupedList, string aPosNumber)
        {
            bool hasFound = false;
            foreach (var item in aGroupedList)
            {
                if (Convert.ToUInt32( item.PosNumber) == Convert.ToUInt32( aPosNumber))
                    hasFound = true;
            }
            return hasFound;
        }

        private void DocumentLabelPrintWindow_Closed(object sender, EventArgs e)
        {
            DocumentLabelPrint DocumentLabelPrintWindow = sender as DocumentLabelPrint;
            if (DocumentLabelPrintWindow != null)
            {
                DocumentLabelPrintWindow.FormClosed -= new FormClosedEventHandler(DocumentLabelPrintWindow_Closed);
            }
            this.Close();
        }

        private void PosNumberFromTB_Leave(object sender, EventArgs e)
        {
            if (!FindPosNumber(MyGroupedItemList, PosNumberFromTB.Text))
            {
                PosNumberFromTB.Text = GetMinPosNumber(MyGroupedItemList);
            }

        }

        private void PosNumberToTB_Leave(object sender, EventArgs e)
        {
            if (!FindPosNumber(MyGroupedItemList,PosNumberToTB.Text))
            {
                PosNumberToTB.Text = GetMaxPosNumber(MyGroupedItemList);
            }

        }
    }


}
