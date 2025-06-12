using EasyHost.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet("run")]
        public IActionResult Run()
        {
            return Ok("Ola easyHost");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var hoteis = _hotelService.GetAll();
            return Ok(hoteis);
        }

    }
}
