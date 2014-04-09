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
        string GetFieldValue(string fieldName, IItem item, string parameters);
        string GetFieldValue(string fieldName, IItem item);
        bool FieldExists(string fieldName, IItem item);
    }
}
