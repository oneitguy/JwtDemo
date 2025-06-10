using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Data;

namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CityTempController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityTempController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("get-temperature")]
        public async Task<IActionResult> GetTemperature([FromBody] City request)
        {
            var result = await _cityService.GetCityTemperatureByNameAsync(request.Name);

            if (!result.IsFound)
            {
                return NotFound(new { message = result.Message });
            }

            return Ok(new { city = result.CityName, avgTemp = result.AvgTemperature });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity([FromBody] City city)
        {
            var addedCity = await _cityService.AddCityAsync(city);
            return Ok(addedCity);
        }
    }
}
