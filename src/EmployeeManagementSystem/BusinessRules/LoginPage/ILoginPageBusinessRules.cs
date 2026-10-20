using Microsoft.Identity.Client;

namespace BusinessRules.LoginPage {
    public interface ILoginPageBusinessRules {

        ILoginPageReader Reader();
        ILoginPageWriter Writer();
    }

    public interface ILoginPageReader {
        Task<AuthenticationResult> Login(string userName, string password);
    }

    public interface ILoginPageWriter {

    }

    public interface IAccountEntity : IAccountEntityProperties {
        Guid AccountID { get; }
    }   
    public interface IAccountEntityProperties {
        string Username { get; set; }
        string PasswordHash { get; set; }
        Guid EmployeeID { get; set; }
   }
}
