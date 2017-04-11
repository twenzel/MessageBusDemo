using Castle.Windsor;
using Chat.Messages;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var activator = new BuiltinHandlerActivator())
            {
                activator.Register(() => new MemberRegisteredHandler());
                activator.Register(() => new MessageReceivedHandler());

                var bus = Configure.With(activator)
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Info))
                    .Transport(t => t.UseMsmq("chat-client"))
                    .Routing(r => r.TypeBased().MapAssemblyOf<RegisterMemberCommand>("chat-server"))
                    .Start();

                bus.Subscribe<MessageReceivedEvent>();

                Console.WriteLine("Please enter nick name:");
                string userName = Console.ReadLine();

                bus.Send(new RegisterMemberCommand
                {
                    Nickname = userName
                });

                Console.WriteLine("Go, start chat:");
                string message;
                while (!string.IsNullOrEmpty(message = Console.ReadLine()))
                {
                    bus.Send(new SendMessageCommand
                    {
                        Message = message,
                        From = userName
                    });
                }
              
            }
        }
    }
}
