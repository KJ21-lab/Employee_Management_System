using HabitClass;

namespace Factory{
    public class HabitFactory {
        public HabitFactory() { }
        public Habitreader Reader() => new Habitreader(); 
    }

    public class Habitreader() {
        public IEnumerable<Habit> Read() => new Habit[0];

    }
}