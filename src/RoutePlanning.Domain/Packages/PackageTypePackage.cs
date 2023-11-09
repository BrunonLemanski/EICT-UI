using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Packages;

[DebuggerDisplay("{Type} -- {Package}")]
public sealed class PackageTypePackage : Entity<PackageTypePackage>
{
    public PackageTypePackage(PackageType type, Package package)
    {
        Type = type;
        Package = package;
    }

    public PackageTypePackage()
    {
        Type = null!;
        Package = null!;
    }

    public PackageType Type { get; private set; }
    public Package Package { get; private set; }
}
