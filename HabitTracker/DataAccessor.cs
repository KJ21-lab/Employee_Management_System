using System;
using System.Data;

public interface DataAccessor {
	InternalStorageCaller InternalServiceCaller();
}

public interface InternalStorageCaller {
	DbConnectionProvider DbConnectionProvider();
	StoredProcedureExecutor SPExecuter(); 
}

public interface DbConnectionProvider {
    IDbConnection DbConnection();
}

public interface StoredProcedureExecutor {
	IEnumerable<DatabaseField> QueryProcedure();
}