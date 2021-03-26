using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDAPI.Data.Repository;
using DDDAPI.Domain.Dtos.Item;
using DDDAPI.Domain.Entities;
using AutoMapper;

namespace DDDAPI.Service.Services
{
    public class ItemService
    {
        private readonly ItemRepository<ItemEntity> _repository;

        private readonly IMapper _mapper;

        public ItemService(ItemRepository<ItemEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ItemDto> Get(uint Codigo)
        {
            var result = await _repository.Get(Codigo);

            return _mapper.Map<ItemDto>(result);
        }
        
        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<IEnumerable<ItemDto>>(result);
        }
        
        public async Task<IEnumerable<ItemDto>> GetAllCompleto()
        {
            var result = await _repository.GetAllCompleto();

            return _mapper.Map<IEnumerable<ItemDto>>(result);
        }
        
        public async Task<ItemDto> GetCompletoByCodigo(uint Codigo)
        {
            var result = await _repository.GetCompletoByCodigo(Codigo);

            return _mapper.Map<ItemDto>(result);
        }

        public async Task<ItemDto> Post(ItemDtoCreate Item)
        {
            var entity = _mapper.Map<ItemEntity>(Item);
            entity = await _repository.Post(entity);

            return _mapper.Map<ItemDto>(entity);
        }
        
        public async Task<ItemDto> Put(ItemDtoUpdate Item)
        {
            var entity = _mapper.Map<ItemEntity>(Item);

            entity = await _repository.Put(entity);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<ItemDto>(entity);
        }

        public async Task<bool> Delete(uint Codigo)
        {
            return await _repository.Delete(Codigo);
        }
    }
}
