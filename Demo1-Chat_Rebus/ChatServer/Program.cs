using Castle.Windsor;
using Rebus.Config;
using Rebus.CastleWindsor;
using System;

namespace Chat.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new WindsorContainer())
            {
                container.AutoRegisterHandlersFromThisAssembly();

                Configure.With(new CastleWindsorContainerAdapter(container))
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Info))
                    .Transport(t => t.UseMsmq("chat-server"))
                    .Start();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
