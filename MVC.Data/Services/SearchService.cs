using System.Collections.Generic;
using System.Linq;
using MVC.Data.Models;
using MVC.Data.ViewModels;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using FacetValue = Sitecore.ContentSearch.Linq.FacetValue;

namespace MVC.Data.Services
{
    public class SearchService : ISearchService
    {
        //Get index
        private readonly ISearchIndex _index = ContentSearchManager.GetIndex(Constants.SitecoreWebIndexName);

        public SearchResultViewModel FieldSearch(string searchTerm, int startIndex, int pageSize)
        {
            using (IProviderSearchContext context = _index.CreateSearchContext())
            {
                var model = new SearchResultViewModel();

                //Get all items in home ordered by content data
                //Faceted on semantics so will work with tagging
                IQueryable<CustomSearchResult> query = context.GetQueryable<CustomSearchResult>()
                    .Where(i => i.Path.StartsWith(Constants.SitecoreHomePath))
                    .Where(i => i.Content.Contains(searchTerm))
                    .FacetOn(i => i.Semantics);

                //Get facet categories
                model.FacetCategories = GetSemanticFacets(query);
                model.ItemList = query.ToList();

                //Get facet list
                model.FacetList = GetFacetDefinitionItems();

                return model;
            }
        }

        /// <summary>
        /// Gets a list of the facet definition items from Sitecore
        /// </summary>
        /// <returns></returns>
        public List<Item> GetFacetDefinitionItems()
        {
            var database = Factory.GetDatabase("master");

            var facets = new Item[] { };
            var item = database.GetItem(Sitecore.Buckets.Util.Constants.FacetFolder).EnsureFallbackVersion();
            if (item != null)
            {
                facets = item.GetChildren(ChildListOptions.SkipSorting).ToArray();
            }

            return facets.ToList();
        }

        public List<Facet> GetSemanticFacets(IQueryable<SearchResultItem> query)
        {
            var facetGroups = new List<Facet>();

            //Get facets from the current query
            FacetResults facetResults = query.GetFacets();

            //Get master database
            var master = Factory.GetDatabase("master");

            foreach (FacetCategory category in facetResults.Categories)
            {
                //Create new facetmodel
                var newFacet = new Facet(category.Name, category.Name);

                //Loop through values
                foreach (FacetValue value in category.Values)
                {
                    if (category.Name == "__semantics")
                    {
                        if (value.Name.Contains("-"))
                        {
                            //Get item
                            Item item = master.GetItem(new ID("{" + value.Name.ToUpper() + "}"));
                            var newFacetValues = new MVC.Data.Models.FacetValue(item.DisplayName, "{" + value.Name.ToUpper() + "}",
                                                                     value.AggregateCount);
                            //Add to model
                            newFacet.Values.Add(newFacetValues);
                        }
                    }
                    else
                    {
                        //Copy values
                        var newFacetValues = new MVC.Data.Models.FacetValue(value.Name, string.Empty, value.AggregateCount);

                        //Add to model
                        newFacet.Values.Add(newFacetValues);
                    }
                }

                //Add to list
                facetGroups.Add(newFacet);
            }

            return facetGroups;
        }

    }
}
