using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    public class TestDriverRepository : IDriverRepository
    {

        public Models.Driver GetDriver()
        {
            Driver driver = new Driver();

            driver.Name = new System.Web.HtmlString("Kimi Kimi-Matias Räikkönen");
            driver.Text = new System.Web.HtmlString("Do you have any special rituals when the helmet is concerned like many have? - I wipe it so that I can see better.");

            return driver;
        }

        public Models.DriverViewModel GetDriverViewModel(Models.Driver driver)
        {
            DriverViewModel driverViewModel = new DriverViewModel();

            driverViewModel.Background = "000000";
            driverViewModel.Driver = driver;

            return driverViewModel;
        }
    }
}
