using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLQueryService.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AFLQueryService.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IOpenApplicationsRepository>().ImplementedBy<OpenApplicationsRepository>().LifestyleTransient());
            container.Register(Component.For<IAcceptedApplicationsRepository>().ImplementedBy<AcceptedApplicationsRepository>().LifestyleTransient());
        }
    }
}
