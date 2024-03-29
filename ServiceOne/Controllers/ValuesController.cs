using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceOne.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "ServiceOne value1", "ServiceOne value2" };
        }

        // GET api/values/5
        [HttpGet("{id}/filter")]
        public string Get(string id)
        {
            return "ServiceOne value";
        }

        [HttpGet("{value}")]
        public string GetQuery(string value)
        {
            var tiozao = Request.Query;
            return "ServiceOne queryString";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // Method intentionally left empty.
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // Method intentionally left empty.
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Method intentionally left empty.
        }
    }
}
