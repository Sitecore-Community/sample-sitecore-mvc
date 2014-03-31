using MVC.Tutorial.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Tutorial.Repositories
{
    public class DriverRepository
    {
        public DriverViewModel GetDriverViewModel(Driver driver)
        {
            var viewModel = new DriverViewModel();

            var rendering = RenderingContext.Current.Rendering;

            viewModel.Background = rendering.Parameters["Background"];
            viewModel.ContextItem = PageContext.Current.Item;
            viewModel.Driver = driver;

            return viewModel;
        }

        public Driver GetDriver()
        {
            var driver = new Driver();

            var rendering = RenderingContext.Current.Rendering;

            var datasource = rendering.Item;

            driver.Name = new HtmlString(FieldRenderer.Render(datasource, "Name"));
            driver.Text = new HtmlString(FieldRenderer.Render(datasource, "Text"));

            return driver;

        }
    }
}