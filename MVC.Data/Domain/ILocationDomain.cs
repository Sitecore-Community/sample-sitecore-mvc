using MVC.Data.Wrappers;
using System;
using System.Collections.Generic;
namespace MVC.Data.Domain
{
    public interface ILocationDomain
    {
        string GetBackground();
        MVC.Data.Models.Location GetLocation(ItemWrapper item, System.Collections.Generic.Dictionary<string, string> parameterDictionary);
        string GetFieldParameters(string fieldName, Dictionary<string, string> parameterDictionary);
    }
}
