using Beer.Messages;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rebus.Bus;

namespace TheBar.Handlers
{
    class SendMoneyCommandHandler : IHandleMessages<SendMoneyCommand>
    {
        public IBus Bus { get; private set; }        

        public SendMoneyCommandHandler(IBus bus)
        {
            Bus = bus;
        }

        public async Task Handle(SendMoneyCommand message)
        {
            Console.WriteLine($"Got {message.Amount:c} in cash.");

            await Bus.Publish(new OrderCompletedEvent());
        }
    }
}
