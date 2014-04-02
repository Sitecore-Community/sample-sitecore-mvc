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
        public string GetField(string fieldName, ItemWrapper item, string parameters)
        {
            return item.Fields[fieldName].Value + parameters;
        }

        public string GetField(string fieldName, ItemWrapper item)
        {
            return item.Fields[fieldName].Value;
        }
    }
}
