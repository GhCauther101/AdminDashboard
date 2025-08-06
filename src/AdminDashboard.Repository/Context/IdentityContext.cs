using AdminDashboard.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Context;

public class IdentityContext : IdentityDbContext<Client>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Payment>()
            .HasOne(p => p.SourceClient)
            .WithMany(c => c.SentPayments)
            .HasForeignKey(p => p.SourceClientId)
            .IsRequired();

        builder.Entity<Payment>()
            .HasOne(p => p.DestinationClient)
            .WithMany(c => c.RecievedPayments)
            .HasForeignKey(p => p.DestinationClientId)
            .IsRequired();

        base.OnModelCreating(builder);
    }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Payment> Payments { get; set; }
}