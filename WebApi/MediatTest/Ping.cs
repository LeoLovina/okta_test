using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebApi.MediatTest
{
    public class Ping : IRequest<string>, INotification
    {
        public DateTime SendingTime { get; set; } 
    }
}
