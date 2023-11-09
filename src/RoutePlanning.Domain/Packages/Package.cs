using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Domain.Packages;

[DebuggerDisplay("{Length}")]
public sealed class Package : Entity<Package>
{

    private readonly List<string> _rejectedTypes = new() { "Recorded Delivery", "Cautious Parcel" };
    private readonly float _weightLimit = 100f;
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

    public bool ValidatePackage()
    {
        return ValidateWeight(Weight)
            && ValidateTypes(PackageTypePackages);
    }

    private bool ValidateTypes(IReadOnlyCollection<PackageTypePackage> types)
    {
        foreach (var packageTypePackage in types)
        {
            if (_rejectedTypes.Contains(packageTypePackage.Type.Type))
            {
                return false;
            }
        }

        return true;
    }

    private bool ValidateWeight(float weight)
    {
        return weight <= _weightLimit;
    }
}
