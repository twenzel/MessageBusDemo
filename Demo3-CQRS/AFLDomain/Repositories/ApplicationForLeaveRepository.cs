using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLDomain.Domains;
using Raven.Client;

namespace AFLDomain.Repositories
{
    public class ApplicationForLeaveRepository : DocumentRepository, IApplicationForLeaveRepository
    {
        public ApplicationForLeaveRepository(IDocumentStore store)
            :base(store)
        {            
        }

        public void Add(ApplicationForLeave application)
        {
            using (IDocumentSession session = OpenSession())
            {
                session.Store(application);

                session.SaveChanges();
            }
        }

        public ApplicationForLeave GetApplication(string applicationId)
        {
            using (IDocumentSession session = OpenSession())
            {
                return session.Load<ApplicationForLeave>(applicationId);
            }
        }

        public void Update(ApplicationForLeave application)
        {
            using (IDocumentSession session = OpenSession())
            {
                session.Store(application);

                session.SaveChanges();
            }

        }
    }
}
