using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVC.Data;
using MVC.Data.Domain;
using MVC.Data.Repositories;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Data.Models;
using Sitecore.MVC.Presentation;
using Sitecore.Mvc.Presentation;

namespace MVC.Tests.Domain
{
    [TestClass()]
    public class LocationDomainTest
    {
        [TestMethod()]
        public void GetFieldParameters_IncorrectKeyValuePair()
        {
            var repository = Mock.Of<ISitecoreRepository>();

            var domain = new LocationDomain(repository);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Image", "?mh=200");

            var parameterString = domain.GetFieldParameters("Text", dictionary);

            Assert.AreEqual(null, parameterString);
        }

        [TestMethod()]
        public void GetLocation_NullTemplate()
        {
            var item = Mock.Of<IItem>();

            var repository = Mock.Of<ISitecoreRepository>();

            var domain = new LocationDomain(repository);

            var location = domain.GetLocation(item);

            Assert.IsNull(location);
        }

        //[TestMethod()]
        //public void GetLocation_ReturnsLocation()
        //{
        //               
        //}

        //[TestMethod()]
        //public void GetField_NullParameters()
        //{      
        //}

        //[TestMethod()]
        //public void GetField_EmptyFieldName()
        //{
        //}

        //[TestMethod()]
        //public void GetField_NullItem()
        //{
        //}
    }
}
