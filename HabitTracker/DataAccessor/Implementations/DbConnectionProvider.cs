using DataAccess.Interfaces;

using Microsoft.Data.Sqlite;

using System.Data;
using System.Data.Common;

namespace DataAccess.Implementations {
    public class DbConnectionProvider(DataAcessConfigSettings config) : IDbConnectionProvider {

        public IDbConnection DbConnection() {
            IDbConnection connection = new SqliteConnection(config.InternalStorage.ConnectionString);
            return connection;
        }
    }
}
