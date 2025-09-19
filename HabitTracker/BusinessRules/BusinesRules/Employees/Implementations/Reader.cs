using BusinessRules.BusinesRules.Employees.Interfaces;

using NewHabitTracker.Server.Models.Interfaces;

namespace BusinessRules.BusinesRules.Employees.Implementations {
    public class EmployeeReader(IEmployeeFactory employeeFactory) : IEmployeeEntityReader {


        public Task<IEnumerable<IEmployeeEntity>> ReadAll() => 
            Task.Run(() => {

                IEnumerable<IEmployeeEntity> entities =
                    employeeFactory
                    .ReadEmployees()
                    .Result
                    .Select(h => new EmployeetEntity(h))
                    .ToList();

                return entities;
            });

        
    }
}
