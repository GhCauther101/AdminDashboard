using AdminDashboard.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Context;

public  class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Client> Clients { get; set; }
}