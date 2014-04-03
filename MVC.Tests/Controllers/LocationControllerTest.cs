using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Tutorial.Controllers;
using MVC.Data.Repositories;
using MVC.Data.Domain;
using System.Web.Mvc;
using MVC.Data.ViewModels;
using MVC.Data.Models;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class LocationControllerTest
    {
        [TestMethod]
        public void LocationControllerTest_ReturnsEmptyIfNoLocation()
        {
            FakeRepository repository = new FakeRepository();
            
            LocationDomain domain = new LocationDomain(repository);

            LocationController locationController = new LocationController(domain);

           var result = locationController.Featured();

           var typeName = result.GetType().Name;

           Assert.AreEqual("ContentResult", typeName);
        }
    }
}
