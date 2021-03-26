using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApi.MediatTest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PingController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var response =  _mediator.Publish(new Ping { SendingTime = DateTime.Now });
            response.Wait();



            return new string[] { "value1", "value2" };
        }

        // GET api/<PingController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var response = await _mediator.Send(new Ping{ SendingTime = DateTime.Now});
            return response;
        }

        // POST api/<PingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
