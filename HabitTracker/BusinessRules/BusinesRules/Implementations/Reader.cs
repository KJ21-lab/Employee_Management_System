using HabitBusinessRulesInterfaces;

using HabitModels;

using NewHabitTracker.Server.Models.Interfaces;

namespace NewHabitTracker.Server.BusinesRules.Implementations {
    public class HabitReader(IHabitFactory habitFactory) : IHabitEntityReader {


        public Task<IEnumerable<IHabitEntity>> ReadAll() => 
            Task.Run<IEnumerable<IHabitEntity>>(() => {

                IEnumerable<IHabitEntity> entities =
                    habitFactory
                    .ReadHabits()
                    .Result
                    .Select(h => new HabitEntity(h))
                    .ToList();

                return entities;
            });

        
    }
}
