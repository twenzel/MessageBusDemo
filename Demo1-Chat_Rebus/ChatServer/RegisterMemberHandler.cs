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
    public class RegisterMemberHandler : IHandleMessages<RegisterMemberCommand>
    {
        public IBus Bus { get; private set; }

        public RegisterMemberHandler(IBus bus)
        {
            Bus = bus;
        }        

        public async  Task Handle(RegisterMemberCommand message)
        {           
            Console.WriteLine($"[MEMBER REGISTERED] : user name = '{message.Nickname}'");

            await Bus.Reply(new MemberRegisteredEvent
            {
                NickName = message.Nickname
            });
        }       
    }
}
