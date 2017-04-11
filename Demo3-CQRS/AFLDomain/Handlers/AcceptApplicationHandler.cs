using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLContracts.Messages;
using AFLDomain.Domains;
using MassTransit;

namespace AFLDomain.Handlers
{
    public class AcceptApplicationHandler : IConsumer<AcceptApplication>
    {
        private readonly IApplicationForLeaveService _service;

        public AcceptApplicationHandler(IApplicationForLeaveService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<AcceptApplication> context)
        {
            await Console.Out.WriteLineAsync($"Accepting application: {context.Message.ApplicationId}");

            _service.AcceptApplication(context.Message);           
        }
    }
}
