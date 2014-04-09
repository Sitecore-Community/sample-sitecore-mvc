using MVC.Data.Models;
using MVC.Data.Repositories;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Data.Domain
{
    /// <summary>
    /// A domain is where you keep all your business logic. There is no data retrieval in the domain;
    /// that is done via an injected repository (in this case, an ISitecoreRepository).
    /// </summary>
    public class LocationDomain : MVC.Data.Domain.ILocationDomain
    {
        private readonly ISitecoreRepository _sitecoreRepository; 
        public LocationDomain(ISitecoreRepository sitecoreRepository)
        {
            _sitecoreRepository = sitecoreRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Location GetLocation(IItem item)
        {
            return GetLocation(item, null);
        }

        /// <summary>
        /// This method retrieves the datasource of the context rendering as a Location object, but it also allows you to pass in
        /// field parameters that are specific to this rendering. For example, you may not want the 'Name' field to be editable in the Page Editor,
        /// because editors may not realize the information is being used elsewhere.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parametersDictionary"></param>
        /// <returns></returns>
        public Location GetLocation(IItem item, Dictionary<string, string> parametersDictionary)
        {
            Location location = null;
            
            // Remember that we are passing in an item *wrapper*, not an actual item (you cannot reference an item in the business logic layer because you 
            // cannot mock it effectively) - but that could still be null. In our case, the 
            // ItemWrapper is coming from the RenderingContextWrapper > Rendering object, which will return 'null' for .Item if it cannot
            // find an actual Sitecore object.
            if (item != null)
            {
                    // Only allow items whose data template ID matches the Location data template ID.
                    if (item.TemplateID == References.LocationTemplateID)
                    {
                        location = new Location();

                        // We aren't using FieldRenderer.Render directly in the domain, because we do not want to create a
                        // dependency on Sitecore. Instead, we pass the field name, item wrapper, and parameters dictionary to our own 'GetField' method.
                        location.Title = new System.Web.HtmlString(GetField("Name", item, parametersDictionary));
                        location.Text = new System.Web.HtmlString(GetField("Text", item, parametersDictionary));

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
                if (parameterDictionary != null && parameterDictionary.Count() > 0)
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
            }

            return null;
        }

        /// <summary>
        /// This method will eventually defer to the ISitecoreRepository to render the field value.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GetField(string fieldName, IItem item, Dictionary<string, string> parameters)
        {
            if (item != null)
            {
                if (!String.IsNullOrEmpty(fieldName))
                {
                    // Get the ISitecoreRepository to check if the field actually exists.
                    if (_sitecoreRepository.FieldExists(fieldName, item))
                    {
                        // Helper to return field parameters for this particular field (the dictionary contains all fields + their parameters)
                        string fieldParameters = GetFieldParameters(fieldName, parameters);

                        if (!String.IsNullOrEmpty(fieldParameters))
                        {
                            // Get field value from Sitecore, having already checked for null/empty, and whether or not the field actually exists.
                            return _sitecoreRepository.GetFieldValue(fieldName, item, fieldParameters);
                        }
                        else
                        {
                            return _sitecoreRepository.GetFieldValue(fieldName, item);
                        }
                    }
                }         
            }

            return String.Empty;
        }
    }
}
