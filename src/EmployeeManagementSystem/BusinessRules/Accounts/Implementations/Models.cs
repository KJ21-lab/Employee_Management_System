using BusinessRules.LoginPage;

using EmployeeManagementSystem.Server.Models.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Accounts.Implementations {
   public class AccountEntity : IAccountEntity {
      public AccountEntity() { }

      public AccountEntity(IAccountRecord record) {
         AccountID = record.AccountID;
         Username = record.Username;
         PasswordHash = record.PasswordHash;
         EmployeeID = record.EmployeeID;
      }

      public Guid AccountID { get; }
      public string Username { get; set; } = string.Empty;
      public string PasswordHash { get; set; } = string.Empty;
      public Guid EmployeeID { get; set; }
   }
}
