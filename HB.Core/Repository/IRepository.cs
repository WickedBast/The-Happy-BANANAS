using HB.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HB.Core.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        int Add(T entity);
        Task<int> AddAsync(T entity);

        int Update(T entity);
        Task<int> UpdateAsync(T entity);

        int Delete(T entity);
        Task<int> DeleteAsync(T entity);

        T GetById(Guid Id);
        Task<T> GetByIdAsync(Guid Id);

        T GetById(Guid Id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(Guid Id, params Expression<Func<T, object>>[] includes);

        T FirstOrDefaultBy(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> exp);

        T FirstOrDefaultBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);
        Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);

        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);

        List<T> GetAll();
        Task<List<T>> GetAllAsync();

        int Count();
        Task<int> CountAsync();

        int Count(Expression<Func<T, bool>> exp);
        Task<int> CountAsync(Expression<Func<T, bool>> exp);

        IQueryable<T> GetBy(Expression<Func<T, bool>> exp);

        IQueryable<T> GetBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);

        //HARD OPERATIONS
        int HardDelete(T entity);
        Task<int> HardDeleteAsync(T entity);

        int HardDeleteRange(List<T> entities);
        Task<int> HardDeleteRangeAsync(List<T> entities);

        int Save();
        Task<int> SaveAsync();
    }
}