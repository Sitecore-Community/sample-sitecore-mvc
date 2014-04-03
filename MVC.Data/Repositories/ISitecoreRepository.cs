using MVC.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    public interface ISitecoreRepository
    {
        string GetFieldValue(string fieldName, ItemWrapper item, string parameters);
        string GetFieldValue(string fieldName, ItemWrapper item);
        bool FieldExists(string fieldName, ItemWrapper item);
    }
}
