using EmployeeManagementSystem.Server.Models.Interfaces;

namespace Persistence.Employees.Implementations {
    public class EmployeeRecord : IEmployeeRecord {
        public EmployeeRecord() {
            EmployeeUID = Guid.NewGuid();
        }

        public EmployeeRecord(EmployeeRecord_DbModel dbModel) {
            EmployeeUID = dbModel.EMPLOYEE_UID;
            Name = dbModel.EMPLOYEE_Name;
            JobTitle = dbModel.EMPLOYEE_JobTitle;
            HireDate = dbModel.EMPLOYEE_HireDate;
            EmployeeID = dbModel.EMPLOYEE_ID;
        }

        public Guid EmployeeUID { get; }
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public int EmployeeID { get; set; } = 0;
    }

    public class EmployeeRecord_DbModel {

        public EmployeeRecord_DbModel() { }
        public EmployeeRecord_DbModel(IEmployeeRecord record) {
            EMPLOYEE_UID = record.EmployeeUID;
            EMPLOYEE_Name = record.Name;
            EMPLOYEE_JobTitle = record.JobTitle;
            EMPLOYEE_HireDate = record.HireDate;
            EMPLOYEE_ID = record.EmployeeID;
        }
        public Guid EMPLOYEE_UID { get; set; }
        public string EMPLOYEE_Name { get; set; }
        public string EMPLOYEE_JobTitle { get; set; }
        public DateTime EMPLOYEE_HireDate { get; set; }
        public int EMPLOYEE_ID { get; set; }
    }
}