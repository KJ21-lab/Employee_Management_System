using Miscellaneous.OperationResult;

namespace EmployeeManagementSystem.Server.Models.Interfaces {
    public interface IEmployeeFactory {

      public IEmployeeRecord Build(
         Action<IEmployeeRecordProperties> configure);

        Task<IEnumerable<IEmployeeRecord>> ReadEmployees();
        Task<IEmployeeRecord?> ReadEmployeeByUID(Guid employeeUID) =>
            Task.Run(() => ReadEmployeesByUIDs([employeeUID]).Result.FirstOrDefault());

        Task<IEnumerable<IEmployeeRecord>> ReadEmployeesByUIDs(IEnumerable<Guid> employeeUIDs);

        Task<OperationResult> Upsert(IEmployeeRecord record);
        Task<OperationResult> DeleteEmployee(Guid employeeUID) => DeleteEmployees([employeeUID]);
        Task<OperationResult> DeleteEmployees(IEnumerable<Guid> employeeUIDs);
    }

   public interface IEmployeeRecord : IEmployeeRecordProperties {
        Guid EmployeeUID { get; }
    }

    public interface IEmployeeRecordProperties {
       string Name { get; set; }
       string JobTitle { get; set; }
       DateTime HireDate { get; set; }
       int EmployeeID { get; set; }
   }
}
