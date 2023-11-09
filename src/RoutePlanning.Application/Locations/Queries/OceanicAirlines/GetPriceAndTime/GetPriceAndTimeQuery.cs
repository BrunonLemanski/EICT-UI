using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Application.Locations.Queries.RouteInfo;

namespace RoutePlanning.Application.Locations.Queries.OceanicAirlines.GetPriceAndTime;
public sealed record GetPriceAndTimeQuery(RouteInfoInput input) : IQuery<RouteInfoOutput>;
