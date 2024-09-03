using Microsoft.EntityFrameworkCore;
using Student.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<T>:IRepository<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;
        
        public EntityFrameworkRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
            

        }

        public async Task AddAsync(T entity)
        {
             _dbset.Add(entity);
             await _context.SaveChangesAsync();
              
       
        }

        public async Task DeleteAsync(T entity)
        {
             _dbset.Remove(entity);
             await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
             return _dbset.ToList();
        }

        public async Task<T> GetById(int id)
        {
          return _dbset.Find(id);

        }

        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            
        }
       
    }
}
