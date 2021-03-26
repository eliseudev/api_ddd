using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Repository;
using DDDAPI.Domain.Dtos.UsuarioAPI;
using DDDAPI.Domain.Entities;
using AutoMapper;

namespace DDDAPI.Service.Services
{
    public class UsuarioAPIService 
    {
        private readonly UsuarioAPIRepository<UsuarioAPIEntity> _repository;

        private readonly IMapper _mapper;

        public UsuarioAPIService(UsuarioAPIRepository<UsuarioAPIEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(string CNPJ)
        {
            return await _repository.Delete(CNPJ);
        }

        public async Task<IEnumerable<UsuarioAPIDto>> Get()
        {
            var result = await _repository.Get();

            return _mapper.Map<IEnumerable<UsuarioAPIDto>>(result);
        }

        public async Task<UsuarioAPIDto> GetByCNPJ(string CNPJ)
        {
            var result = await _repository.GetByCNPJ(CNPJ);

            return _mapper.Map<UsuarioAPIDto>(result);
        }

        public async Task<UsuarioAPIDto> Insert(UsuarioAPIDtoCreate usuarioAPI)
        {
            var entity = _mapper.Map<UsuarioAPIEntity>(usuarioAPI);
            entity = await _repository.Insert(entity);

            return _mapper.Map<UsuarioAPIDto>(entity);
        }

        public async Task<UsuarioAPIDto> Update(UsuarioAPIDtoUpdate usuarioAPI)
        {
            var entity = _mapper.Map<UsuarioAPIEntity>(usuarioAPI);
            entity = await _repository.Update(entity);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<UsuarioAPIDto>(entity);
        }
    }
}
