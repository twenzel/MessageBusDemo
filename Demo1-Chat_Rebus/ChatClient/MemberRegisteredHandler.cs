using Chat.Messages;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client
{
    public class MemberRegisteredHandler : IHandleMessages<MemberRegisteredEvent>
    {
        public Task Handle(MemberRegisteredEvent message)
        {
            Console.WriteLine();
            Console.WriteLine($"[User was registered] : nickname = '{message.NickName}'");

            return Task.FromResult<int>(0);
        } 
    }
}
