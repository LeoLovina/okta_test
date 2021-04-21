using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Ping> Pings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
