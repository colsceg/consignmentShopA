using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ConsignmentShopMainUI.Test
{
    public partial class DocumentLabelPrint : Form
    {
        private Store Store = new Store();

        private Item myItem;

        /// <summary>
        /// the calling method sets this item
        /// </summary>
        public Item MyItem { get; set; }

        /// <summary>
        /// Set when Label is printed
        /// </summary>
        public bool MyContractPrinted { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentLabelPrint()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Set myItem after loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentLabelPrint_Load(object sender, EventArgs e)
        {
            this.myItem = this.MyItem;

        }

        /// <summary>
        /// when Item not null then set visible true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentLabelPrint_Shown(object sender, EventArgs e)
        {
            //if (myItem != null)
            //{
            //    this.Visible = true;
            //}

            CreateDocumentEx();
        }

        /// <summary>
        /// Object list for DYMO labelObjects
        /// </summary>
        //List<DymoSDK.Interfaces.ILabelObject> _labelObjects;
        //public List<DymoSDK.Interfaces.ILabelObject> LabelObjects
        //{
        //    get
        //    {
        //        if (_labelObjects == null)
        //            _labelObjects = new List<DymoSDK.Interfaces.ILabelObject>();
        //        return _labelObjects;
        //    }
        //    set
        //    {
        //        _labelObjects = value;
        //    }
        //}

        /// <summary>
        /// Prints a Label with a Dymo label priter
        /// </summary>
        //private void CreateDymoSDKLabel()
        //{
        //    DymoSDK.Implementations.DymoLabel dymoSDKLabel;
        //    dymoSDKLabel = new DymoLabel();
        //    #region Design values
        //    string itemDescription = "Hosenanzug kariert";
        //    string size = "Gr.: 176-180";
        //    string salesPrice = "€ 5555,00";
        //    string begindatum = "20.02.2020";
        //    string vendorAndItemnumber = "1444/123456";
        //    #endregion
        //    //TODO: get items values

        //    //string itemDescription = myItem.ItemDescription;
        //    //string size = myItem.Size;
        //    //string salesPrice = myItem.SalesPrice;
        //    //string begindate = myItem.BeginDate;
        //    //string accountID = myItem.AccountID;
        //    //string itemNumber = myItem.ItemNumber;
        //    //string vendorAndItemnumber = accountID + "/" + itemNumber;


        //    //Load label from file path global variable
        //    dymoSDKLabel.LoadLabelFromFilePath("Test.Label");

        //    //Get object names list
        //    LabelObjects = dymoSDKLabel.GetLabelObjects().ToList();

        //    if (dymoSDKLabel != null)
        //    {
        //        //Update label object value
        //        dymoSDKLabel.UpdateLabelObject(LabelObjects[0], itemDescription);
        //        dymoSDKLabel.UpdateLabelObject(LabelObjects[1], size);
        //        dymoSDKLabel.UpdateLabelObject(LabelObjects[2], salesPrice);
        //        dymoSDKLabel.UpdateLabelObject(LabelObjects[3], begindatum);
        //        dymoSDKLabel.UpdateLabelObject(LabelObjects[4], vendorAndItemnumber);

        //        Printer printer = new Printer();
        //        printer.Name = "450 S";
        //        printer.DriverName = "450driver";

        //        DymoPrinter.Instance.PrintLabel(dymoSDKLabel, printer.Name, 1, barcodeGraphsQuality: false);
              
        //    }

        //}

        /// <summary>
        /// Creates the document for a single label as a RichTextDocument
        /// </summary>
        private void CreateDocumentEx()
        {
            string mySize = myItem.Size;
            string myAccountID = myItem.AccountID;
            string myBegindate = myItem.BeginDate;
            string myDescription = myItem.ItemDescription;
            string myItemNumber = myItem.ItemNumber;
            string mySalesPrice = myItem.SalesPrice;

            myRichTextBoxEx.Font = new Font("Arial", 11f, FontStyle.Regular);
            myRichTextBoxEx.BackColor = Color.White;
            myRichTextBoxEx.ForeColor = Color.Black;

            //Höhe und Breite in millimetern
            double myWidth = 30;
            double myHeight = 30;
            string whiteSpeces = "";

            //string string1 = CutStringToLength("Hosenanzug kariert", 14); //mySize maximal 15 Buchstaben
            //string string2 = CutStringToLength("164-176", 7); //maximal 7 Bucstaben
            //string string3 = CutStringToLength("11150,00 €", 10);//mySalesPrice; maximal 99999,00
            //string string4 = CutStringToLength("02.02.2020", 10); //myBeginDate;
            //string string5 = CutStringToLength("1544" + "/" + "12345", 18); //myAccountID + "/" + myItemNumber; maximal 18 Zeichen

            string string1 = CutStringToLength(myDescription, 14); //mySize maximal 15 Buchstaben
            string string2 = CutStringToLength(mySize, 7); //maximal 7 Bucstaben
            string string3 = CutStringToLength(mySalesPrice, 10);//mySalesPrice; maximal 99999,00
            string string4 = CutStringToLength(myBegindate, 10); //myBeginDate;
            string string5 = CutStringToLength(myAccountID + "/" + myItemNumber, 18); //myAccountID + "/" + myItemNumber; maximal 18 Zeichen

            #region 30x30 Label
            ////Die fünf Zeilen ausgeben für  30 x 30
            ////ItemDescrition
            ////maximal 15 Buchstaben FontSize 11
            //whiteSpeces = CalculateWhiteSpeces(string1, 14);
            //myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
            //myRichTextBoxEx.SelectedText = whiteSpeces + string1 + "\n";

            ////Size
            ////FontSize 7 -- FontSize 12 maximal 12
            //whiteSpeces = CalculateWhiteSpeces(string2, 8);
            //myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Regular);
            //myRichTextBoxEx.SelectedText = whiteSpeces + "Gr.:";
            //myRichTextBoxEx.SelectionFont = new Font("Arial", 12f, FontStyle.Bold);
            //myRichTextBoxEx.SelectedText = string2 + "\n";

            ////SalesPrice
            ////FontSize = 16 maximal 4-stellig 10 Zeichen
            //whiteSpeces = CalculateWhiteSpeces(string3, 11);
            //myRichTextBoxEx.SelectionFont = new Font("Arial", 16f, FontStyle.Bold);
            //myRichTextBoxEx.SelectedText = whiteSpeces + string3 + "\n";

            ////BeginDate
            ////FontSize = 8 
            //whiteSpeces = CalculateWhiteSpeces(string4, 18);
            //myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Regular);
            //myRichTextBoxEx.SelectedText = whiteSpeces + string4 + "\n";

            ////AccountID + ItemSource
            ////FontSize = 8 maximal 18 Zeichen
            //whiteSpeces = CalculateWhiteSpeces(string5, 18);
            //myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Regular); //Eine Leerzeile
            //myRichTextBoxEx.SelectedText = whiteSpeces + string5 + "\n";

            #endregion

            #region 25x25 label
            //Die fünf Zeilen ausgeben für  30 x 30
            //ItemDescrition
            //maximal 10 Buchstaben FontSize 11
            whiteSpeces = CalculateWhiteSpeces(string1, 10);
            myRichTextBoxEx.SelectionFont = new Font("Arial", 11f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = whiteSpeces + string1 + "\n";

            //Size
            //FontSize 7 -- FontSize 12 maximal 12
            whiteSpeces = CalculateWhiteSpeces(string2, 7);
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = whiteSpeces + "Gr.:";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 12f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = string2 + "\n";

            //SalesPrice
            //FontSize = 16 maximal 4-stellig 10 Zeichen
            whiteSpeces = CalculateWhiteSpeces(string3, 8);
            myRichTextBoxEx.SelectionFont = new Font("Arial", 16f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = whiteSpeces + string3 + "\n";

            //BeginDate
            //FontSize = 8 
            whiteSpeces = CalculateWhiteSpeces(string4, 18);
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = string4 + "\n";

            //AccountID + ItemSource
            //FontSize = 8 maximal 18 Zeichen
            whiteSpeces = CalculateWhiteSpeces(string5, 18);
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Regular); //Eine Leerzeile
            myRichTextBoxEx.SelectedText = string5 + "\n";

            #endregion

        }

        private string CalculateWhiteSpeces(string myString, int maxSigns)
        {
            int len = myString.Length;
            len = maxSigns - len;
            string whiteSpaces = "";
            for (int i = 0; i < len; i++)
            {
                whiteSpaces += " ";
            }
            return whiteSpaces;
        }

        private string CutStringToLength(string myString, int maxLen)
        {
            int len = myString.Length;
            if (len > maxLen) {
                len = len - maxLen;
                myString = myString.Remove((myString.Length - len), len);
            }
            return myString;
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
