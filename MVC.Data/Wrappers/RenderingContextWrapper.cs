using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Mvc.Presentation
{
    public class RenderingContextWrapper : IRenderingContext 
    {
        public IRenderingWrapper Rendering {

            get
            {
                return new RenderingWrapper(RenderingContext.CurrentOrNull.Rendering);
            }
        }
    }
}
