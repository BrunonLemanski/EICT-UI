using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Infrastructure.Database.Orders;
public sealed class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Package).WithOne(x => x.Order);

        //builder.HasOne(x => x.FromLocation).WithMany().HasForeignKey(x => x.FromLocationId);

        //builder.HasOne(x => x.ToLocation).WithMany().HasForeignKey(y => y.ToLocationId);
    }
}
