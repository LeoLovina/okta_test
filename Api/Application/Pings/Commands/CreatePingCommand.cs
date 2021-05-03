using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using MapsterMapper;


namespace Application.Pings.Commands
{
    public class CreatePingCommand : IRequestWrapper<PingDto>
    {
        [Required]
        public string HostName { get; set; }
        public string Message { get; set; }
    }

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
            var entity = _mapper.Map<Ping>(request);

            entity.SendingTime = DateTime.Now;
            await _dbContext.Pings.AddAsync(entity, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success<PingDto>(_mapper.Map<PingDto>(entity));
        }
    }
}
