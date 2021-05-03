using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Mapster;
using MapsterMapper;


namespace Application.Pings.Queries
{
    public class GetAllPingsQuery : IRequestWrapper<List<PingDto>>
    {
    }

    public class CreatePingEventHandler : IRequestHandlerWrapper<GetAllPingsQuery, List<PingDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePingEventHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<PingDto>>> Handle(GetAllPingsQuery request, CancellationToken cancellationToken)
        {
            var result = _dbContext.Pings.ProjectToType<PingDto>().ToList();
            return ServiceResult.Success(result);
        }
    }
}
