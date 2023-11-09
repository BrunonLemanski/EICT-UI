using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Infrastructure.Services;

namespace RoutePlanning.Infrastructure.Api;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public sealed class LocationController : ControllerBase
{
    private readonly LocationService _locationService;

    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public Task<List<Location>> GetAllLocations()
    {
        return _locationService.GetLocationsAsync();
    }

}
