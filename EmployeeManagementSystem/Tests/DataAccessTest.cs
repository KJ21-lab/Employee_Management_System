using DataAccess.Implementations;
using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using Persistence.Employees.Implementations;
using Tests;
using SQLitePCL;

public class DataAccessTest {
    [Fact]
    public async Task Test1() {
     
        var dataAccesor = new TestDataAccesor().DataAccessorGenerator();
        
        IEmployeeFactory factory =  new EmployeeFactory(dataAccesor);

        IEnumerable<IEmployeeRecord> records =
          await factory
            //.ReadHabits();
          .ReadEmployeesByUIDs([Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA")]);

        Console.WriteLine(records);
    }
}