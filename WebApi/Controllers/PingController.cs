using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Application.Common;
using Application.Dto;
using Application.Ping.Commands;
using Application.Ping.Queries;
using MediatR;


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
        public async Task<ServiceResult<List<PingDto>>> Get()
        {
            var response = await _mediator.Send(new GetAllPingsQuery());
            return response;
        }

        // GET api/<PingController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            //var response = await _mediator.Send(new Ping{ SendingTime = DateTime.Now});
            //return response;
            return "haha";
        }

        // POST api/<PingController>
        [HttpPost]
        public async Task<ServiceResult<PingDto>> Post(CreatePingCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
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
