using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Client.Web.Authorization;
using RoutePlanning.Application.Locations.Queries.RouteInfo;
using RoutePlanning.Application.Locations.Queries.AvailableRoutes;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(nameof(TokenRequirement))]
[AllowAnonymous]
public sealed class RoutesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoutesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public Task<RouteInfoOutput> RouteInfo(RouteInfoInput input) 
    {
        return _mediator.Send(new RouteInfoQuery(input));
    }

    [HttpGet("[action]")]
    public Task AvailableRoutes()
    {
        return _mediator.Send(new AvailableRoutesQuery());
    }

    [HttpPost("[action]")]
    public async Task AddTwoWayConnection(CreateTwoWayConnectionCommand command)
    {
        await _mediator.Send(command);
    }
}
