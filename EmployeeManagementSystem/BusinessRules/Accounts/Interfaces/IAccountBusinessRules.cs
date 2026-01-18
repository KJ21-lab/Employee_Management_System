using BusinessRules.LoginPage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Accounts.Interfaces {
   public interface IAccountBusinessRules {
      IAccountEntityReader Reader();
      IAccountEntityWriter Writer();
   }

   public interface IAccountEntityReader {
      Task<IEnumerable<IAccountEntity>> ReadAll();
   }

   public interface IAccountEntityWriter {

   }
}
