using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Miscellaneous.Implementations;
using EmployeeManagementSystem.Server.Miscellaneous.Interfaces;
using EmployeeManagementSystem.Server.Models.Interfaces;

using Miscellaneous.DBCommands;

namespace Persistence.Employees.Implementations {
    public class EmployeeFactory(IDataAccessor dataAccessor) : IEmployeeFactory {

        public IEmployeeRecord Build(
         Action<IEmployeeRecordProperties> configure) {
            IEmployeeRecord record = new EmployeeRecord();
            configure(record);
            return record;
        }

        public Task<IEnumerable<IEmployeeRecord>> ReadEmployeesByUIDs(IEnumerable<Guid> employeeUIDs) =>
           Task.Run(() => _read(sqlQuery: DBCommands.SQLQueries.EmployeeQueries.ReadEmployeesByUIDs,
                                parameters: new { EmployeeUIDs = employeeUIDs }));

        public Task<IEnumerable<IEmployeeRecord>> ReadEmployees() =>
            Task.Run(() => _read(sqlQuery: DBCommands.SQLQueries.EmployeeQueries.ReadEmployees));

        public Task<OperationResult> Insert(IEmployeeRecord record) =>
         Task.Run<OperationResult>(() => {
         try {
               _execute(sqlQuery: DBCommands.SQLQueries.EmployeeQueries.InsertEmployees,
                        parameters: new 
                        { EMPLOYEE_UID      = record.EmployeeUID,
                          EMPLOYEE_Name     = record.Name,
                          EMPLOYEE_JobTitle = record.JobTitle,
                          EMPLOYEE_HireDate = record.HireDate,
                          EMPLOYEE_ID       = record.EmployeeID } );
               return new GlobalOperationResult();
            } catch (Exception ex) {
               return new GlobalOperationResult($"Employee Insert Failed. { ex.Message } ");
           }
         });


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

        private void _execute(
           string sqlQuery,
            object? parameters = null) {
         var connection = dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection();
         dataAccessor
        .InternalStorageCaller().QueryExecutor()
        .NonQueryProcedure(
          sqlQuery: sqlQuery,
          parameters: parameters,
          connection: dataAccessor.InternalStorageCaller().DbConnectionProvider().DbConnection());
         Console.WriteLine("");
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