using BusinessRules.BusinesRules.Employees.Interfaces;

namespace DependencyInjectors {
    public interface IBusinessRulesInjector {

        IEmployeeBusinessRules EmployeeBusinessRules();
    }
}