namespace BusinessRules.Employees.Interfaces {
    public interface IEmployeeBusinessRules {

        IEmployeeEntityReader Reader();
        IEmployeeEntityWriter Writer();
    }

    public interface IEmployeeEntity : IEmployeeEntityProperties  {
        Guid EmployeeID { get; }   
    }

    public interface IEmployeeEntityProperties {
        string Name { get; set; }
        string JobTitle { get; set; }
        DateTime HireDate { get; set; }
    }

    public interface IEmployeeEntityReader {
        Task<IEnumerable<IEmployeeEntity>> ReadAll();

    }

    public interface IEmployeeEntityWriter {


    }
}