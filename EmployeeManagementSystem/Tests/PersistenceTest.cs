using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Persistence.Employees.Implementations;

namespace Tests;

public class PersistenceTest()
{
   [Theory]
   [InlineData( "Bob", "Developer",  "2026-12-25", 1)]
   public async void InsertingEmployee(
       string test_name, 
       string test_jobTitle, 
       DateTime test_date, 
       int test_id)
   {

      var dataAccesor = new TestDataAccesor().DataAccessorGenerator();

      IEmployeeFactory factory = new EmployeeFactory(dataAccesor);

      IEmployeeRecord record =
        factory
        .Build((configure) => {
           configure.Name = test_name;
           configure.JobTitle = test_jobTitle;
           configure.HireDate = test_date;
           configure.EmployeeID = test_id;
        });

       await factory.Insert(record);

        
       return; 
   }
}
