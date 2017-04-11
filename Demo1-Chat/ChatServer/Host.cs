using Shuttle.Core.Host;
using Shuttle.Esb;
using Shuttle.Esb.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    public class Host : IHost, IDisposable
    {
        private IServiceBus _bus;

        public void Start()
        {
            _bus = ServiceBus.Create(c => c.SubscriptionManager(SubscriptionManager.Default())).Start();
        }

        public void Dispose()
        {
            _bus.Dispose();
        }
    }
}
