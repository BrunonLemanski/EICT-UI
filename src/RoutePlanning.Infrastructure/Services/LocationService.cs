
using Microsoft.EntityFrameworkCore;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Infrastructure.Services;
public class LocationService
{
    private readonly RoutePlanningDatabaseContext _context;

    public LocationService(RoutePlanningDatabaseContext context)
    {
        _context = context;
    }    

    public async Task<List<Location>> GetLocationsAsync()
    {
        return await _context.Locations.ToListAsync();
    }
}
