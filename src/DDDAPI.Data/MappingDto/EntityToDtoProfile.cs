using DDDAPI.Domain.Dtos.CEP;
using DDDAPI.Domain.Dtos.Municipio;
using DDDAPI.Domain.Dtos.UF;
using DDDAPI.Domain.Dtos.UsuarioAPI;
using DDDAPI.Domain.Dtos.Item;
using DDDAPI.Domain.Dtos.ItemPisCofins;
using DDDAPI.Domain.Entities;
using AutoMapper;

namespace DDDAPI.Data.MappingDto
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {            
            #region CEP
            CreateMap<CEPDto, CEPEntity>().ReverseMap();
            CreateMap<CEPDtoCreate, CEPEntity>().ReverseMap();
            CreateMap<CEPDtoUpdate, CEPEntity>().ReverseMap();
            #endregion

            #region Item
            CreateMap<ItemDto, ItemEntity>().ReverseMap();
            CreateMap<ItemDtoCreate, ItemEntity>().ReverseMap();
            CreateMap<ItemDtoUpdate, ItemEntity>().ReverseMap();
            #endregion

            #region ItemPisCofins
            CreateMap<ItemPisCofinsDto, ItemPisCofinsEntity>().ReverseMap();
            CreateMap<ItemPisCofinsDtoCreate, ItemPisCofinsEntity>().ReverseMap();
            CreateMap<ItemPisCofinsDtoUpdate, ItemPisCofinsEntity>().ReverseMap();
            #endregion
            
            #region Municipio
            CreateMap<MunicipioDto, MunicipioEntity>().ReverseMap();            
            CreateMap<MunicipioDtoCompleto, MunicipioEntity>().ReverseMap();           
            CreateMap<MunicipioDtoCreate, MunicipioEntity>().ReverseMap();           
            CreateMap<MunicipioDtoUpdate, MunicipioEntity>().ReverseMap();  
            #endregion

            #region UF
            CreateMap<UFDto, UFEntity>().ReverseMap();
            #endregion

            #region UsuarioAPI
            CreateMap<UsuarioAPIDto, UsuarioAPIEntity>().ReverseMap();
            CreateMap<UsuarioAPIDtoCreate, UsuarioAPIEntity>().ReverseMap();
            CreateMap<UsuarioAPIDtoUpdate, UsuarioAPIEntity>().ReverseMap();
            #endregion
        }
    }
}
