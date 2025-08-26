using NewHabitTracker.Server.Miscellaneous.Interfaces;

namespace NewHabitTracker.Server.Models.Interfaces {
    public interface IHabitFactory {

        Task<IEnumerable<IHabitRecord>> ReadHabits();
        Task<IHabitRecord?> ReadHabit(Guid habitID) =>
            Task.Run(() => ReadHabits([habitID]).Result.FirstOrDefault());

        Task<IEnumerable<IHabitRecord>> ReadHabits(IEnumerable<Guid> habitIDs);

        Task<OperationResult> Upsert(Guid habitID) => Upsert([habitID]);
        Task<OperationResult> Upsert(IEnumerable<Guid> habitIDs);

    }

    public interface IHabitRecord : IHabitRecordProperties {
        int habitId { get; }
    }

    public interface IHabitRecordProperties {
        string habitName { get; set; }
        string habitDesc { get; set; }
    }
}
