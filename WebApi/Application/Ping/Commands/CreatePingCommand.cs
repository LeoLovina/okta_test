using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Dto;

namespace WebApi.Application.Ping.Commands
{
    public class CreatePingCommand : IRequestWrapper<PingDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
