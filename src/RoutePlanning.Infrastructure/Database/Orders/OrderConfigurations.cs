using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Orders;
using RoutePlanning.Domain.Packages;

namespace RoutePlanning.Infrastructure.Database.Orders;
public sealed class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Package).WithOne(x => x.Order).HasPrincipalKey<Package>(y => y.OrderId);

        builder.HasOne(x => x.FromLocation).WithMany();

        builder.HasOne(x => x.ToLocation).WithMany();
    }
}
