using MVC.Data.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
namespace MVC.Data.Domain
{
    public interface ILocationDomain
    {
        string GetBackground();
        Location GetLocation(IItemWrapper item, Dictionary<string, string> parameterDictionary);
        Location GetLocation(IItemWrapper item);
        string GetFieldParameters(string fieldName, Dictionary<string, string> parameterDictionary);
    }
}
