using DataAccess.Interfaces;

using Miscellaneous.DBCommands;

using Persistence.Tasks.Interfaces;

namespace Persistence.Tasks.Implementations {
   public class TaskFactory (IDataAccessor dataAccessor): ITaskFactory {
      public Task<IEnumerable<ITaskRecord>> ReadAll() => 
         Task.Run(() => _read(sqlQuery: DBCommands.SQLQueries.TaskQueries.ReadTasks));
      public Task<IEnumerable<ITaskRecord>> ReadTaskByUIDs(IEnumerable<Guid> taskUIDs) => 
         Task.Run(() => _read(sqlQuery: DBCommands.SQLQueries.TaskQueries.ReadAccountsByUIDs,
                              parameters: new { TaskUIDs = taskUIDs }));
      public Task<IEnumerable<ITaskRecord>> Upsert(Guid taskUID) => Task.Run(() => Upsert([taskUID]));
      public Task<IEnumerable<ITaskRecord>> Upsert(IEnumerable<Guid> taskUID) => throw new NotImplementedException();

      private IEnumerable<ITaskRecord> _read(
            string sqlQuery,
            object? parameters = null) =>
        dataAccessor
        .InternalStorageCaller().QueryExecutor()
        .QueryProcedure<TaskRecord_DBModel>(
          sqlQuery: sqlQuery,
          parameters: parameters,
          connection: dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection())
        .Select(model => new TaskRecord(dbModel: model))
        .ToList();
   }
}
