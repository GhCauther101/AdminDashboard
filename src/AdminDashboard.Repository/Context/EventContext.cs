using AdminDashboard.Entity.Event.Base;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Context;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions options) : base(options)
    { }

    public DbSet<EventEntry> TriggerEvents { get; set; }
}