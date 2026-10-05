using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Persistence.Employees.Implementations;


namespace BusinessRules.Employees.Implementations {
    public class EmployeeReader(IEmployeeFactory employeeFactory) : IEmployeeEntityReader {

       public async Task<IEnumerable<IEmployeeEntity>> ReadAll() {

           IEnumerable<IEmployeeRecord> records =
               await employeeFactory
                     .ReadEmployees();

           return records
                  .Select(e => new EmployeetEntity(e))
                  .ToList();
       }
       public async Task<IEmployeeEntity> Read(Guid employeeUID) {

          IEnumerable<IEmployeeEntity> records = await Read([employeeUID]);
          
          return records.FirstOrDefault();
       }
        
        public async Task<IEnumerable<IEmployeeEntity>> Read(IEnumerable<Guid> employeeUIDs) { 

            IEnumerable<IEmployeeRecord> records =
                 await employeeFactory
                       .ReadEmployeesByUIDs(employeeUIDs);
                 
             return records
                    .Select(e => new EmployeetEntity(e))
                    .ToList();
        }
    }
}
