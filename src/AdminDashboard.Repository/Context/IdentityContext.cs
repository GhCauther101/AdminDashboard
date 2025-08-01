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

    public DbSet<Client> Clients { get; set; }
}