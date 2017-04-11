using Castle.Windsor;
using Chat.Messages;
using Shuttle.Esb;
using Shuttle.Esb.Castle;
using Shuttle.Esb.SqlServer;
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
            var subscriptionManager = SubscriptionManager.Default();
            //subscriptionManager.Subscribe<MessageReceivedEvent>();

            using (var bus = ServiceBus.Create(c => {
                c.MessageHandlerFactory(new CastleMessageHandlerFactory(new WindsorContainer()));
                c.SubscriptionManager(subscriptionManager);                
            }).Start())
            {
               
                Console.WriteLine("Please enter nick name:");
                string userName = Console.ReadLine();
                
                bus.Send(new RegisterMemberCommand
                {
                    Nickname = userName
                }, c => c.WillExpire(DateTime.Now.AddSeconds(5)));


                Console.WriteLine("Go, start chat:");
                string message;
                while (!string.IsNullOrEmpty(message = Console.ReadLine()))
                {
                    bus.Send(new SendMessageCommand
                    {
                        Message = message,
                        From = userName
                    }, c => c.WillExpire(DateTime.Now.AddSeconds(5)));
                }
            }
        }
    }
}
