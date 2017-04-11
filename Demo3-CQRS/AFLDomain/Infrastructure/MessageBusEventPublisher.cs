using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;

namespace AFLDomain.Infrastructure
{
    public class MessageBusEventPublisher : IEventPublisher
    {
        private IPublishEndpoint _endpoint;

        public MessageBusEventPublisher(IPublishEndpoint endPoint)
        {
            _endpoint = endPoint;
        }

        public void Publish(object eventObject)
        {
            _endpoint.Publish(eventObject);
        }
    }
}
