using Microsoft.EntityFrameworkCore;
using Registration_user.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Registration_user.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {

    }
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
    }
}
