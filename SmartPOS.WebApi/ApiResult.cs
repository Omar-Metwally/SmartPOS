using IResult = SmartPOS.Common.Results.IResult;

namespace SmartPOS.WebApi;

using System.Text.Json.Serialization;

public record ApiResult
{
    public bool IsSuccess { get; init; }
    public int StatusCode { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Message { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IEnumerable<string>? ErrorMessages { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IEnumerable<string>? SuccessMessages { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public object? Result { get; init; }

    public static ApiResult Success(int statusCode = 200, string? message = null, object? result = null, IEnumerable<string>? successMessages = null)
    {
        return new ApiResult
        {
            IsSuccess = true,
            StatusCode = statusCode,
            Message = message,
            Result = result,
            SuccessMessages = successMessages
        };
    }

    public static ApiResult Failure(int statusCode, string? message = null, List<string>? errors = null)
    {
        return new ApiResult
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = message,
            ErrorMessages = errors
        };
    }
}

//public record ApiResult<T> : ApiResult
//{
//    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
//    public new T? Result { get; init; }

//    public static new ApiResult<T> Success(T? result, int statusCode = 200, string? message = null, List<string>? successMessages = null)
//    {
//        return new ApiResult<T>
//        {
//            IsSuccess = true,
//            StatusCode = statusCode,
//            Message = message,
//            SuccessMessages = successMessages,
//            Result = result
//        };
//    }

//    public static new ApiResult<T> Failure(int statusCode, string? message = null, List<string>? errors = null)
//    {
//        return new ApiResult<T>
//        {
//            IsSuccess = false,
//            StatusCode = statusCode,
//            Message = message,
//            ErrorMessages = errors
//        };
//    }
//}

public static class ResultExtensions
{
    public static ApiResult ToApiResult(this IResult result)
    {
        return new ApiResult
        {
            StatusCode = (int)result.StatusCode,
            IsSuccess = result.IsSuccess,
            Message = result.Message,
            ErrorMessages = result.Errors.Count > 0 ? result.Errors.Select(e => e.Message).ToList() : default,
            SuccessMessages = result.Successes.Count > 0 ? result.Successes.Select(e => e.Message).ToList() : default,
            Result = result.IsSuccess ? result.Value : default
        };
    }

    //public static ApiResult<T> ToApiResult<T>(this IResult<T> result)
    //{
    //    return new ApiResult<T>
    //    {
    //        StatusCode = (int)result.StatusCode,
    //        IsSuccess = result.IsSuccess,
    //        Message = result.Message,
    //        ErrorMessages = result.Errors.Count > 0 ? result.Errors.Select(e => e.Message).ToList() : default,
    //        SuccessMessages = result.Successes.Count > 0 ? result.Successes.Select(e => e.Message).ToList() : default,
    //        Result = result.IsSuccess ? result.Value : default
    //    };
    //}
}