using Kreta.Backend.Datas.Entities;

namespace Kreta.Backend.Repos
{
    public class StudentRepo<TDbContext> : RepositoryBase<TDbContext,Student>, IStudentRepo
    {
    }
}
