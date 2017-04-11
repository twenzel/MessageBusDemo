using Beer.Messages;
using Castle.Windsor;
using Rebus.CastleWindsor;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new WindsorContainer())
            {
                container.AutoRegisterHandlersFromThisAssembly();

                var bus = Configure.With(new CastleWindsorContainerAdapter(container))
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Warn))
                    .Transport(t => t.UseMsmq("consumer"))
                    .Routing(r => r.TypeBased().MapAssemblyOf<GiveBeer>("thebar"))
                    .Start();

                bus.Subscribe<OrderCompleted>();
                bus.Subscribe<OrderCanceled>();

                Console.WriteLine("Hi, what's your name?");
                string customerName = Console.ReadLine();

                string amount;

                Console.WriteLine($"\r\nHow many beers do you would like to have, {customerName}?");
                while (!string.IsNullOrEmpty(amount = Console.ReadLine()))
                {
                    bus.Send(new GiveBeer
                    {
                        Amount = int.Parse(amount),
                        CustomerName = customerName
                    });                    
                }
                                
            }
        }
    }
}
