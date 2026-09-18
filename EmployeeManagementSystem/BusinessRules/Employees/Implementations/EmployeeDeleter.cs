using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.OperationResult;

namespace BusinessRules.Employees.Implementations {
   internal class EmployeeDeleter(IEmployeeFactory employeeFactory) : IEmployeeEntityDeleter {

      public Task<OperationResult> DeleteEmployees(IEnumerable<Guid> employeeGuids) => 
         Task.Run<OperationResult>(() => {
            try {

               employeeFactory.
               DeleteEmployees(employeeGuids);

               return new GlobalOperationResult();
            } catch (Exception ex) { 
               return new GlobalOperationResult($"Failed to delete employee {ex.Message}");
            }
         });
   }
}
