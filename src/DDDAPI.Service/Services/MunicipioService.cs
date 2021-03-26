using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Repository;
using DDDAPI.Domain.Dtos.Municipio;
using DDDAPI.Domain.Entities;
using AutoMapper;

namespace DDDAPI.Service.Services
{
    public class MunicipioService
    {
        private readonly MunicipioRepository<MunicipioEntity> _repository;

        private readonly IMapper _mapper;

        public MunicipioService(MunicipioRepository<MunicipioEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MunicipioDto> Get(uint Id)
        {
            var result = await _repository.Get(Id);

            return _mapper.Map<MunicipioDto>(result);
        }
        
        public async Task<MunicipioDtoCompleto> GetCompletoById(uint Id)
        {
            var result = await _repository.GetCompletoById(Id);

            return _mapper.Map<MunicipioDtoCompleto>(result);
        }
        
        public async Task<MunicipioDtoCompleto> GetCompletoByIBGE(int codIBGE)
        {
            var result = await _repository.GetCompletoByIBGE(codIBGE);

            return _mapper.Map<MunicipioDtoCompleto>(result);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<IEnumerable<MunicipioDto>>(result);
        }

        public async Task<MunicipioDto> Post(MunicipioDtoCreate municipio)
        {
            var entity = _mapper.Map<MunicipioEntity>(municipio);
            entity = await _repository.Post(entity);

            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<MunicipioDto> Put(MunicipioDtoUpdate municipio)
        {
            var entity = _mapper.Map<MunicipioEntity>(municipio);
            entity = await _repository.Put(entity);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<bool> Delete(uint Id)
        {
            return await _repository.Delete(Id);
        }
    }
}
