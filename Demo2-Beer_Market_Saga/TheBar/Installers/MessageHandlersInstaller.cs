using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rebus.CastleWindsor;

namespace TheBar.Installers
{
    public class MessageHandlersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // just register all Rebus handlers from this assembly
            container.AutoRegisterHandlersFromThisAssembly();

            container.Register(Component.For<ICashier>().ImplementedBy<Cashier>().LifeStyle.Singleton);
        }
    }
}
