using NewHabitTracker.Server.Models.Interfaces;

namespace Persistence.Employees.Implementations {
    public class EmployeeRecord : IEmployeeRecord {
        public EmployeeRecord() {
            EmployeeID = Guid.NewGuid();
        }

        public EmployeeRecord(EmployeeRecord_DbModel dbModel) {
            EmployeeID = dbModel.EMPLOYEE_ID;
            Name = dbModel.EMPLOYEE_Name;
            JobTitle = dbModel.EMPLOYEE_JobTitle;
            HireDate = dbModel.EMPLOYEE_HireDate;
        }

        public Guid EmployeeID { get; }
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }

    public class EmployeeRecord_DbModel {

        public EmployeeRecord_DbModel() { }
        public EmployeeRecord_DbModel(IEmployeeRecord record) {
            EMPLOYEE_ID = record.EmployeeID;
            EMPLOYEE_Name = record.Name;
            EMPLOYEE_JobTitle = record.JobTitle;
            EMPLOYEE_HireDate = record.HireDate;
        }
        public Guid EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_Name { get; set; }
        public string EMPLOYEE_JobTitle { get; set; }
        public DateTime EMPLOYEE_HireDate { get; set; }
    }
}