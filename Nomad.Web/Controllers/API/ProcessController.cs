using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Nomad.Web.Models;
using Nomad.Logic;

namespace Nomad.Web.Controllers.API
{
    [RoutePrefix("API/PROCESS")]
    public class ProcessController : ApiController
    {
        [Route("GET/{no}")]
        [AcceptVerbs("GET")]
        public async Task<IHttpActionResult> GetData(int no)
        {
            if(no <= 0)
            {
                return InternalServerError(new Exception("Input parameter must be positive and greater than 0."));
            }
            else
            {
                ReturnModel model = new ReturnModel();
                int[] input = Utilities.Create(no);
                Parallel.Invoke(
                   () => model.GroupA = Utilities.Filter(input, FilterType.NoFilter),
                   () => model.GroupB = Utilities.Filter(input, FilterType.OddNumberOnly),
                   () => model.GroupC = Utilities.Filter(input, FilterType.EvenNumberOnly),
                   () => model.GroupD = Utilities.Filter(input, FilterType.Combination)
                );
                var temp = await Task.Run(() => {return model;});
                return Ok(temp);
            }
        }
    }
}
