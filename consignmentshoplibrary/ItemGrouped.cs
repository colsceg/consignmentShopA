using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class ItemGrouped
    {
        public string ContractID { get; set; }
        public string PosNumber { get; set; }
        public int ItemCount { get; set; }
        public string ItemDescription { get; set; }
        public decimal SumPrice { get; set; }
        public int WithLabelCount { get; set; }
    }
}
