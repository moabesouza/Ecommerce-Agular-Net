using AutoMapper;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;

namespace Ecom.API.MappingProfiles
{
    public class CategoriaMapping : Profile
    {

        public CategoriaMapping()
        {
            CreateMap<CategoriaDTO, CAT_Categoria>().ReverseMap();
            CreateMap<ListingCategoriaDTO, CAT_Categoria>().ReverseMap();
            CreateMap<UpdateCategoriaDTO, CAT_Categoria>().ReverseMap();
        }
    }
}
