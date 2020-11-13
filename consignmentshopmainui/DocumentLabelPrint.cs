using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class DocumentLabelPrint : Form
    {
        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();
        private List<Contract> ContractsList = new List<Contract>();
        private List<Item> ItemsList = new List<Item>();
        private Store Store = new Store();
        private string myContractID;

        public string MyContractID { get; set; }
        public string MyPosNumberFrom { get; set; }
        public string MyPosNumberTo { get; set; }
        public string MyItemNumber { get; set; }
        public int MyLastLabelNumber { get; set; }

        public DocumentLabelPrint()
        {
            InitializeComponent();

        }

        private void DocumentLabelPrint_Load(object sender, EventArgs e)
        {
            this.myContractID = this.MyContractID;

        }

        public bool MyContractPrinted { get; set; }

        private void Setup()
        {
            CreateDocumentEx();
        }

        private void DocumentLabelPrint_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(MyItemNumber))
            {
                this.Visible = false;
            }
            Setup();
        }

        private void CreateDocumentEx()
        {
            int myLastLabelRow;
            int myLastLabelColumn;
            string myLastLabelPrefixCols = "";
            string myLastLabelPrefixRows = "";
            string myDescription;
            string myItemNumber;
            string mySalesPrice;

            myRichTextBoxEx.Font = new Font("Arial", 11f, FontStyle.Regular);
            myRichTextBoxEx.BackColor = Color.White;
            myRichTextBoxEx.ForeColor = Color.Black;
            //Artikelliste einlesen
            List<Item> myContractItemList = new List<Item>();

            if (String.IsNullOrWhiteSpace(MyItemNumber))
            {
                myContractItemList = DbItems.GetItemsWithContractIDLabelPrint(MyContractID, Store.BuildNumberToString(MyPosNumberFrom), Store.BuildNumberToString(MyPosNumberTo));
            }
            else
            {
                myContractItemList = DbItems.GetItemsWithContractIDLabelPrintOne(MyContractID, Store.BuildNumberToString(MyPosNumberFrom), Store.BuildNumberToString(MyItemNumber));
            }


            int myRowSize = myContractItemList.Count;
            if (myRowSize > 0)
            {
                if (MyLastLabelNumber < 80)
                {
                    myLastLabelRow = MyLastLabelNumber / 5;
                    myLastLabelColumn = MyLastLabelNumber % 5;
                }
                else
                {
                    myLastLabelRow = 0;
                    myLastLabelColumn = 0;
                    MyLastLabelNumber = 0;
                }

                //Leer Etiketten drucken wenn kein neuer Bogen für jede leere Etiketten Reihe (Lastlabel > 0)
                int[] tabs = { 149, 300, 449, 600, 590 };
                myRichTextBoxEx.SelectionTabs = tabs;
                for (int i = 0; i < myLastLabelRow; i++)
                {
                    myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
                    myRichTextBoxEx.SelectedText = "\t" + "" + "\n";

                    myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
                    myRichTextBoxEx.SelectedText = "\t" + "" + "\n";

                    myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
                    myRichTextBoxEx.SelectedText = "\t" + "" + "\n";

                    myRichTextBoxEx.SelectionFont = new Font("Arial", 8f, FontStyle.Bold); //Eine Leerzeile
                    myRichTextBoxEx.SelectedText = "\t" + "" + "\n";
                }

                for (int i = 0; i < myLastLabelColumn; i++)
                {
                    myLastLabelPrefixCols += "\t";
                }
                Item myItem = new Item();
                int index = 0;
                string format = "{0,10}";
                myContractID = Item.ConvertContractIDToContractNumber(myContractID);
                while (myRowSize > 0)
                {
                    string string1 = "";
                    string string2 = "";
                    string string3 = "";
                    if (myRowSize >= 5 || (myLastLabelColumn + myRowSize) >= 5)
                    {
                        for (int i = 0; i < (5 - myLastLabelColumn); i++)
                        {

                            myItem = myContractItemList[index];
                            myDescription = myItem.ItemDescription;
                            mySalesPrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", Convert.ToDecimal(myItem.SalesPrice));
                            if (myDescription.Length > 20)
                            {
                                myDescription = myDescription.Remove(20, myDescription.Length - 20);
                            }
                            else
                            {
                                myDescription = String.Format(format, myDescription);
                            }
                            myItemNumber = myItem.PosNumber;
                            string1 = myLastLabelPrefixCols + string1 + myContractID + "/" + myItemNumber + "\t";
                            string2 = myLastLabelPrefixCols + string2 + myDescription + "\t";
                            string3 = myLastLabelPrefixCols + string3 + mySalesPrice + "\t";
                            index += 1;
                            MyLastLabelNumber += 1;
                            myLastLabelPrefixCols = "";
                        }
                        myRowSize = myRowSize - (5 - myLastLabelColumn);
                        myLastLabelRow += 1;
                        myLastLabelColumn = 0;
                    }
                    else
                    {
                        for (int i = 0; i < myRowSize; i++)
                        {
                            myItem = myContractItemList[index];
                            MyLastLabelNumber += 1;
                            myItemNumber = myItem.PosNumber;
                            myDescription = myItem.ItemDescription;
                            mySalesPrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,10:C2}", Convert.ToDecimal(myItem.SalesPrice));
                            if (myDescription.Length > 20)
                            {
                                myDescription = myDescription.Remove(20, myDescription.Length - 20);
                            }
                            else
                            {
                                myDescription = String.Format(format, myDescription);
                            }
                            myItemNumber = myItem.PosNumber;
                            string1 = myLastLabelPrefixRows + myLastLabelPrefixCols + string1 + myContractID + "/" + myItemNumber + "\t";
                            string2 = myLastLabelPrefixCols + string2 + myDescription + "\t";
                            string3 = myLastLabelPrefixCols + string3 + mySalesPrice + "\t";
                            index += 1;
                            myLastLabelPrefixCols = "";
                            myLastLabelPrefixRows = "";
                        }
                        myRowSize = 0;
                    }
                    //Die drei Zeilen und eine Leerzeile ausgeben
                    myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
                    myRichTextBoxEx.SelectedText = string1.Remove((string1.Length - 1), 1) + "\n";

                    myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
                    myRichTextBoxEx.SelectedText = string2.Remove((string2.Length - 1), 1) + "\n";

                    myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
                    myRichTextBoxEx.SelectedText = string3.Remove((string3.Length - 1), 1) + "\n";

                    myRichTextBoxEx.SelectionFont = new Font("Arial", 8f, FontStyle.Bold); //Eine Leerzeile
                    myRichTextBoxEx.SelectedText = "" + "\n";
                    if (MyLastLabelNumber == 80)
                    {
                        MyLastLabelNumber = 0;
                    }
                } //end While

                if (!String.IsNullOrWhiteSpace(MyItemNumber))
                {
                    //zur Abfrage Drucken Speichern Abbrechen
                    //MessageBox.Show("not implemented yet");
                    PrintRichTextContents myPrint = new PrintRichTextContents();
                    myPrint.MyPrintDialog = printDialog1;
                    myPrint.MyRichTextBoxEx = myRichTextBoxEx;
                    myPrint.PageNumberEnabled = false;

                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        MyContractPrinted = true;
                        myPrint.PrintRTContents();
                    }
                    this.Close();
                }
            }
        }


        private void PrintButton_Click(object sender, EventArgs e)
        {
            //zur Abfrage Drucken Speichern Abbrechen
            //MessageBox.Show("not implemented yet");
            PrintRichTextContents myPrint = new PrintRichTextContents();
            myPrint.MyPrintDialog = printDialog1;
            myPrint.MyRichTextBoxEx = myRichTextBoxEx;
            myPrint.PageNumberEnabled = false;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                MyContractPrinted = true;
                myPrint.PrintRTContents();
            }
            this.Close();
        }
    }
}
