using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ping
    {
        public long Id { get; set; }
        [MaxLength(128)]
        public string HostName { get; set; }

        public int Times { get; set; }
        public string Message { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime SendingTime { get; set; }
    }
}
