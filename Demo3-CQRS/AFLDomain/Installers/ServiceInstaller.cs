using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLDomain.Domains;
using AFLDomain.Infrastructure;
using AFLDomain.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AFLDomain.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IApplicationForLeaveService>().ImplementedBy<ApplicationForLeaveService>().LifestyleTransient());
            container.Register(Component.For<IApplicationForLeaveRepository>().ImplementedBy<ApplicationForLeaveRepository>().LifestyleTransient());

            container.Register(Component.For<IEventStore>().ImplementedBy<InMemoryEventStore>().LifestyleTransient());
            container.Register(Component.For<IEventPublisher>().ImplementedBy<MessageBusEventPublisher>().LifestyleTransient());
        }
    }
}
