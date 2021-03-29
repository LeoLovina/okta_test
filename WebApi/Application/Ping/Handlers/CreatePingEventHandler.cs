using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Application.Dto;
using WebApi.Application.Ping.Commands;

namespace WebApi.Application.Ping.Handlers
{
    public class CreatePingEventHandler: IRequestHandlerWrapper<CreatePingCommand, PingDto>
    {
        public Task<PingDto> Handle(CreatePingCommand request, CancellationToken cancellationToken)
        {

            var entity = new PingDto()
            {
                SendingTime = DateTime.Now,
                Message = $"ID={request.Id}  Name={request.Name}"
            };
            return Task.FromResult(entity);
        }
    }
}
