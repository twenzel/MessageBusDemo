using System;
using Castle.Windsor;
using TheBar.Installers;

namespace TheBar
{
    class Program
    {
        static void Main(string[] args)
        {
            // change output encoding for correct currency sign display
            Console.OutputEncoding = System.Text.Encoding.UTF8;

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
