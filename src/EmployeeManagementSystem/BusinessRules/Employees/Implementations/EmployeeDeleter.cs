using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.OperationResult;

namespace BusinessRules.Employees.Implementations {
   internal class EmployeeDeleter(IEmployeeFactory employeeFactory) : IEmployeeEntityDeleter {

      public async Task<OperationResult> DeleteEmployees(IEnumerable<Guid> employeeGuids) {

         bool employeesExists = await employeeFactory.Exists(employeeGuids);

         if(employeesExists)
            await employeeFactory
                  .DeleteEmployees(employeeGuids);
         else
            return new GlobalOperationResult("Employee record was not found", ResultTypes.NotFound);

         return new GlobalOperationResult();
      } 
   }
}

