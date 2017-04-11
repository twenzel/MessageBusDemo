using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Messages;
using Rebus.Bus;
using Rebus.Handlers;

namespace Consumer.Handlers
{
    public class GiveMoneyHandler : IHandleMessages<GiveMoney>
    {
        public IBus Bus { get; private set; }

        public GiveMoneyHandler(IBus bus)
        {
            Bus = bus;
        }

        public async Task Handle(GiveMoney message)
        {
            Console.WriteLine($"Makes {message.TotalPrice:c}.");

            await Bus.Reply(new SendMoney
            {
                Amount = message.TotalPrice.RoundToNextNoteValue(),
                CustomerName = message.CustomerName
            });
        }
    }
}
