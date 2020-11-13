using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class VendorSearch
    {
        String _s;

        public VendorSearch(String s)
        {
            _s = s;
        }

        public bool StartsWith(Vendor e)
        {
            return e.FullName.StartsWith(_s, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
