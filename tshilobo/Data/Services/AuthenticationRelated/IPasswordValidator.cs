using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace tshilobo.Data.Services.AuthenticationRelated
{
    public interface IPasswordValidator<TUser> where TUser : class
    {
        Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password);
    }
}
