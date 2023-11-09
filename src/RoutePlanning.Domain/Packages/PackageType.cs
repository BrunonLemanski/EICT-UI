using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Packages;

[DebuggerDisplay("{Type}")]
public sealed class PackageType : Entity<PackageType>
{
    public PackageType(string type, float fee) 
    {
        Type = type;
        Fee = fee;
    }

    public string Type { get; set; }
    public float Fee { get; set; }

    private readonly List<PackageTypePackage> _packageTypePackages = new();

    public IReadOnlyCollection<PackageTypePackage> PackageTypePackages => _packageTypePackages.AsReadOnly();

}
