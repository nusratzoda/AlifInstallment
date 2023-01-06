using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Context;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //CourseAssignment Many to Many Course/Instructor
        modelBuilder.Entity<Order>()
            .HasOne(c => c.Customer)
            .WithMany(o => o.Orders)
            .HasForeignKey(ci => ci.CustomerId);

        modelBuilder.Entity<Order>()
            .HasOne(i => i.Installment)
            .WithMany(o => o.Orders)
            .HasForeignKey(ii => ii.InstallmentId);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; } //Many to Many
    public DbSet<Installment> Installments { get; set; }
    public DbSet<Product> Products { get; set; }
}