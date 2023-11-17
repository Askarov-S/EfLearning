using EfLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLearning.Data.DbContexts;

public class AppDbContext : DbContext
{
    [Column("users")]
    public DbSet<User> Users { get; set; }
    [Column("roles")]
    public DbSet<Role> Roles { get; set; }
    [Column("products")]
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Host=localhost;Username=postgres;Password=1101jamshid;Port=5432;Database=EfLearning;";
        optionsBuilder.UseNpgsql(connectionString);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the relationship
        modelBuilder.Entity<Product>()
           .HasOne(p => p.User)
           .WithMany(u => u.Products)
           .HasForeignKey(p => p.UserId)
           .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
