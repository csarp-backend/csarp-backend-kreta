using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Context
{
    public class KretaInMemoryContext : KretaContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
