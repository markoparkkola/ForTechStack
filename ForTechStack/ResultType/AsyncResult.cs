namespace ForTechStack.ResultType;

internal class AsyncResult<T>
{
    private Task<Result<T>> task;

    public AsyncResult(Task<Result<T>> task)
    {
        this.task = task;
    }

    public static AsyncResult<T> Create(Task<Result<T>> task) => new AsyncResult<T>(task);

    public async Task<AsyncResult<T>> OnSuccess(Action<T> fn, ConfigureAwaitOptions? options = null)
    {
        var result = await task.ConfigureAwait(options ?? ConfigureAwaitOptions.None);
        result.OnSuccess(fn);
        return this;
    }

    public async Task<AsyncResult<T>> OnFailure(Action<Result<T>> fn, ConfigureAwaitOptions? options = null)
    {
        var result = await task.ConfigureAwait(options ?? ConfigureAwaitOptions.None);
        result.OnFailure(fn);
        return this;
    }
}
