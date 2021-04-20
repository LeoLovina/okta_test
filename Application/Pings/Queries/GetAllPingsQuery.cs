using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;


namespace Application.Pings.Queries
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
