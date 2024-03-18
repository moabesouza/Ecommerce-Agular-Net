using Ecom.API.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;

        public CategoriaController(IUnitOfWork UOW)
        {
            _uOW = UOW;
        }

        [HttpGet("todas-categorias")]
        public async Task<ActionResult> Get()
        {
            var allCategorias = await _uOW.CategoriaRepository.GetAllAsync();

            if (allCategorias is not null)
            {
                var res = allCategorias.Select(x => new ListingCategoryDTO
                {
                    cat_id_categoria = x.id,
                    cat_nm_nome = x.cat_nm_nome,
                    cat_ds_descricao = x.cat_ds_descricao

                }).ToList();

                return Ok(res);
            }
            return BadRequest("Not Foud");
        }

        [HttpGet("categoria/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var categoria = await _uOW.CategoriaRepository.GetAsync(id);

            var newCategoriaDTO = new ListingCategoryDTO
            {
                cat_id_categoria = categoria.id,
                cat_nm_nome = categoria.cat_nm_nome,
                cat_ds_descricao = categoria.cat_ds_descricao
            };

            if (categoria is not null)
                return Ok(newCategoriaDTO);
            return BadRequest($"Not Found This Id [{id}]");
        }

        [HttpPost("cadastrar-categoria")]
        public async Task<ActionResult> Post(CategoriaDTO catDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCategoria = new CAT_Categoria()
                    {
                        cat_nm_nome = catDTO.cat_nm_nome,
                        cat_ds_descricao = catDTO.cat_ds_descricao
                    };
                    await _uOW.CategoriaRepository.AddAsync(newCategoria);
                    return Ok(newCategoria);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("editar-categoria/{id}")]
        public async Task<ActionResult> Put(int id, CategoriaDTO catDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoria = await _uOW.CategoriaRepository.GetAsync(id);
                    if (categoria is not null)
                    {
                        categoria.cat_nm_nome = catDTO.cat_nm_nome;
                        categoria.cat_ds_descricao = catDTO.cat_nm_nome;
                        await _uOW.CategoriaRepository.UpdateAsync(id, categoria);

                    }
                    return BadRequest($"Not Found This Id [{id}]");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletar-categoria/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _uOW.CategoriaRepository.GetAsync(id);
                if (categoria is not null)
                {
                    await _uOW.CategoriaRepository.DeleteAsync(id);
                    return Ok($"Categoria [{categoria.cat_nm_nome}] deletada com sucesso");
                }
                return BadRequest($"Not Found This Id [{id}]");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
