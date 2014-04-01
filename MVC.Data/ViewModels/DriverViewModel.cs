using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Data.Models
{
    /// <summary>
    /// The driver view model contains data about the rendering that does not need to be stored in the actual model - like
    /// that particular rendering's background colour, or a reference to the context item (the current page).
    /// </summary>
    public class DriverViewModel
    {
        public Driver Driver { get; set; }

        public string Background { get; set; }
        
        public Item ContextItem { get; set; }
    }
}