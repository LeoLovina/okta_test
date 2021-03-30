using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi.Application.Common;
using WebApi.Application.Dto;

namespace WebApi.Application.Ping.Commands
{
    public class CreatePingCommand : IRequestWrapper<PingDto>
    {
        [Required]
        [Range(0, 10)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class CreatePingEventHandler : IRequestHandlerWrapper<CreatePingCommand, PingDto>
    {
        public async Task<ServiceResult<PingDto>> Handle(CreatePingCommand request, CancellationToken cancellationToken)
        {
            var entity = new PingDto()
            {
                SendingTime = DateTime.Now,
                Message = $"ID={request.Id}  Name={request.Name}"
            };
            return ServiceResult.Success(entity);
        }

    }
}
