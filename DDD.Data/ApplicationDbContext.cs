using DDD.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<DocumentValue> DocumentValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
