using ElColeto.Domain.Contracts;
using ElColeto.Persistence;
using ElColeto.Persistence.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElColeto.Application.Helpers
{
    class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
