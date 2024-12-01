using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Common;
using Menu.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Persistence.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;
        public AsyncRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) return await Table.Where(predicate).CountAsync();

            return await Table.CountAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? sort = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (sort is not null) return await sort(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? sort = null, bool enableTracking = false, int currentPage = 1, int pageSize = 5)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (sort is not null) return await sort(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);

            return await queryable.FirstOrDefaultAsync(predicate);
        }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await Table.AddRangeAsync(entities);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                Table.Remove(entity);
                dbContext.SaveChanges();
            });
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)
        {
            await Task.Run(() =>
            {
                Table.RemoveRange(entities);
                dbContext.SaveChanges();
            });
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                Table.Update(entity);
                dbContext.SaveChanges();
            });

            return entity;
        }
    }
}
