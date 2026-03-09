using Dapper;

using DataAccess.Interfaces;

using System.Data;
using System.Diagnostics;

namespace DataAccess.Implementations {
    internal class QueryExecutor : IQueryExecutor {

        private readonly IDbConnection defaultConnection;

        public IEnumerable<DatabaseField> QueryProcedure<DatabaseField>(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "") {
            IEnumerable<DatabaseField> records =
            _executeQueryProcedure<DatabaseField>(
                sqlQuery: sqlQuery,
                parameters: parameters,
                connection: ref connection,
                consoleOutput: consoleOutput)
            .ToList();

            return records;
        }

        public void NonQueryProcedure<DatabaseField>(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "") =>
            _executeNonQueryProcedure<DatabaseField>(
                sqlQuery: sqlQuery,
                parameters: parameters,
                connection: ref connection,
                consoleOutput: consoleOutput);

        private IEnumerable<DatabaseFields> _executeQueryProcedure<DatabaseFields>(
            string sqlQuery,
            ref IDbConnection connection,
            string consoleOutput,
            object? parameters = null) {
            try {
                
                connection ??= defaultConnection;
                IEnumerable<DatabaseFields> databaseRecords;
                using (connection) {
                    connection.Open();
                    databaseRecords = connection.Query<DatabaseFields>(
                        sql: sqlQuery,
                        param: parameters,
                        commandType: CommandType.Text,
                        commandTimeout: 0);
                    connection.Close();
                }

                return databaseRecords;
            } finally {
                connection.Close();
                connection.Dispose();
            }
        }

        private void _executeNonQueryProcedure<DatabaseField>(
            string sqlQuery,
            ref IDbConnection connection,
            string consoleOutput,
            object? parameters = null) {
            try {

                connection ??= defaultConnection;
                using (connection) {
                    connection.Open();
                    connection.Execute(
                        sql: sqlQuery,
                        param: parameters,
                        commandType: CommandType.Text,
                        commandTimeout: 0);
                    connection.Close();
                }

            } finally {
                connection.Close();
                connection.Dispose();
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
