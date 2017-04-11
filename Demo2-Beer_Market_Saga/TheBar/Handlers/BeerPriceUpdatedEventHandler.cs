using Beer.Messages;
using Rebus.Bus;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBar.Handlers
{
    class BeerPriceUpdatedEventHandler : IHandleMessages<BeerPriceUpdatedEvent>
    {
        public IBus Bus { get; private set; }
        public ICashier Cashier { get; private set; }

        public BeerPriceUpdatedEventHandler(IBus bus, ICashier cashier)
        {
            Bus = bus;
            Cashier = cashier;
        }

        public Task Handle(BeerPriceUpdatedEvent message)
        {
            Console.WriteLine($"BeerPrice updated to {message.PricePerBottle:c}");

            Cashier.UpdatePricePerBottle(message.PricePerBottle);

            return Task.FromResult<int>(0);
        }
    }
}
