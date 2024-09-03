using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Abstractions
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task AddAsync(T entity);
       // void Add(T entity); 
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
