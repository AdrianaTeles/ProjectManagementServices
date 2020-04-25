using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition, params string[] includes);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition, params string[] includes);

        Task<long> CountAsync();

        Task<long> CountAsync(Expression<Func<T, bool>> whereCondition);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> whereCondition);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T entity);

        Task<int> SaveChangesAsync();
    }
}