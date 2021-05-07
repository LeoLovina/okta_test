using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("odata/[controller]")]
    public class PingODataController : ControllerBase
    {

        private readonly IApplicationDbContext _dbContext;

        public PingODataController(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [ApiExplorerSettings(IgnoreApi = false)]
        [EnableQuery]
        [HttpGet]
        public IQueryable<Ping> Get()
        {
            return _dbContext.Pings.AsQueryable();
        }
    }
}
