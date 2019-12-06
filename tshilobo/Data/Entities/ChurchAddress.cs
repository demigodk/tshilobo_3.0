namespace tshilobo.Data.Entities
{
    public partial class ChurchAddress
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public int ChurchId { get; set; }

        public virtual Church Church { get; set; }
    }
}
