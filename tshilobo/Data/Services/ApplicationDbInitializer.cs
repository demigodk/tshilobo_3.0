using Microsoft.AspNetCore.Identity;
using System;

namespace tshilobo.Data.Services
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                tshiloboUser user = new tshiloboUser
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com",
                    DisplayName = "Tshilobo Admin",
                    LastName = "Admin",
                    FirstName = "Tshilobo",
                    GenderId = 1,
                    DateOfBirth = new DateTime(Convert.ToInt32(1991), Convert.ToInt32(02), Convert.ToInt32(23), 0, 0, 0)
                };

                IdentityResult result = userManager.CreateAsync(user, "P0dC@5tHome").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
