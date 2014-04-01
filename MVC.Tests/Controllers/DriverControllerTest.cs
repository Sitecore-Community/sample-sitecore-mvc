using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Data.Repositories;
using MVC.Tutorial.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Tests.Controllers
{
    [TestClass()]
    public class DriverControllerTest
    {
        [TestMethod]
        public void TestFeaturedView()
        {
            var controller = new DriverController(new TestDriverRepository());
            var result = controller.Featured() as ViewResult;
            Assert.AreEqual("DriverViewModel", result.Model.GetType().Name);
        }
    }
}
