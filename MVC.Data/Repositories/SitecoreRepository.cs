using MVC.Data.Wrappers;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    public class SitecoreRepository : ISitecoreRepository
    {
        public string GetFieldValue(string fieldName, ItemWrapper item, string parameters)
        {
            return FieldRenderer.Render(item.Item, fieldName, parameters);
        }

        public string GetFieldValue(string fieldName, ItemWrapper item)
        {
            return FieldRenderer.Render(item.Item, fieldName);
        }
    
        public bool FieldExists(string fieldName, ItemWrapper item)
        {
            if (item.Item[fieldName] != null)
            {
                return true;
            }

            return false;
        }
    }
}
