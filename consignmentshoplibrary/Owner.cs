

namespace ConsignmentShopLibrary
{
    public class Owner
    {
        public string OwnerName { get; set; }
        public string FirstName { get; set; }
        public string FootString { get; set; }
        public string Street { get; set; }
        public string Plz { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilNumber { get; set; }
        public string StoreName { get; set; }
        public uint Margin { get; set; }
        public uint Period { get; set; }


        public string FullInfo => $"{ OwnerName } { FirstName }";
    }
}
