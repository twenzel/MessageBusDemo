using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoContracts;
using NServiceBus;

namespace Sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName: "order_sender");

            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UseTransport<RabbitMQTransport>().ConnectionString("host=172.17.0.2;username=guest;password=guest");
            endpointConfiguration.SendOnly();

            // Initialize the endpoint with the finished configuration
            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            try
            {
                var cmd = new CreateOrder()
                {
                    Id = Guid.NewGuid().ToString("n").Substring(20),
                    Title = "new super duper mainframe"
                };

                await endpointInstance.Send("order_input", cmd);
            }
            finally
            {
                await endpointInstance.Stop()
                    .ConfigureAwait(false);
            }
        }
    }
}
