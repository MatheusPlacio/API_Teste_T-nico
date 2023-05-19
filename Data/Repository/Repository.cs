using Data.Context;
using Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyContext _context;

        public Repository(MyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
           _context.Set<T>().Remove(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> Get()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
           _context.Update(entity);
          await  _context.SaveChangesAsync();
        }

    }

}
