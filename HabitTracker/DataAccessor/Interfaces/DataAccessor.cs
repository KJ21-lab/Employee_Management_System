namespace DataAccess.Interfaces {
    using System.Data;

    public interface IDataAccessor {
        IInternalStorageCaller InternalStorageCaller();
    }

    public interface IInternalStorageCaller {
        IDbConnectionProvider DbConnectionProvider();
        IStoredProcedureExecutor SPExecuter();
    }

    public interface IDbConnectionProvider {
        IDbConnection DbConnection();
    }

    public interface IStoredProcedureExecutor {
        IEnumerable<DatabaseField> QueryProcedure<DatabaseField>();
    }
}
