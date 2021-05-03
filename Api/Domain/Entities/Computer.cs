using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Computer : AuditableEntity
    {
        public long Id { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }

        public DateTime BuyDate { get; set; }

        [AllowNull]
        public string Memo { get; set; }

    }
}
