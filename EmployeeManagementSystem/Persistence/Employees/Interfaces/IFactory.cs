using NewHabitTracker.Server.Miscellaneous.Interfaces;

namespace EmployeeManagementSystem.Server.Models.Interfaces {
    public interface IEmployeeFactory {

        Task<IEnumerable<IEmployeeRecord>> ReadEmployees();
        Task<IEmployeeRecord?> ReadEmployeeByUID(Guid employeeUID) =>
            Task.Run(() => ReadEmployeesByUIDs([employeeUID]).Result.FirstOrDefault());

        Task<IEnumerable<IEmployeeRecord>> ReadEmployeesByUIDs(IEnumerable<Guid> employeeUIDs);

        Task<OperationResult> Upsert(Guid employeeUID) => Upsert([employeeUID]);
        Task<OperationResult> Upsert(IEnumerable<Guid> employeeUIDs);

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
