using MVC.Data.Models;
using Sitecore.Links;
using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC.Tutorial.Controllers
{
    public class CircuitController : Controller
    {
        /// <summary>
        /// This ActionResult is used by the Controller Rendering 'Featured Circuit' - the Sitecore item is located under
        /// /sitecore/Layout/Renderings/MVC Tutorial/Featured Circuit. This Controller Rendering shows how to use a custom model
        /// that inherits Sitecore's own RenderingModel class.
        /// </summary>
        /// <returns></returns>
        public ActionResult Featured()
        {            
            Circuit circuit = new Circuit();

            // The RenderingModel base class has an Initialize() method that expects the context rendering. By using .Initialize(), 
            // you make other properties - such as .Item, which represents the rendering's datasource - available. Notice that because
            // we are using RenderingContext.Current.Rendering directly in this Controller, we have a dependency on Sitecore.
            circuit.Initialize(RenderingContext.Current.Rendering);

            return View(circuit);
        }
    }
}
