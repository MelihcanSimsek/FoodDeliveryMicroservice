using Microsoft.EntityFrameworkCore.Storage;
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Application.Interfaces.UnitOfWorks;
using PaymentService.Persistence.Context;
using PaymentService.Persistence.Repositories;

namespace PaymentService.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        private IDbContextTransaction Transaction;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task BeginTransactionAsync()
        {
            Transaction = await dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await Transaction.CommitAsync();
            await Transaction.DisposeAsync();
        }
        public async Task RollbackTransactionAsync()
        {
            await Transaction.RollbackAsync();
            await Transaction.DisposeAsync();
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
     
        public int Save() => dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }
}
