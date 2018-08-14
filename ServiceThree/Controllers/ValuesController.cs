using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceThree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "ServiceThree value1", "ServiceThree value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "ServiceThree value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // Method intentionally left empty.
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
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
