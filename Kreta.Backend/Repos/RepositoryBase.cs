using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class RepositoryBase<TDbContext, TEntity> : IRepositoryBase<TEntity>
        where TDbContext: DbContext
        where TEntity : class
    {

    }
}
