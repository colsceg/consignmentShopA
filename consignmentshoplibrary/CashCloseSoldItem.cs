using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class CashCloseSoldItem
    {
        Store store = new Store();
        public string AccountID { get; set; }
        public string ContractID { get; set; }
        public string SalesPrice { get; set; }
        public string CostPrice { get; set; }
        public string ItemDescription { get; set; }
        public string PosNumber { get; set; }
        public int PosCount { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string FullName => $"{LastName }, { FirstName}";

        public string FullInfo => $"{AccountID }" + "  " + $"  { FullName}  " + $" {buildContractNumber()}" + "/" + "  " + $" {buildCount()}" + " "  + $" {buildPrice()} ";

        private string buildPrice()
        {
            string test = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", Convert.ToDouble( SalesPrice));
            return test;
        }

        private string buildCount()
        {
            string test = store.SetStringLengthToFour(Convert.ToString(PosCount));
            return test;
        }
        private string buildContractNumber()
        {
            string test = Item.ConvertContractIDToContractNumber(ContractID);
            return test;
        }


    }
}
