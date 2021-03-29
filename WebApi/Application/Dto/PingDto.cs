using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebApi.Application.Dto
{
    // 
    public class PingDto : IRequest
    {
        public DateTime SendingTime { get; set; }
        public string Message { get; set; }
    }
}
