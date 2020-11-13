using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class ItemSalesVolumeGrouped
    {
        public string ContractID { get; set; }
        public string ItemDescription { get; set; }
        public int SoldCount { get; set; }
        public int Comission { get; set; }
        public string SumSoldPrice { get; set; }
        public string SumCostPrice { get; set; }
        public string SumComission { get; set; }
        public string SoldDate { get; set; }
    }
}
