using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.OperationResult;

namespace BusinessRules.Employees.Implementations {
   public class EmployeeWriter(IEmployeeFactory employeeFactory) : IEmployeeEntityWriter {

      public Task<OperationResult> Upsert(Action<IEmployeeEntityProperties> config) =>
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
   }
}
