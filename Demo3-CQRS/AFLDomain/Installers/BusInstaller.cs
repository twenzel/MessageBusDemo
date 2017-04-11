using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLDomain.Handlers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AFLDomain.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {           
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://172.17.0.2"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "domain_input", e =>
                {
                    e.LoadFrom(container);
                });
            });
            
            container.Register(Component.For<IBus, IBusControl, IPublishEndpoint>().Instance(busControl));         

            busControl.Start();
        }
    }

    public static class BusInstallerUtil
    {
        public static void RegisterStoppingBus(this IApplicationBuilder app, IApplicationLifetime lifetime)
        {
            lifetime.ApplicationStopping.Register(() => {
                IBusControl busControl = app.ApplicationServices.GetService<IBusControl>();
                busControl.Stop();

            });
        }
    }
}
