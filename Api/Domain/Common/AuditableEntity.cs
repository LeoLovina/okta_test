using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        [MaxLength(64, ErrorMessage = "Creator must be 64 characters or less")]
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(64, ErrorMessage = "Modifier must be 64 characters or less")]
        public string Modifier { get; set; }

        public DateTime ModifyDate {get; set; }
    }
}
