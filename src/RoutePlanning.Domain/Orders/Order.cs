using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Packages;

namespace RoutePlanning.Domain.Orders;

[DebuggerDisplay("{OrderDate}")]
public sealed class Order : Entity<Order>
{
    public Order(string status, float price, DateTime orderDate) 
    {
        Status = status;
        Price = price;
        OrderDate = orderDate;
        //Package = package;
        //FromLocation = fromLocation;
        //ToLocation = toLocation;
    }

    public Order()
    {
        Status = null!;
        Price = 0;
        OrderDate = DateTime.Now;
        //Package = null!;
        //FromLocation = null!;
        //ToLocation = null!;
    }

    public string Status { get; set; }
    public float Price { get; set; }
    public DateTime OrderDate { get; set; }
    //public int FromLocationId { get; set; }
    //public int ToLocationId { get; set; }
    //public Package Package { get; set; }
    //public Location FromLocation { get; set; }
    //public Location ToLocation { get; set; }
}
