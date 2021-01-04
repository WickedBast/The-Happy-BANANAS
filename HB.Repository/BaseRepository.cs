using HB.Core.Entity;
using HB.Core.Repository;
using HB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HB.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefaultBy(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefaultBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid Id, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid Id, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public int HardDelete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> HardDeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public int HardDeleteRange(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> HardDeleteRangeAsync(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
