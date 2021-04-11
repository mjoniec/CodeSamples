using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("jobs/saveFiles")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/data
        [HttpPost("data")]
        public ActionResult<IEnumerable<string>> Post([FromBody] RequestModel model)
        {
            return new string[] { "value1", model.Name };
        }
    }

    public class RequestModel
    {
        [JsonProperty("ix")]
        public int Index { get; set; }
        public string Name { get; set; }
        public int? Visits { get; set; }
        public DateTime Date { get; set; }
    }
}
