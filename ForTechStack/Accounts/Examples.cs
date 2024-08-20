using DDD.Data;
using DDD.Data.Entities;

namespace ForTechStack.Accounts;

public static class Examples
{
    public static void FillContext(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        context.Accounts.AddRange(
            new AccountBuilder(100, "Assets").Build()
        );
        
        context.Accounts.AddRange(
            new AccountBuilder(200, "Liabilities").Build()
        );

        context.Accounts.AddRange(
            new AccountBuilder(300, "Profit",
                new AccountBuilder(3000, "Sales",
                    new AccountBuilder(3100, "Common sales",
                        new AccountBuilder(3110, "Sales 1"),
                        new AccountBuilder(3120, "Sales 2")
                    )
                )
            ).Build()
        );

        context.SaveChanges();
    }

    private class AccountBuilder(int Number, string Name, params AccountBuilder[] builders)
    {
        public IEnumerable<Account> Build(Account? parent = null)
        {
            var thisAccount = new Account
            {
                Name = Name,
                Key = Guid.NewGuid(),
                Number = Number,
                ParentKey = parent?.Key
            };

            yield return thisAccount;

            foreach (var childAccount in builders.SelectMany(builder => builder.Build(thisAccount)))
            {
                yield return childAccount;
            }
        }
    }
}
