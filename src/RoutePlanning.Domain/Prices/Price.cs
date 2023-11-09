
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Prices;
public sealed class Price : Entity<Price>
{
    public Price(DateTime validFrom, DateTime validTo, int rangeFrom, int rangTo, int cost)
    {
        ValidFrom = validFrom;
        ValidTo = validTo;
        RangeFrom = rangeFrom;
        RangeTo = rangTo;
        Cost = cost;
    }

    public Price()
    {
        ValidFrom = DateTime.Now;
        ValidTo = DateTime.Now;
        RangeFrom = 0;
        RangeTo = 0;
        Cost = 0;
    }

    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public int RangeFrom { get; set; }
    public int RangeTo { get; set; }
    public int Cost { get; set; }
}
