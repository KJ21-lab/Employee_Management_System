using EmployeeManagementSystem.Server.Models.Interfaces;

namespace DependencyInjectors.PersistenceInjector {
    public interface IPersistenceFactoriesInjector {

        IEmployeeFactory EmployeeFactory();

    }
}
