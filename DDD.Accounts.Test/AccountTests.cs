using DDD.Common.Accounts;
using NUnit.Framework;

namespace DDD.Accounts.Test;

[TestFixture]
public class AccountTests
{
    private static AccountTree _accountTree = null!;

    [SetUp]
    public void SetUp()
    {
        // This is a bit stupid since this builds account tree and throws
        // exception here if it fails.
        _accountTree = TestData.AccountTree;
    }

    [Test]
    public void ShouldReturnRootAccounts()
    {
        Assert.That(_accountTree is not null);
    }

    [Test]
    public void ShouldFindSales1Account()
    {
        var sut = _accountTree.FindAccount(x => x.Number, 3110);
        Assert.That(sut is not null);
        Assert.That(sut!.Number == 3110);
        Assert.That(sut!.Name == "Sales 1");
    }
}
