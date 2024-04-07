using AutoMapper;
using Azure;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Core.Sharing;
using Ecom.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infra.Repositories
{
    public class ProdutoRepository : GenericRepository<PRD_Produto>, IProdutoRepository
    {
        private readonly AppDbContext _context;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uOW;

        public ProdutoRepository(AppDbContext context, IFileProvider fileProvider, IMapper mapper) : base(context)
        {
            _context = context;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }

        public async Task<ReturnProdutoDTO> ConsultarTodosProdutos(ProdutoParams prd_params)
        {
            var result_ = new ReturnProdutoDTO();
            var query = await _context.PRD_Produto
                .Include(p => p.Categoria)
                .AsNoTracking()
                .ToListAsync();

            //pesquisa por nome
            if (!string.IsNullOrEmpty(prd_params.search))
                query = query.Where(x => x.prd_nm_nome.ToLower().Contains(prd_params.search)).ToList();

            //buscar categoria
            if (prd_params.categoria_id.HasValue)
                query = query.Where(x => x.prd_id_categoria == prd_params.categoria_id.Value).ToList();

            //ordenação por valor
            if (!string.IsNullOrEmpty(prd_params.sort))
            {
                query = prd_params.sort switch
                {
                    "valorAsc" => query.OrderBy(x => x.prd_vl_valor).ToList(),
                    "valorDesc" => query.OrderByDescending(x => x.prd_vl_valor).ToList(),
                    _ => query.OrderBy(x => x.prd_nm_nome).ToList(),
                };
            }

            result_.totalItems = query.Count();
            //paginção        
            query = query.Skip((prd_params.pageNumber - 1) * (prd_params.PageSize)).Take(prd_params.PageSize).ToList();

            result_.Produto = _mapper.Map<List<ProdutoDTO>>(query);
            return result_;
        }


        /// <summary>
        /// Método para cadastrar um novo produto.
        /// </summary>
        /// <param name="prdDTO">Objeto contendo os dados do produto a ser cadastrado.</param>
        /// <returns>True se o produto foi cadastrado com sucesso, caso contrário, False.</returns>
        public async Task<bool> CadastrarProdutoAsync(CadastrarProdutoDTO prdDTO)
        {
            try
            {

                string src = string.Empty;
                if (prdDTO.upload_image is not null)
                {
                    string root = "/imagens/produto/";
                    // Gera um nome único para a imagem com base no GUID e no nome original da imagem
                    var nome_produto = $"{Guid.NewGuid()}";

                    if (!Directory.Exists("wwwroot" + root))
                    {
                        Directory.CreateDirectory("wwwroot" + root);
                    }


                    // Define o caminho completo da imagem no diretório wwwroot/imagens
                    src = root + nome_produto;


                    // Obtém informações sobre o arquivo a partir do provedor de arquivos
                    var picInfo = _fileProvider.GetFileInfo(src);

                    // Obtém o caminho físico do diretório raiz do provedor de arquivos
                    var rootPath = picInfo.PhysicalPath;

                    // Cria um fluxo de arquivo para salvar a imagem
                    using (var fileStream = new FileStream(rootPath, FileMode.Create))
                    {
                        // Copia a imagem para o diretório
                        await prdDTO.upload_image.CopyToAsync(fileStream);
                    }

                }

                var res = _mapper.Map<PRD_Produto>(prdDTO);

                // Define o caminho da imagem no objeto do produto
                res.prd_nm_imagem = src;

                // Adiciona o produto ao repositório
                await _context.PRD_Produto.AddAsync(res);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Método para atualizar produto.
        /// </summary>
        /// <param name="prdDTO">Objeto contendo os dados do produto a ser atualizado.</param>
        /// <returns>True se o produto foi atualizado com sucesso, caso contrário, False.</returns>
        public async Task<bool> EditarProdutoAsync(int id, EditarProdutoDTO prdDTO)
        {
            try
            {
                var currentProduct = await _context.PRD_Produto.AsNoTracking().FirstOrDefaultAsync(p => p.id == id);
                if (currentProduct is not null)
                {
                    string src = string.Empty;
                    if (prdDTO.upload_image is not null)
                    {
                        string root = "/imagens/produto/";
                        // Gera um nome único para a imagem com base no GUID e no nome original da imagem
                        var nome_produto = $"{Guid.NewGuid()}" + prdDTO.upload_image.FileName;

                        if (!Directory.Exists("wwwroot" + root))
                        {
                            Directory.CreateDirectory("wwwroot" + root);
                        }


                        // Define o caminho completo da imagem no diretório wwwroot/imagens
                        src = root + nome_produto;

                        // Obtém informações sobre o arquivo a partir do provedor de arquivos
                        var picInfo = _fileProvider.GetFileInfo(src);

                        // Obtém o caminho físico do diretório raiz do provedor de arquivos
                        var rootPath = picInfo.PhysicalPath;

                        // Cria um fluxo de arquivo para salvar a imagem
                        using (var fileStream = new FileStream(rootPath, FileMode.Create))
                        {
                            // Copia a imagem para o diretório
                            await prdDTO.upload_image.CopyToAsync(fileStream);
                        }

                    }
                    //remover old imagem
                    if (!string.IsNullOrEmpty(currentProduct.prd_nm_imagem))
                    {
                        var picInfo = _fileProvider.GetFileInfo(currentProduct.prd_nm_imagem);
                        var rootPath = picInfo.PhysicalPath;
                        System.IO.File.Delete(rootPath);
                    }


                    var res = _mapper.Map<PRD_Produto>(prdDTO);

                    // Define o caminho da imagem no objeto do produto
                    res.prd_nm_imagem = src;
                    res.id = id;
                    // Atualizar o produto ao repositório
                    _context.PRD_Produto.Update(res);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeletarProduto(int id)
        {
            try
            {
                var currentProduct = await _context.PRD_Produto.FindAsync(id);
                if (currentProduct is not null)
                {

                    //remover old imagem
                    if (!string.IsNullOrEmpty(currentProduct.prd_nm_imagem))
                    {
                        var picInfo = _fileProvider.GetFileInfo(currentProduct.prd_nm_imagem);
                        var rootPath = picInfo.PhysicalPath;
                        System.IO.File.Delete(rootPath);
                    }

                    _context.PRD_Produto.Remove(currentProduct);
                    await _context.SaveChangesAsync();
                    return true;

                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
