using BusinessRules.Employees.Implementations;
using BusinessRules.Employees.Interfaces;
using BusinessRules.LoginPage;

using DependencyInjectors.PersistenceInjector;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace DependencyInjectors.BusinessRules {
   public class BusinessRulesInjector(
       IPersistenceFactoriesInjector persistenceFactoriesInjector,
       IPasswordHasher<IAccountRecord> passwordHasher
   ) : IBusinessRulesInjector {

      public IEmployeeBusinessRules EmployeeBusinessRules() => new EmployeeBusinessRules(persistenceFactoriesInjector.EmployeeFactory());

        public ILoginPageBusinessRules LoginPageBusinessRules() => new LoginPageBusinessRules(persistenceFactoriesInjector.AccountFactory(), passwordHasher);
    }
}
