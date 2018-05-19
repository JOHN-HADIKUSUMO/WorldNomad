using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Web;
using Nomad.Web.Models;
using Nomad.Logic;
using Nomad.Web.Controllers.API;

namespace Nomad.Testing
{
    [TestClass]
    public class Logic
    {
        [TestMethod]
        public void Create()
        {
            int limit = 10;
            int[] array = Utilities.Create(limit);
            Assert.IsTrue(array.Length == limit);
        }

        [TestMethod]
        public void NoFilter()
        {
            int limit = 30;
            int[] arrayInt = Utilities.Create(limit);
            string[] arrayString = Utilities.Filter(arrayInt, FilterType.NoFilter);
            Assert.IsTrue(arrayString.Length > 0);
        }

        [TestMethod]
        public void Odd()
        {
            int limit = 30;
            int[] arrayInt = Utilities.Create(limit);
            string[] arrayString = Utilities.Filter(arrayInt, FilterType.OddNumberOnly);
            Assert.IsTrue(arrayString.Length > 0);
        }

        [TestMethod]
        public void Even()
        {
            int limit = 30;
            int[] arrayInt = Utilities.Create(limit);
            string[] arrayString = Utilities.Filter(arrayInt, FilterType.EvenNumberOnly);
            Assert.IsTrue(arrayString.Length > 0);
        }

        [TestMethod]
        public void Combination()
        {
            int limit = 30;
            int[] arrayInt = Utilities.Create(limit);
            string[] arrayString = Utilities.Filter(arrayInt, FilterType.Combination);
            Assert.IsTrue(arrayString.Length > 0);
        }
    }
}
