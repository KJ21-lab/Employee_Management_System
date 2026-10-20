using DataAccess.Interfaces;

using EmployeeManagementSystem.Server.Models.Interfaces;

using Persistence.Employees.Implementations;
using Persistence.UserAccount.Implementations;

namespace DependencyInjectors.PersistenceInjector {
    public class PersistenceFactoriesInjector(IInternalStorageCaller internalStorageCaller) : IPersistenceFactoriesInjector {
        public IEmployeeFactory EmployeeFactory() => new EmployeeFactory(internalStorageCaller);
        public IAccountFactory AccountFactory() => new AccountFactory(internalStorageCaller);
    }
}
