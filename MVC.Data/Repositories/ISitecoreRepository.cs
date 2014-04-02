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
        string GetField(string fieldName, ItemWrapper item, string parameters);
        string GetField(string fieldName, ItemWrapper item);
    }
}
