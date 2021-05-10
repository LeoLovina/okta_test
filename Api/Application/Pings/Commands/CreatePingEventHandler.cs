using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using Mapster;
using MapsterMapper;


namespace Application.Pings.Commands
{
    public class CreatePingEventHandler : IRequestHandlerWrapper<CreatePingCommand, PingDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePingEventHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResult<PingDto>> Handle(CreatePingCommand request, CancellationToken cancellationToken)
        {
            var ping = _mapper.Map<Ping>(request);
            //var computers = request.Computers.Adapt<List<Computer>>();

            ping.SendingTime = DateTime.Now;
            await _dbContext.Pings.AddAsync(ping, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success<PingDto>(_mapper.Map<PingDto>(ping));
        }
    }
}
