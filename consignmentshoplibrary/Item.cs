using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Item
    {
        public Item() {}

        public string ContractID { get; set; }
        public string AccountID { get; set; }
        public string Color { get; set; } //color
        public string Brand { get; set; } //brand
        public string Prop { get; set; } //prop   
        public string Size { get; set; } //size
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public  string SalesPrice { get; set; }
        public string CostPrice { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string PayoutDate { get; set; }
        public string SoldDate { get; set; }
        public int WithLabel { get; set; }
        public string PosNumber { get; set; }
        public string DeleteDate { get; set; }

        /// <summary>
        /// Convert a DateString dd.mm.yyyy into yyyy-mm-dd
        /// </summary>
        /// <param name="aDateString"></param>
        /// <returns></returns>
        public static string ConvertDateStringToSQLiteTimeString(string aDateString)
        {
            string result = "";
            if (!String.IsNullOrEmpty(aDateString))
            {
                //Prüfen ob Datum in lesbarer Form dd.mm.yyyy
                int length = aDateString.Length;
                if (aDateString.IndexOf('.', 0) + aDateString.LastIndexOf('.', length - 1) == 7)
                {
                    //Liste mit Substrings bilden
                    string[] liste = aDateString.Split('.');
                    if (liste.GetUpperBound(0) == 2)
                        //Substrings in umgekehrter REiehnfolge mit '-' zusammenfügen
                        result = (liste[2] + '-' + liste[1] + '-' + liste[0]);
                    if (result.Length == 8)
                        result = "20" + result;
                }
            }
            return result;
        }

        /// <summary>
        /// Convert a DateString yyyy-mm-dd into dd.mm.yyyy
        /// </summary>
        /// <param name="aSQLiteString"></param>
        /// <returns></returns>
        public static string ConvertSQLiteTimeStringToDateString(string aSQLiteString)
        {
            string result = "";
            if (!String.IsNullOrEmpty(aSQLiteString))
            {
                //Prüfen ob Datum in lesbarer Form dd.mm.yyyy
                int length = aSQLiteString.Length;
                if (aSQLiteString.IndexOf('-', 0) + aSQLiteString.LastIndexOf('-', length - 1) == 11)
                {
                    //Liste mit Substrings bilden
                    string[] liste = aSQLiteString.Split('-');
                    if (liste.GetUpperBound(0) == 2)
                        //Substrings in umgekehrter REiehnfolge mit '-' zusammenfügen
                        result = (liste[2] + '.' + liste[1] + '.' + liste[0]);
                }
            }
            return result;
        }

        /// <summary>
        /// Converts a string yynnnn to nnnn/yy
        /// </summary>
        /// <param name="nContractID"></param>
        /// <returns></returns>
        public static string ConvertContractIDToContractNumber(string nContractID)
        {
            string contractNumber;

            //int myIndex = anContractID.IndexOf('/');
            if (nContractID.Length == 6)
            {
                contractNumber = nContractID.Substring(2, 4) + '/' + nContractID.Substring(0, 2);
                return contractNumber;
            }

            return "";
        }

        public static int ConvertItemNumberStringToInt(string anItemNumberString)
        {
            int value;
            if (int.TryParse(anItemNumberString, out value))
                return value;
            else
                return 0;
        }
    }
}
