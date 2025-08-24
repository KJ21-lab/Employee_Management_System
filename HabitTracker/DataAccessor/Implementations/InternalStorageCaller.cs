using DataAccess.Interfaces;

namespace DataAccess.Implementations {
    internal class InternalStorageCaller(DataAcessConfigSettings config) : IInternalStorageCaller {

        public IDbConnectionProvider DbConnectionProvider() => 
            new DbConnectionProvider(config);

        public IStoredProcedureExecutor SPExecuter() {
            throw new NotImplementedException();
        }
    }
}
