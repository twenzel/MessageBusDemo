using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Messages;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rebus.Auditing.Messages;
using Rebus.Config;
using Rebus.Routing.TypeBased;

namespace TheBar.Installers
{
    public class RebusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SagaConnection"].ConnectionString;

            Configure.With(new CastleWindsorContainerAdapter(container))
                    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Warn))
                    .Routing(r =>
                    {
                        r.TypeBased().MapAssemblyOf<GiveBeer>("thebar").Map<BeerPriceUpdatedEvent>("thetrader");
                    })                    
                    .Transport(t => t.UseMsmq("thebar"))
                    .Sagas(s => s.StoreInSqlServer(connectionString, "Sagas", "SagaIndex"))
                    .Timeouts(t =>
                    {                                                
                        // store timeouts in SQL Server to make them persistent and survive restarts
                        t.StoreInSqlServer(connectionString, "Timeouts");
                    })
                    .Start();
            
        }
    }
}
