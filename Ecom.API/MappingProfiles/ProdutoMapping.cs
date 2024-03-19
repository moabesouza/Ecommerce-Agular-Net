using AutoMapper;
using Ecom.API.Dtos;
using Ecom.Core.Entities;

namespace Ecom.API.MappingProfiles
{
    public class ProdutoMapping : Profile
    {
        public ProdutoMapping()
        {

            CreateMap<PRD_Produto, ProdutoDTO>()
           .ForMember(dest => dest.prd_nm_categoria, opt => opt.MapFrom(src => src.Categoria.cat_nm_nome)).ReverseMap();
            CreateMap<CadastrarProdutoDTO, PRD_Produto>().ReverseMap();
        }
    }
}
