using Microsoft.AspNetCore.Mvc;
using EasyHost.Application.Interfaces;
using EasyHost.Application.DTOs.Request.HospedeRequest;
using EasyHost.Application.DTOs.Response.HospedeResponse;

namespace EasyHost.Api.Controllers
{
    [ApiController]
    [Route("Hospede")]
    public class HospedeController : ControllerBase
    {
        private readonly IHospedeService _service;

        public HospedeController(IHospedeService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar")]
        public ActionResult<HospedeDto> CreateHospede([FromBody] CreateHospedeDto dto)
        {
            var created = _service.CreateHospede(dto);
            return CreatedAtAction(
                nameof(GetHospedeById),
                new { id = created.id },
                created
            );
        }

        [HttpGet]
        public ActionResult<IEnumerable<HospedeDto>> GetAllHospedes(Guid hotelId)
        {
            var list = _service.GetAllHospedes(hotelId);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<HospedeDto> GetHospedeById(Guid id)
        {
            try
            {
                var hospede = _service.GetHospedeById(id);
                return Ok(hospede);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpGet("cpf/{cpf}")]
        public ActionResult<HospedeDto> GetHospedeByCpf(string cpf)
        {
            try
            {
                var hospede = _service.GetHospedeByCpf(cpf);
                return Ok(hospede);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHospede(Guid id)
        {
            _service.DeleteHospede(id);
            return NoContent();
        }

        [HttpGet("{id}/valor-consumo")]
        public ActionResult<decimal> GetValorTotalConsumo(Guid id)
        {
            var total = _service.GetValorTotalConsumo(id);
            return Ok(total);
        }
    }
}
