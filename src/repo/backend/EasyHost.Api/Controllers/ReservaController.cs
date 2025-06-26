using Microsoft.AspNetCore.Mvc;
using EasyHost.Application.DTOs.Request.ReservaRequest;
using EasyHost.Application.DTOs.Response.ReservaResponse;
using EasyHost.Application.Interfaces;

namespace EasyHost.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar")]
        public ActionResult<ReservaDto> CadastrarReserva([FromBody] CreateReservaDto dto)
        {
            try
            {
                var created = _service.CadastrarReserva(dto);
                return CreatedAtAction(nameof(GetReservaPorId), new { id = created._id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar reserva: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReservaDto>> GetAllReservas(Guid hotelId)
        {
            try
            {
                var reservas = _service.GetAllReservas(hotelId);
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar reservas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ReservaDto> GetReservaPorId(Guid id)
        {
            try
            {
                var reserva = _service.GetReservaPorId(id);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar reserva: {ex.Message}");
            }
        }

        [HttpPut("alterar")]
        public IActionResult AlterarReserva([FromBody] UpdateReservaDto dto)
        {
            try
            {
                _service.AlterarReserva(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao alterar reserva: {ex.Message}");
            }
        }

        [HttpDelete("cancelar/{id}")]
        public IActionResult CancelarReserva(Guid id)
        {
            try
            {
                _service.CancelarReserva(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cancelar reserva: {ex.Message}");
            }
        }

        [HttpGet("calcular-preco/{id}")]
        public ActionResult<decimal> CalcularPrecoReserva(Guid id)
        {
            try
            {
                var preco = _service.CalcularPrecoReserva(id);
                return Ok(preco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao calcular preço da reserva: {ex.Message}");
            }
        }

        [HttpGet("tempo-medio/{hotelId}")]
        public ActionResult<double> GetTempoMedioReserva(Guid hotelId)
        {
            try
            {
                var tmepoMedio = _service.GetTempoMediaReserva(hotelId);
                return Ok(tmepoMedio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao calcular tempo médio de reserva: {ex.Message}");
            }
        }
    }
}
