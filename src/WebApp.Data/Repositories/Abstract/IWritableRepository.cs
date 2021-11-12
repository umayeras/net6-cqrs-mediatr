namespace WebApp.Data.Repositories.Abstract
{
    public interface IWritableRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}