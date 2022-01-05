using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebApp.Data.DbContexts;
using WebApp.Data.Repositories.Abstract;

namespace WebApp.Data.Repositories;

public class WritableRepository<T> : IReadOnlyRepository<T>, IWritableRepository<T> where T : class
{
    private readonly WritableDbContext context;
    private readonly DbSet<T> dbSet;

    public WritableRepository(WritableDbContext context)
    {
        this.context = context ?? throw new ArgumentException(null, nameof(context));
        dbSet = this.context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return dbSet;
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await dbSet.Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null,
        bool? tracking = false)
    {
        IQueryable<T> query = dbSet;
        if (tracking == false)
        {
            query = query.AsNoTracking();
        }

        if (includes != null)
        {
            query = includes(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await dbSet.SingleOrDefaultAsync(predicate);
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }
}