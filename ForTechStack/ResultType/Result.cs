namespace ForTechStack.ResultType;

public sealed class Result<T>
{
    private readonly Option<T> _value;
    private readonly Option<string> _errorMessage;
    private readonly Option<Exception> _exception;

    private Result(string? errorMessage, Exception? exception)
    {
        _value = Option<T>.None;
        _errorMessage = errorMessage == null ? Option<string>.None : new Option<string>(errorMessage);
        _exception = exception == null ? Option<Exception>.None : new Option<Exception>(exception);
    }

    private Result(T value)
    {
        _value = new Option<T>(value);
        _errorMessage = Option<string>.None;
        _exception = Option<Exception>.None;
    }

    public bool IsSuccess => _value.HasValue;
    public bool HasErrorMessage => _errorMessage.HasValue;
    public bool HasException => _exception.HasValue;
    public string ErrorMessage => _errorMessage.Value;
    public Exception Exception => _exception.Value;

    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(string? errorMessage = null, Exception? exception = null) => new Result<T>(errorMessage, exception);

    public Result<T> OnSuccess(Action<T> fn)
    {
        if (IsSuccess)
        {
            fn(_value.Value);
        }
        return this;
    }

    public Result<T> OnFailure(Action<Result<T>> fn)
    {
        if (!IsSuccess)
        {
            fn(this);
        }
        return this;
    }
}
