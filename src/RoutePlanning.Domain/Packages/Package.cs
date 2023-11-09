using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Domain.Packages;

[DebuggerDisplay("{Length}")]
public sealed class Package : Entity<Package>
{
    public Package(int length, int width, int height, float weight, Order order) 
    {
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
        Order = order;
    }

    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public float Weight { get; set; }

    public Order Order { get; set; }

    private readonly List<PackageTypePackage> _packageTypePackages = new();

    public IReadOnlyCollection<PackageTypePackage> PackageTypePackages => _packageTypePackages.AsReadOnly();
}
