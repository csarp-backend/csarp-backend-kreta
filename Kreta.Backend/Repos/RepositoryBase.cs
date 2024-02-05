using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kreta.Backend.Repos
{
    public abstract class RepositoryBase<TDbContext, TEntity> : IRepositoryBase<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IDbEntity<TEntity>, new()
    {
        private readonly IDbContextFactory<TDbContext> _dbContextFactory;
        private readonly DbContext _dbContext;
        private DbSet<TEntity>? _dbSet;

        public RepositoryBase(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            TDbContext dbContext = _dbContextFactory.CreateDbContext();
            _dbContext = dbContext;
            // Itt megkapjuk az adatábzis táblát
            _dbSet = dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> FindAll()
        {
            if (_dbSet is null)
            {
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            }
            return _dbSet.AsNoTracking();
        }
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            if (_dbSet is null)
            {
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            }
            return _dbSet.Where(expression).AsNoTracking();
        }
        public async Task<ControllerResponse> UpdateAsync(TEntity entity)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(RepositoryBase<TDbContext, TEntity>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{entity} frissítése nem sikerült!");

            }
            return response;
        }

        public Task<ControllerResponse> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ControllerResponse> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
