using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MVC.Data.Domain;
using MVC.Data.Repositories;
using MVC.Data.Services;
using Sitecore.Mvc.Presentation;
using Sitecore.MVC.Presentation;
using System.Web.Mvc;

namespace MVC.Web.IoC.Installers
{
    public class DefaultInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Castle.MicroKernel.Registration.Classes.FromThisAssembly()
                        .BasedOn<IController>()
                        .LifestyleTransient()
                        .Configure(x => x.Named(x.Implementation.FullName)));

            container.Register(Component.For<ILocationDomain>().ImplementedBy<LocationDomain>().Named("MVC.LocationDomain"));
            container.Register(Component.For<ISitecoreRepository>().ImplementedBy<SitecoreRepository>().Named("Mvc.SitecoreRepository"));
            container.Register(Component.For<IRenderingContext>().ImplementedBy<RenderingContextWrapper>().Named("Mvc.RenderingContextWrapper"));
            container.Register(Component.For<IPageContext>().ImplementedBy<PageContextWrapper>().Named("Mvc.PageContextWrapper"));
            container.Register(Component.For<ISearchService>().ImplementedBy<SearchService>().Named("Mvc.SearchService"));
        }
    }
}