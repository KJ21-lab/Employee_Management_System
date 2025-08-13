using HabitBusinessRulesInterfaces;

namespace HabitModels {
    public class IMPHabitRecordEntity :  HabitRecordEntity {
        public IMPHabitRecordEntity() { }

        public IMPHabitRecordEntity(int id, string Name, string desc) {
            habitId = id;
            habitName = Name;
            habitDesc = desc;
        }

        public int habitId { get; set; }
        public string habitName { get; set; }
        public string habitDesc { get; set; }
    }
}