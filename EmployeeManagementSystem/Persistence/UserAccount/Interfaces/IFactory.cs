using NewHabitTracker.Server.Miscellaneous.Interfaces;

namespace EmployeeManagementSystem.Server.Models.Interfaces {
    public interface IAccountFactory {

        Task<IEnumerable<IAccountRecord>> ReadAccounts();
        Task<IAccountRecord?> ReadAccountById(Guid accountId) =>
            Task.Run(() => ReadAccountsByIds([accountId]).Result.FirstOrDefault());

        Task<IEnumerable<IAccountRecord>> ReadAccountsByIds(IEnumerable<Guid> accountIds);

        Task<OperationResult> Upsert(Guid accountId) => Upsert([accountId]);
        Task<OperationResult> Upsert(IEnumerable<Guid> accountIds);

    }

    public interface IAccountRecord : IAccountRecordProperties {
        Guid AccountID { get; }
    }

    public interface IAccountRecordProperties {
        string Username { get; set; }
        string PasswordHash { get; set; }
        Guid EmployeeID { get; set; }
    }
}