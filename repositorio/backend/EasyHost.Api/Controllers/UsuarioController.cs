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

        [HttpPut("atualizar")]
        public ActionResult<UsuarioDto> Atualizar([FromBody] UpdateUsuarioRequestDto dto)
        {
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

        [HttpGet]
        public ActionResult<UsuarioDto> GetUserByEmail(string email)
        {
            try
            {
                var user = _usuarioService.GetUsuarioByEmail(email);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
