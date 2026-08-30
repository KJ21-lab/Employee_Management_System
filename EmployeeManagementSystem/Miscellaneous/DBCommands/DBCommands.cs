namespace Miscellaneous.DBCommands {
   public static class DBCommands {
      public static class SQLQueries {
         public static class EmployeeQueries {
            public const string ReadEmployees = @"SELECT * FROM EmployeeRecord";
            public const string ReadEmployeesByUIDs = @"SELECT * FROM EmployeeRecord WHERE TRIM(EMPLOYEE_ID) IN(@EMPLOYEE_UID)";
            public const string InsertEmployees =
               @"INSERT INTO EmployeeRecord (EMPLOYEE_UID, EMPLOYEE_Name, EMPLOYEE_JobTitle, EMPLOYEE_HireDate, EMPLOYEE_ID)" +
               "VALUES (@EMPLOYEE_UID, @EMPLOYEE_Name, @EMPLOYEE_JobTitle, @EMPLOYEE_HireDate, @EMPLOYEE_ID)";
         }

         public static class AccountsQueries {
            public const string ReadAccounts = @"SELECT * FROM AccountsRecord";
            public const string ReadAccountsByIds = @"SELECT * FROM AccountsRecord WHERE TRIM(ACCOUNT_ID) IN(@ACCOUNT_ID)";
         }
         public static class TaskQueries {
            public const string ReadTasks = @"SELECT * FROM TaskRecord";
            public const string ReadAccountsByUIDs = @"SELECT * FROM TaskRecord WHERE TRIM(TASK_ID) IN(@TASK_UID)";
         }
      }

   }
}
