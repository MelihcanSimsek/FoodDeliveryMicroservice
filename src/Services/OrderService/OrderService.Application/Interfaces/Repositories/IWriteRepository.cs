using OrderService.Domain.Common;


namespace OrderService.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);
    }
}
