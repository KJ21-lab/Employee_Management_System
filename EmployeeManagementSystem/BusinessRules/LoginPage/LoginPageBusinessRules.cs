using EmployeeManagementSystem.Server.Models.Interfaces;

using Microsoft.Identity.Client;

using Persistence.UserAccount.Implementations;

namespace BusinessRules.LoginPage {
    public class LoginPageBusinessRules(IAccountFactory accountFactory) : ILoginPageBusinessRules {
        public ILoginPageReader Reader() => new LoginPageReader(accountFactory);
        public ILoginPageWriter Writer() => throw new NotImplementedException();
    }

    public class LoginPageReader(IAccountFactory accountFactory) : ILoginPageReader {

        public Task<AuthenticationResult> Login(string userName, string password) =>
             Task.Run(() => {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrEmpty(password))
                    return new AuthenticationResult(false, null, "Invalid credentials.");

                // TODO: add ReadAccountByUsername to IAccountFactory to avoid loading all accounts.
                var accounts = accountFactory.ReadAccounts();
                var account = accounts.FirstOrDefault(a => a.Username.Equals(userName, StringComparison.OrdinalIgnoreCase));
                if (account == null) return new AuthenticationResult(false, null, "Invalid credentials.");

                var verification = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, password);
                if (verification == PasswordVerificationResult.Failed)
                    return new AuthenticationResult(false, null, "Invalid credentials.");

                // success (SuccessRehashNeeded treated as success here)
                return new AuthenticationResult(true, account, null);
            });
    }
}
