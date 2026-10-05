using Dapper;

using DataAccess.Interfaces;

using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataAccess.Implementations {
    internal class QueryExecutor : IQueryExecutor {

        private readonly IDbConnection defaultConnection;

        public async Task<IEnumerable<DatabaseField>> QueryProcedure<DatabaseField>(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "") {
            IEnumerable<DatabaseField> records =
            
            await _executeQueryProcedure<DatabaseField>(
                sqlQuery: sqlQuery,
                parameters: parameters,
                connection:  connection,
                consoleOutput: consoleOutput);
            
            return records.ToList();
        }

        public async Task NonQueryProcedure(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "") =>
            await _executeNonQueryProcedure(
                sqlQuery: sqlQuery,
                parameters: parameters,
                connection: connection,
                consoleOutput: consoleOutput);

        private async Task<IEnumerable<DatabaseFields>> _executeQueryProcedure<DatabaseFields>(
            string sqlQuery,
            IDbConnection connection,
            string consoleOutput,
            object? parameters = null) {
                
            connection ??= defaultConnection;
            IEnumerable<DatabaseFields> databaseRecords;

            using (connection) {
                connection.Open();
                databaseRecords =  await connection.QueryAsync<DatabaseFields>(
                    sql: sqlQuery,
                    param: parameters,
                    commandType: CommandType.Text,
                    commandTimeout: 30);
                connection.Close();
            }

            return databaseRecords;
        }

        private async Task _executeNonQueryProcedure(
            string sqlQuery,
            IDbConnection connection,
            string consoleOutput,
            object? parameters = null) {

            connection ??= defaultConnection;
            using (connection) {
                connection.Open();
                await connection.ExecuteAsync(
                    sql: sqlQuery,
                    param: parameters,
                    commandType: CommandType.Text,
                    commandTimeout: 0);
            }
        }

        public QueryExecutor(IDbConnection defaultConnection) {
            // Register your new type handler here
            SqlMapper.AddTypeHandler(new GuidTypeHandler());

            // Your existing code
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
            this.defaultConnection = defaultConnection;
        }
    }
}
