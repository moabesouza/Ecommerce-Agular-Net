using AutoMapper;
using Ecom.API.Dtos;
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
        public async Task<ActionResult> Get()
        {
            var src = await _uOW.ProdutoRepository.GetAllAsync(x => x.Categoria);
            var result = _mapper.Map<List<ProdutoDTO>>(src);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var src = await _uOW.ProdutoRepository.GetByIdAssync(id, x => x.Categoria);
            var result = _mapper.Map<ProdutoDTO>(src);
            return Ok(result);

        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Post(CadastrarProdutoDTO prdDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = _mapper.Map<PRD_Produto>(prdDTO);
                    await _uOW.ProdutoRepository.AddAsync(res);
                    return Ok(res);
                }
                return BadRequest(prdDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
