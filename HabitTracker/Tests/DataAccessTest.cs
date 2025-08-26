using DataAccess.Implementations;
using DataAccess.Interfaces;

using Factory;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NewHabitTracker.Server.Models.Interfaces;

using SQLitePCL;

using System.IO;

using Xunit; // Assuming you are using XUnit

public class DataAccessTest {
    [Fact]
    public async Task Test1() { // Use async Task for async methods
        Batteries.Init();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();

        // Register all services, from lowest to highest level dependency.
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<DataAcessConfigSettings>();

        // This is where you register all the services
        services.AddSingleton<IDataAccessor, DataAccessor>();

        // Build the service provider.
        var serviceProvider = services.BuildServiceProvider();

        var dataAccessor = serviceProvider.GetRequiredService<IDataAccessor>();

        var factory = new HabitFactory(dataAccessor);

        IEnumerable<IHabitRecord> records =
          await factory
          .ReadHabits();



        Console.WriteLine(records);
    }
}