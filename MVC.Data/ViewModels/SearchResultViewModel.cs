using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Data.Models;
using Sitecore.Data.Items;

namespace MVC.Data.ViewModels
{
    public class SearchResultViewModel
    {
        public SearchResultViewModel()
        {
            Test = new List<String>();
            FacetCategories = new List<Facet>();
            ItemList = new List<CustomSearchResult>();
        }

        public IList<CustomSearchResult> ItemList { get; set; }
        public IList<Item> FacetList { get; set; }
        public IList<Facet> FacetCategories { get; set; }
        public IList<string> Test { get; set; }

    }
}
