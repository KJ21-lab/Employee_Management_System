using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Miscellaneous.Implementations;
using EmployeeManagementSystem.Server.Miscellaneous.Interfaces;
using EmployeeManagementSystem.Server.Models.Interfaces;

namespace BusinessRules.Employees.Implementations {
   public class EmployeeWriter(IEmployeeFactory employeeFactory) : IEmployeeEntityWriter {

      public Task<OperationResult> Upsert(IEmployeeEntity entity) =>
         Task.Run<OperationResult>(() => {
            try {
               IEmployeeRecord record =
                  employeeFactory.Build((configure) => { 
                     configure.Name       = entity.Name;
                     configure.JobTitle   = entity.JobTitle;
                     configure.HireDate   = entity.HireDate;
                     configure.EmployeeID = entity.EmployeeID;
                   });

               employeeFactory.Upsert(record);

               return new GlobalOperationResult();

            } catch (Exception ex){
               return new GlobalOperationResult(ex.Message);
            }
         
         });
   }
}
