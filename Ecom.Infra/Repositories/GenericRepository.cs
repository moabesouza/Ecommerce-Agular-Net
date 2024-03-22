using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infra.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int> 
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync() =>  await _context.Set<T>().CountAsync();

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().AsNoTracking().ToList();


        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();


        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            //aplicar os includes
            foreach(var item in includes)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync(); 
        }

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetByIdAssync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(x => x.id == id);

            //aplicar os includes
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await (query).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var exitingEntity = await _context.Set<T>().FindAsync(id);
            if(exitingEntity is not null) {
                _context.Update(exitingEntity);
                await _context.SaveChangesAsync();
            }
           
        }
    }
}
