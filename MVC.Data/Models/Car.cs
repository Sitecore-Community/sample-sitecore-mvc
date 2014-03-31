using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Data.Models
{
    // This model is an example of how to use a custom model with a View Rendering. As you can see, it inherits from IRenderingModel,
    // which implements one method - Initialize. Sitecore's MVC pipelines will call the Initialize() method on when the specified model when the
    // View Rendering is loaded, and pass in the context Rendering object
    //
    // This model has a corresponding Sitecore item under /sitecore/Layouts/Models/Car that specify the full Model Type.
    // This model is used by the Featured Car rendering under /sitecore/Layouts/Renderings/MVC Tutorial/Featured Car
    //
    // This particular model would be quite difficult to test because it requires you to mock and pass in a Rendering object, which is
    // quite complex and ultimately relies on the Sitecore Item class, which is difficult to mock and test.
    public class Car : IRenderingModel
    {
        public HtmlString Make { get; set; }
        public HtmlString Model { get; set; }

        // Rendering represents the context rendering - this particular model is only ever used by View Renderings
        public Sitecore.Mvc.Presentation.Rendering Rendering { get; set; }

        // Item represents the rendering's datasource, and PageItem represents the context page
        // These properties exist on Sitecore's own RenderingModel object
        public Item Item { get; set; }
        public Item PageItem { get; set; }

        public void Initialize(Sitecore.Mvc.Presentation.Rendering rendering)
        {
            // Use the Rendering object passed in by Sitecore to set the datasource Item and context PageItem properties
            Rendering = rendering;
            Item = rendering.Item;
            PageItem = PageContext.Current.Item;

            // Set property values using FieldRenderer to ensure that the values are editable in the Page Editor
            Make = new HtmlString(FieldRenderer.Render(Item, "Make"));
            Model = new HtmlString(FieldRenderer.Render(Item, "Model"));
        }
    }
}