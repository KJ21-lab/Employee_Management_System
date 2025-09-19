using BusinessRules.BusinesRules.Employees.Interfaces;

using NewHabitTracker.Server.Models.Interfaces;

namespace BusinessRules.BusinesRules.Employees.Implementations {
    public class EmployeetEntity : IEmployeeEntity {
        public EmployeetEntity() { }

        public EmployeetEntity(IEmployeeRecord record) {
            EmployeeID = record.EmployeeID;
            Name = record.Name;
            JobTitle = record.JobTitle;
            HireDate = record.HireDate;
        }

        public Guid EmployeeID { get; }
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }
}