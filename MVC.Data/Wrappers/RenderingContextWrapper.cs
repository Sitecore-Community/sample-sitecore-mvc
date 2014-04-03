using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Wrappers
{
    public class RenderingContextWrapper
    {
        RenderingContext _renderingContext;
        public RenderingContextWrapper()
        {
            Item = new ItemWrapper();

            if (RenderingContext.CurrentOrNull != null)
            {
                _renderingContext = RenderingContext.CurrentOrNull;
                
                if (_renderingContext.Rendering.Item != null)
                {
                    Item.Item = _renderingContext.Rendering.Item;
                }

            }
        }

        public ItemWrapper Item { get; set; }
        public RenderingParameters Parameters { get; set; }
    }
}
