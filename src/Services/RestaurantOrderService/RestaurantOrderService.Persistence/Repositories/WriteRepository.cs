﻿using Microsoft.EntityFrameworkCore;
using RestaurantOrderService.Application.Interfaces.Repositories;
using RestaurantOrderService.Domain.Common;


namespace RestaurantOrderService.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                Table.Remove(entity);
            });
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)
        {
            await Task.Run(() => Table.RemoveRange(entities));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                Table.Update(entity);
            });

            return entity;
        }
    }
}
