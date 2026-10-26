namespace DataAccess.Interfaces {
   using System.Data;

   public interface IInternalStorageCaller {
        IDbConnectionProvider DbConnectionProvider();
        IQueryExecutor QueryExecutor();
    }

    public interface IDbConnectionProvider {
        IDbConnection DbConnection();
    }

    public interface IQueryExecutor {
      Task<IEnumerable<T>> QueryProcedure<T>(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "");

        Task<int> NonQueryProcedure(
            string sqlQuery,
            IDbConnection connection,
            object? parameters = null,
            string consoleOutput = "");
   }
}
