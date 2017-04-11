using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFLDomain.Infrastructure
{
    public class InMemoryEventStore : IEventStore
    {
        public List<object> Events { get; private set; } = new List<object>();

        public void Store(object eventObject)
        {
            Events.Add(eventObject); 
        }
    }
}
