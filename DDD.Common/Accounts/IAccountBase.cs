namespace DDD.Common.Accounts;

public interface IAccountBase
{
    public Guid Key { get; }
    public Guid? ParentKey { get; }
    public int Number { get; }
    public string Name { get; }
}