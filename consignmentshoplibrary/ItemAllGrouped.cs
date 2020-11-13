using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class ItemAllGrouped
    {
        public string AccountID { get; set; }
        public string ContractID { get; set; }
        public decimal SumPrice { get; set; }
        public decimal SumCost { get; set; }
        public int ItemsCount { get; set; }
    }
}
