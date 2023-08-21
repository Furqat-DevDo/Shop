using Microsoft.EntityFrameworkCore;
using Registration.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Registration.Data;

public class RegDbContext : DbContext
{
    public RegDbContext(DbContextOptions<RegDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging(true);
        //optionsBuilder.LogTo(s =>Console.WriteLine(s));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(u =>
        {
            u.HasQueryFilter(f => f.IsDeleted != true);
        });
    }

}
