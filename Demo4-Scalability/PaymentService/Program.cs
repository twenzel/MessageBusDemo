using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Rebus.Config;
using Rebus.CastleWindsor;
using DemoContracts;

namespace PaymentService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new WindsorContainer())
            {
                container.AutoRegisterHandlersFromThisAssembly();

                var bus = Configure.With(new CastleWindsorContainerAdapter(container))
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Info))
                    .Transport(t => t.UseRabbitMq("amqp://guest:guest@172.17.0.2", "payment_input"))                    
                    .Start();

                bus.Subscribe<OrderCreated>();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
