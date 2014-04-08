using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    public interface ISitecoreRepository
    {
        string GetFieldValue(string fieldName, IItemWrapper item, string parameters);
        string GetFieldValue(string fieldName, IItemWrapper item);
        bool FieldExists(string fieldName, IItemWrapper item);
    }
}
