using DataAccess.Interfaces;

namespace DataAccess.Implementations {
    internal class InternalStorageCaller(DataAcessConfigSettings config) : IInternalStorageCaller {

        public IDbConnectionProvider DbConnectionProvider() =>
            new DbConnectionProvider(config);

        public IQueryExecutor QueryExecutor() =>
            new QueryExecutor(defaultConnection: DbConnectionProvider().DbConnection());
    }
    //"C:\Program Files\DB Browser for SQLite\TestDatabase.db"
}
