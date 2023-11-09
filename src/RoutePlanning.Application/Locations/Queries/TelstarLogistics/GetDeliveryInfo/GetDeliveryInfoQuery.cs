using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Application.Locations.Queries.RouteInfo;

namespace RoutePlanning.Application.Locations.Queries.TelstarLogistics.GetDeliveryInfo;
public sealed record GetDeliveryInfoQuery(RouteInfoInput input) : IQuery<RouteInfoOutput>;
