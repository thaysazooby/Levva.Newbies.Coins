using Levva.Newbies.Coins.Logic.Dtos;
using Levva.Newbies.Coins.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(UsuarioDto usuario)
        {
            _service.Create(usuario);
            return Created("", usuario);
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> Get(int Id) 
        {
            return _service.Get(Id);
        }

        [HttpGet]
        public ActionResult<List<UsuarioDto>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPut("{id}")]
        public IActionResult Update(UsuarioDto usuario) 
        {
            _service.Update(usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id) 
        {
            _service.Delete(Id);
            return Ok();
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public ActionResult<LoginDto> Login(LoginDto? loginDto)
        {
            var login = _service.Login(loginDto);

            if (login == null)
                return BadRequest("Usuário ou senha inválido");

            return Ok(login);
        }
    }
}
