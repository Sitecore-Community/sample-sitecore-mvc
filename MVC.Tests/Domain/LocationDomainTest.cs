using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Data.Domain;
using MVC.Data.Repositories;
using System;
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
    }
}
