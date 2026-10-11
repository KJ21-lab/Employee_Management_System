using DataAccess.Implementations;
using DataAccess.Interfaces;

using DependencyInjectors;
using DependencyInjectors.BusinessRules;
using DependencyInjectors.PersistenceInjector;

namespace EmployeeMangementSystem.Server {
   public static class DependencyInjections {

      public static void AddAllDependencies(this IServiceCollection service) {
         
         service.AddSingleton<DataAcessConfigSettings>();
         service.AddSingleton<IPersistenceFactoriesInjector, PersistenceFactoriesInjector>();
         service.AddSingleton<IBusinessRulesInjector, BusinessRulesInjector>();
         service.AddSingleton<IInternalStorageCaller, InternalStorageCaller>();

      }
   }
}
