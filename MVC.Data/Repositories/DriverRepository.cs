using MVC.Data.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Data.Repositories
{
    /// <summary>
    /// This is a data repostiory with a dependency on SITECORE - it uses RenderingContext and PageContext objects,
    /// both of which have a dependency on the Sitecore framework. You could separate your code into a service layer (which
    /// contains all business logic, no dependency on Sitecore) and a data repository (Sitecore dependency).
    /// </summary>
    public class DriverRepository : MVC.Data.Repositories.IDriverRepository
    {
        public DriverViewModel GetDriverViewModel(Driver driver)
        {
            var viewModel = new DriverViewModel();

            var rendering = RenderingContext.Current.Rendering;

            // This retrieves the 'Background' parameter from the context rendering
            viewModel.Background = rendering.Parameters["Background"];
            viewModel.ContextItem = PageContext.Current.Item;

            viewModel.Driver = driver;

            return viewModel;
        }

        /// <summary>
        /// This method instantiates a new Driver and populates it with data from Sitecore.
        /// </summary>
        /// <returns></returns>
        public Driver GetDriver()
        {
            var driver = new Driver();
          
            var rendering = RenderingContext.Current.Rendering;

            var datasource = rendering.Item;

            // Warning: Notice that we do not have an opportunity to pass in field parameters here, which you may
            // require - particularly for image max width and height
            driver.Name = new HtmlString(FieldRenderer.Render(datasource, "Name"));
            driver.Text = new HtmlString(FieldRenderer.Render(datasource, "Text"));
            driver.Image = new HtmlString(FieldRenderer.Render(datasource, "Image"));

            return driver;
        }
    }
}