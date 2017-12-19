using Equinox.Domain.Core.Events;
using Equinox.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}