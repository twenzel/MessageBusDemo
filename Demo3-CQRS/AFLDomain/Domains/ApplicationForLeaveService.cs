using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLContracts.Messages;
using AFLDomain.Infrastructure;
using AFLDomain.Repositories;

namespace AFLDomain.Domains
{
    public class ApplicationForLeaveService : IApplicationForLeaveService
    {
        private readonly IEventStore _eventStore;
        private readonly IEventPublisher _publisher;
        private readonly IApplicationForLeaveRepository _repository;

        public ApplicationForLeaveService(IEventStore store, IEventPublisher publisher, IApplicationForLeaveRepository repository)
        {
            _eventStore = store;
            _publisher = publisher;
            _repository = repository;
        }

        public void AcceptApplication(AcceptApplication message)
        {
            var application = _repository.GetApplication(message.ApplicationId);

            if (application == null)
                throw new ArgumentException($"No application for leave with id {message.ApplicationId} found!");

            application.IsAccepted = true;
            application.AcceptedOn = DateTime.Now;
            _repository.Update(application);

            var newEvent = new ApplicationForLeaveAccepted()
            {
                Requester = application.Requester,
                From = application.From,
                To = application.To,
                ApplicationId = application.Id,
                AcceptedOn = application.AcceptedOn
            };

            _eventStore.Store(newEvent);
            _publisher.Publish(newEvent);        
        }

        public void CreateApplicationRequest(ApplicationForLeave applicationForLeave)
        {
            _repository.Add(applicationForLeave);

            var newEvent = new ApplicationForLeaveRequested()
            {
                Requester = applicationForLeave.Requester,
                From = applicationForLeave.From,
                To = applicationForLeave.To,
                ApplicationId = applicationForLeave.Id                
            };

            _eventStore.Store(newEvent);
            _publisher.Publish(newEvent);
        }
    }
}
