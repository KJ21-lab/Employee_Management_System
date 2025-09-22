using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Persistence.Employees.Implementations;

namespace DependencyInjectors.PersistenceInjector {
    public class PersistenceFactoriesInjector(IDataAccessor dataAccessor) : IPersistenceFactoriesInjector {
        public IEmployeeFactory EmployeeFactory() => new EmployeeFactory(dataAccessor);

    }
}
