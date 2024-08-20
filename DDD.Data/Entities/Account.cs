using DDD.Common.Accounts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DDD.Data.Entities;

[Index("Number", IsUnique = true)] // single tenant db :)
public class Account : IAccountBase
{
    [Key]
    public Guid Key { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? ParentKey { get; set; }
}
