using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Domain.Common;

namespace PaymentService.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
