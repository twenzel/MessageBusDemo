﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoContracts;
using Rebus.Handlers;

namespace PaymentService
{
    public class OrderCreatedHandler : IHandleMessages<OrderCreated>
    {
        public Task Handle(OrderCreated message)
        {
            Console.WriteLine($"Received OrderCreated: OrderId = {message.OrderId}");

            return Task.CompletedTask;
        }
    }
}
