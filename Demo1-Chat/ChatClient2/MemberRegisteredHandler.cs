using Chat.Messages;
using Shuttle.Esb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client2
{
    public class MemberRegisteredHandler : IMessageHandler<MemberRegisteredEvent>
    {
        public void ProcessMessage(IHandlerContext<MemberRegisteredEvent> context)
        {
            Console.WriteLine();
            Console.WriteLine($"[User was registered] : nickname = '{context.Message.NickName}'");            
        }
    }
}
