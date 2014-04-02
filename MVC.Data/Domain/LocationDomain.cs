using MVC.Data.Models;
using MVC.Data.Repositories;
using MVC.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Data.Domain
{
    public class LocationDomain : MVC.Data.Domain.ILocationDomain
    {
        private ISitecoreRepository _sitecoreRepository;
        public LocationDomain(ISitecoreRepository sitecoreRepository)
        {
            _sitecoreRepository = sitecoreRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parametersDictionary"></param>
        /// <returns></returns>
        public Location GetLocation(ItemWrapper item, Dictionary<string, string> parametersDictionary)
        {
            Location location = null;

            if (item != null)
            {
                if (item.TemplateID == References.LocationTemplateID)
                {
                    location = new Location();

                    location.Title = new System.Web.HtmlString(GetField("Title", item, parametersDictionary));
                    location.Text = new System.Web.HtmlString(GetField("Description", item, parametersDictionary));

                    return location;
                }
            }

            return null;
        }

        public string GetBackground()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="parameterDictionary"></param>
        /// <returns></returns>
        public string GetFieldParameters(string fieldName, Dictionary<string, string> parameterDictionary)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                if (parameterDictionary.ContainsKey(fieldName))
                {
                    var queryString = parameterDictionary[fieldName];

                    if (!String.IsNullOrEmpty(queryString))
                    {
                        return queryString;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string GetField(string fieldName, ItemWrapper item, Dictionary<string, string> parameters)
        {
            if (item != null)
            {
                if (!String.IsNullOrEmpty(fieldName))
                {
                    if (item.Fields[fieldName] != null)
                    {
                        string fieldParameters = GetFieldParameters(fieldName, parameters);

                        _sitecoreRepository.GetField(fieldName, item, fieldParameters);
                    }
                }         
            }

            return String.Empty;
        }
    }
}
