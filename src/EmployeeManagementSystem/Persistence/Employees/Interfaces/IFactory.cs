using Miscellaneous.OperationResult;

namespace EmployeeManagementSystem.Server.Models.Interfaces {
    public interface IEmployeeFactory {

         IEmployeeRecord Build(
            Action<IEmployeeRecordProperties> configure);

        Task<IEnumerable<IEmployeeRecord>> ReadEmployees();
        Task<IEmployeeRecord?> ReadEmployeeByUID(Guid employeeUID);

        Task<IEnumerable<IEmployeeRecord>> ReadEmployeesByUIDs(IEnumerable<Guid> employeeUIDs);

        Task<int> Upsert(IEmployeeRecord record);
        Task<int> DeleteEmployees(IEnumerable<Guid> employeeUIDs);

        Task<bool> Exists(IEnumerable<Guid> employeeUID);
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
