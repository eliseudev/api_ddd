using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Repository;
using DDDAPI.Domain.Dtos.UF;
using DDDAPI.Domain.Entities;
using AutoMapper;

namespace DDDAPI.Service.Services
{
    public class UFService
    {
        private readonly UFRepository<UFEntity> _repository;

        private readonly IMapper _mapper;

        public UFService(UFRepository<UFEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UFDto> Get(uint Id)
        {
            var result = await _repository.Get(Id);

            return _mapper.Map<UFDto>(result);
        }

        public async Task<IEnumerable<UFDto>> GetAll()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<IEnumerable<UFDto>>(result);
        }
    }
}
