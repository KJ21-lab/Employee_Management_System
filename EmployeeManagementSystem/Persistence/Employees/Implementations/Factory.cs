using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using NewHabitTracker.Server.Miscellaneous.Interfaces;

namespace Persistence.Employees.Implementations {
    public class EmployeeFactory(IDataAccessor dataAccessor) : IEmployeeFactory {

        public IEmployeeRecord Build(
         Action<IEmployeeRecordProperties> configure) {
            IEmployeeRecord record = new EmployeeRecord();
            configure(record);
            return record;
        }

        public Task<IEnumerable<IEmployeeRecord>> ReadEmployeesByIds(IEnumerable<Guid> employeeIDs) =>
           Task.Run(() => _read(sqlQuery: @"SELECT * FROM EmployeeRecord WHERE TRIM(EMPLOYEE_ID) IN(@EMPLOYEE_ID)",
                                parameters: new { EmployeeIDs = employeeIDs }));

        public Task<IEnumerable<IEmployeeRecord>> ReadEmployees() =>
            Task.Run(() => _read(sqlQuery: @"SELECT * FROM EmployeeRecord"));

        public Task<OperationResult> Upsert(Guid employeeID) => throw new NotImplementedException();
        public Task<OperationResult> Upsert(IEnumerable<Guid> employeeIDs) => throw new NotImplementedException();

        private IEnumerable<IEmployeeRecord> _read(
            string sqlQuery,
            object? parameters = null) =>
        dataAccessor
        .InternalStorageCaller().QueryExecutor()
        .QueryProcedure<EmployeeRecord_DbModel>(
          sqlQuery: sqlQuery,
          parameters: parameters,
          connection: dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection())
        .Select(model => new EmployeeRecord(dbModel: model))
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