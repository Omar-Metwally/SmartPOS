using Microsoft.AspNetCore.Http;
using SmartPOS.Core.Contracts.Infrastructure.Identity;
using System.Security.Claims;

namespace SmartPOS.Infrastructure.Identity.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;

    public int? GetBranchId()
    {
        var branchIdClaim = User?.FindFirst("branch");
        return branchIdClaim != null ? int.Parse(branchIdClaim.Value) : null;
    }

    public int? GetUserId()
    {
        return 1;
    }

    public string? GetUserName()
    {
        return "Hello";
    }
}