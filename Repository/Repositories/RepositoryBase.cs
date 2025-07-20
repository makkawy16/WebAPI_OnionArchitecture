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
    }
}
