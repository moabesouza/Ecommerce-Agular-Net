using AutoMapper;
using AutoMapper.Execution;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Ecom.API.Helper
{
    public class ProdutoUrlResolver : IValueResolver<PRD_Produto, ProdutoDTO, string>
    {
        private readonly IConfiguration _config;

        public ProdutoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(PRD_Produto source, ProdutoDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.prd_nm_imagem)) 
            {
                return _config["ApiURL"] + source.prd_nm_imagem;
            }

            return null;
        }
    }
}
