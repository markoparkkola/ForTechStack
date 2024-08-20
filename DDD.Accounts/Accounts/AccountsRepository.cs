using DDD.Common.Accounts;
using DDD.Data;
using Entities = DDD.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Shared.Accounts;

public class AccountsRepository(ApplicationDbContext context) : IAccountRepository
{
    public async Task<AccountTree> GetAccountTreeAsync(CancellationToken cancellationToken)
    {
        var accountsInDb = await context.Accounts.ToListAsync(cancellationToken);
        var accountsByParentKey = accountsInDb.Cast<IAccountBase>().ToLookup(x => x.ParentKey);
        var rootAccounts = accountsByParentKey[null];

        if (rootAccounts.Count() != 3)
        {
            throw new Exception("There needs to be exactely three (3) root accounts.");
        }

        var incomeAccount = rootAccounts.First(x => x.Number == AccountNumbers.IncomeSheetAccountNumber);
        var assetsAccount = rootAccounts.First(x => x.Number == AccountNumbers.AssetsAccountNumber);
        var liabilitiesAccount = rootAccounts.First(x => x.Number == AccountNumbers.LiabilitiesAccountNumber);

        var incomes = new TopLevelAccount(
            accountsByParentKey,
            incomeAccount
        );
        var assets = new TopLevelAccount(
            accountsByParentKey,
            assetsAccount
        );
        var liabilities = new TopLevelAccount(
            accountsByParentKey,
            liabilitiesAccount
        );

        return new AccountTree(
            incomes,
            assets,
            liabilities
        );
    }
}
