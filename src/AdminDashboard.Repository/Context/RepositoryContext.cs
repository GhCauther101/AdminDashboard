using AdminDashboard.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Context;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Payment>()
            .HasOne(p => p.SourceClient)
            .WithMany(c => c.SentPayments)
            .HasForeignKey(p => p.SourceClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Payment>()
            .HasOne(p => p.DestinationClient)
            .WithMany(c => c.RecievedPayments)
            .HasForeignKey(p => p.DestinationClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Payment> Payments { get; set; }
}