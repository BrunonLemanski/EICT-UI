using Netcompany.Net.UnitOfWork;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Prices;
using RoutePlanning.Domain.Users;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Client.Web;

public static class DatabaseInitialization
{
    public static async Task SeedDatabase(WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();

        var context = serviceScope.ServiceProvider.GetRequiredService<RoutePlanningDatabaseContext>();
        await context.Database.EnsureCreatedAsync();

        var unitOfWorkManager = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
        await using (var unitOfWork = unitOfWorkManager.Initiate())
        {
            //await SeedUsers(context);
            //await SeedLocationsAndRoutes(context);
            //await SeedPrices(context);

            //unitOfWork.Commit();
        }
    }

    private static async Task SeedPrices(RoutePlanningDatabaseContext context)
    {
        var row1 = new Price(DateTime.Parse("2022-11-01T00:00:00"), DateTime.Parse("2023-04-30T23:59:59"), 0, 10, 8);
        await context.AddAsync(row1);

        var row2 = new Price(DateTime.Parse("2022-11-01T00:00:00"), DateTime.Parse("2023-04-30T23:59:59"), 10, 50, 8);
        await context.AddAsync(row2);

        var row3 = new Price(DateTime.Parse("2022-11-01T00:00:00"), DateTime.Parse("2023-04-30T23:59:59"), 50, 1000, 8);
        await context.AddAsync(row3);

        var row4 = new Price(DateTime.Parse("2022-05-01T00:00:00"), DateTime.Parse("2023-10-31T23:59:59"), 0, 10, 5);
        await context.AddAsync(row4);

        var row5 = new Price(DateTime.Parse("2022-05-01T00:00:00"), DateTime.Parse("2023-10-31T23:59:59"), 10, 50, 5);
        await context.AddAsync(row5);

        var row6 = new Price(DateTime.Parse("2022-05-01T00:00:00"), DateTime.Parse("2023-10-31T23:59:59"), 50, 1000, 5);
        await context.AddAsync(row6);
    }

    private static async Task SeedLocationsAndRoutes(RoutePlanningDatabaseContext context)
    {

        var KANARISKE = new Location("DE KANARISKE ØER");
        await context.AddAsync(KANARISKE);

        var DAKAR = new Location("DAKAR");
        await context.AddAsync(DAKAR);

        var SIERRA = new Location("SIERRA LEONE");
        await context.AddAsync(SIERRA);

        var HELENA = new Location("ST. HELENA");
        await context.AddAsync(HELENA);

        var GULD = new Location("GULD KYSTEN");
        await context.AddAsync(GULD);

        var SLAVE = new Location("SLAVE KYSTEN");
        await context.AddAsync(SLAVE);

        var HVALBUGTEN = new Location("HVALBUGTEN");
        await context.AddAsync(HVALBUGTEN);

        var KAPSTADEN = new Location("KAPSTADEN");
        await context.AddAsync(KAPSTADEN);

        var MARIE = new Location("KAP ST. MARIE");
        await context.AddAsync(MARIE);

        var MOCAMBIQUE = new Location("MOCAMBIQUE");
        await context.AddAsync(MOCAMBIQUE);

        var GUARDAFUI = new Location("KAP GUARDAFUI");
        await context.AddAsync(GUARDAFUI);

        var AMATAVE = new Location("AMATAVE");
        await context.AddAsync(AMATAVE);

        var SUAKIN = new Location("SUAKIN");
        await context.AddAsync(SUAKIN);

        var CAIRO = new Location("CAIRO");
        await context.AddAsync(CAIRO);

        var TUNIS = new Location("TUNIS");
        await context.AddAsync(TUNIS);

        var TANGER = new Location("TANGER");
        await context.AddAsync(TANGER);

        CreateTwoWayConnection(KANARISKE, DAKAR, 5);
        CreateTwoWayConnection(KANARISKE, TANGER, 3);
        CreateTwoWayConnection(DAKAR, KANARISKE, 5);
        CreateTwoWayConnection(DAKAR, SIERRA, 3);
        CreateTwoWayConnection(DAKAR, HELENA, 10);
        CreateTwoWayConnection(SIERRA, DAKAR, 3);
        CreateTwoWayConnection(SIERRA, GULD, 4);
        CreateTwoWayConnection(SIERRA, HELENA, 4);
        CreateTwoWayConnection(HELENA, SIERRA, 11);
        CreateTwoWayConnection(HELENA, DAKAR, 10);
        CreateTwoWayConnection(HELENA, HVALBUGTEN, 10);
        CreateTwoWayConnection(HELENA, KAPSTADEN, 9);
        CreateTwoWayConnection(GULD, SIERRA, 4);
        CreateTwoWayConnection(GULD, SLAVE, 4);
        CreateTwoWayConnection(GULD, HVALBUGTEN, 11);
        CreateTwoWayConnection(SLAVE, GULD, 4);
        CreateTwoWayConnection(SLAVE, HVALBUGTEN, 9);
        CreateTwoWayConnection(HVALBUGTEN, SLAVE, 9);
        CreateTwoWayConnection(HVALBUGTEN, GULD, 11);
        CreateTwoWayConnection(HVALBUGTEN, HELENA, 10);
        CreateTwoWayConnection(HVALBUGTEN, KAPSTADEN, 3);
        CreateTwoWayConnection(KAPSTADEN, HELENA, 9);
        CreateTwoWayConnection(KAPSTADEN, HVALBUGTEN, 3);
        CreateTwoWayConnection(KAPSTADEN, MARIE, 8);
        CreateTwoWayConnection(MARIE, KAPSTADEN, 8);
        CreateTwoWayConnection(MARIE, MOCAMBIQUE, 3);
        CreateTwoWayConnection(MOCAMBIQUE, MARIE, 3);
        CreateTwoWayConnection(MOCAMBIQUE, GUARDAFUI, 8);
        CreateTwoWayConnection(GUARDAFUI, MOCAMBIQUE, 8);
        CreateTwoWayConnection(GUARDAFUI, AMATAVE, 8);
        CreateTwoWayConnection(GUARDAFUI, SUAKIN, 4);
        CreateTwoWayConnection(AMATAVE, GUARDAFUI, 8);
        CreateTwoWayConnection(SUAKIN, GUARDAFUI, 4);
        CreateTwoWayConnection(SUAKIN, CAIRO, 4);
        CreateTwoWayConnection(CAIRO, SUAKIN, 4);
        CreateTwoWayConnection(CAIRO, TUNIS, 5);
        CreateTwoWayConnection(TUNIS, CAIRO, 5);
        CreateTwoWayConnection(TUNIS, TANGER, 3);
        CreateTwoWayConnection(TANGER, TUNIS, 3);
        CreateTwoWayConnection(TANGER, KANARISKE, 3);

    }

    private static async Task SeedUsers(RoutePlanningDatabaseContext context)
    {
        var alice = new User("alice", User.ComputePasswordHash("alice123!"));
        await context.AddAsync(alice);

        var bob = new User("bob", User.ComputePasswordHash("!CapableStudentCries25"));
        await context.AddAsync(bob);
    }

    private static void CreateTwoWayConnection(Location locationA, Location locationB, int distance)
    {
        locationA.AddConnection(locationB, distance);
        locationB.AddConnection(locationA, distance);
    }
}
