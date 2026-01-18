using BusinessRules.Accounts.Interfaces;
using BusinessRules.LoginPage;

using EmployeeManagementSystem.Server.Models.Interfaces;

namespace BusinessRules.Accounts.Implementations {
   public class AccountReader(IAccountFactory accountFactory) : IAccountEntityReader {
      public Task<IEnumerable<IAccountEntity>> ReadAll() =>
            Task.Run(() => {
               IEnumerable<IAccountEntity> entities =
                   accountFactory
                       .ReadAccounts()
                       .Result
                       .Select(r => new AccountEntity(r))
                       .ToList();

               return entities;
            });
   }
}
