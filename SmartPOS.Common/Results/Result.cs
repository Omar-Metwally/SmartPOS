using FluentResults;
using System.Collections.Generic;
using System.Net;
using Error = FluentResults.Error;

namespace SmartPOS.Common.Results;

public class Result<T> : FluentResults.Result<T>, IResult<T>
{
    private HttpStatusCode _statusCode = HttpStatusCode.OK;
    private string _message = "Success";

    public HttpStatusCode StatusCode
    {
        get => _statusCode;
        set => _statusCode = value;
    }

    public string Message
    {
        get => _message;
        set => _message = value;
    }

    public Result() : base()
    {
        UpdateStatusAndMessage(HttpStatusCode.OK);
    }

    public Result(T value) : base()
    {
        WithValue(value);
        UpdateStatusAndMessage(HttpStatusCode.OK);
    }

    public new IResult WithError(IError error)
    {
        base.WithError(error);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult<T> WithError(string errorMessage)
    {
        base.WithError(errorMessage);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult<T> WithErrors(IEnumerable<string> errors)
    {
        base.WithErrors(errors);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult<T> WithErrors(IEnumerable<IError> errors)
    {
        base.WithErrors(errors);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public IResult<T> WithMailableError(IMailableError error)
    {
        base.WithError(error);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public IResult<T> WithMailableErrors(IEnumerable<IMailableError> errors)
    {
        base.WithErrors(errors);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult WithSuccess(ISuccess success)
    {
        base.WithSuccess(success);
        return this;
    }

    public async Task<IResult<T>> WithTask(Func<Task> task)
    {
        try
        {
            await task();
            return this;
        }
        catch (Exception exception)
        {
            base.WithError(new Error(exception.Message).CausedBy(exception));
            UpdateStatusAndMessage(HttpStatusCode.InternalServerError);
            return this;
        }
    }

    public async Task<IResult<T>> WithTask(Func<Task> task, string errorMessageIfFail)
    {
        try
        {
            await task();
            return this;
        }
        catch (Exception exception)
        {
            base.WithError(new Error(errorMessageIfFail).CausedBy(exception));
            UpdateStatusAndMessage(HttpStatusCode.InternalServerError);
            return this;
        }
    }

    public IResult<T> WithStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public IResult<T> WithMessage(string message)
    {
        Message = message;
        return this;
    }

    public IResult<TNewValue> ChangeType<TNewValue>(TNewValue value)
    {
        var result = new Result<TNewValue>(value)
        {
            StatusCode = StatusCode,
            Message = Message
        };
        result.WithReasons(Reasons);
        return result;
    }

    private void UpdateStatusAndMessage(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Message = statusCode.ToString();
    }

    public Result<TNewValue> Bind<TNewValue>(Func<T, Result<TNewValue>> bind)
    {
        var result = new Result<TNewValue>();
        result.WithReasons(Reasons);

        if (IsSuccess)
        {
            var converted = bind(Value);
            result.WithValue(converted.ValueOrDefault);
            result.WithReasons(converted.Reasons);
        }

        return result;
    }

    public IResult<T> WithOk()
    {
        return WithStatusCode(HttpStatusCode.OK).WithMessage("Success");
    }

    public IResult<T> WithCreated()
    {
        return WithStatusCode(HttpStatusCode.Created).WithMessage("Created");
    }

    public IResult<T> WithUpdated()
    {
        return WithStatusCode(HttpStatusCode.Accepted).WithMessage("Updated");
    }

    public IResult<T> WithBadRequest(string? errorMessage = null)
    {
        StatusCode = HttpStatusCode.BadRequest;
        Message = "Bad Request";
        if (errorMessage != null)
        {
            return WithError(errorMessage);
        }
        return this;
    }

    public IResult<T> WithDeleted()
    {
        return WithStatusCode(HttpStatusCode.NoContent).WithMessage("Deleted");
    }

    public IResult<T> WithNotFound(string? errorMessage = null)
    {
        StatusCode = HttpStatusCode.NotFound;
        Message = "Not Found";
        if (errorMessage != null)
        {
            return WithError(errorMessage);
        }
        return this;
    }

    public new IResult<T> WithValue(T value)
    {
        base.WithValue(value);
        return this;
    }

    object? IResult.Value => ValueOrDefault;
    IResult IResult.WithOk() => WithOk();
    IResult IResult.WithCreated() => WithCreated();
    IResult IResult.WithUpdated() => WithUpdated();
    IResult IResult.WithBadRequest(string? errorMessage) => WithBadRequest(errorMessage);
    IResult IResult.WithDeleted() => WithDeleted();
    IResult IResult.WithErrors(IEnumerable<string> errorMessages) => WithErrors(errorMessages);
    IResult IResult.WithMailableError(IMailableError error) => WithMailableError(error);
    IResult IResult.WithMailableErrors(IEnumerable<IMailableError> errors) => WithMailableErrors(errors);
    IResult IResult.WithStatusCode(HttpStatusCode statusCode) => WithStatusCode(statusCode);
    IResult IResult.WithMessage(string message) => WithMessage(message);
    async Task<IResult> IResult.WithTask(Func<Task> task) => await WithTask(task);
    async Task<IResult> IResult.WithTask(Func<Task> task, string errorMessageIfFail) => await WithTask(task, errorMessageIfFail);
    IResult IResult.WithValue(object value) => WithValue((T)value);
    IResult IResult.WithErrors(IEnumerable<FluentResults.IError> errorMessages) => WithErrors(errorMessages);
}

public class Result : FluentResults.Result, IResult
{
    private HttpStatusCode _statusCode = HttpStatusCode.OK;
    private string _message = "Success";

    public object? Value { get; private set; }

    public HttpStatusCode StatusCode
    {
        get => _statusCode;
        set => _statusCode = value;
    }

    public string Message
    {
        get => _message;
        set => _message = value;
    }

    public Result() : base()
    {
        UpdateStatusAndMessage(HttpStatusCode.OK);
    }

    public Result(object value) : base()
    {
        Value = value;
        UpdateStatusAndMessage(HttpStatusCode.OK);
    }

    public new IResult WithError(IError error)
    {
        base.WithError(error);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult WithError(string errorMessage)
    {
        base.WithError(errorMessage);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult WithErrors(IEnumerable<string> errors)
    {
        base.WithErrors(errors);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult WithErrors(IEnumerable<IError> errors)
    {
        base.WithErrors(errors);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public new IResult WithSuccess(ISuccess success)
    {
        base.WithSuccess(success);
        return this;
    }

    public async Task<IResult> WithTask(Func<Task> task)
    {
        try
        {
            await task();
            return this;
        }
        catch (Exception exception)
        {
            base.WithError(new Error(exception.Message).CausedBy(exception));
            UpdateStatusAndMessage(HttpStatusCode.InternalServerError);
            return this;
        }
    }

    public async Task<IResult> WithTask(Func<Task> task, string errorMessageIfFail)
    {
        try
        {
            await task();
            return this;
        }
        catch (Exception exception)
        {
            base.WithError(new Error(errorMessageIfFail).CausedBy(exception));
            UpdateStatusAndMessage(HttpStatusCode.InternalServerError);
            return this;
        }
    }

    public IResult WithStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public IResult WithMessage(string message)
    {
        Message = message;
        return this;
    }

    public IResult<TNewValue> ChangeType<TNewValue>(TNewValue value)
    {
        var result = new Result<TNewValue>(value)
        {
            StatusCode = StatusCode,
            Message = Message
        };
        result.WithReasons(Reasons);
        return result;
    }

    private void UpdateStatusAndMessage(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Message = statusCode.ToString();
    }

    public IResult WithOk()
    {
        return WithStatusCode(HttpStatusCode.OK).WithMessage("Success");
    }

    public IResult WithCreated()
    {
        return WithStatusCode(HttpStatusCode.Created).WithMessage("Created");
    }

    public IResult WithUpdated()
    {
        return WithStatusCode(HttpStatusCode.Accepted).WithMessage("Updated");
    }

    public IResult WithBadRequest(string? errorMessage = null)
    {
        StatusCode = HttpStatusCode.BadRequest;
        Message = "Bad Request";
        if (errorMessage != null)
        {
            return WithError(errorMessage);
        }
        return this;
    }

    public IResult WithDeleted()
    {
        return WithStatusCode(HttpStatusCode.NoContent).WithMessage("Deleted");
    }

    public IResult WithNotFound(string? errorMessage = null)
    {
        StatusCode = HttpStatusCode.NotFound;
        Message = "Not Found";
        if (errorMessage != null)
        {
            return WithError(errorMessage);
        }
        return this;
    }

    public IResult WithMailableError(IMailableError error)
    {
        base.WithError(error);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public IResult WithMailableErrors(IEnumerable<IMailableError> errors)
    {
        base.WithErrors(errors);
        UpdateStatusAndMessage(HttpStatusCode.BadRequest);
        return this;
    }

    public IResult WithValue(object value)
    {
        Value = value;
        return this;
    }
}

public interface IResultBase : FluentResults.IResultBase { }

public interface IResult : IResultBase
{
    HttpStatusCode StatusCode { get; set; }
    string Message { get; set; }
    object? Value { get; }

    IResult WithOk();
    IResult WithCreated();
    IResult WithUpdated();
    IResult WithBadRequest(string? errorMessage);
    IResult WithDeleted();
    IResult WithMailableError(IMailableError error);
    IResult WithMailableErrors(IEnumerable<IMailableError> errors);
    IResult WithErrors(IEnumerable<string> errorMessages);
    IResult WithErrors(IEnumerable<IError> errorMessages);
    IResult WithStatusCode(HttpStatusCode statusCode);
    IResult WithMessage(string message);
    Task<IResult> WithTask(Func<Task> task);
    Task<IResult> WithTask(Func<Task> task, string errorMessageIfFail);
    IResult WithValue(object value);
}

public interface IResult<T> : IResult
{
    new T Value { get; }

    new IResult<T> WithOk();
    new IResult<T> WithCreated();
    new IResult<T> WithUpdated();
    new IResult<T> WithBadRequest(string? errorMessage);
    new IResult<T> WithDeleted();
    new IResult<T> WithMailableError(IMailableError error);
    new IResult<T> WithMailableErrors(IEnumerable<IMailableError> errors);
    new IResult<T> WithErrors(IEnumerable<string> errorMessages);
    new IResult<T> WithErrors(IEnumerable<IError> errorMessages);
    new IResult<T> WithStatusCode(HttpStatusCode statusCode);
    new IResult<T> WithMessage(string message);
    new Task<IResult<T>> WithTask(Func<Task> task);
    new Task<IResult<T>> WithTask(Func<Task> task, string errorMessageIfFail);
    IResult<T> WithValue(T value);
    IResult<TNewValue> ChangeType<TNewValue>(TNewValue value);
}

public interface IMailableError : IError;

public class MailableError : Error ,IMailableError;