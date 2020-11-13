using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
   public class Contract
    {
        private string _SoldSum;
        private string _PayedSum;
        private string _ProvisionSum;

        private Store store = new Store();

        public Contract() :this ("", "", 50) { }
        public Contract(string contractID) :this(contractID, "", 50) { } 
        public Contract(string contractID, string accountID, int margin )
        {
            ContractID = contractID;
            AccountID = accountID;
            Margin = margin;
            NumberOfItems = 0;
            PayedSum = "0";
            ProvisionSum = "0";
            SoldSum = "0";
            SoldNumbers = 0;
            ContractInfo = "";
        }

        public string ContractID { get; set; }
        public string AccountID { get; set; }
        public string BeginDate { get; set; }
        public string CloseDate { get; set; }
        public string EndDate { get; set; }
        public int NumberOfItems { get; set; }
        public string ProvisionSum
        {
            get { return store.ChangeKommaToPoint(_ProvisionSum); }
            set
            {
                _ProvisionSum = value;
            }
        }

        public int SoldNumbers { get; set; }

        public string SoldSum
        {
            get { return store.ChangeKommaToPoint(_SoldSum); }
            set
            {
                _SoldSum = value;
            }
        }
        public string PayedSum
        {
            get { return store.ChangeKommaToPoint(_PayedSum); }
            set
            {
                _PayedSum = value;
            }
        }

        public string ContractInfo { get; set; }
        public int Margin { get; set; }
        public bool Archived { get; set; }
    }
}
