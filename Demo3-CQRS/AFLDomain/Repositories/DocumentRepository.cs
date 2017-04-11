using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Embedded;

namespace AFLDomain.Repositories
{
    public abstract class DocumentRepository
    {
        private IDocumentStore _store;             

        public DocumentRepository(IDocumentStore store)
        {
            _store = store;
        }
  
        public IDocumentSession OpenSession()
        {
            return _store.OpenSession("Domain");
        }        
    }
}
