using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Ping : AuditableEntity
    {
        public long Id { get; set; }
        [MaxLength(128)]
        [Required]
        public string HostName { get; set; }
        public int Times { get; set; }
        public string Message { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime SendingTime { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
    }
}
