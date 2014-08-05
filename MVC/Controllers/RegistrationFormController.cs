using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using MVC.Data.ViewModels;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;

namespace MVC.Web.Controllers
{
    public class RegistrationFormController : SitecoreController
    {

        public ActionResult RegistrationIndex()
        {

            return base.Index();
        }

        [HttpPost]
        public ActionResult Submit(RegisterViewModel customerDetails)
        {
            if(ModelState.IsValid)
            {
                Session["Register"] = customerDetails;

                //Redirect to a route
                return RedirectToRoute("RegistrationStep2");
            }

            IView pageView = PageContext.Current.PageView;
            if (pageView == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return (ActionResult)this.View(pageView);
            }

        }

        [HttpPost]
        public ActionResult SubmitStep2(RegisterViewModel step2Details)
        {
            if(ModelState.IsValid)
            {
                Session["Register"] = step2Details;

                //Redirect to a route 
                return RedirectToRoute("RegistrationStep3");
            }


            IView pageView = PageContext.Current.PageView;
            if (pageView == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return (ActionResult)this.View(pageView);
            }

        }

        [HttpPost]
        public ActionResult SubmitStep3(RegisterViewModel step3Details)
        {
            if(ModelState.IsValid)
            {
                Session["Register"] = step3Details;

                //Do your form processing stuff here
                //*******

                //Redirect to a route
                return RedirectToRoute("RegistrationFinal");
            }

            IView pageView = PageContext.Current.PageView;
            if (pageView == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return (ActionResult)this.View(pageView);
            }

        }
    }
}
