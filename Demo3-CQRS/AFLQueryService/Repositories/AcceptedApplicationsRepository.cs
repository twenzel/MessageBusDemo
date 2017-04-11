using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLQueryService.Models;
using Raven.Client;

namespace AFLQueryService.Repositories
{
    public class AcceptedApplicationsRepository : DocumentRepository, IAcceptedApplicationsRepository
    {
        public AcceptedApplicationsRepository(IDocumentStore store)
            :base(store)
        {
        }

        public void AddApplication(AcceptedApplication acceptedApplication)
        {
            using (var session = OpenSession())
            {
                session.Store(acceptedApplication, acceptedApplication.Id);
                session.SaveChanges();
            }
        }

        public IEnumerable<AcceptedApplication> GetAll()
        {
            using (var session = OpenSession())
            {
                return session.Query<AcceptedApplication>().ToList();
            }
        }
    }
}
