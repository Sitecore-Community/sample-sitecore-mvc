using Sitecore.Data.Items;
using System;

namespace Sitecore.Mvc.Presentation
{
    public interface IRenderingWrapper
    {
        RenderingParameters Parameters { get; }
        IItem Item { get; }
    }
}
