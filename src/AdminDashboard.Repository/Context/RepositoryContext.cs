using AdminDashboard.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Context;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Payment> Payments { get; set; }
}