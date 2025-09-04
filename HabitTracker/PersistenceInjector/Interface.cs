using DependencyInjectors.PersistenceInjector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectors {
    internal interface IDependencyInjectors {

        IPersistenceFactoriesInjector PersistenceInjector();
        IBusinessRulesInjector BusinessRulesInjector();
    }
}
