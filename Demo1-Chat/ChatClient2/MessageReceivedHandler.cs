using Chat.Messages;
using Shuttle.Esb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherNamespace
{
    public class MessageReceivedHandler : IMessageHandler<MessageReceivedEvent>
    {
        public void ProcessMessage(IHandlerContext<MessageReceivedEvent> context)
        {
            Console.WriteLine();
            Console.WriteLine($"[{context.Message.From}] : {context.Message.Message}");
            Console.WriteLine();
        }

        //public bool IsReusable
        //{
        //    get { return true; }
        //}
    }
}
