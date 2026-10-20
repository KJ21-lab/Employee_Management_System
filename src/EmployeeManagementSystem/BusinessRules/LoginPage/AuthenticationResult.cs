using EmployeeManagementSystem.Server.Models.Interfaces;

namespace BusinessRules.LoginPage {
    public sealed record AuthenticationResult(
        bool Succeeded,
        IAccountRecord? Account,
        string? ErrorMessage
    );
}