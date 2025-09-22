using DataAccess.Interfaces;

using DependencyInjectors.BusinessRules;
using DependencyInjectors.PersistenceInjector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectors {
    internal class DependencyInjectors : IDependencyInjectors {

        private readonly IDataAccessor _dataAccessor;

        public DependencyInjectors(IDataAccessor dataAccessor) {
             _dataAccessor = dataAccessor;
        }

        public IPersistenceFactoriesInjector PersistenceInjector() => new PersistenceFactoriesInjector(_dataAccessor);
        public IBusinessRulesInjector BusinessRulesInjector() => new BusinessRulesInjector(PersistenceInjector());
    }
}
