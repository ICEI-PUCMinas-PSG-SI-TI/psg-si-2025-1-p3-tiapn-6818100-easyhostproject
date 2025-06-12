using EasyHost.Application.DTOs.Request.Usuario;
using EasyHost.Application.DTOs.Request.UsuarioRequest;
using EasyHost.Application.DTOs.Response.UsuarioResponse;
using EasyHost.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyHost.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarUsuario([FromBody] CreateUsuarioRequestDto dto)
        {
            try
            {
                var usuario = _usuarioService.CadastrarUsuario(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(new { error = ex.Message });

                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UsuarioLoginDto dto)
        {
            try
            {
                 var token = _usuarioService.Login(dto);

                 return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public ActionResult<UsuarioDto> Atualizar(Guid id, [FromBody] UpdateUsuarioRequestDto dto)
        {
            if (id != dto.id)
                return BadRequest(new { error = "O ID da rota difere do corpo da requisição." });

            try
            {
                var usuario = _usuarioService.AtualizarUsuario(dto);
                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpPatch("mudar-senha")]
        public IActionResult ChangePassword([FromBody] UsuarioChangePasswordDto dto)
        {
            try
            {
                _usuarioService.MudarSenha(dto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
