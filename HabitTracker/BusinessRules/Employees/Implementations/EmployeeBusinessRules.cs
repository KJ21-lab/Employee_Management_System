using BusinessRules.BusinesRules.Employees.Implementations;
using BusinessRules.Employees.Interfaces;

using NewHabitTracker.Server.Models.Interfaces;

namespace BusinessRules.Employees.Implementations {
    public class EmployeeBusinessRules(IEmployeeFactory employeeFactory) : IEmployeeBusinessRules {

        public IEmployeeEntityReader Reader() => new EmployeeReader(employeeFactory);
        public IEmployeeEntityWriter Writer() => throw new NotImplementedException();
    }
}
