using Microsoft.AspNetCore.Mvc;
using EasyHost.Application.Interfaces;
using EasyHost.Application.DTOs.Request.QuartoRequest;
using EasyHost.Application.DTOs.Response.QuartoResponse;

namespace EasyHost.Api.Controllers
{
    [ApiController]
    [Route("Quarto")]
    public class QuartoController : ControllerBase
    {
        private readonly IQuartoService _service;

        public QuartoController(IQuartoService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar")]
        public ActionResult<QuartoDto> Cadastrar([FromBody] CreateQuartoDto dto)
        {
            var created = _service.CadastrarQuartoAsync(dto);
            return CreatedAtAction(
                nameof(GetQuartoPorId),
                new { id = created.id},
                created);
        }

        [HttpGet]
        public ActionResult<IEnumerable<QuartoDto>> GetAllQuartos(Guid hotelId)
        {
            var list = _service.GetAllQuartos(hotelId);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<QuartoDto> GetQuartoPorId(Guid id)
        {
            try
            {
                var quarto = _service.GetQuartoPorId(id);
                return Ok(quarto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpPut("alterar")]
        public IActionResult AlterarQuarto([FromBody] UpdateQuartoDto dto)
        {
            try
            {
                _service.AlterarQuartoAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(new { error = ex.Message });

                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarQuarto(Guid id)
        {
            try
            {
                _service.RemoverQuartoAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpGet("disponiveis")]
        public ActionResult<IEnumerable<QuartoDto>> ObterQuartosDisponiveis([FromQuery] DateOnly dataInicial, Guid hotelId)
        {
            var list = _service.ObterQuartosDisponiveis(dataInicial, hotelId);
            return Ok(list);
        }
    }
}
