using BusinessRules.Accounts.Interfaces;
using BusinessRules.LoginPage;

using EmployeeManagementSystem.Server.Models.Interfaces;

namespace BusinessRules.Accounts.Implementations {
   public class AccountReader(IAccountFactory accountFactory) : IAccountEntityReader {
      public async Task<IEnumerable<IAccountEntity>> ReadAll() {
         IEnumerable<IAccountRecord> accounts =
             await accountFactory
                 .ReadAccounts();

         return accounts
               .Select(r => new AccountEntity(r))
               .ToList(); ;
      }
   }
}
