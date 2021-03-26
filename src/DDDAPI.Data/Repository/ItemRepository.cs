using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Context;
using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Repository
{
    public class ItemRepository<T> where T:ItemEntity
    {
        protected readonly ContextDB _context;
        private readonly DbSet<T> _dataset;

        public ItemRepository(ContextDB context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        
        public async Task<T> Get(uint Codigo)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync(ite => ite.Codigo.Equals(Codigo));
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
        public async Task<IEnumerable<T>> GetAllCompleto()
        {
            try
            {
                return await _dataset.Include(ite => ite.PisCofins).ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public async Task<T> GetCompletoByCodigo(uint Codigo)
        {
            try
            {
                return await _dataset.Include(ite => ite.PisCofins) //Inclui o pis e cofins
                    .FirstOrDefaultAsync(ite => ite.Codigo.Equals(Codigo));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<T> Post(T item)
        {
            try
            {
                _dataset.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }
        
        public async Task<T> Put(T item)
        {
            try
            {
                var result = await GetCompletoByCodigo(item.Codigo);
                if (result == null)
                {
                    return null;
                }

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<bool> Delete(uint Codigo)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(ite => ite.Codigo.Equals(Codigo));
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
