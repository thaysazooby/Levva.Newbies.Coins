using Levva.Newbies.Coins.Logic.Dtos;
using Levva.Newbies.Coins.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers
{
    [Authorize]
    [Route("api/transaction")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _service;
        private readonly ICategoriaService _categoriaService;
        public TransacaoController(ITransacaoService service, ICategoriaService categoriaService)
        {
            _service = service;
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public IActionResult Create(CreateTransacaoDto transacao)
        {
            var userId = User.Identity!.Name;

            var transaction = _service.Create(Convert.ToInt32(userId), transacao);
            var category = _categoriaService.Get(transacao.CategoryId);

            transaction.Category = category;
            return Created("", transaction);
        }

        [HttpGet("{id}")]
        public ActionResult<TransacaoDto> Get(int Id)
        {
            return _service.Get(Id);
        }

        [HttpGet]
        public ActionResult<List<TransacaoDto>> GetAll([FromQuery] string? search)
        {
            if (search == null) return _service.GetAll();

            return _service.SearchDescription(search);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TransacaoDto transacao)
        {
            _service.Update(transacao);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            _service.Delete(Id);
            return Ok();
        }
    }
}
