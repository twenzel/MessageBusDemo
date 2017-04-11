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
    class GiveBeerComandHandler : IHandleMessages<GiveBeerCommand>
    {
        public IBus Bus { get; private set; }
        public ICashier Cashier { get; private set; }        

        public GiveBeerComandHandler(IBus bus, ICashier cashier)
        {
            Bus = bus;
            Cashier = cashier;
        }

        public async Task Handle(GiveBeerCommand message)
        {
            Console.WriteLine($"GiveBeerCommand recieved");            

            await Bus.Reply(new SendBeerCommand
            {
                TotalPrice = message.Amount * Cashier.GetPricePerBottle(),
                Beer = message.Amount.Times(() => new Beer.Messages.Beer()).ToArray()
            });

            await Bus.Publish(new BeerOrderedEvent() { Amount = message.Amount });
        }
    }
}
