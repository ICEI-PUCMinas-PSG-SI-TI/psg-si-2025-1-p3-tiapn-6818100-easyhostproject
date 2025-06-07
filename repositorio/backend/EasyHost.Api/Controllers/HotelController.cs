using EasyHost.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EasyHost.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelService _hotelService;

        public HotelController(ILogger<HotelController> logger, IHotelService hotelService)
        {
            _logger = logger;
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
