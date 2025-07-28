using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext appContext;

        public RepositoryBase(AppDbContext appContext)
        {
            this.appContext = appContext;
        }

        public void Create(T entity)
        => appContext.Set<T>().Add(entity);

        public void Delete(T entity)
       => appContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges? appContext.Set<T>() : appContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return FindAll(trackChanges).Where(expression);
        }

        public void Update(T entity)
        => appContext.Set<T>().Update(entity);

        public async Task<T> FindByIdAsync(int id) => await appContext.Set<T>().FindAsync(id);

        public async Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await appContext.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate) => await appContext.Set<T>().AnyAsync(predicate);

        public  T GetAllIncluding(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includingPredicate)
            => (T)appContext.Set<T>().Where(predicate).Include(includingPredicate);

        public void SaveChanges() => appContext.SaveChanges();
    }
}
