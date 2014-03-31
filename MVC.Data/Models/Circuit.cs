using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Data.Models
{
    /// <summary>
    ///  This model inherits from Sitecore's own RenderingModel - see CircuitController.cs for use.
    /// </summary>
    public class Circuit : RenderingModel
    {
        // Use HtmlString rathre than string for any properties that you wish to edit with the Page Editor - this is because
        // in Page Editor mode, Sitecore outputs additional HTML to create the edit frames around your fields. If you simply use
        // 'string', MVC will escape your HTML and the Page Editor will not work.
        public HtmlString Name
        {
            get
            {
                // Because we are using Sitecore's FieldRenderer directly in the model, it is tightly
                // coupled with Sitecore and not testable. However, this is fine if testing is not your priority.                
                return new HtmlString(FieldRenderer.Render(this.Item, "Name"));
            }
        }

        public HtmlString Text
        {
            get
            {
                return new HtmlString(FieldRenderer.Render(this.Item, "Text"));
            }
        }
    }
}