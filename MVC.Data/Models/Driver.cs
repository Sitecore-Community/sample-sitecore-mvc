using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Data.Models
{
    /// <summary>
    ///  This light-weight model is used as an example of how you can isolate Sitecore-dependent code into a repository, which
    ///  means your models have no dependency on Sitecore and look much more like regular ASP.NET MVC models. See DriverController.cs
    ///  for usage.
    /// </summary>
    public class Driver
    {
        public HtmlString Name { get; set; }
        public HtmlString Text { get; set; }
        public HtmlString Image { get; set; }
    }
}