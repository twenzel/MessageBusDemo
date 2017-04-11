using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoContracts;
using Rebus.Bus;
using Rebus.Handlers;

namespace OrderService
{
    public class CreateOrderHandler : IHandleMessages<CreateOrder>
    {
        public IBus Bus { get; private set; }

        public CreateOrderHandler(IBus bus)
        {
            Bus = bus;
        }

        public async Task Handle(CreateOrder message)
        {
            Console.WriteLine($"Received CreateOrder: Id = {message.Id}, Title = {message.Title}");

            await Bus.Publish(new OrderCreated
            {
                OrderId = message.Id
            });
        }
    }
}
