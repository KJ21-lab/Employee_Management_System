using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using NewHabitTracker.Server.Miscellaneous.Interfaces;

namespace Persistence.UserAccount.Implementations {
    public class AccountFactory(IDataAccessor dataAccessor) : IAccountFactory {

        public IAccountRecord Build(
            Action<IAccountRecordProperties> configure) {
            IAccountRecord record = new AccountRecord();
            configure(record);
            return record;
        }

        public Task<IEnumerable<IAccountRecord>> ReadAccountsByIds(IEnumerable<Guid> accountIDs) =>
            Task.Run(() => _read(sqlQuery: @"SELECT * FROM AccountsRecord WHERE TRIM(ACCOUNT_ID) IN(@ACCOUNT_ID)",
                                 parameters: new { AccountIDs = accountIDs }));

        public Task<IEnumerable<IAccountRecord>> ReadAccounts() =>
            Task.Run(() => _read(sqlQuery: @"SELECT * FROM AccountsRecord"));

        public Task<OperationResult> Upsert(Guid accountID) => throw new NotImplementedException();
        public Task<OperationResult> Upsert(IEnumerable<Guid> accountIDs) => throw new NotImplementedException();

        private IEnumerable<IAccountRecord> _read(
            string sqlQuery,
            object? parameters = null) =>
            dataAccessor
                .InternalStorageCaller().QueryExecutor()
                .QueryProcedure<AccountRecord_DbModel>(
                    sqlQuery: sqlQuery,
                    parameters: parameters,
                    connection: dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection())
                .Select(model => new AccountRecord(dbModel: model))
                .ToList();

        private void _execute() {

        }
    }
}