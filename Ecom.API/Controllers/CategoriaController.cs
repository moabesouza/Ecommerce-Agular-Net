using AutoMapper;
using Ecom.API.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;

        public CategoriaController(IUnitOfWork UOW, IMapper mapper)
        {
            _uOW = UOW;
           _mapper = mapper;
        }

        [HttpGet("todos")]
        public async Task<ActionResult> Get()
        {
            var allCategorias = await _uOW.CategoriaRepository.GetAllAsync();

            if (allCategorias is not null)
            {
                var res = _mapper.Map<IReadOnlyList<CAT_Categoria>,IReadOnlyList<ListingCategoriaDTO>>(allCategorias);
                //var res = allCategorias.Select(x => new ListingCategoryDTO
                //{
                //    cat_id_categoria = x.id,
                //    cat_nm_nome = x.cat_nm_nome,
                //    cat_ds_descricao = x.cat_ds_descricao

                //}).ToList();

                return Ok(res);
            }
            return BadRequest("Not Foud");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var categoria = await _uOW.CategoriaRepository.GetAsync(id);

            //var newCategoriaDTO = new ListingCategoryDTO
            //{
            //    id = categoria.id,
            //    cat_nm_nome = categoria.cat_nm_nome,
            //    cat_ds_descricao = categoria.cat_ds_descricao
            //};

            if (categoria is not null)
                return Ok(_mapper.Map<CAT_Categoria, ListingCategoriaDTO>(categoria));
            return BadRequest($"Not Found This Id [{id}]");
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Post(CategoriaDTO catDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var newCategoria = new CAT_Categoria()
                    //{
                    //    cat_nm_nome = catDTO.cat_nm_nome,
                    //    cat_ds_descricao = catDTO.cat_ds_descricao
                    //};
                    var res = _mapper.Map<CAT_Categoria>(catDTO);
                    await _uOW.CategoriaRepository.AddAsync(res);
                    return Ok(res);
                }

                return BadRequest(catDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult> Put(UpdateCategoriaDTO catDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoria = await _uOW.CategoriaRepository.GetAsync(catDTO.id);
                    if (categoria is not null)
                    {
                        //categoria.cat_nm_nome = catDTO.cat_nm_nome;
                        //categoria.cat_ds_descricao = catDTO.cat_nm_nome;

                        _mapper.Map(catDTO, categoria);
                        await _uOW.CategoriaRepository.UpdateAsync(catDTO.id, categoria);
                        return Ok(catDTO);
                    }
               
                }

                return BadRequest($"Not Found This Id [{catDTO.id}]");
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluir/{id}")]
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
