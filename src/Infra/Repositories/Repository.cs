using Core.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Repositories;

internal abstract class Repository<T> : IRepository<T> where T : Trackable
{
    private Context Context { get; init; }
    public DbSet<T> DbSet => Context.Set<T>();
    public IQueryable<T> Query => DbSet.AsNoTracking();
    public Repository(Context context) => Context = context;
    public virtual void AddOrUpdate(T entity) => DbSet.Update(entity);
    public virtual void Delete(T Entity) => DbSet.Remove(Entity);
    public virtual async Task<long> CountAsync() => await Query.LongCountAsync();
    public virtual async Task SaveAsync() => await Context.SaveChangesAsync();
    public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        => await DbSet.FirstOrDefaultAsync(predicate);
    public virtual async ValueTask<T?> FindAsync(Guid key)
        => await DbSet.FindAsync(key);
    public virtual async Task<TResult?> FindAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> projection)
        => await Query.Where(filter).Select(projection).SingleOrDefaultAsync();
    public virtual async Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter)
        => await Query.Where(filter).ToListAsync();
    public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<T, TResult>> projection)
        => await Query.Select(projection).ToListAsync();
    public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> projection)
        => await Query.Where(filter).Select(projection).ToListAsync();
    public virtual async Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<T, TResult>> projection)
        => await Query.Skip(skip).Take(take).Select(projection).ToListAsync();
    public virtual async Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> projection)
        => await Query.Where(filter).Skip(skip).Take(take).Select(projection).ToListAsync();
    public virtual async Task<IList<T>> GetAsync(int skip, int take)
        => await Query.Skip(skip).Take(take).ToListAsync();
    public virtual async Task<IList<T>> GetAsync(int skip, int take, Expression<Func<T, bool>> filter)
        => await Query.Where(filter).Skip(skip).Take(take).ToListAsync();
}
