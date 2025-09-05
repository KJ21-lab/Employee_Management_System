using DataAccess.Interfaces;

using Factory;

using NewHabitTracker.Server.Models.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectors.PersistenceInjector {
    public class PersistenceFactoriesInjector(IDataAccessor dataAccessor) : IPersistenceFactoriesInjector {
        public IHabitFactory HabitFactory() => new HabitFactory(dataAccessor);

    }
}
