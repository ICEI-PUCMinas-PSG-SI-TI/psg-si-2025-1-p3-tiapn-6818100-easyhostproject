using EasyHost.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EasyHost.Application.DTOs.Response.HotelResponse;

namespace EasyHost.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var hoteis = _hotelService.GetAll();
            return Ok(hoteis);
        }

        [HttpGet("{id}")]
        public ActionResult<HotelDto> GetHotelById(Guid id)
        {
            try
            {
                var hotel = _hotelService.GetHotelById(id);
                return Ok(hotel);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
