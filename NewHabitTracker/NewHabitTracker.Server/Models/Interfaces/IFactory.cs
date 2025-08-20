namespace NewHabitTracker.Server.Models.Interfaces {
    public interface IHabitFactory {

        Task<IHabitRecord?> ReadHabit(Guid habitID) =>
            Task.Run(() => ReadHabits([habitID]).Result.FirstOrDefault());

        Task<IEnumerable<IHabitRecord>> ReadHabits(IEnumerable<Guid> habitIDs);

        Task<OperationResult> Upsert(Guid habitID) => Upsert([habitID]);
        Task<OperationResult> Upsert(IEnumerable<Guid> habitIDs);

    }

    public interface IHabitRecord {
        Guid habitId { get; }
    }

    public interface IHabitProperties {
        string habitName { get; set; }
        string habitDesc { get; set; }
    }
}
