using MVC.Data.Domain;
using MVC.Data.Repositories;
using MVC.Data.ViewModels;
using Sitecore.Mvc.Presentation;
using Sitecore.MVC.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC.Tutorial.Controllers
{
    public class LocationController : Controller
    {
        /// <summary>
        /// This project uses Castle Windsor to inject dependencies into the controller. 
        /// Have a look at <see cref="MVC.Tutorial.IoC.Installers.DefaultInstallers"/> in the MVC.Tutorial project to see Castle Windsor
        /// injecting concrete classes. IPageContext and IRenderingContext are wrappers for Sitecore's RenderingContext and PageContext.
        /// </summary>
        private readonly ILocationDomain _locationDomain;
        private readonly IPageContext _pageContext;
        private readonly IRenderingContext _renderingContext;
        public LocationController(ILocationDomain locationDomain, IPageContext pageContext, IRenderingContext renderingContext)
        {
            _locationDomain = locationDomain;
            _pageContext = pageContext;
            _renderingContext = renderingContext;
        }

        /// <summary>
        /// What if you don't - or can't - use an IoC container like Castle? Below is an example of poor man's dependency injection. You are unlikely to see
        /// this in the wild! However, if you are building an application that cannot rely on your choice of IoC container, you might have to do something
        /// like this.
        /// </summary>
        public LocationController() : this(new LocationDomain(new SitecoreRepository()), new PageContextWrapper(), new RenderingContextWrapper())
        {
            // A cleaner (but still not good) way would be to delegate the instantiation of the LocationController to a service locator of some kind
            // e.g.  public LocationController() : ApplicationController.CreateLocationController()
        }

        /// <summary>
        ///  This ActionResult is used by the 'Featured Location' component.
        /// </summary>
        /// <returns></returns>
        public ActionResult Featured()
        {
            LocationViewModel viewModel = new LocationViewModel();
            
            // There should be no data retrieval logic in your controller - therefore, we have delegated the
            // Location model fetching to an ILocationDomain object, which contains all our business logic.
            // It takes our IRenderingContext wrapper and a list of field parameters, which we could mock if we wanted to unit test our controller.
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            // In this particular instance, we do not want the 'Name' field to be editable in the Page Editor
            parameters.Add("Name", "?disable-web-editing=true");

            viewModel.Location = _locationDomain.GetLocation(_renderingContext.Rendering.Item, parameters);

            if (viewModel.Location == null)
            {
                // Ideally, we would want to crete a NoDatasource action and use RedirectToAction if no location is returned,
                // but it is not possible to use RedirectToAction with Sitecore ( you get that view only, rather than an assembled Sitecore page).
                // The compromise is to return a separate view - this one can be used for any rendering that needs a 'no datasource set' message
                // display in Page Editor.
                if (_pageContext.IsPageEditor)
                {
                    return View("~/Views/Shared/_NoDatasource.cshtml");
                }

                // The visitor does not need to see anything at all if no datasource has been set for this particular rendering.
                return new EmptyResult();
            }

            return View(viewModel);
        }
    }
}
