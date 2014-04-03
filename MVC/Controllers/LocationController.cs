using MVC.Data.Domain;
using MVC.Data.Repositories;
using MVC.Data.ViewModels;
using MVC.Data.Wrappers;
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
        public ILocationDomain _locationDomain;
        public LocationController(ILocationDomain locationDomain)
        {
            _locationDomain = locationDomain;
        }

        public ActionResult Featured()
        {
            LocationViewModel viewModel = new LocationViewModel();

            var pageContext = new PageContextWrapper();
            var renderingContext = new RenderingContextWrapper();

            viewModel.Location = _locationDomain.GetLocation(renderingContext.Item);

            if (viewModel.Location == null)
            {
                if (pageContext.IsPageEditor)
                {
                    return Content("<p>No location specified!");
                }

                return Content("");
            }

            return View(viewModel);
        }
    }
}
