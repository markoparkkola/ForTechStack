namespace DDD.Common.Accounts;

public interface IAccountService
{
    Task<AccountTree> GetAccountTreeAsync(CancellationToken cancellationToken = default);
}
