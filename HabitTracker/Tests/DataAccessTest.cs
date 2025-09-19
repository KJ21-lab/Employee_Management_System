using DataAccess.Implementations;
using DataAccess.Interfaces;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NewHabitTracker.Server.Models.Interfaces;

using Persistence.Employees.Implementations;

using SQLitePCL;

public class DataAccessTest {
    [Fact]
    public async Task Test1() {
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

        var factory = new EmployeeFactory(dataAccessor);

        IEnumerable<IEmployeeRecord> records =
          await factory
            //.ReadHabits();
          .ReadEmployeesByIds([Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA")]);

        Console.WriteLine(records);
    }
}