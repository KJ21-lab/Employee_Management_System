namespace DataAccess.Interfaces {
    using System.Data;
    using System.Data.Common;

    public interface IDataAccessor {
        IInternalStorageCaller InternalStorageCaller();
    }

    public interface IInternalStorageCaller {
        IDbConnectionProvider DbConnectionProvider();
        IQueryExecutor QueryExecutor();
    }

    public interface IDbConnectionProvider {
        IDbConnection DbConnection();
    }

    public interface IQueryExecutor {
        IEnumerable<DatabaseField> QueryProcedure<DatabaseField>(
            string sqlQuery,
            IDbConnection connection,
            string consoleOutput = "");
    }
}
