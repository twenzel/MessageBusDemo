using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFLDomain.Infrastructure
{
    public interface IEventStore
    {
        void Store(object eventObject);
    }
}
