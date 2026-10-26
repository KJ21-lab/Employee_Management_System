using Dapper;

using DataAccess.Interfaces;

using System.Data;
using System.Diagnostics;

namespace DataAccess.Implementations {
    internal class QueryExecutor : IQueryExecutor {

        private readonly IDbConnectionProvider connectionProvider;

        public async Task<IEnumerable<T>> QueryProcedure<T>(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "") {
            IEnumerable<T> records =
            
            await _executeQueryProcedure<T>(
                sqlQuery: sqlQuery,
                parameters: parameters,
                connection:  connection,
                consoleOutput: consoleOutput);
            
            return records.ToList();
        }
        
        public async Task<int> NonQueryProcedure(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "") =>
            await _executeNonQueryProcedure(
                sqlQuery: sqlQuery,
                parameters: parameters,
                connection: connection,
                consoleOutput: consoleOutput);

        private async Task<IEnumerable<T>> _executeQueryProcedure<T>(
            string sqlQuery,
            IDbConnection connection,
            string consoleOutput,
            object? parameters = null) {

            Stopwatch stopwatch = Stopwatch.StartNew();
                
            connection ??= connectionProvider.DbConnection();
            IEnumerable<T> databaseRecords;

            using (connection) {
                connection.Open();
                databaseRecords =  await connection.QueryAsync<T>(
                    sql: sqlQuery,
                    param: parameters,
                    commandType: CommandType.Text,
                    commandTimeout: 30);
                connection.Close();
            }

            stopwatch.Stop();

            return databaseRecords;
        }

        private async Task<int> _executeNonQueryProcedure(
            string sqlQuery,
            IDbConnection connection,
            string consoleOutput,
            object? parameters = null) {

            Stopwatch stopwatch = Stopwatch.StartNew();
            int recordsAffected;

            connection ??= connectionProvider.DbConnection();
            using (connection) {
                connection.Open();
                recordsAffected = await connection.ExecuteAsync(
                    sql: sqlQuery,
                    param: parameters,
                    commandType: CommandType.Text,
                    commandTimeout: 0);
            }
            stopwatch.Stop();

            return recordsAffected;
        }

        public QueryExecutor(IDbConnectionProvider connectionProvider) {
            // Register your new type handler here
            SqlMapper.AddTypeHandler(new GuidTypeHandler());

            // Your existing code
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
            this.connectionProvider = connectionProvider;
        }
    }
}
