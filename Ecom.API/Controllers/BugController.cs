using Ecom.API.Errors;
using Ecom.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/bug")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BugController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            var produto = _context.PRD_Produto.Find(50);
            if (produto is null)
                return NotFound(new BaseCommonResponse(404));
            return Ok(produto);
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var produto = _context.PRD_Produto.Find(50);
            produto.prd_nm_nome = "";
            return Ok();
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetNotFoudRequest(int id)
        {
            return Ok();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new BaseCommonResponse(400));
        }

    }
}
