using MediatR;
using Microsoft.Extensions.Logging;
using SmartPOS.Common.Results;
using SmartPOS.Core.Contracts.Infrastructure.Identity;
using System.Text.Json;

namespace SmartPOS.Core.Behaviors;

public class RequestLoggingBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingBehavior<TRequest, TResponse>> logger,
    ICurrentUserService currentUserService) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : IResult
{
    private readonly ILogger<RequestLoggingBehavior<TRequest, TResponse>> _logger = logger;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;
        string username = _currentUserService.GetUserName() ?? "Unknown";

        _logger.LogInformation(
            "Processing request {RequestName} for user {Username}", requestName, username);

        TResponse result = await next();

        if (result.IsSuccess)
        {
            _logger.LogInformation(
                "Completed request {RequestName} for user {Username}", requestName, username);
        }
        else
        {
            string errorDetails = JsonSerializer.Serialize(result.Errors);
            _logger.LogError(
                "Completed request {RequestName} for user {Username} with errors: {Errors}",
                requestName, username, errorDetails);
        }

        return result;
    }
}

