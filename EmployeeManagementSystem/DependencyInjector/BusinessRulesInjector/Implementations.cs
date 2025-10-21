using BusinessRules.Employees.Implementations;
using BusinessRules.Employees.Interfaces;
using BusinessRules.LoginPage;

using DependencyInjectors.PersistenceInjector;

using Microsoft.Identity.Client;

namespace DependencyInjectors.BusinessRules {
    public class BusinessRulesInjector(IPersistenceFactoriesInjector persistenceFactoriesInjector) : IBusinessRulesInjector {

        public IEmployeeBusinessRules EmployeeBusinessRules() => new EmployeeBusinessRules(persistenceFactoriesInjector.EmployeeFactory());

        public ILoginPageBusinessRules LoginPageBusinessRules() => new LoginPageBusinessRules(persistenceFactoriesInjector.AccountFactory());
    }
}
