﻿using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;

namespace Shop.Core.Data;

public class RegDbContext : DbContext
{
    public RegDbContext(DbContextOptions<RegDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<VerificationEntity> Verifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.EnableSensitiveDataLogging(true);
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
