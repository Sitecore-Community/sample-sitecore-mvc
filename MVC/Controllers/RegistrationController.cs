using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVC.Data.ViewModels;

namespace MVC.Web.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: /Registration/
        public ActionResult Index()
        {
            var model = new RegisterViewModel();

            return View("~/Views/Registration/Register.cshtml", model);
        }

        public ActionResult Step2()
        {
            var model = new RegisterViewModel();

            if (Session["Register"] == null)
            {
                return RedirectToRoute("Registration");
            } else
            {
                model = (RegisterViewModel)Session["Register"];
            }

            return View("~/Views/Registration/Register2.cshtml", model);
        }

        public ActionResult Step3()
        {
            var model = (RegisterViewModel)Session["Register"];

            if (model == null)
            {
                return RedirectToRoute("Registration");
            }

            return View("~/Views/Registration/Register3.cshtml", model);
        }

        public ActionResult Final()
        {
            var model = (RegisterViewModel)Session["Register"];

            if (model == null)
            {
                return RedirectToRoute("Registration");
            }

            return View("~/Views/Registration/RegisterFinal.cshtml", model);
        }


    }
}
