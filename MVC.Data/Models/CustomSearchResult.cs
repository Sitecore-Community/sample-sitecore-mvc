using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace MVC.Data.Models
{
    public class CustomSearchResult : SearchResultItem
    {
        [IndexField("Content")]
        public string PageStuff { get; set; }

        [IndexField("_highlightedSearch")]
        public string HighlightedSearch { get; set; }

    }
}
