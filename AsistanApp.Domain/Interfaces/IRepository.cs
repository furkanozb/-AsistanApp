using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsistanApp.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> predicate = null);
    }
}
