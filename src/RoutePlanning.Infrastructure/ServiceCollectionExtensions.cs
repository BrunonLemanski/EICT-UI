using Microsoft.Extensions.DependencyInjection;
using RoutePlanning.Infrastructure.Database;
using Netcompany.Net.DomainDrivenDesign;
using Netcompany.Net.UnitOfWork;
using Netcompany.Net.UnitOfWork.AmbientTransactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RoutePlanning.Infrastructure;
public static class ServiceCollectionExtensions

{
    public static IServiceCollection AddRoutePlanningInfrastructure(this IServiceCollection services, IConfiguration config )
    {
        services.AddDbContext<RoutePlanningDatabaseContext>(builder =>
        {
            builder.UseSqlServer(config.GetConnectionString("Database"));
        });


        services.AddDomainDrivenDesign(options => options.UseDbContext<RoutePlanningDatabaseContext>());
        services.AddUnitOfWork(builder => builder.UseAmbientTransactions().With<RoutePlanningDatabaseContext>());

        return services;
    }
}
