using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class MakeSearch
    {
            String _s;

            public MakeSearch(String s)
            {
                _s = s;
            }

            public bool StartsWith(Make e)
            {
                return e.Name.StartsWith(_s, StringComparison.InvariantCultureIgnoreCase);
            }
        }
}
