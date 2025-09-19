using NewHabitTracker.Server.Miscellaneous.Interfaces;

namespace NewHabitTracker.Server.Models.Interfaces {
    public interface IEmployeeFactory {

        Task<IEnumerable<IEmployeeRecord>> ReadEmployees();
        Task<IEmployeeRecord?> ReadEmployeeById(Guid employeeId) =>
            Task.Run(() => ReadEmployeesByIds([employeeId]).Result.FirstOrDefault());

        Task<IEnumerable<IEmployeeRecord>> ReadEmployeesByIds(IEnumerable<Guid> habitIDs);

        Task<OperationResult> Upsert(Guid employeeId) => Upsert([employeeId]);
        Task<OperationResult> Upsert(IEnumerable<Guid> employeeIds);

    }

    public interface IEmployeeRecord : IEmployeeRecordProperties {
        Guid EmployeeID { get; }
    }

    public interface IEmployeeRecordProperties {
        string Name { get; set; }
        string JobTitle { get; set; }
        DateTime HireDate { get; set; }
    }
}
