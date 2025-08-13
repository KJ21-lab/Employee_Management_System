namespace HabitBusinessRulesInterfaces {
    public interface HabitBusinessRules {

        public HabitEntityReader Reader();
        public HabitEntityWriter Writer();
    }

    public interface HabitRecordEntity : HabitPropertiesEntity  {
        int habitId { get; }   
    }

    public interface HabitPropertiesEntity {
        string habitName { get; set; }
        string habitDesc { get; set; }
    }

    public interface HabitEntityReader {
        public HabitRecordEntity Reader();
    }

    public interface HabitEntityWriter {


    }
}