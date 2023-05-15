using Levva.Newbies.Coins.Logic.Dtos;
using Levva.Newbies.Coins.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _service;
        public TransacaoController(ITransacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(TransacaoDto transacao)
        {
            _service.Create(transacao);
            return Created("", transacao);
        }

        [HttpGet]
        public ActionResult<TransacaoDto> Get(int Id)
        {
            return _service.Get(Id);
        }

        [HttpGet("list")]
        public ActionResult<List<TransacaoDto>> Get()
        {
            return _service.GetAll();
        }

        [HttpPut]
        public IActionResult Update(TransacaoDto transacao)
        {
            _service.Update(transacao);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _service.Delete(Id);
            return Ok();
        }
    }
}
