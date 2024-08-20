namespace DDD.Common.Accounts;

public record Account(AccountId Id, string Name, int Number, Account? Parent, IReadOnlyList<Account> Children);
