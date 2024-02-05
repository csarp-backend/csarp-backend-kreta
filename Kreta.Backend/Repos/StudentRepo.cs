using Kreta.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class StudentRepo<TDbContext> : RepositoryBase<TDbContext,Student>, IStudentRepo
        where TDbContext : DbContext
    {
    }
}
