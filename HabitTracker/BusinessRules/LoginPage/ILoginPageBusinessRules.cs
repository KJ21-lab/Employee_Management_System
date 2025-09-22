using NewHabitTracker.Server.Miscellaneous.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.LoginPage {
    public interface ILoginPageBusinessRules {

        ILoginPageReader Reader();
        ILoginPageWriter Writer();
    }

    public interface ILoginPageReader {
        Task<OperationResult> Verify();
    }

    public interface ILoginPageWriter {

    }

    public interface IAccountEntity {
        Guid AccountID { get; }
    }   
    public interface IAccountEntityProperties {
        string Username { get; set; }
        string Password { get; set; }
    }   
}
