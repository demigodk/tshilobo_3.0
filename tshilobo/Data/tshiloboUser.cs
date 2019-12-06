using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

/// <summary>
/// Author      :   Bondo Kalombo
/// Date        :   26/10/2018
/// </summary>
namespace tshilobo.Data
{
    // Add profile data for application users by adding properties to the tshiloboUser class
    public class tshiloboUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public int GenderId { get; set; }

        public bool BelongsToAChurch { get; set; }

        public int ChurchId { get; set; }

        [PersonalData]
        public int TitleId { get; set; }

        [PersonalData]
        public string DisplayName { get; set; }

        [PersonalData]
        public DateTime DateOfBirth { get; set; }


        // For navigating through the Identity objects
        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; } = new List<IdentityUserLogin<string>>();

    }
}
