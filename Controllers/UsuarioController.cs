using CadastroUsuarios.Api.DTOs;
using CadastroUsuarios.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarios.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioCreateDTO dto)
        {
            var resultado = await _service.RegistrarUsuario(dto);

            if (!resultado.Sucesso)
                return BadRequest(new { mensagem = resultado.Mensagem });

            return Ok(new { mensagem = resultado.Mensagem });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO dto)
        {
            var usuario = await _service.Login(dto);
            if (usuario == null)
                return Unauthorized(new { mensagem = "Credenciais inválidas." });

            return Ok(usuario);
        }
    }
}
