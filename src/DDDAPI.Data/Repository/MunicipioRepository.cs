using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Context;
using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Repository
{
    public class MunicipioRepository<T> where T:MunicipioEntity
    {
        protected readonly ContextDB _context;
        private readonly DbSet<T> _dataset;

        public MunicipioRepository(ContextDB context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        
        public async Task<T> Get(uint Id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(m => m.Id.Equals(Id));
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public async Task<T> GetCompletoById(uint Id)
        {
            try
            {
                return await _dataset.Include(m => m.UF) //Inclui a UF
                    .FirstOrDefaultAsync(m => m.Id.Equals(Id));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<T> GetCompletoByIBGE(int codIBGE)
        {
            try
            {
                return await _dataset.Include(m => m.UF) //Inclui a UF
                    .FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));
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

        public async Task<T> Post(T municipio)
        {
            try
            {
                _dataset.Add(municipio);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return municipio;
        }
        
        public async Task<T> Put(T municipio)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(m => m.Id.Equals(municipio.Id));
                if (result == null)
                {
                    return null;
                }

                _context.Entry(result).CurrentValues.SetValues(municipio);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return municipio;
        }

        public async Task<bool> Delete(uint Id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(m => m.Id.Equals(Id));
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
