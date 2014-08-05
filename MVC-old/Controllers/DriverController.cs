using MVC.Data.Repositories;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC.Tutorial.Controllers
{
    /// <summary>
    /// The DriverController demonstrates how to use the repository pattern to populate a custom model to allow for
    /// maximum testability. 
    /// </summary>
    public class DriverController : Controller
    {
        // You could - and should - inject your repositories. In this example, we are telling the controller to use a hard-coded
        // instance of DriverRepository (which contains Sitecore code) if no repository was provided. Realistically, you would 
        // keep this information in your application root, where you configure your IoC container (like Castle Windsor, or Ninject).
        IDriverRepository _driverRepository;
        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverController()
        {
            _driverRepository = new DriverRepository();
        }

        /// <summary>
        /// This ActionResult is used by the Controller Rendering 'Featured Driver' - the Sitecore item is located under
        /// /sitecore/Layout/Renderings/MVC Tutorial/Featured Driver. This Controller Rendering shows how to use a custom model
        /// that is populated by a repository.
        /// </summary>
        /// <returns></returns>
        public ActionResult Featured()
        {
            var repository = _driverRepository;

            // Technically, models should only contain data about that model - for example, the Driver model only contains the driver's
            // name and description. It should not contain additional information requried by the View Rendering, such as the background
            // colour or font size. 
            // 
            // In this example, the Controller Rendering has a number of parameters that the author can pick from, including Background Colour.
            // We use the repository to return a DriverViewModel, which is populated with the author's choices, rather than cramming that
            // information into the Driver model, where it does not belong.
            var driver = repository.GetDriver();
            var driverViewModel = repository.GetDriverViewModel(driver);

            return View(driverViewModel);
        }
    }
}
