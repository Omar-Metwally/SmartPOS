using Microsoft.AspNetCore.Diagnostics;
using SmartPOS.Core.Contracts.Infrastructure.Identity;
using System.Security.Claims;

namespace SmartPOS.WebApi.Middleware;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, ICurrentUserService currentUserService) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

        string username = _currentUserService.GetUserName() ?? "Unknown";

        var response = new ApiResult()
        {
            IsSuccess = false,
            StatusCode = 500,
            Message = "Internal Server Error",
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}
