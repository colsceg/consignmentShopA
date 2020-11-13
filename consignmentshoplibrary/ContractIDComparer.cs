using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class ContractIDComparer : IComparer<ItemReport>
    {
        public int Compare(ItemReport x, ItemReport y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.ContractID.CompareTo(y.ContractID);
        }
    }
}
