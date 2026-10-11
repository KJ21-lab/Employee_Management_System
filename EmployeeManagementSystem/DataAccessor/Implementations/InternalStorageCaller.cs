using DataAccess.Interfaces;

namespace DataAccess.Implementations {
    public class InternalStorageCaller(DataAcessConfigSettings config) : IInternalStorageCaller {

      public IDbConnectionProvider DbConnectionProvider() =>
            new DbConnectionProvider(config);

        public IQueryExecutor QueryExecutor() =>
            new QueryExecutor(connectionProvider: DbConnectionProvider());
    }
    //"C:\Program Files\DB Browser for SQLite\TestDatabase.db"
}
