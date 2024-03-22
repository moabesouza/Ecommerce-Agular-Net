using AutoMapper;
using Ecom.API.Errors;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecom.API.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;

        public ProdutoController(IUnitOfWork UOW, IMapper mapper)
        {
            _uOW = UOW;
            _mapper = mapper;
        }

        [HttpGet("todos")]
        public async Task<ActionResult> Get(string sort, int cat_id, int pageNumber, int pageSize)
        {
            var src = await _uOW.ProdutoRepository.ConsultarTodosProdutos(sort, cat_id, pageNumber, pageSize);
            var result = _mapper.Map<List<ProdutoDTO>>(src);
            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseCommonResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var src = await _uOW.ProdutoRepository.GetByIdAssync(id, x => x.Categoria);
            if (src is null)
            {
                return NotFound(new BaseCommonResponse(404));
            }
            var result = _mapper.Map<ProdutoDTO>(src);
            return Ok(result);

        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Post([FromForm] CadastrarProdutoDTO prdDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _uOW.ProdutoRepository.CadastrarProdutoAsync(prdDTO);
                    return res ? Ok(prdDTO) : BadRequest(res);
                }
                return BadRequest(prdDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] EditarProdutoDTO prdDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _uOW.ProdutoRepository.EditarProdutoAsync(id, prdDTO);
                    return res ? Ok(prdDTO) : BadRequest(res);
                }
                return BadRequest(prdDTO);
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
                if (ModelState.IsValid)
                {
                    var res = await _uOW.ProdutoRepository.DeletarProduto(id);
                    return res ? Ok(res) : BadRequest(res);
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
