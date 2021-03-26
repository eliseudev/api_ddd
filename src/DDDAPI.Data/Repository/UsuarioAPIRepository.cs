using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Context;
using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Repository
{
    public class UsuarioAPIRepository<T> where T:UsuarioAPIEntity
    {
        protected readonly ContextDB _context;
        private readonly DbSet<T> _dataset;

        public UsuarioAPIRepository(ContextDB context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> GetByCNPJ(string CNPJ)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(u => u.CNPJ.Equals(CNPJ));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> Get()
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

        public async Task<bool> Exists(string CNPJ)
        {
            return await _dataset.AnyAsync (u => u.CNPJ.Equals(CNPJ));
        }

        public async Task<T> Insert(T usuarioAPI)
        {
            try
            {
                _dataset.Add(usuarioAPI);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return usuarioAPI;
        }

        public async Task<T> Update(T usuarioAPI)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(u => u.CNPJ.Equals(usuarioAPI.CNPJ));
                if (result == null)
                {
                    return null;
                }

                _context.Entry(result).CurrentValues.SetValues(usuarioAPI);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return usuarioAPI;
        }
        
        public async Task<bool> Delete(string CNPJ)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(u => u.CNPJ.Equals(CNPJ));
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
