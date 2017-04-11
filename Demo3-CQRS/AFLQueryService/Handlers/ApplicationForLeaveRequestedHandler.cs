using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLContracts.Messages;
using AFLQueryService.Models;
using AFLQueryService.Repositories;
using MassTransit;

namespace AFLQueryService.Handlers
{  
    public class ApplicationForLeaveRequestedHandler : IConsumer<ApplicationForLeaveRequested>
    {
        private IOpenApplicationsRepository _openRepository;        

        public ApplicationForLeaveRequestedHandler(IOpenApplicationsRepository openRepository)
        {
            _openRepository = openRepository;            
        }

        public async Task Consume(ConsumeContext<ApplicationForLeaveRequested> context)
        {
            await Console.Out.WriteLineAsync($"received application request: {context.Message.ApplicationId}");

            _openRepository.AddRequest(new OpenApplication() {
                From = context.Message.From,
                To = context.Message.To,
                ApplicationId = context.Message.ApplicationId,
                Requester = context.Message.Requester,
            });            
        }
    }
}
