using HabitInterfaces;

namespace HabitClass {
    public class Habit : IHabitRecord {
        public Habit() { }

        public Habit(int id, string Name, string desc) {
            habitId = id;
            habitName = Name;
            habitDesc = desc;
        }

        public int habitId { get; set; }
        public string habitName { get; set; }
        public string habitDesc { get; set; }
    }

    public class HabitRecord_DbModel {
        public int HABIT_ID { get; set; }
        public string HABIT_NAME { get; set; }
        public string HABIT_DESC { get; set; }
    }
}