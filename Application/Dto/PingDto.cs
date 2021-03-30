using System;
using MediatR;

namespace Application.Dto
{
    // 
    public class PingDto : IRequest
    {
        public DateTime SendingTime { get; set; }
        public string Message { get; set; }
    }
}
