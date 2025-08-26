using DataAccess.Interfaces;

using HabitClass;

using NewHabitTracker.Server.Miscellaneous.Interfaces;
using NewHabitTracker.Server.Models.Interfaces;

namespace Factory {
    public class HabitFactory(IDataAccessor dataAccessor) : IHabitFactory {


        public IHabitRecord Build(
         Action<IHabitRecordProperties> configure) {
            IHabitRecord record = new HabitRecord();
            configure(record);
            return record;
        }

        public Task<IEnumerable<IHabitRecord>> ReadHabits(IEnumerable<Guid> habitIds) =>
           Task.Run(() => _read(sqlQuery: @"SELECT * FROM HabitRecord WHERE HABIT_ID IN(@HabitId)"));

        public Task<IEnumerable<IHabitRecord>> ReadHabits() =>
            Task.Run(() => _read(sqlQuery: @"SELECT * FROM HabitRecord"));

        public Task<OperationResult> Upsert(Guid habitID) => throw new NotImplementedException();
        public Task<OperationResult> Upsert(IEnumerable<Guid> habitIDs) => throw new NotImplementedException();

        private IEnumerable<IHabitRecord> _read(
            string sqlQuery) =>
        dataAccessor
        .InternalStorageCaller().QueryExecutor()
        .QueryProcedure<HabitRecord_DbModel>(
          sqlQuery: sqlQuery,
          connection: dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection())
        .Select(model => new HabitRecord(dbModel: model))
        .ToList();

        private void _execute() {

        }
    }
}


//namespace PUMC.Implementations.Persistence.Driver {

//    public class PumcDriverHeaderRecordsFactory(

//      IntegratedServiceCallers integratedServiceCallers) : DriverHeaderRecordsFactory {

//        public DriverHeaderRecord Build(

//          EmployeeUID employeeUID,

//          Action<DriverHeaderRecordProperties> configure) {

//            DriverHeaderRecord record = new PumcDriverHeaderRecord(employeeUID);

//            configure(record);

//            return record;

//        }



//        public Task<IEnumerable<DriverHeaderRecord>> Read() =>

//          Task.Run(() =>

//            _read(procedureName: "pumc_DriverHeaderRecords_Read"));



//        public Task<IEnumerable<DriverHeaderRecord>> Read(

//          IEnumerable<DriverUID> driverUIDs) =>

//          Task.Run(() =>

//            _read(

//              procedureName: "pumc_DriverHeaderRecords_ReadByUID",

//              parameters: new {

//                  UIDS = driverUIDs.Select(uid => new { UID = uid.Value }).ToDataTable()

//              }));



//        public Task<OperationResult> Upsert(

//          IEnumerable<DriverHeaderRecord> records) =>

//          Task.Run<OperationResult>(() => {

//              try {

//                  _execute(

//                procedureName: "pumc_DriverHeaderRecords_Upsert",

//                parameters: new {

//                    Records =

//                    records

//                    .DistinctBy(record => record.UID)

//                    .Select(record => new DriverHeaderRecord_DbModel(record))

//                    .ToDataTable()

//                });

//                  return new GlobalOperationResult();

//              } catch (Exception ex) {

//                  return new GlobalOperationResult(

//                $"Failed to upsert Driver Header Records [ {ex.Message} ]");

//              }

//          });







//        private void _execute(

//          string procedureName,

//          object? parameters = null) =>

//          integratedServiceCallers

//          .InternalStorageCaller().SpExecutor()

//          .NonQueryProcedure(

//            procedureName: procedureName,

//            connection: integratedServiceCallers.InternalStorageCaller().DbConnectionProvider().PumcDbConnection(),

//            parameters: parameters);

//    }

//}