using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Mvc.Presentation
{
    public class RenderingWrapper : IRenderingWrapper
    {
        private Rendering _rendering;
        public RenderingWrapper(Rendering rendering)
        {
            _rendering = rendering;
        }

        public IItem Item
        {
            get
            {
                if (_rendering.Item != null)
                {
                    return new ItemWrapper(_rendering.Item);
                }

                return null;
            }
        }

        public RenderingParameters Parameters
        {
            get
            {
                return _rendering.Parameters;
            }
        }
    }
}
