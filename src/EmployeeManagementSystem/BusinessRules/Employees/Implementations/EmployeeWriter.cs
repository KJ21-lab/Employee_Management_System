using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.OperationResult;

namespace BusinessRules.Employees.Implementations {
   public class EmployeeWriter(IEmployeeFactory employeeFactory) : IEmployeeEntityWriter {

      public async Task<OperationResult> UpsertEmployee(Action<IEmployeeEntityProperties> config) {
            IEmployeeEntityProperties props = new EmployeeEntityProperties();
            config(props);
         
            IEmployeeRecord record =
               employeeFactory.Build((configure) => { 
                  configure.Name       = props.Name;
                  configure.JobTitle   = props.JobTitle;
                  configure.HireDate   = props.HireDate;
                  configure.EmployeeID = props.EmployeeID;
                });
         
            await employeeFactory.Upsert(record);
         
            return new GlobalOperationResult();
      } 

      public async Task<OperationResult> UpsertEmployee(
         Guid employeeUID, 
         Action<IEmployeeEntityProperties> config) { 
            IEmployeeEntityProperties props = new EmployeeEntityProperties();
            config(props);

            IEmployeeRecord? record = 
               await employeeFactory
               .ReadEmployeeByUID(employeeUID);
               
            if(record is null)
               return new GlobalOperationResult($"Employee record was not found.", ResultTypes.NotFound);

            record.EmployeeID = props.EmployeeID;
            record.Name       = props.Name;
            record.JobTitle   = props.JobTitle;
            record.HireDate   = props.HireDate;

            await employeeFactory.Upsert(record);

            return new GlobalOperationResult();
      }
   }
}
