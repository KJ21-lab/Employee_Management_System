using NewHabitTracker.Server.Models.Interfaces;

namespace DependencyInjectors.PersistenceInjector {
    public interface IPersistenceFactoriesInjector {

        IHabitFactory HabitFactory();

    }
}
