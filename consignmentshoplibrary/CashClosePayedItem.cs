using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class CashClosePayedItem
    {
        private Store store = new Store();
        public string AccountID { get; set; }
        public string ContractID { get; set; }
        public string CostPrice { get; set; }
        public string SumTotalToPay { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string FullName => $"{LastName }, { FirstName}";

        public string FullInfo => $"{AccountID}" + "  " + $"  {FullName}  " + $" {buildContractNumber()}" + " " + $" {buildPrice()} ";

        private string buildPrice()
        {
            string test = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,8:C2}", Convert.ToDouble( CostPrice));
            return test;
        }

        private string buildContractNumber()
        {
            string test = Item.ConvertContractIDToContractNumber(ContractID);
            return test;
        }
    }
}
