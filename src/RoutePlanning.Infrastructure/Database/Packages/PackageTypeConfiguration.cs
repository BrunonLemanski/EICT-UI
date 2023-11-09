using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Packages;

namespace RoutePlanning.Infrastructure.Database.Packages;
public sealed class PackageTypeConfiguration : IEntityTypeConfiguration<PackageType>
{
    public void Configure(EntityTypeBuilder<PackageType> builder)
    {
        builder.HasKey(x=> x.Id);

        builder.HasMany(x => x.PackageTypePackages).WithOne(x => x.Type);
    }
}
