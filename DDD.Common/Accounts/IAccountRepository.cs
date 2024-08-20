namespace DDD.Common.Accounts;

public interface IAccountRepository
{
    Task<AccountTree> GetAccountTreeAsync(CancellationToken cancellationToken);
}
