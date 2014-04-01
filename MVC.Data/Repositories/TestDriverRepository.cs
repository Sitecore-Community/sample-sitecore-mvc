using MVC.Data.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    /// <summary>
    /// This is a test repository - you could inject this into your controller if your Sitecore implementation is not ready
    /// to be used as a data source.
    /// </summary>
    public class TestDriverRepository : IDriverRepository
    {
        public Models.Driver GetDriver()
        {
            Driver driver = new Driver();

            driver.Name = new System.Web.HtmlString("Kimi Kimi-Matias Räikkönen");
            driver.Text = new System.Web.HtmlString("Do you have any special rituals when the helmet is concerned like many have? - I wipe it so that I can see better.");

            return driver;
        }

        public Models.DriverViewModel GetDriverViewModel(Driver driver)
        {
            DriverViewModel driverViewModel = new DriverViewModel();

            driverViewModel.Background = "000000";
            driverViewModel.Driver = driver;

            return driverViewModel;
        }
    }
}
