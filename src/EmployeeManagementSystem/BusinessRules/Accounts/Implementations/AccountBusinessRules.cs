using BusinessRules.Accounts.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

namespace BusinessRules.Accounts.Implementations {
   public class AccountBusinessRules(IAccountFactory accountFactory): IAccountBusinessRules {
      public IAccountEntityReader Reader() => new AccountReader(accountFactory);

      public IAccountEntityWriter Writer() => throw new NotImplementedException();
   }
}
