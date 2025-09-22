using BusinessRules.Employees.Implementations;
using BusinessRules.Employees.Interfaces;

using DependencyInjectors.PersistenceInjector;

namespace DependencyInjectors.BusinessRules {
    public class BusinessRulesInjector(IPersistenceFactoriesInjector persistenceFactoriesInjector) : IBusinessRulesInjector {

        public IEmployeeBusinessRules EmployeeBusinessRules() => new EmployeeBusinessRules(persistenceFactoriesInjector.EmployeeFactory());
    }
}
