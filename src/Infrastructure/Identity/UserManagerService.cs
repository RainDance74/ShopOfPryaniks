using Microsoft.AspNetCore.Identity;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Application.Common.Models;

namespace ShopOfPryaniks.Infrastructure.Identity;

public class UserManagerService(
    UserManager<ApplicationUser> userManager)
    : IUserManager
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        IdentityResult result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        ApplicationUser? user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        IdentityResult result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }
}
