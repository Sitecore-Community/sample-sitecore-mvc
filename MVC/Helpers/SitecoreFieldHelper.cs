using System.Web;
using Sitecore.Mvc.Helpers;
using Sitecore.Data.Items;

namespace MVC.Tutorial
{
    /// <summary>
    /// 
    /// </summary>
    public static class SitecoreFieldHelper
    {
        /// <summary>
        /// This is a custom field helper for image fields, allowing you to pass properties like 'max width' and 'max height' in as
        /// named parameters, rather than using new { }
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        /// <param name="mh"></param>
        /// <param name="mw"></param>
        /// <param name="disableWebEditing"></param>
        /// <returns></returns>
        public static HtmlString ImageField(this SitecoreHelper helper, string fieldName, Item item, int mh, int mw, bool disableWebEditing = false)
        {
            return helper.Field(fieldName, item, new { mh, mw, DisableWebEdit = disableWebEditing });
        }
    }
}