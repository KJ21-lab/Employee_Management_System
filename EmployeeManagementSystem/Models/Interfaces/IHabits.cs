namespace HabitInterfaces {
    public interface IHabitRecord {
        int habitId { get; }   
    }

    public interface IHabitProperties {
        string habitName { get; set; }
        string habitDesc { get; set; }
    }
}