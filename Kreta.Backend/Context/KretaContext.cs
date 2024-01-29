using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Context
{
    public class KretaContext : DbContext
    {
        public KretaContext(DbContextOptions options) : base(options)
        {
        }
    }
}
