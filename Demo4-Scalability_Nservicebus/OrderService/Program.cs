using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using NServiceBus;
using NServiceBus.Logging;

namespace OrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "Order Service";
            var endpointConfiguration = new EndpointConfiguration("order_input");
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UseTransport<RabbitMQTransport>()
                   .ConnectionString("host=172.17.0.2;username=guest;password=guest");
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");

            var defaultFactory = LogManager.Use<DefaultFactory>();
            defaultFactory.Level(LogLevel.Warn);

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            try
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            finally
            {
                await endpointInstance.Stop().ConfigureAwait(false);
            }
        }
    }
}
