using HabitInterfaces;

namespace HabitClass {
    public class Habit : HabitRecord {
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
}