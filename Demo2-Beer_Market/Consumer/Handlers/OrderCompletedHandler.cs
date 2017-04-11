using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Messages;
using Rebus.Handlers;

namespace Consumer.Handlers
{   
    public class OrderCompletedHandler : IHandleMessages<OrderCompletedEvent>
    {       
        public Task Handle(OrderCompletedEvent message)
        {
            Console.WriteLine("Great!\r\n");

            Console.WriteLine($"How many beers do you would like to have?");
            return Task.FromResult<int>(0);
        }
    }
}
