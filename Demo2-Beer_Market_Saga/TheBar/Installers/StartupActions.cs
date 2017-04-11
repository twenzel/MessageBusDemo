using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Messages;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rebus.Bus;

namespace TheBar.Installers
{
    public class StartupActions : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {           
            var bus = container.Resolve<IBus>();

            bus.Subscribe<BeerPriceUpdatedEvent>();
        }
    }
}
