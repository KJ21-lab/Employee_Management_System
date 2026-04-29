namespace BusinessRules.Employees.Interfaces {
    public interface IEmployeeBusinessRules {

        IEmployeeEntityReader Reader();
        IEmployeeEntityWriter Writer();
    }

    public interface IEmployeeEntity : IEmployeeEntityProperties  {
        Guid EmployeeUID { get; }   
    }

    public interface IEmployeeEntityProperties {
        string Name { get; set; }
        string JobTitle { get; set; }
        DateTime HireDate { get; set; }
        int EmployeeID { get; set; }
    }

    public interface IEmployeeEntityReader {
        Task<IEnumerable<IEmployeeEntity>> ReadAll();
        Task<IEnumerable<IEmployeeEntity>> Read(IEnumerable<Guid> employeeUids);
        Task<IEmployeeEntity?> Read(Guid employeeUID) =>
         Task.Run(() => Read([employeeUID]).Result.FirstOrDefault());
    }

    public interface IEmployeeEntityWriter {


    }
}