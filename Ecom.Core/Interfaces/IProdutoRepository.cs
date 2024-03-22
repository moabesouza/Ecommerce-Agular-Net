using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interfaces
{
    public interface IProdutoRepository: IGenericRepository<PRD_Produto>
    {
        Task<IEnumerable<ProdutoDTO>> ConsultarTodosProdutos(string sort, int? cat_id, int pageNumber, int pageSize);
            
        Task<bool>CadastrarProdutoAsync(CadastrarProdutoDTO prdDTO);

        Task<bool> EditarProdutoAsync(int id, EditarProdutoDTO prdDTO);

        Task<bool> DeletarProduto(int id);
    }
}
