using DataAccess.Interfaces;

using DependencyInjectors.PersistenceInjector;

using HabitBusinessRulesInterfaces;

using NewHabitTracker.Server.BusinesRules.Implementations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectors.BusinessRules {
    internal class BusinessRulesInjector(IPersistenceFactoriesInjector persistenceFactoriesInjector) : IBusinessRulesInjector {

        public IHabitBusinessRules HabitBusinessRules() => new HabitBusinessRules(persistenceFactoriesInjector.HabitFactory());

    }
}
