using DDD.Common.Accounts;
using NUnit.Framework;

namespace DDD.Accounts.Test;

public static class TestData
{
    private class TestAccount : IAccountBase
    {
        public Guid Key { get; set; }

        public Guid? ParentKey { get; set; }

        public int Number { get; set; }

        public string Name { get; set; } = string.Empty;
    }

    public static Guid AssetsAccountGuid = new Guid("307ADFB1-5A1A-427A-9726-9C4EC060DF0F");
    public static Guid LiabilitiesAccountGuid = new Guid("51F0DB19-E6B1-4D62-9FCF-F370473DA6EA");
    public static Guid ProfitAccountGuid = new Guid("2DB75B47-B7E5-4286-9E5E-016DC37A9461");
    public static Guid SalesAccountGuid = new Guid("85ED7ACA-36A1-4DEC-A65B-B6EEB2A8719C");
    public static Guid CommonSalesAccountGuid = new Guid("6E891260-3BC4-4556-8D8F-C66C5E9FB9DA");
    public static Guid Sales1AccountGuid = new Guid("4E625DEF-D867-469C-8318-A7DB3B05C7E5");
    public static Guid Sales2AccountGuid = new Guid("2E272475-122A-449D-ABFE-83B1C94A090E");

    public static IAccountBase[] Assets = [
        new TestAccount { Key = AssetsAccountGuid, Number = 100, Name = "Assets" }
    ];

    public static IAccountBase[] Liabilities = [
        new TestAccount { Key = LiabilitiesAccountGuid, Number = 200, Name = "Liabilities" }
    ];

    public static IAccountBase[] Profits = [
        new TestAccount { Key = ProfitAccountGuid, Number = 300, Name = "Profits" },
        new TestAccount { Key = SalesAccountGuid, Number = 3000, Name = "Sales", ParentKey = ProfitAccountGuid },
        new TestAccount { Key = CommonSalesAccountGuid, Number = 3100, Name = "Common sales", ParentKey = SalesAccountGuid },
        new TestAccount { Key = Sales1AccountGuid, Number = 3110, Name = "Sales 1", ParentKey = CommonSalesAccountGuid },
        new TestAccount { Key = Sales2AccountGuid, Number = 3120, Name = "Sales 2", ParentKey = CommonSalesAccountGuid }
    ];


    /// <summary>
    /// 100 - assets root
    /// 200 - liabilities root
    /// 300 - profit root
    ///  
    /// 1000-1999 - assets
    /// 
    /// 2000-2999 - liabilities
    /// 
    /// 3000-9999 - profit
    /// 
    /// 3000 - sales
    /// 3100 - common sales accounts
    /// 3110 - sales account 1
    /// 3120 - sales account 2
    ///  
    /// 4000 - purchases
    /// </summary>
    public static AccountTree AccountTree
    {
        get
        {
            return new AccountTree(
                new TopLevelAccount(Assets.ToLookup(x => x.ParentKey), Assets[0]),
                new TopLevelAccount(Liabilities.ToLookup(x => x.ParentKey), Liabilities[0]),
                new TopLevelAccount(Profits.ToLookup(x => x.ParentKey), Profits[0])
            );
        }
    }
}
