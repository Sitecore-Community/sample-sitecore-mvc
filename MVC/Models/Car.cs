using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Tutorial.Models
{
    public class Car : IRenderingModel
    {
        public HtmlString Make { get; set; }
        public HtmlString Model { get; set; }

        public Sitecore.Mvc.Presentation.Rendering Rendering { get; set; }
        public Item Item { get; set; }
        public Item PageItem { get; set; }

        public void Initialize(Sitecore.Mvc.Presentation.Rendering rendering)
        {
            Rendering = rendering;
            Item = rendering.Item;
            PageItem = PageContext.Current.Item;

            Make = new HtmlString(FieldRenderer.Render(Item, "Make"));
            Model = new HtmlString(FieldRenderer.Render(Item, "Model"));
        }
    }
}