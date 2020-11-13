using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class TransactionItem
    {
        public TransactionItem() { }

        public string Timestamp { get; set; }
        public string AccountID { get; set; }
        public string CustomerFullInfo { get; set; } 
    }
}
