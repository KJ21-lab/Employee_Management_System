using EmployeeManagementSystem.Server.Models.Interfaces;

namespace BusinessRules.LoginPage {
    // simple DTO used by your business rules
    public sealed record AuthenticationResult(
        bool Succeeded,
        IAccountRecord? Account,
        string? ErrorMessage
    );
}