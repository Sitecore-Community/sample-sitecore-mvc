using Sitecore.Data;
using Sitecore.Data.Items;
using System;
namespace Sitecore.Mvc.Presentation
{
    public interface IItemWrapper
    {
        string DisplayName { get; }
        ID TemplateID { get; }
        Item Item { get; set; }
    }
}
