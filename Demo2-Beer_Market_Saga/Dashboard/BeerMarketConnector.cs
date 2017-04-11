using Beer.Messages;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class BeerMarketConnector : IDisposable
    {
        private BuiltinHandlerActivator _activator;

        public event EventHandler<decimal> BeerPriceChanged;
        public event EventHandler<int> BeerOrdered;

        public void Dispose()
        {
            _activator?.Dispose();
        }

        public void RaiseBeerPriceChanged(decimal pricePerBottle)
        {
            BeerPriceChanged?.Invoke(this, pricePerBottle);           
        }

        public void RaiseBeerOrdered(int amount)
        {
            BeerOrdered?.Invoke(this, amount);            
        }

        public void Init()
        {
            _activator = new BuiltinHandlerActivator();

            _activator.Register(() => new EventHandler(this));

            var bus = Configure.With(_activator)
                .Transport(t => t.UseMsmq("dashboard"))
                 .Routing(r => r.TypeBased()           
                    .Map<BeerPriceUpdatedEvent>("thetrader")
                    .Map<BeerOrderedEvent>("thebar")
                 )                 
                .Start();

            bus.Subscribe<BeerPriceUpdatedEvent>();
            bus.Subscribe<BeerOrderedEvent>();
        }
    }
}
