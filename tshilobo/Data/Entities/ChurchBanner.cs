namespace tshilobo.Data.Entities
{
    public partial class ChurchBanner
    {
        public int BannerId { get; set; }
        public string BannnerName { get; set; }
        public int ChurchId { get; set; }
        public byte[] BannerContent { get; set; }
        public bool IsActive { get; set; }

        public virtual Church Church { get; set; }
    }
}
