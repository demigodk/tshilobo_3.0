using System.Collections.Generic;

namespace tshilobo.Data.Entities
{
    public partial class Gender
    {
        public Gender()
        {
            User = new HashSet<User>();
        }

        public int GenderId { get; set; }
        public string Gname { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
