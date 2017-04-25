using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoContracts;
using NServiceBus;

namespace OrderService
{
    public class CreateOrderHandler : IHandleMessages<CreateOrder>
    {
        public Task Handle(CreateOrder message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received CreateOrder: Id = {message.Id}, Title = {message.Title}");

            return context.Publish(new OrderCreated
            {
                OrderId = message.Id
            });
        }
    }
}
