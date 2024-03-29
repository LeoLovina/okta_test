﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Application.Pings.Commands;
using Application.Pings.Queries;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.Extensions.Logging;
using Ping = Domain.Entities.Ping;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PingController> _logger;
        private readonly IApplicationDbContext _dbContext;

        public PingController(ILogger<PingController> logger, IMediator mediator, IApplicationDbContext dbContext)
        {
            _logger = logger;
            _mediator = mediator;
            _dbContext = dbContext;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Pings);
        }

        // GET api/<PingController>/5
        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _dbContext.Pings.FirstOrDefault(x => x.Id == id);
            return Ok(result);
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
            throw new ArgumentException($"We don't offer a weather forecast for this city");
        }

        // DELETE api/<PingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int A = 10;
            var B = A / 0;
        }
    }
}
