using Beer.Messages;
using Rebus.Bus;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Handlers
{ 
    class SendBeerCommandHandler : IHandleMessages<SendBeerCommand>
    {
        public IBus Bus { get; private set; }        

        public SendBeerCommandHandler(IBus bus)
        {
            Bus = bus;            
        }

        public async Task Handle(SendBeerCommand message)
        {
            Console.WriteLine($"{message.Beer.Length} Beers are served. Makes {message.TotalPrice:c}.");

            await Bus.Reply(new SendMoneyCommand
            {
                Amount = message.TotalPrice.RoundToNextNoteValue()
            });
        }
    }
}
