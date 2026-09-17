using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.OperationResult;

namespace BusinessRules.Employees.Implementations {
   public class EmployeeWriter(IEmployeeFactory employeeFactory) : IEmployeeEntityWriter {

      public Task<OperationResult> UpsertEmployee(Action<IEmployeeEntityProperties> config) =>
         Task.Run<OperationResult>(() => {
            try {
               IEmployeeEntityProperties props = new EmployeeEntityProperties();
               config(props);

               IEmployeeRecord record =
                  employeeFactory.Build((configure) => { 
                     configure.Name       = props.Name;
                     configure.JobTitle   = props.JobTitle;
                     configure.HireDate   = props.HireDate;
                     configure.EmployeeID = props.EmployeeID;
                   });

               employeeFactory.Upsert(record);

               return new GlobalOperationResult();
            } catch (Exception ex){
               return new GlobalOperationResult(ex.Message);
            }
         
         });

      public Task<OperationResult> UpsertEmployee(
         Guid employeeUID, 
         Action<IEmployeeEntityProperties> config) =>
         Task.Run<OperationResult>(() => {
            try {
               IEmployeeEntityProperties props = new EmployeeEntityProperties();
               config(props);

               IEmployeeRecord record = 
                  employeeFactory
                  .ReadEmployeeByUID(employeeUID)
                  .Result ?? throw new Exception($"Employee record {employeeUID} was not found.");

               record.EmployeeID = props.EmployeeID;
               record.Name       = props.Name;
               record.JobTitle   = props.JobTitle;
               record.HireDate   = props.HireDate;

               employeeFactory.Upsert(record);

               return new GlobalOperationResult();
            } catch (Exception ex){
               return new GlobalOperationResult(ex.Message);
            }
         });
   }
}
