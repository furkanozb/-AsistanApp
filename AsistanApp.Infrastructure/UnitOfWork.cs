using AsistanApp.Domain.Interfaces;
using AsistanApp.Infrastructure.Context;
using AsistanApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistanApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AsistanAppDbContext _context = null;
        private bool disposed = false;

        public UnitOfWork(AsistanAppDbContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
