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
using Rebus.Activation;
using Rebus.Config;
using Rebus.Routing.TypeBased;

namespace Sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var activator = new BuiltinHandlerActivator())
            {                
                var bus = Configure.With(activator)
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Info))
                    .Transport(t => t.UseRabbitMqAsOneWayClient("amqp://guest:guest@172.17.0.2"))
                    .Routing( r=> r.TypeBased().Map<CreateOrder>("order_input"))
                    .Start();


                bus.Send(new CreateOrder() {
                    Id = Guid.NewGuid().ToString("n").Substring(20),
                    Title = "new super duper mainframe"
                });
            }
        }
    }
}
