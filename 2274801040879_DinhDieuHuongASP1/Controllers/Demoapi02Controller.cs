﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2274801040879_DinhDieuHuongASP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Demoapi02Controller : ControllerBase
    {
        // GET: api/<Demoapi02Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Demoapi02Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Demoapi02Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Demoapi02Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Demoapi02Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
