using DataAccess.Implementations;
using DataAccess.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SQLitePCL;

namespace Tests {
   internal class TestDataAccesor {

      public IDataAccessor DataAccessorGenerator() {
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

         return dataAccessor;
      }

   }
}
