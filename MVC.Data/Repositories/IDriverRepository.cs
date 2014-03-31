using System;
namespace MVC.Data.Repositories
{
    public interface IDriverRepository
    {
        MVC.Data.Models.Driver GetDriver();
        MVC.Data.Models.DriverViewModel GetDriverViewModel(MVC.Data.Models.Driver driver);
    }
}
