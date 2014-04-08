using Sitecore.Data.Items;
using System;

namespace Sitecore.Mvc.Presentation
{
    public interface IRenderingWrapper
    {
        RenderingParameters Parameters { get; }
        IItemWrapper Item { get; }
    }
}
