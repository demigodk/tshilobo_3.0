using System;
using System.Collections.Generic;

namespace tshilobo.Data.Entities
{
    public partial class Church
    {
        public Church()
        {
            ChurchAddress = new HashSet<ChurchAddress>();
            ChurchBanner = new HashSet<ChurchBanner>();
            Theme = new HashSet<Theme>();
        }

        public int ChurchId { get; set; }
        public string ChurchCode { get; set; }
        public bool? HasBranches { get; set; }
        public bool? IsMainBranch { get; set; }
        public string MissionStatement { get; set; }
        public string ChurchName { get; set; }
        public DateTime? FoundingDate { get; set; }
        public string FounderName { get; set; }
        public string CreatorId { get; set; }
        public int? DenominationId { get; set; }
        public string VisionStatement { get; set; }
        public string ChurchLeaderId { get; set; }
        public string MainBelief { get; set; }
        public int? MainBranchId { get; set; }

        public virtual User ChurchLeader { get; set; }
        public virtual User Creator { get; set; }
        public virtual Denomination Denomination { get; set; }
        public virtual ICollection<ChurchAddress> ChurchAddress { get; set; }
        public virtual ICollection<ChurchBanner> ChurchBanner { get; set; }
        public virtual ICollection<Theme> Theme { get; set; }
    }
}
