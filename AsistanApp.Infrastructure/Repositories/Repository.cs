using AsistanApp.Domain.Interfaces;
using AsistanApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsistanApp.Infrastructure.Repositories
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly AsistanAppDbContext _context = null;
        private readonly DbSet<T> _entity;

        public Repository(AsistanAppDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>> predicate = null)
        {
            return await _entity.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }
    }
}
