using Beer.Messages;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Rebus.Auditing.Messages;
using Rebus.CastleWindsor;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TheBar.Installers;

namespace TheBar
{
    class Program
    {
        static void Main(string[] args)
        {            
            using (var container = new WindsorContainer())
            {                                                             
                container
                    .Install(new MessageHandlersInstaller())
                    .Install(new RebusInstaller())
                    .Install(new StartupActions());

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
