using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi.Application.Common;
using WebApi.Application.Dto;

namespace WebApi.Application.Ping.Queries
{
    public class GetAllPingsQuery : IRequestWrapper<List<PingDto>>
    {
    }

    public class CreatePingEventHandler : IRequestHandlerWrapper<GetAllPingsQuery, List<PingDto>>
    {
        public async Task<ServiceResult<List<PingDto>>> Handle(GetAllPingsQuery request, CancellationToken cancellationToken)
        {
            List<PingDto> result = new List<PingDto>()
            {
                new PingDto {SendingTime = DateTime.Now, Message = "1"},
                new PingDto {SendingTime = DateTime.Now, Message = "2"},
                new PingDto {SendingTime = DateTime.Now, Message = "3"},
            };

            return ServiceResult.Success(result);
        }
    }
}
