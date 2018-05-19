using System;
using System.Collections;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Web;
using Nomad.Web.Models;
using Nomad.Web.Controllers.API;

namespace Nomad.Testing
{
    [TestClass]
    public class API
    {
        [TestMethod]
        public async Task GetData()
        {
            int limit = 30;
            int GroupA_Expected_Length = 30;
            int GroupB_Expected_Length = 15;
            int GroupC_Expected_Length = 15;
            int GroupD_Expected_Length = 30;

            string[] GroupA_Expected_Output = new string[] 
            {"1","2","3","4","5","6","7","8","9","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30"
            };

            string[] GroupB_Expected_Output = new string[]
            {"1","3","5","7","9","11","13","15","17","19",
            "21","23","25","27","29"
            };

            string[] GroupC_Expected_Output = new string[]
            {"2","4","6","8","10","12","14","16","18","20",
            "22","24","26","28","30"
            };

            string[] GroupD_Expected_Output = new string[]
            {"1","2","C","4","E","C","7","8","C","E",
            "11","E","13","14","Z","16","17","C","19","E",
            "C","22","23","C","E","26","C","28","29","Z"
            };

            var controller = new ProcessController();
            OkNegotiatedContentResult<ReturnModel> item = (OkNegotiatedContentResult <ReturnModel>)await controller.GetData(limit);
            Assert.IsTrue(item.Content.GroupA.Length == GroupA_Expected_Length);
            Assert.IsTrue(item.Content.GroupB.Length == GroupB_Expected_Length);
            Assert.IsTrue(item.Content.GroupC.Length == GroupC_Expected_Length);
            Assert.IsTrue(item.Content.GroupD.Length == GroupD_Expected_Length);

            Assert.IsTrue(item.Content.GroupA.SequenceEqual(GroupA_Expected_Output));
            Assert.IsTrue(item.Content.GroupB.SequenceEqual(GroupB_Expected_Output));
            Assert.IsTrue(item.Content.GroupC.SequenceEqual(GroupC_Expected_Output));
            Assert.IsTrue(item.Content.GroupD.SequenceEqual(GroupD_Expected_Output));
        }

        [TestMethod]
        public async Task Fail()
        {
            bool status = true;
            int limit = 0;
            try
            {
                var controller = new ProcessController();
                OkNegotiatedContentResult<ReturnModel> item = (OkNegotiatedContentResult<ReturnModel>)await controller.GetData(limit);
            }
            catch(Exception ex)
            {
                status = false;
            }
            Assert.IsFalse(status);
        }
    }
}
