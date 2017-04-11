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

namespace TheTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new WindsorContainer())
            {

                container.Register(Component.For<PriceCalculator>().Instance(new PriceCalculator()));
                container.AutoRegisterHandlersFromThisAssembly();

                var bus = Configure.With(new CastleWindsorContainerAdapter(container))
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Warn))
                    .Transport(t => t.UseMsmq("thetrader"))                    
                    .Routing(r => r.TypeBased().MapAssemblyOf<GiveBeerCommand>("thebar"))                     
                    .Start();

                bus.Subscribe<BeerOrderedEvent>();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
