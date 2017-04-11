using Chat.Messages;
using Rebus.Bus;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    public class SendMessageHandler : IHandleMessages<SendMessageCommand>
    {
        public IBus Bus { get; private set; }

        public SendMessageHandler(IBus bus)
        {
            Bus = bus;
        }        

        public async Task Handle(SendMessageCommand message)
        {
            Console.WriteLine($"[Message SENT] : {message.From}->'{message.Message}'");

            await Bus.Publish(new MessageReceivedEvent
            {
                Message = message.Message,
                From = message.From
            });
        }       
    }
}
