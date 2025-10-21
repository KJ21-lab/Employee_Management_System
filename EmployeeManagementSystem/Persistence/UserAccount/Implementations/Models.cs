using EmployeeManagementSystem.Server.Models.Interfaces;

namespace Persistence.UserAccount.Implementations {
    public class AccountRecord : IAccountRecord {
        public AccountRecord() {
            AccountID = Guid.NewGuid();
        }

        public AccountRecord(AccountRecord_DbModel dbModel) {
            AccountID = dbModel.ACCOUNT_ID;
            Username = dbModel.ACCOUNT_Username;
            PasswordHash = dbModel.ACCOUNT_PasswordHash;
            EmployeeID = dbModel.ACCOUNT_EmployeeID;
        }

        public Guid AccountID { get; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid EmployeeID { get; set; }
    }

    public class AccountRecord_DbModel {

        public AccountRecord_DbModel() { }
        public AccountRecord_DbModel(IAccountRecord record) {
            ACCOUNT_ID = record.AccountID;
            ACCOUNT_Username = record.Username;
            ACCOUNT_PasswordHash = record.PasswordHash;
            ACCOUNT_EmployeeID = record.EmployeeID;
        }
        public Guid ACCOUNT_ID { get; set; }
        public string ACCOUNT_Username { get; set; }
        public string ACCOUNT_PasswordHash { get; set; }
        public Guid ACCOUNT_EmployeeID { get; set; }
    }
}