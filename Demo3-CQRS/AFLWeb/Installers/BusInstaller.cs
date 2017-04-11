using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AFLWeb.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                // using app setttings directly
                cfg.Host(new Uri(ConfigurationManager.AppSettings["rabbitMQHost"]), h =>
                {
                    h.Username(ConfigurationManager.AppSettings["rabbitMQHostUser"]);
                    h.Password(ConfigurationManager.AppSettings["rabbitMQHostPassword"]);
                });
            });

            container.Register(Component.For<ISendEndpointProvider, IBusControl>().Instance(busControl));            

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
