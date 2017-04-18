using Beer.Messages;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Rebus.CastleWindsor;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using System;

namespace TheTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            // change output encoding for correct currency sign display
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (var container = new WindsorContainer())
            {
                container.Register(Component.For<PriceCalculator>().Instance(new PriceCalculator()));
                container.AutoRegisterHandlersFromThisAssembly();

                var bus = Configure.With(new CastleWindsorContainerAdapter(container))
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Warn))
                    .Transport(t => t.UseMsmq("thetrader"))                    
                    .Routing(r => r.TypeBased().MapAssemblyOf<GiveBeer>("thebar"))                     
                    .Start();

                bus.Subscribe<BeerOrderedEvent>();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
