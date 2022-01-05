using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace WebApp.Data.Repositories.Abstract;

public interface IReadOnlyRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<IReadOnlyList<T>> GetAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null,
        bool? tracking = false);

    Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
}