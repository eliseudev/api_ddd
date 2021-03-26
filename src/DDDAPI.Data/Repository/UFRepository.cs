using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Context;
using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Repository
{
    public class UFRepository<T> where T:UFEntity
    {
        protected readonly ContextDB _context;
        private readonly DbSet<T> _dataset;

        public UFRepository(ContextDB context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        
        public async Task<T> Get(uint Id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(u => u.Id.Equals(Id));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
