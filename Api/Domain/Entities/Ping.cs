using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ping
    {
        public long Id { get; set; }
        public string HostName { get; set; }
        public string Message { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
