using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public abstract class RepositoryBase<TDbContext, TEntity> : IRepositoryBase<TEntity>
        where TDbContext: DbContext
        where TEntity : class, IDbEntity<TEntity>, new()
    {

    }
}
