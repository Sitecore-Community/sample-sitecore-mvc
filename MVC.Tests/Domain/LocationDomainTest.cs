using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Data;
using MVC.Data.Domain;
using MVC.Data.Repositories;
using MVC.Data.Wrappers;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Tests.Domain
{
    [TestClass()]
    public class LocationDomainTest
    {
        [TestMethod()]
        public void GetFieldParameters_CorrectKeyValuePair()
        {
            var repository = new FakeRepository();

            var domain = new LocationDomain(repository);

            Dictionary<string, string> dictionary =  new Dictionary<string,string>();

            dictionary.Add("Image", "?mh=200");

            var parameterString = domain.GetFieldParameters("Image", dictionary);

            Assert.AreEqual("?mh=200", parameterString);
        }

        [TestMethod()]
        public void GetFieldParameters_IncorrectKeyValuePair()
        {
            var repository = new FakeRepository();

            var domain = new LocationDomain(repository);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Image", "?mh=200");

            var parameterString = domain.GetFieldParameters("Text", dictionary);

            Assert.AreEqual(null, parameterString);
        }

        [TestMethod()]
        public void GetLocation_NullTemplate()
        {      

            ItemWrapper item = new ItemWrapper();                       

            var repository = new FakeRepository();

            var domain = new LocationDomain(repository);

            var location = domain.GetLocation(item);

            Assert.IsNull(location);
        }

        [TestMethod()]
        public void GetLocation_ReturnsLocation()
        {
            ItemWrapper item = new ItemWrapper();

            item.TemplateID = References.LocationTemplateID;

            var repository = new FakeRepository();

            var domain = new LocationDomain(repository);

            var location = domain.GetLocation(item);

            Assert.IsNotNull(location);            
        }

        [TestMethod()]
        public void GetField_NullParameters()
        {
            ItemWrapper item = new ItemWrapper();

            item.TemplateID = References.LocationTemplateID;

            var repository = new FakeRepository();

            var domain = new LocationDomain(repository);

            var location = domain.GetField("Test", item, null);

            Assert.IsNotNull(location);
            Assert.AreEqual("Test", location);
        }

        [TestMethod()]
        public void GetField_EmptyFieldName()
        {
            ItemWrapper item = new ItemWrapper();

            item.TemplateID = References.LocationTemplateID;

            var repository = new FakeRepository();

            var domain = new LocationDomain(repository);

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("Test", "?mw=300");

            var location = domain.GetField(String.Empty, item, parameters);

            Assert.IsNotNull(location);
            Assert.AreEqual(String.Empty, location);
        }

        [TestMethod()]
        public void GetField_NullItem()
        {
            ItemWrapper item = new ItemWrapper();

            item.TemplateID = References.LocationTemplateID;

            var repository = new FakeRepository();

            var domain = new LocationDomain(repository);

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("Test", "?mw=300");

            var location = domain.GetField("Test", null, parameters);

            Assert.IsNotNull(location);
            Assert.AreEqual(String.Empty, location);
        }
    }
}
