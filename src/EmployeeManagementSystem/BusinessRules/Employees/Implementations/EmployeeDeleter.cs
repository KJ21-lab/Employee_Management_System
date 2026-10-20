using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.OperationResult;

namespace BusinessRules.Employees.Implementations {
   internal class EmployeeDeleter(IEmployeeFactory employeeFactory) : IEmployeeEntityDeleter {

      public async Task<OperationResult> DeleteEmployees(IEnumerable<Guid> employeeGuids) {
         await employeeFactory
               .DeleteEmployees(employeeGuids);

         return new GlobalOperationResult();
      } 
   }
}

