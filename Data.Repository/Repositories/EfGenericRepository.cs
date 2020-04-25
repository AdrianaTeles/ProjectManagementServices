using Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Repositories
{
    public class EfGenericRepository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> ObjectSet { get; set; }

        private readonly DbContext Context;

        public EfGenericRepository(DbContext dbContext)
        {
            ObjectSet = dbContext.Set<T>();
            Context = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await ObjectSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await ObjectSet.AddRangeAsync(entities);
        }

        public Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition)
        {
            return ObjectSet.Where(whereCondition).FirstOrDefaultAsync();
        }

        public Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition, params string[] includes)
        {
            var ret = ObjectSet.Where(whereCondition);

            ret = includes.Aggregate(ret, (current, item) => current.Include(item));

            return ret.FirstOrDefaultAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await ObjectSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition)
        {
            return await ObjectSet.Where(whereCondition).ToListAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition, params string[] includes)
        {
            var ret = ObjectSet.Where(whereCondition);

            ret = includes.Aggregate(ret, (current, item) => current.Include(item));

            return await ret.ToListAsync<T>();
        }

        public Task<long> CountAsync()
        {
            return ObjectSet.LongCountAsync<T>();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> whereCondition)
        {
            return ObjectSet.Where(whereCondition).LongCountAsync<T>();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> whereCondition)
        {
            return ObjectSet.AnyAsync(whereCondition);
        }

        public void Delete(T entity)
        {
            ObjectSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            ObjectSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Context.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entities = from e in Context.ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                try
                {
                    Validator.ValidateObject(entity, validationContext);
                }
                catch (Exception ex)
                {
                   // Log.Error(ex, "Error while saving changes. {@ErrorObject}", new { Class = GetType().Name, entity });
                    throw;
                }
            }

            return await Context.SaveChangesAsync();
        }
    }
}
