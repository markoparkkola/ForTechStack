using DDD.Common.Accounts;

namespace DDD.Shared.Accounts;

public class AccountsService(IAccountRepository accountRepository) : IAccountService
{
    public Task<AccountTree> GetAccountTreeAsync(CancellationToken cancellationToken = default)
        => accountRepository.GetAccountTreeAsync(cancellationToken);
}
