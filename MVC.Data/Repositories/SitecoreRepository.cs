using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    /// <summary>
    /// Any methods that require us to touch Sitecore are isolated to this repository - data retrieval only,
    /// no business logic.
    /// </summary>
    public class SitecoreRepository : ISitecoreRepository
    {
        public string GetFieldValue(string fieldName, IItemWrapper item, string parameters)
        {
            return FieldRenderer.Render(item.Item, fieldName, parameters);
        }

        public string GetFieldValue(string fieldName, IItemWrapper item)
        {
            return FieldRenderer.Render(item.Item, fieldName);
        }
    
        public bool FieldExists(string fieldName, IItemWrapper item)
        {
            if (item.Item[fieldName] != null)
            {
                return true;
            }

            return false;
        }
    }
}
