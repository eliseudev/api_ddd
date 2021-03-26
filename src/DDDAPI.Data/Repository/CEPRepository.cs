using System;
using System.Threading.Tasks;
using DDDAPI.Data.Context;
using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Repository
{
    public class CEPRepository<T> where T:CEPEntity
    {
        protected readonly ContextDB _context;
        private readonly DbSet<T> _dataset;

        public CEPRepository(ContextDB context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        
        public async Task<T> Get(uint Id)
        {
            try
            {
                return await _dataset.Include(c => c.Municipio) //Inclui o municipio
                    .ThenInclude(m => m.UF) //Inclui a UF no município
                    .FirstOrDefaultAsync(c => c.Id.Equals(Id));
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public async Task<T> Get(string cep)
        {
            try
            {
                return await _dataset.Include(c => c.Municipio) //Inclui o municipio
                    .ThenInclude(m => m.UF) //Inclui a UF no município
                    .FirstOrDefaultAsync(c => c.CEP.Equals(cep));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<T> Post(T cep)
        {
            try
            {
                _dataset.Add(cep);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return cep;
        }
        
        public async Task<T> Put(T cep)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(c => c.Id.Equals(cep.Id));
                if (result == null)
                {
                    return null;
                }

                _context.Entry(result).CurrentValues.SetValues(cep);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return cep;
        }

        public async Task<bool> Delete(uint Id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(c => c.Id.Equals(Id));
                if (result == null)
                {
                    return true;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
