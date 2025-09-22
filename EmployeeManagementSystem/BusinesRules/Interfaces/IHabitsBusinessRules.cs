namespace HabitBusinessRulesInterfaces {
    public interface HabitBusinessRules {

        public HabitEntityReader Reader();
        public HabitEntityWriter Writer();
    }

    public interface IHabitEntity : IHabitPropertiesEntity  {
        int habitId { get; }   
    }

    public interface IHabitPropertiesEntity {
        string habitName { get; set; }
        string habitDesc { get; set; }
    }

    public interface HabitEntityReader {
        public IHabitEntity Reader();
    }

    public interface HabitEntityWriter {


    }
}