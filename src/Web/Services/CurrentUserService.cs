using System.Security.Claims;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Web.Services;

public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        IsAuthenticated = UserId != null;
    }

    public string? UserId { get; }

    public bool IsAuthenticated { get; }
}
