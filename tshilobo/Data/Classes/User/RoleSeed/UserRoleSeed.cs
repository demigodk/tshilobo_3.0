using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace tshilobo.Data.Classes.User.RoleSeed
{
    public static class UserRoleSeed
    {
        public static async Task CreateRoleAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<tshiloboUser>>();
            string[] roleNames = { "SuperUser", "DeptAdmin", "ChurchAdmin", "ChurchMember", "AppUser", "MainLeader", "SubLeader" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExists = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //creating a super user who could maintain the web app
            var superuser = new tshiloboUser
            {
                Email = configuration.GetSection("UserSettings")["UserEmail"],
                UserName = configuration.GetSection("UserSettings")["UserName"],
                FirstName = configuration.GetSection("UserSettings")["UserFirstName"],
                LastName = configuration.GetSection("UserSettings")["UserLastName"],
                DisplayName = configuration.GetSection("UserSettings")["UserDisplayName"],
                DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0),
                GenderId = Convert.ToInt32(configuration.GetSection("UserSettings")["UserGenderId"])
            };

            string UserPassword = configuration.GetSection("UserSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]);

            if (user == null)
            {
                var createSuperUser = await UserManager.CreateAsync(superuser, UserPassword);
                if (createSuperUser.Succeeded)
                {
                    // here we assign the new user the "SuperUser" role
                    await UserManager.AddToRoleAsync(superuser, "SuperUser");
                }
            }
        }
    }
}
