using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MVC.Data.Domain;
using MVC.Data.Repositories;
using Sitecore.Mvc.Presentation;
using Sitecore.MVC.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Tutorial.IoC.Installers
{

    public class DefaultInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Castle.MicroKernel.Registration.Classes.FromThisAssembly()
                        .BasedOn<IController>()
                        .LifestyleTransient()
                        .Configure(x => x.Named(x.Implementation.FullName)));

            container.Register(Component.For<ILocationDomain>().ImplementedBy<LocationDomain>());
            container.Register(Component.For<ISitecoreRepository>().ImplementedBy<SitecoreRepository>());
            container.Register(Component.For<IRenderingContext>().ImplementedBy<RenderingContextWrapper>());
            container.Register(Component.For<IPageContext>().ImplementedBy<PageContextWrapper>());
        }
    }
}