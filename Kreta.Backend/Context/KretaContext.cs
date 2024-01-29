using Kreta.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Context
{
    public class KretaContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public KretaContext(DbContextOptions options) : base(options)
        {
        }
    }
}
