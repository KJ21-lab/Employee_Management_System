using BusinessRules.BusinesRules.Employees.Implementations;
using BusinessRules.BusinesRules.Employees.Interfaces;

using DependencyInjectors.PersistenceInjector;

namespace DependencyInjectors.BusinessRules {
    public class BusinessRulesInjector(IPersistenceFactoriesInjector persistenceFactoriesInjector) : IBusinessRulesInjector {

        public IEmployeeBusinessRules EmployeeBusinessRules() => new EmployeeBusinessRules(persistenceFactoriesInjector.EmployeeFactory());
    }
}
