using Microsoft.AspNetCore.Identity;

using ShopOfPryaniks.Application.Common.Models;

namespace ShopOfPryaniks.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}