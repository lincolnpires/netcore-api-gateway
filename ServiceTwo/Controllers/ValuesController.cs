using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ServiceTwo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly bool isProduction;

        public ValuesController(IConfiguration configuration)
        {
            isProduction = configuration.GetValue<bool>(nameof(isProduction));
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "ServiceTwo value1", "ServiceTwo value2", $"{nameof(isProduction)}: {isProduction}" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "ServiceTwo value";
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
