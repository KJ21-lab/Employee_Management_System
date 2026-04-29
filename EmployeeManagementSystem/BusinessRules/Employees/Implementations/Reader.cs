using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;


namespace BusinessRules.Employees.Implementations {
    public class EmployeeReader(IEmployeeFactory employeeFactory) : IEmployeeEntityReader {

        public Task<IEnumerable<IEmployeeEntity>> ReadAll() => 
            Task.Run(() => {

                IEnumerable<IEmployeeEntity> entities =
                    employeeFactory
                    .ReadEmployees()
                    .Result
                    .Select(e => new EmployeetEntity(e))
                    .ToList();

                return entities;
            });
        
      public Task<IEnumerable<IEmployeeEntity>> Read(IEnumerable<Guid> employeeUIDS) => 
            Task.Run(() => {

                IEnumerable<IEmployeeEntity> entities =
                    employeeFactory
                    .ReadEmployeesByUIDs(employeeUIDS)
                    .Result
                    .Select(e => new EmployeetEntity(e))
                    .ToList();

                return entities;
            });
    }
}
