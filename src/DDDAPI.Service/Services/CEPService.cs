using System.Threading.Tasks;
using DDDAPI.Data.Repository;
using DDDAPI.Domain.Dtos.CEP;
using DDDAPI.Domain.Entities;
using AutoMapper;

namespace DDDAPI.Service.Services
{
    public class CEPService
    {
        private readonly CEPRepository<CEPEntity> _repository;

        private readonly IMapper _mapper;

        public CEPService(CEPRepository<CEPEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<CEPDto> Get(uint Id)
        {
            var result = await _repository.Get(Id);

            return _mapper.Map<CEPDto>(result);
        }
        
        public async Task<CEPDto> Get(string cep)
        {
            var result = await _repository.Get(cep);

            return _mapper.Map<CEPDto>(result);
        }

        public async Task<CEPDto> Post(CEPDtoCreate cep)
        {
            var entity = _mapper.Map<CEPEntity>(cep);
            entity = await _repository.Post(entity);

            return _mapper.Map<CEPDto>(entity);
        }
        
        public async Task<CEPDto> Put(CEPDtoUpdate cep)
        {
            var entity = _mapper.Map<CEPEntity>(cep);
            entity = await _repository.Put(entity);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<CEPDto>(entity);
        }

        public async Task<bool> Delete(uint Id)
        {
            return await _repository.Delete(Id);
        }
    }
}
