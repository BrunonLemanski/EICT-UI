using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Application.Locations.Queries.RouteInfo;

namespace RoutePlanning.Application.Locations.Queries.TelstarLogistics.GetDeliveryInfo;
public class GetDeliveryInfoQueryHandler : IQueryHandler<GetDeliveryInfoQuery, RouteInfoOutput>
{

    private readonly HttpClient _client = new HttpClient();

    public async Task<RouteInfoOutput> Handle(GetDeliveryInfoQuery request, CancellationToken cancellationToken)
    {
        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://wa-tl-dk1.azurewebsites.net/api/Routes/GetDeliveryInfo"),
            Content = new StringContent(JsonSerializer.Serialize(request.input), Encoding.UTF8, MediaTypeNames.Application.Json)
        };

        var response = await _client.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        var result = await response.Content.ReadFromJsonAsync<RouteInfoOutput>().ConfigureAwait(false);

        if (result == null)
        {
            result = new RouteInfoOutput() { Price = -2f, Time = -2 };
        }

        return result;
    }
}
