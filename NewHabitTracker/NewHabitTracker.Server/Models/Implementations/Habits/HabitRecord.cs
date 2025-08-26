using NewHabitTracker.Server.Models.Interfaces;

namespace HabitClass {
    public class HabitRecord : IHabitRecord {
        public HabitRecord() {
            habitId = 2;//Guid.NewGuid();
        }

        public HabitRecord(HabitRecord_DbModel dbModel) {
            habitId = int.Parse(dbModel.HABIT_ID);//Guid.Parse(dbModel.HABIT_ID);
            habitName = dbModel.HABIT_NAME;
            habitDesc = dbModel.HABIT_DESC;
        }

        public int habitId { get; }
        public string habitName { get; set; } = string.Empty;
        public string habitDesc { get; set; } = string.Empty;
    }

    public class HabitRecord_DbModel {

        public HabitRecord_DbModel() { }
        public HabitRecord_DbModel(IHabitRecord record) {
            HABIT_ID = record.habitId.ToString();
            HABIT_NAME = record.habitName;
            HABIT_DESC = record.habitDesc;
        }
        public string HABIT_ID { get; set; }
        public string HABIT_NAME { get; set; }
        public string HABIT_DESC { get; set; }
    }
}