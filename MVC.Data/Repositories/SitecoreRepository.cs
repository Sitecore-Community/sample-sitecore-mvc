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
        public string GetField(string fieldName, ItemWrapper item, string parameters)
        {
            return FieldRenderer.Render(item.Item, fieldName, parameters);
        }

        public string GetField(string fieldName, ItemWrapper item)
        {
            return FieldRenderer.Render(item.Item, fieldName);
        }
    }
}
