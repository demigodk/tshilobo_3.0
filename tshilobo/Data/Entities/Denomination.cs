using System.Collections.Generic;

namespace tshilobo.Data.Entities
{
    public partial class Denomination
    {
        public Denomination()
        {
            Church = new HashSet<Church>();
        }

        public int DenominationId { get; set; }
        public string Denomination1 { get; set; }

        public virtual ICollection<Church> Church { get; set; }
    }
}
