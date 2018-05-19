using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Web.Models
{
    public class ReturnModel
    {
        public ReturnModel()
        {
            GroupA = new string[] { };
            GroupB = new string[] { };
            GroupC = new string[] { };
            GroupD = new string[] { };
        }
        public string[] GroupA { get; set; }
        public string[] GroupB { get; set; }
        public string[] GroupC { get; set; }
        public string[] GroupD { get; set; }
    }
}