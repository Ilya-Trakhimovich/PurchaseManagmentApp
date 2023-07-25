using Domain.Repo.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Linq.Expressions;

namespace AppServices.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PurchaseManagmentAppContext RepositoryContext;
        public RepositoryBase(PurchaseManagmentAppContext repositoryContext) =>
            RepositoryContext = repositoryContext;

        public async Task<IQueryable<T>> FindAllAsync(bool trackChanges) =>
            !trackChanges ? await Task.Run(() => RepositoryContext.Set<T>().AsNoTracking())
            : await Task.Run(() => RepositoryContext.Set<T>());

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? await Task.Run(() => RepositoryContext.Set<T>().Where(expression).AsNoTracking())
            : await Task.Run(() => RepositoryContext.Set<T>().Where(expression));

        public async Task CreateAsync(T entity) => await Task.Run(() => RepositoryContext.Set<T>().Add(entity));

        public async Task UpdateAsync(T entity) => await Task.Run(() => RepositoryContext.Set<T>().Update(entity));

        public async Task RemoveAsync(T entity) => await Task.Run(() => RepositoryContext.Set<T>().Remove(entity));
    }
}
