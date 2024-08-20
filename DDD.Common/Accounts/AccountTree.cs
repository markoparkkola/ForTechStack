namespace DDD.Common.Accounts;

public record AccountTree(
    TopLevelAccount IncomeSheet, 
    TopLevelAccount Balance, 
    TopLevelAccount Liabilities
)
{
    public Account? FindAccount<TProp>(Func<Account, TProp> propertySelector, TProp value)
    {
        Account? result = null;
        Parallel.ForEach(
            [IncomeSheet, Balance, Liabilities],
            new ParallelOptions { MaxDegreeOfParallelism = 1 },
            (topLevelAccount, state) =>
        {
            var account = FindAccount(propertySelector, value, topLevelAccount.Account, state);
            if (account != null)
            {
                result = account;
                state.Stop();
            }
        });
        return result;
    }

    public Account GetByKey(Guid key)
    {
        return FindAccount(x => x.Id.Key, key) ?? throw new ArgumentException(nameof(key));
    }

    private Account? FindAccount<TProp>(
        Func<Account, TProp> propertySelector, 
        TProp? value, 
        Account account, 
        ParallelLoopState state)
    {
        if (state.IsStopped)
        {
            return null;
        }

        var property = propertySelector(account) ?? throw new Exception("That's weird.");
        if (property.Equals(value))
        {
            return account;
        }

        foreach (var child in account.Children)
        {
            var result = FindAccount(propertySelector, value, child, state);
            if (result != null)
            {
                return result;
            }
        }
        
        return null;
    }
}
