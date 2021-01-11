using HB.Core.Entity;
using HB.Core.Repository;
using HB.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static HB.Core.Enum.Enums;

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
            _context.Set<T>().Add(entity);
            return Save();
        }

        public async Task<int> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await SaveAsync();
        }

        public int AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return Save();
        }

        public async Task<int> AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return await SaveAsync();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).AnyAsync(exp);
        }

        public int Count()
        {
            return _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).Count();
        }

        public int Count(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).Count(exp);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).CountAsync(exp);
        }

        public int Delete(T entity)
        {
            entity.RecordStatus = RecordStatus.Deleted;
            entity.UpdateDate = DateTime.UtcNow;
            _context.Entry<T>(entity).CurrentValues.SetValues(entity);
            //_context.Set<T>().Remove(entity);
            return Save();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            entity.RecordStatus = RecordStatus.Deleted;
            entity.UpdateDate = DateTime.UtcNow;
            _context.Entry<T>(entity).CurrentValues.SetValues(entity);
            //_context.Set<T>().Remove(entity);
            return await SaveAsync();
        }

        public int DeleteRange(List<T> entities)
        {
            entities.ForEach(x =>
            {
                x.RecordStatus = RecordStatus.Deleted;
            });
            _context.Set<T>().UpdateRange(entities);
            return Save();
        }

        public async Task<int> DeleteRangeAsync(List<T> entities)
        {
            entities.ForEach(x =>
            {
                x.RecordStatus = RecordStatus.Deleted;
            });
            _context.Set<T>().UpdateRange(entities);
            return await SaveAsync();
        }

        public T FirstOrDefaultBy(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).FirstOrDefault(exp);
        }

        public T FirstOrDefaultBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).Where(exp);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).FirstOrDefaultAsync(exp);
        }

        public async Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).Where(exp);
            return await includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefaultAsync();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(x => x.RecordStatus != RecordStatus.Deleted).ToListAsync();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).Where(x => x.RecordStatus != RecordStatus.Deleted);
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(exp).Where(x => x.RecordStatus != RecordStatus.Deleted);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public T GetById(Guid Id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == Id && x.RecordStatus != RecordStatus.Deleted);
        }

        public T GetById(Guid Id, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.Id == Id && x.RecordStatus != RecordStatus.Deleted);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id && x.RecordStatus != RecordStatus.Deleted);
        }

        public async Task<T> GetByIdAsync(Guid Id, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.Id == Id && x.RecordStatus != RecordStatus.Deleted);
            return await includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefaultAsync();
        }

        public int HardDelete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Save();
        }

        public async Task<int> HardDeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await SaveAsync();
        }

        public int HardDeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return Save();
        }

        public async Task<int> HardDeleteRangeAsync(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return await SaveAsync();
        }



        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return Save();
        }

        public Task<int> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return SaveAsync();
        }

        public int UpdateRange(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            return Save();
        }

        public async Task<int> UpdateRangeAsync(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            return await SaveAsync();
        }

        public int Save() => _context.SaveChanges();
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}

