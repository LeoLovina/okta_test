using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Dto;

namespace Application.Ping.Commands
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
