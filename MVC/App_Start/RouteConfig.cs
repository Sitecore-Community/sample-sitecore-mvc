using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
            "SearchResults", // Route name
            "Search/{criteria}/{page}", // URL with parameters
            new
            {
                action = "SearchIndex",
                controller = "Search",
                scItemPath = "/sitecore/content/Home/Search Results",
                partialView = "true",
                criteria = UrlParameter.Optional,
                page = UrlParameter.Optional
            });

            routes.MapRoute(
            "Registration", // Route name
            "Registration", // URL with parameters
            new
            {
                action = "RegistrationIndex",
                controller = "RegistrationForm",
                scItemPath = "/sitecore/content/Home/Registration",
                partialView = "true"
            });

            routes.MapRoute(
            "RegistrationStep2", // Route name
            "Registration/Step2", // URL with parameters
            new
            {
                scItemPath = "/sitecore/content/Home/Registration/Registration - Step 2",
                partialView = "true"
            });

            routes.MapRoute(
            "RegistrationStep3", // Route name
            "Registration/Confirm", // URL with parameters
            new
            {
                scItemPath = "/sitecore/content/Home/Registration/Registration - Step 3",
                partialView = "true"
            });

            routes.MapRoute(
            "RegistrationFinal", // Route name
            "Registration/Complete", // URL with parameters
            new
            {
                scItemPath = "/sitecore/content/Home/Registration/Registration - Final",
                partialView = "true"
            });
        }
    }
}