using Chat.Messages;
using Shuttle.Esb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    public class SendMessageHandler : IMessageHandler<SendMessageCommand>
    {
        public void ProcessMessage(IHandlerContext<SendMessageCommand> context)
        {
            Console.WriteLine($"[Message SENT] : {context.Message.From}->'{context.Message.Message}'");

            context.Publish(new MessageReceivedEvent
            {
                Message = context.Message.Message,
                From = context.Message.From
            });
        }
    }
}
