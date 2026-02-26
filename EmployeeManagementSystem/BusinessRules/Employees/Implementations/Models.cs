using BusinessRules.Employees.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

namespace BusinessRules.Employees.Implementations {
    public class EmployeetEntity : IEmployeeEntity {
        public EmployeetEntity() { }

        public EmployeetEntity(IEmployeeRecord record) {
            EmployeeUID = record.EmployeeUID;
            Name = record.Name;
            JobTitle = record.JobTitle;
            HireDate = record.HireDate;
            EmployeeID = record.EmployeeID;
        }

        public Guid EmployeeUID { get; }
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public int EmployeeID { get; set; } = 0;
    }
}