using Netcompany.Net.Cqs.Queries;

namespace RoutePlanning.Application.Locations.Queries.RouteInfo;
public sealed record RouteInfoQuery(RouteInfoInput input) : IQuery<RouteInfoOutput>;

