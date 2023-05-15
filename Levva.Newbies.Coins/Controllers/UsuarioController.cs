using Levva.Newbies.Coins.Logic.Dtos;
using Levva.Newbies.Coins.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public ActionResult<UsuarioDto> Get(int Id) 
        {
            return _service.Get(Id);
        }

        [HttpGet("list")]
        public ActionResult<List<UsuarioDto>> Get()
        {
            return _service.GetAll();
        }

        [HttpPut]
        public IActionResult Update(UsuarioDto usuario) 
        {
            _service.Update(usuario);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id) 
        {
            _service.Delete(Id);
            return Ok();
        }

        [HttpPost("login")]
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
