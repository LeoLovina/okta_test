using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ping> Pings { get; set; }
        public DbSet<Computer> Computers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var auditEntity in ChangeTracker.Entries<AuditableEntity>())
            {
                if (auditEntity.State == EntityState.Added)
                {
                    auditEntity.Entity.CreateDate = DateTime.Now;
                    auditEntity.Entity.Creator = "someone";
                }
                else if (auditEntity.State == EntityState.Modified)
                {
                    auditEntity.Entity.ModifyDate = DateTime.Now;;
                    auditEntity.Entity.Modifier = "one";
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
