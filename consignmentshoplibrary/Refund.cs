
using System;

namespace ConsignmentShopLibrary
{
    /// <summary>
    /// Ablageort eingabedatum und ausgabedatum
    /// </summary>
    public class Refund : Vendor, IEquatable<Refund>
    {     
        //public string AccountID { get; set; } //VendorID
        //public string Name { get; set; } //VendorID

        public string Place { get; set; } //Ablageort
        public string Input { get; set; } //EingabeDatum   
        public string Output { get; set; } //Ausgabedatum

        public bool Equals(Refund other)
        {
            if (this.AccountID == other.AccountID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
