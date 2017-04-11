using Beer.Messages;
using Rebus.Bus;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTrader.Handlers
{    
    class BeerOrderedEventHandler : IHandleMessages<BeerOrderedEvent>
    {        
        public IBus Bus { get; private set; }
        public PriceCalculator Calculator { get; private set; }
        private decimal _currentPrice = PriceCalculator.BASE_PRICE;

        public BeerOrderedEventHandler(IBus bus, PriceCalculator calculator)
        {
            Bus = bus;
            Calculator = calculator;
        }

        public async Task Handle(BeerOrderedEvent message)
        {
            Console.WriteLine($"{message.Amount} beers ordered.");
           
            var newPrice = Calculator.CalcPrice(message.Amount);

            if (newPrice != _currentPrice)
            {
                _currentPrice = newPrice;

                await Bus.Publish(new BeerPriceUpdatedEvent
                {
                    PricePerBottle = newPrice
                });
            }
        }    
    }
}
