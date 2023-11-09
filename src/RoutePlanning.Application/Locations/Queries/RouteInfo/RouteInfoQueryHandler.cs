using Netcompany.Net.Cqs.Queries;

namespace RoutePlanning.Application.Locations.Queries.RouteInfo;

public class RouteInfoQueryHandler : IQueryHandler<RouteInfoQuery, RouteInfoOutput>
{
    private readonly string[] _rejectedTypes = { "Recorded Delivery", "Cautious parcels" };
    private readonly float _wieghtLimit = 100f;

    public Task<RouteInfoOutput> Handle(RouteInfoQuery request, CancellationToken cancellationToken)
    {

        var result = new RouteInfoOutput();
        var input = request.input;

        if (!ValidatePackage(input))
        {
            return Task.FromResult(result);
        }

        // TODO: Calculate duration and price
        return Task.FromResult(result);

    }

    private bool ValidatePackage(RouteInfoInput input)
    {
        return input != null
            && ValidateWeight(input.Weight)
            && ValidateTypes(input.Types)
            && ValidateRoute(input.From, input.To);
    }

    private bool ValidateRoute(string from, string to)
    {

        // TODO: Check in database if the route exists.
        throw new NotImplementedException();
    }

    private bool ValidateTypes(string[] types)
    {
        foreach (var type in types)
        {
            if (_rejectedTypes.Contains(type))
            {
                return false;
            }
        }

        return true;
    }

    private bool ValidateWeight(float weight)
    {
        return weight <= _wieghtLimit;
    }
}
