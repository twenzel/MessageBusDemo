using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Messages;
using Rebus.Handlers;

namespace Consumer.Handlers
{
    public class OrderFinishedHandler : IHandleMessages<OrderCompleted>, IHandleMessages<OrderCanceled>
    {
        public Task Handle(OrderCanceled message)
        {
            Console.WriteLine("Too late. Next customer will be served.\r\n");

            Console.WriteLine($"How many beers do you would like to have, {message.CustomerName}?");

            return Task.FromResult<int>(0);
        }

        public Task Handle(OrderCompleted message)
        {
            Console.WriteLine("Great!\r\n");

            Console.WriteLine($"How many beers do you would like to have, {message.CustomerName}?");
            return Task.FromResult<int>(0);
        }
    }
}
