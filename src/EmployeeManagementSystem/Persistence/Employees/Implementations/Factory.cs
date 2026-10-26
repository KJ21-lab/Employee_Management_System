using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Microsoft.AspNetCore.Components;

using Miscellaneous.DBCommands;
using Miscellaneous.OperationResult;

using System.Collections;
using System.Collections.Generic;

namespace Persistence.Employees.Implementations {
    public class EmployeeFactory(IInternalStorageCaller internalStorageCaller) : IEmployeeFactory {

       public IEmployeeRecord Build(
        Action<IEmployeeRecordProperties> configure) {
           IEmployeeRecord record = new EmployeeRecord();
           configure(record);
           return record;
       }
       
       public async Task<IEnumerable<IEmployeeRecord>> ReadEmployees() =>
           await _read(sqlQuery: DBCommands.SQLQueries.EmployeeQueries.ReadEmployees);
       
       public async Task<IEmployeeRecord?> ReadEmployeeByUID(Guid employeeUID) {
       
          IEnumerable<IEmployeeRecord> records = 
              await ReadEmployeesByUIDs([employeeUID]);
       
           return records.FirstOrDefault();
       }
        
       public async Task<IEnumerable<IEmployeeRecord>> ReadEmployeesByUIDs(IEnumerable<Guid> employeeUIDs) =>
             await _read(sqlQuery: DBCommands.SQLQueries.EmployeeQueries.ReadEmployeesByUIDs,
                         parameters: new { EMPLOYEE_UIDs = employeeUIDs.Select(uid => uid.ToString())});

       public async Task<int> Upsert(IEmployeeRecord record) {
               int recordsAffected = await _execute(sqlQuery: DBCommands.SQLQueries.EmployeeQueries.UpsertEmployees,
                        parameters: new 
                        { EMPLOYEE_UID      = record.EmployeeUID.ToString(),
                          EMPLOYEE_Name     = record.Name,
                          EMPLOYEE_JobTitle = record.JobTitle,
                          EMPLOYEE_HireDate = record.HireDate,
                          EMPLOYEE_ID       = record.EmployeeID });

               return recordsAffected;
       }
      
       public async Task<int> DeleteEmployees(IEnumerable<Guid> employeeUIDs) {
           int recordsAffected = await _execute(
              sqlQuery: DBCommands.SQLQueries.EmployeeQueries.DeleteEmployees,
              parameters: new { EMPLOYEE_UIDs = employeeUIDs.Select(uid => uid.ToString()) });
           
           return recordsAffected;
      }
      public async Task<bool> Exists(IEnumerable<Guid> employeeUIDs) {

         var epmloyeeUids = employeeUIDs.Select(uid => uid.ToString()).ToList();

         IEnumerable<int> result = await internalStorageCaller
             .QueryExecutor()
             .QueryProcedure<int>(
                sqlQuery: DBCommands.SQLQueries.EmployeeQueries.EmployeeExists,
                parameters: new { UIDs = epmloyeeUids },
                connection: internalStorageCaller.DbConnectionProvider().DbConnection());

         return (result.FirstOrDefault() == epmloyeeUids.Count);
      }

      private async Task<IEnumerable<IEmployeeRecord>> _read(
             string sqlQuery,
             object? parameters = null) {
       
          IEnumerable<EmployeeRecord_DbModel> records = 
             await internalStorageCaller
             .QueryExecutor()
             .QueryProcedure<EmployeeRecord_DbModel>(
               sqlQuery: sqlQuery,
               parameters: parameters,
               connection: internalStorageCaller.DbConnectionProvider().DbConnection());
       
             return records
                    .Select(model => new EmployeeRecord(dbModel: model))
                    .ToList();
       }

       private async Task<int> _execute(
          string sqlQuery,
          object? parameters = null) =>
          await internalStorageCaller
            .QueryExecutor()
            .NonQueryProcedure(
              sqlQuery: sqlQuery,
              parameters: parameters,
              connection: internalStorageCaller.DbConnectionProvider().DbConnection());
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