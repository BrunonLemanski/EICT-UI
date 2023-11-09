using Microsoft.EntityFrameworkCore;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database;
public sealed class RoutePlanningDatabaseContext : DbContext
{
    public DbSet<Location> Locations { get; set; }
    public RoutePlanningDatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoutePlanningDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
