using Miscellaneous.OperationResult;

namespace BusinessRules.Employees.Interfaces {
    public interface IEmployeeBusinessRules {

        IEmployeeEntityReader Reader();
        IEmployeeEntityWriter Writer();
        IEmployeeEntityDeleter Deleter();
    }

    public interface IEmployeeEntity : IEmployeeEntityProperties  {
        Guid EmployeeUID { get; }   
    }

    public interface IEmployeeEntityProperties {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public int EmployeeID { get; set; }
    }

    public interface IEmployeeEntityReader {
        Task<IEnumerable<IEmployeeEntity>> ReadAll();
        Task<IEnumerable<IEmployeeEntity>> Read(IEnumerable<Guid> employeeUids);
        Task<IEmployeeEntity?> Read(Guid employeeUID) =>
        Task.Run(() => Read([employeeUID]).Result.FirstOrDefault());
    }

    public interface IEmployeeEntityWriter {
      Task<OperationResult> UpsertEmployee(Action<IEmployeeEntityProperties> config);
      Task<OperationResult> UpsertEmployee(Guid employeeUID, 
         Action<IEmployeeEntityProperties> config);
   }

    public interface IEmployeeEntityDeleter {
      Task<OperationResult> DeleteEmployee(Guid employeeGuid) => DeleteEmployees([employeeGuid]);
      Task<OperationResult> DeleteEmployees(IEnumerable<Guid> employeeGuids);
   }
}