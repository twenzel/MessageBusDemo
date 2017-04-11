using Chat.Messages;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client
{
    public class MessageReceivedHandler : IHandleMessages<MessageReceivedEvent>
    {
        public Task Handle(MessageReceivedEvent message)
        {            
            Console.WriteLine($"[{message.From}] : {message.Message}");

            return Task.FromResult<int>(0);
        }
    }
}
