namespace DDD.Common.Accounts;

public class TopLevelAccount
{
    public TopLevelAccount(ILookup<Guid?, IAccountBase> accountsByParentId, IAccountBase rootAccount)
    {
        var account = new Account(
            new AccountId(rootAccount.Key), 
            rootAccount.Name,
            rootAccount.Number,
            null,
            Enumerable.Empty<Account>().ToList()
        );

        Account = account with
        {
            Children = TraverseAccountTree(accountsByParentId, rootAccount)
        };
    }

    public Account Account { get; }

    private IReadOnlyList<Account> TraverseAccountTree(
        ILookup<Guid?, IAccountBase> accountsByParentId, 
        IAccountBase currentAccountBase,
        Account? parentAccount = null)
    {
        return accountsByParentId[currentAccountBase.Key].Select(x =>
        {
            var account = new Account(
                new AccountId(x.Key),
                x.Name,
                x.Number,
                parentAccount,
                Enumerable.Empty<Account>().ToList()
            );

            return account with
            {
                Children = TraverseAccountTree(accountsByParentId, x, account)
            };
        }).ToList();
    }
}
