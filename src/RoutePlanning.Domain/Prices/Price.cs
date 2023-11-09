
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Prices;
public sealed class Price : Entity<Price>
{
    public Price()
    {
        Vali
    }

    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public int RangeFrom { get; set; }
    public int RangeTo { get; set; }
    public int Cost { get; set; }
}
