using System;

namespace tshilobo.Data.Entities
{
    public partial class Theme
    {
        public int ThemeId { get; set; }
        public int ChurchId { get; set; }
        public DateTime DateCreated { get; set; }
        public string YearTheme { get; set; }
        public string CreatorId { get; set; }

        public virtual Church Church { get; set; }
        public virtual User Creator { get; set; }
    }
}
