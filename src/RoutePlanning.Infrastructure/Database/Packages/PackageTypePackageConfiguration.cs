using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Packages;

namespace RoutePlanning.Infrastructure.Database.Packages;
public sealed class PackageTypePackageConfiguration : IEntityTypeConfiguration<PackageTypePackage>
{
    public void Configure(EntityTypeBuilder<PackageTypePackage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Package).WithMany();
        
        builder.HasOne(x => x.Type).WithMany();
    }
}
