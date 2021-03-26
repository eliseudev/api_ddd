using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Context;
using DDDAPI.Domain.Dtos.Login;
using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Repository
{
    public class LoginRepository<T> where T:UsuarioAPIEntity
    {
        protected readonly ContextDB _context;
        private readonly DbSet<T> _dataset;

        public LoginRepository(ContextDB context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> GetByCNPJ(string CNPJ)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(l => l.CNPJ.Equals(CNPJ));
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
