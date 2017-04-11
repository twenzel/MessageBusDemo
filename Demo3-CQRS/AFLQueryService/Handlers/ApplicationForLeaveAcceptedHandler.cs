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
    public class ApplicationForLeaveAcceptedHandler : IConsumer<ApplicationForLeaveAccepted>
    {
        private IOpenApplicationsRepository _openRepository;
        private IAcceptedApplicationsRepository _acceptedRepository;

        public ApplicationForLeaveAcceptedHandler(IOpenApplicationsRepository openRepository, IAcceptedApplicationsRepository acceptedRepository)
        {
            _openRepository = openRepository;
            _acceptedRepository = acceptedRepository;
        }

        public async Task Consume(ConsumeContext<ApplicationForLeaveAccepted> context)
        {
            await Console.Out.WriteLineAsync($"received application accepted: {context.Message.ApplicationId}");

            _openRepository.RemoveApplication(context.Message.ApplicationId);

            _acceptedRepository.AddApplication(new AcceptedApplication() {
                AcceptedOn = context.Message.AcceptedOn,
                From = context.Message.From,
                To = context.Message.To,
                ApplicationId = context.Message.ApplicationId.ToString(),
                Requester = context.Message.Requester,
            });
        }
    }
}
