using MVC.Data.ViewModels;

namespace MVC.Data.Services
{
    public interface ISearchService
    {
        SearchResultViewModel FieldSearch(string searchTerm, int startIndex, int pageSize);
    }
}
