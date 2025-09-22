using HabitBusinessRulesInterfaces;

namespace DependencyInjectors {
    public interface IBusinessRulesInjector {

        IHabitBusinessRules HabitBusinessRules();
    }
}