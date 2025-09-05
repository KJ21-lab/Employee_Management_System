using HabitBusinessRulesInterfaces;

using NewHabitTracker.Server.Models.Interfaces;

namespace NewHabitTracker.Server.BusinesRules.Implementations {
    public class HabitBusinessRules(IHabitFactory habitFactory) : IHabitBusinessRules {

        public IHabitEntityReader Reader() => new HabitReader(habitFactory);
        public IHabitEntityWriter Writer() => throw new NotImplementedException();
    }

}
