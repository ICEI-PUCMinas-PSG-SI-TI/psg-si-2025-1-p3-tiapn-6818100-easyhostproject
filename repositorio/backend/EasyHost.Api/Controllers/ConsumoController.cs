using Microsoft.AspNetCore.Mvc;
using EasyHost.Application.Interfaces;
using EasyHost.Application.DTOs.Request.ConsumoRequest;
using EasyHost.Application.DTOs.Response.ConsumoResponse;

namespace EasyHost.Api.Controllers
{
    [ApiController]
    [Route("Consumo")]
    public class ConsumoController : ControllerBase
    {
        private readonly IConsumoService _service;

        public ConsumoController(IConsumoService service)
        {
            _service = service;
        }

        [HttpPost("{hospedeId}")]
        public ActionResult<ConsumoDto> CreateConsumo([FromBody] CreateConsumoDto dto)
        {
            var created = _service.CreateConsumo(dto);
            return CreatedAtAction(
                nameof(GetConsumosByHospedeId),
                new { hospedeId = dto.hospedeId},
                created);
        }

        [HttpGet("{hospedeId}")]
        public ActionResult<IEnumerable<ConsumoDto>> GetConsumosByHospedeId(Guid hospedeId)
        {
            var list = _service.GetConsumosByHospedeId(hospedeId);
            return Ok(list);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConsumo(Guid id)
        {
            _service.DeleteConsumo(id);
            return NoContent();
        }

        [HttpGet("consumoFrequencia/{hotelId}")]
        public ActionResult<IEnumerable<ConsumoDto>> GetConsumosFrequencia(Guid hotelId)
        {
            var consumoFrequencia = _service.GetConsumosFrequencia(hotelId);
            return Ok(consumoFrequencia);
        }
    }
}
