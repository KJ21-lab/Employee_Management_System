using BusinessRules.Accounts.Interfaces;
using BusinessRules.Employees.Interfaces;
using BusinessRules.LoginPage;

namespace DependencyInjectors {
    public interface IBusinessRulesInjector {

        IEmployeeBusinessRules EmployeeBusinessRules();
        ILoginPageBusinessRules LoginPageBusinessRules();
        IAccountBusinessRules AccountBusinessRules();
    }
}