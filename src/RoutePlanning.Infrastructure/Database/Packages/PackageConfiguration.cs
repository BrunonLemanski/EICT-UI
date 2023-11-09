
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Orders;
using RoutePlanning.Domain.Packages;

namespace RoutePlanning.Infrastructure.Database.Packages;
public sealed class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.PackageTypePackages).WithOne(x => x.Package);

        builder.HasOne(x => x.Order).WithOne(x => x.Package).HasPrincipalKey<Order>(y => y.PackageId);
    }
}
