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
            string consoleOutput = "") { 
            IEnumerable<DatabaseField> records =
            _executeQueryProcedure<DatabaseField>(
                sqlQuery: sqlQuery,
                connection: ref connection,
                consoleOutput: consoleOutput)
            .ToList();

            return records;
        }
        private IEnumerable<DatabaseFields> _executeQueryProcedure<DatabaseFields>(
            string sqlQuery,
            ref IDbConnection connection,
            string consoleOutput) {
                try {
                    Console.WriteLine($"[ DB Call ] :: {sqlQuery} :: starting");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    //connection ??= defaultConnection;
                    IEnumerable<DatabaseFields> databaseRecords;
                    using (connection) {
                        connection.Open();
                        databaseRecords = connection.Query<DatabaseFields>(
                            sql: sqlQuery,
                            commandType: CommandType.Text,
                            commandTimeout: 0);
                        connection.Close();
                    }

                    stopwatch.Stop();
                    Console.WriteLine($"[ DB Call ] :: {sqlQuery} :: finished [ {stopwatch.ElapsedMilliseconds} ms] :: [ {databaseRecords.Count()} records ]");
                    if (string.IsNullOrWhiteSpace(consoleOutput)) {
                        Console.WriteLine($"${{consoleOutput}}");
                    }
                    return databaseRecords;
                } finally {
                    connection.Close();
                    connection.Dispose();
                }
            }

        public QueryExecutor(IDbConnection defaultConnection) {
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
            this.defaultConnection = defaultConnection;
        }
    }
}
