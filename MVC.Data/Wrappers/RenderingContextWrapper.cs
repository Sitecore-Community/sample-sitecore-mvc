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
            if (RenderingContext.CurrentOrNull != null)
            {
                _renderingContext = RenderingContext.CurrentOrNull;
                
                if (_renderingContext.Rendering.Item != null)
                {
                    Item = new ItemWrapper(_renderingContext.Rendering.Item);
                }

            }
        }

        public ItemWrapper Item { get; set; }
        public RenderingParameters Parameters { get; set; }
    }
}
