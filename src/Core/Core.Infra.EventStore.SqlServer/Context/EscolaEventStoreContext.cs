using System.Data.Entity;

namespace Core.Infra.EventStore.SqlServer.Context
{
    public class EscolaEventStoreContext : DbContext
    {
        public EscolaEventStoreContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<LoggedEvent> LoggedEvents { get; set; }
    }
}