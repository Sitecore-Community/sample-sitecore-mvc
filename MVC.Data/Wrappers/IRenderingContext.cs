using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Mvc.Presentation
{
    public interface IRenderingContext
    {
        IRenderingWrapper Rendering { get; }
    }
}
