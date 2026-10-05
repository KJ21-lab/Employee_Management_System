using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.DBCommands;
using Miscellaneous.OperationResult;

namespace Persistence.UserAccount.Implementations {
    public class AccountFactory(IDataAccessor dataAccessor) : IAccountFactory {

        public IAccountRecord Build(
            Action<IAccountRecordProperties> configure) {
            IAccountRecord record = new AccountRecord();
            configure(record);
            return record;
        }

        public async Task<IEnumerable<IAccountRecord>> ReadAccountsByIds(IEnumerable<Guid> accountIDs) =>
            await _read(sqlQuery: DBCommands.SQLQueries.AccountsQueries.ReadAccountsByIds,
                        parameters: new { AccountIDs = accountIDs });

        public async Task<IEnumerable<IAccountRecord>> ReadAccounts() =>
            await _read(sqlQuery: DBCommands.SQLQueries.AccountsQueries.ReadAccounts);

        public Task<OperationResult> Upsert(Guid accountID) => throw new NotImplementedException();
        public Task<OperationResult> Upsert(IEnumerable<Guid> accountIDs) => throw new NotImplementedException();

        private async Task<IEnumerable<IAccountRecord>> _read(
            string sqlQuery,
            object? parameters = null) {
      
            IEnumerable<AccountRecord_DbModel> model =  
                await dataAccessor
                .InternalStorageCaller().QueryExecutor()
                .QueryProcedure<AccountRecord_DbModel>(
                    sqlQuery: sqlQuery,
                    parameters: parameters,
                    connection: dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection());


            return model
                     .Select(model => new AccountRecord(dbModel: model))
                     .ToList();
        }

        private void _execute() {

        }
    }
}