using MVC.Data.Wrappers;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    public class FakeRepository : ISitecoreRepository
    {
        public string GetFieldValue(string fieldName, ItemWrapper item, string parameters)
        {
            return fieldName + parameters;
        }

        public string GetFieldValue(string fieldName, ItemWrapper item)
        {
            return fieldName;
        }

        public bool FieldExists(string fieldName, ItemWrapper item)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                return true;
            }

            return false;
        }
    }
}
