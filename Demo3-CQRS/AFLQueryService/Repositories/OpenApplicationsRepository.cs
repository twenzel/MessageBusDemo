using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLQueryService.Models;
using Raven.Client;

namespace AFLQueryService.Repositories
{
    public class OpenApplicationsRepository : DocumentRepository, IOpenApplicationsRepository
    {
        public OpenApplicationsRepository(IDocumentStore store)
            :base(store)
        {
        }

        public void RemoveApplication(string applicationId)
        {
            using (var session = OpenSession())
            {
                var item = session.Query<OpenApplication>().FirstOrDefault(a => a.ApplicationId == applicationId);

                if (item != null)
                {
                    session.Delete(item);
                    session.SaveChanges();
                }
            }
        }

        public IEnumerable<OpenApplication> GetAll()
        {
            using (var session = OpenSession())
            {
                return session.Query<OpenApplication>().ToList();
            }
        }


        public void AddRequest(OpenApplication request)
        {
            using (var session = OpenSession())
            {
                session.Store(request);
                session.SaveChanges();
            }
        }
    }
}
