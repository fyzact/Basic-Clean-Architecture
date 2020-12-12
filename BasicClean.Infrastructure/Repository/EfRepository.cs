using BasicClean.Core.Enitties;
using BasicClean.Core.Interfaces.Repositories;
using System;

using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace BasicClean.Infrastructure.Repository
{


    internal class EFCommandRepository<T, TKey> : ICommandRepository<T, TKey> where T : BaseEntity<TKey>
    {
        readonly TodoDbContext _context;
        public EFCommandRepository(TodoDbContext todoDbContext)
        {
            _context = todoDbContext;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(TKey id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity).State
                 = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity).State
                = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    internal class EFQueryRepository<T, TKey> : IQueryRepository<T, TKey> where T : BaseEntity<TKey>
    {
        readonly TodoDbContext _context;
        public EFQueryRepository(TodoDbContext todoDbContext)
        {
            _context = todoDbContext;
        }
        public T Get(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
               .Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
               .Where(predicate).ToListAsync();
        }

        public  async Task<T> GetAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).FirstOrDefaultAsync();
        }
    }
}
