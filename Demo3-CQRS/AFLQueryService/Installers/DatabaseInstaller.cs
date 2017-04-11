using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Raven.Client;
using Raven.Client.Embedded;

namespace AFLQueryService.Installers
{
    public class DatabaseInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IDocumentStore documentStore = new EmbeddableDocumentStore
            {
                ConnectionStringName = "RavenDB",
                UseEmbeddedHttpServer = true
            };
            
            documentStore.Initialize();

            documentStore.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists("QueryService");


            container.Register(Component.For<IDocumentStore>().Instance(documentStore));
        }
    }
}
