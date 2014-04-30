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
using Sitecore.Data.Items;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class CircuitControllerTest
    {
        [TestMethod]
        public void CircuitControllerTest_WillNeverWork()
        {
            CircuitController circuitController = new CircuitController();

            // var test = new Mock<RenderingContext>();
            // test.Setup(x => x.PageContext = new PageContext());
            // var test2 = Mock.Of<Item>();

            var result = circuitController.Featured();
        }
    }
}