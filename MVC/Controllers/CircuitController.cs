using MVC.Tutorial.Models;
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
    public class CircuitController : Controller
    {
        public ActionResult Featured()
        {
            Circuit circuit = new Circuit();

            circuit.Initialize(RenderingContext.Current.Rendering);

            return View(circuit);
        }
    }
}
