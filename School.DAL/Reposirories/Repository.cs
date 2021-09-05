using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.Reposirories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SchoolContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(SchoolContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var obj = await _dbSet.FindAsync(id);

            return obj;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var objList = await _dbSet.AsNoTracking().ToListAsync();

            return objList;
        }

        public virtual IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task Add(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public async Task AddRange(IEnumerable<TEntity> objs)
        {
            await _dbSet.AddRangeAsync(objs);
        }

        public async Task Remove(Guid id)
        {
            var obj = await _dbSet.FindAsync(id);
            Remove(obj);
        }

        public void Remove(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public void RemoveRange(IEnumerable<TEntity> objs)
        {
            _dbSet.RemoveRange(objs);
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public void UpdateRange(IEnumerable<TEntity> objs)
        {
            _dbSet.UpdateRange(objs);
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
