using BusinessRules.Employees.Interfaces;

namespace DependencyInjectors {
    public interface IBusinessRulesInjector {

        IEmployeeBusinessRules EmployeeBusinessRules();
    }
}