using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Tutorial.Controllers;
using MVC.Data.Repositories;
using MVC.Data.Domain;
using System.Web.Mvc;
using MVC.Data.ViewModels;
using MVC.Data.Models;
using Sitecore.MVC.Presentation;
using Sitecore.Mvc.Presentation;
using Moq;
using MVC.Data;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class LocationControllerTest
    {
        [TestMethod]
        public void LocationControllerTest_ReturnsEmptyIfNoLocation()
        {
            var repository = Mock.Of<ISitecoreRepository>();
            var pageContext = Mock.Of<IPageContext>();

            var rendering = Mock.Of<IRenderingWrapper>();

            var renderingContext = Mock.Of<IRenderingContext>(rc => rc.Rendering == rendering);

            LocationDomain domain = new LocationDomain(repository);

            LocationController locationController = new LocationController(domain, pageContext, renderingContext);

            var result = locationController.Featured();

            Assert.AreEqual("EmptyResult", result.GetType().Name);
        }

        [TestMethod]
        public void LocationControllerTest_ReturnsPageEditorErrorIfNoLocation()
        {
            var repository = Mock.Of<ISitecoreRepository>();
            var pageContext = Mock.Of<IPageContext>(pc => pc.IsPageEditor == true);

            var rendering = Mock.Of<IRenderingWrapper>();

            var renderingContext = Mock.Of<IRenderingContext>(rc => rc.Rendering == rendering);

            LocationDomain domain = new LocationDomain(repository);

            LocationController locationController = new LocationController(domain, pageContext, renderingContext);

            var result = locationController.Featured() as ViewResult;

            Assert.AreEqual("~/Views/Shared/_NoDatasource.cshtml", result.ViewName);
        }
    }
}
