using System.Collections.Generic;

namespace tshilobo.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            RoleClaim = new HashSet<RoleClaim>();
            UserRole = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<RoleClaim> RoleClaim { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
