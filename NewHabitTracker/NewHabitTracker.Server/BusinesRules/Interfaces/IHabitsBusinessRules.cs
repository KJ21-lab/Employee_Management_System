namespace HabitBusinessRulesInterfaces {
    public interface IHabitBusinessRules {

        IHabitEntityReader Reader();
        IHabitEntityWriter Writer();
    }

    public interface IHabitEntity : IHabitPropertiesEntity  {
        Guid habitId { get; }   
    }

    public interface IHabitPropertiesEntity {
        string habitName { get; set; }
        string habitDesc { get; set; }
    }

    public interface IHabitEntityReader {
        Task<IEnumerable<IHabitEntity>> ReadAll();
    }

    public interface IHabitEntityWriter {


    }
}