using DataAccess.Interfaces;

using Miscellaneous.DBCommands;

using Persistence.Tasks.Interfaces;

namespace Persistence.Tasks.Implementations {
   public class TaskFactory (IDataAccessor dataAccessor): ITaskFactory {
      public async Task<IEnumerable<ITaskRecord>> ReadAll() => 
         await _read(sqlQuery: DBCommands.SQLQueries.TaskQueries.ReadTasks);
      public async Task<IEnumerable<ITaskRecord>> ReadTaskByUIDs(IEnumerable<Guid> taskUIDs) => 
         await _read(sqlQuery: DBCommands.SQLQueries.TaskQueries.ReadAccountsByUIDs,
                              parameters: new { TaskUIDs = taskUIDs });
      public Task<IEnumerable<ITaskRecord>> Upsert(Guid taskUID) => Task.Run(() => Upsert([taskUID]));
      public Task<IEnumerable<ITaskRecord>> Upsert(IEnumerable<Guid> taskUID) => throw new NotImplementedException();

      private async Task<IEnumerable<ITaskRecord>> _read(
            string sqlQuery,
            object? parameters = null) {
      
         IEnumerable<TaskRecord_DBModel> models = 
            await dataAccessor
            .InternalStorageCaller().QueryExecutor()
            .QueryProcedure<TaskRecord_DBModel>(
               sqlQuery: sqlQuery,
               parameters: parameters,
               connection: dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection());
        
         return models
                  .Select(model => new TaskRecord(dbModel: model))
                  .ToList();
      }

   }
}
