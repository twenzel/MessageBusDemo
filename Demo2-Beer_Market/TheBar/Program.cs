using Beer.Messages;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Rebus.Auditing.Messages;
using Rebus.CastleWindsor;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBar
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new WindsorContainer())
            {
                container.AutoRegisterHandlersFromThisAssembly();
                container.Register(Component.For<ICashier>().ImplementedBy<Cashier>().LifeStyle.Singleton);

                var bus = Configure.With(new CastleWindsorContainerAdapter(container))
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Warn))
                    .Routing(r => {
                        r.TypeBased().MapAssemblyOf<GiveBeerCommand>("thebar").Map< BeerPriceUpdatedEvent>("thetrader");
                    })                    
                    .Transport(t => t.UseMsmq("thebar"))
                    .Start();

                bus.Subscribe<BeerPriceUpdatedEvent>();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
