using System.Web;
using Sitecore.Mvc.Helpers;
using Sitecore.Data.Items;

namespace MVC.Tutorial
{
    public static class SitecoreFieldHelper
    {
        public static HtmlString ImageField(this SitecoreHelper helper, string fieldName, Item item, int mh, int mw, bool disableWebEditing = false)
        {
            return helper.Field(fieldName, item, new { mh, mw, DisableWebEdit = disableWebEditing });
        }
    }
}