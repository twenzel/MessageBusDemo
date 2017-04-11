using Beer.Messages;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class EventHandler: IHandleMessages<BeerPriceUpdatedEvent>, IHandleMessages<BeerOrderedEvent>
    {
        private readonly BeerMarketConnector _connector;

        public EventHandler(BeerMarketConnector connector)
        {
            _connector = connector;
        }

        public Task Handle(BeerPriceUpdatedEvent message)
        {
            _connector.RaiseBeerPriceChanged(message.PricePerBottle);

            return Task.FromResult<int>(0);
        }

        public Task Handle(BeerOrderedEvent message)
        {
            _connector.RaiseBeerOrdered(message.Amount);

            return Task.FromResult<int>(0);
        }
    }
}
