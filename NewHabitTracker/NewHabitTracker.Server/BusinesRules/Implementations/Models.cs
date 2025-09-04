using HabitBusinessRulesInterfaces;

using NewHabitTracker.Server.Models.Interfaces;

namespace HabitModels {
    public class HabitEntity : IHabitEntity {
        public HabitEntity() { }

        public HabitEntity(Guid id, string Name, string desc) {
            habitId = id;
            habitName = Name;
            habitDesc = desc;
        }
        public HabitEntity(IHabitRecord record) {
            habitId = record.habitId;
            habitName = record.habitName;
            habitDesc = record.habitDesc;
        }

        public Guid habitId { get; set; }
        public string habitName { get; set; }
        public string habitDesc { get; set; }
    }
}