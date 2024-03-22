using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;

namespace Ecom.API.MappingProfiles
{
    public class ProdutoMapping : Profile
    {
        public ProdutoMapping()
        {

            CreateMap<PRD_Produto, ProdutoDTO>()
           .ForMember(dest => dest.prd_nm_categoria, opt => opt.MapFrom(src => src.Categoria.cat_nm_nome))
           .ForMember(dest => dest.prd_nm_imagem, opt => opt.MapFrom<ProdutoUrlResolver>()).ReverseMap();
            CreateMap<CadastrarProdutoDTO, PRD_Produto>().ReverseMap();
            CreateMap<EditarProdutoDTO, PRD_Produto>().ReverseMap();

        }
    }
}
