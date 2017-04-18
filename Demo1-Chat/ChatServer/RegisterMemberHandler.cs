using Chat.Messages;
using Shuttle.Esb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    public class RegisterMemberHandler : IMessageHandler<RegisterMemberCommand>
    {
        public void ProcessMessage(IHandlerContext<RegisterMemberCommand> context)
        {
            Console.WriteLine($"[MEMBER REGISTERED] : user name = '{context.Message.Nickname}'");

            context.Send(new MemberRegisteredEvent
            {
                NickName = context.Message.Nickname
            }, c => c.Reply());
        }
    }
}
