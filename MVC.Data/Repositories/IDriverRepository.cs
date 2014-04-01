using MVC.Data.Models;
using System;
using System.Collections.Generic;
namespace MVC.Data.Repositories
{
    public interface IDriverRepository
    {
        MVC.Data.Models.Driver GetDriver();
        MVC.Data.Models.DriverViewModel GetDriverViewModel(Driver driver);
    }
}
