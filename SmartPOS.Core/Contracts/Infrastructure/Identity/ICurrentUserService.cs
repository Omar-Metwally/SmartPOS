using System.Security.Claims;

namespace SmartPOS.Core.Contracts.Infrastructure.Identity;

public interface ICurrentUserService
{
    ClaimsPrincipal User { get; }
    int? GetBranchId();
    int? GetUserId();
    string? GetUserName();
}