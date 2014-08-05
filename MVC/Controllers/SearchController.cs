using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Data.Models;
using MVC.Data.Services;
using MVC.Data.ViewModels;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;

namespace MVC.Web.Controllers
{
    public class SearchController : SitecoreController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }

        public ActionResult SearchIndex()
        {
            return base.Index();
        }

        public ActionResult SearchResults()
        {
            //var model = new SearchResultViewModel();
            var model = new SearchResultViewModel();

            if (RouteData.Values["criteria"] != null)
            {

                var searchTerm = RouteData.Values["criteria"].ToString();

                //Perform search
                model = _searchService.FieldSearch(searchTerm: searchTerm, startIndex:0, pageSize:10);

                //}
            }

            return View("/Views/Search/SearchResults.cshtml", model);
        }

        [HttpPost]
        public ActionResult Submit(Search query)
        {
            if (ModelState.IsValid)
            {
                query.SearchPage = "1";

                //Redirect to a route that will be injected into the main placeholder
                return RedirectToRoute("SearchResults", new { criteria = query.SearchTerm, page = query.SearchPage });
            }


            IView pageView = PageContext.Current.PageView;
            if (pageView == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return (ActionResult)this.View(pageView);
            }


        }
    }
}
