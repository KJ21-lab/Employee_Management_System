namespace HabitInterfaces {
    public interface HabitRecord {
        int habitId { get; }   
    }

    public interface HabitProperties {
        string habitName { get; set; }
        string habitDesc { get; set; }
    }
}