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
    class SendBeerHandler : IHandleMessages<SendBeer>
    {
        public IBus Bus { get; private set; }        

        public SendBeerHandler(IBus bus)
        {
            Bus = bus;            
        }

        public Task Handle(SendBeer message)
        {
            Console.WriteLine($"{message.Beer.Length} Beers are served.");

            return Task.FromResult<int>(0);
        }
    }
}
