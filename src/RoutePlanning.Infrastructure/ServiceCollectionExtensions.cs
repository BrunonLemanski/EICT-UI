using Microsoft.Extensions.DependencyInjection;
using RoutePlanning.Infrastructure.Database;
using Netcompany.Net.DomainDrivenDesign;
using Netcompany.Net.UnitOfWork;
using Netcompany.Net.UnitOfWork.AmbientTransactions;
using Microsoft.EntityFrameworkCore;

namespace RoutePlanning.Infrastructure;
public static class ServiceCollectionExtensions

{
    public static IServiceCollection AddRoutePlanningInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<RoutePlanningDatabaseContext>(builder =>
        {
            builder.UseSqlServer("Server=tcp:dbs-eit-dk1.database.windows.net;Database=db-eit-dk1;User Id=admin-eit-dk1;Password=Eastindia4thewin;");
        });

        services.AddDomainDrivenDesign(options => options.UseDbContext<RoutePlanningDatabaseContext>());
        services.AddUnitOfWork(builder => builder.UseAmbientTransactions().With<RoutePlanningDatabaseContext>());

        return services;
    }
}
