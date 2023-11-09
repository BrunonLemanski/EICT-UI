using Netcompany.Net.Cqs.Queries;

namespace RoutePlanning.Application.Locations.Queries.AvailableRoutes;
public class AvailableRoutesHandler : IQueryHandler<AvailableRoutesQuery, string[][]>
{
    public Task<string[][]> Handle(AvailableRoutesQuery request, CancellationToken cancellationToken)
    {

        // Retrive routes from database
        throw new NotImplementedException();
    }
}
