using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CityTempController : ControllerBase
{
    private readonly AppDbContext _context;

    public CityTempController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("get-temperature")]
    public IActionResult GetTemperature([FromBody] CityRequest request)
    {
        var city = _context.Cities.FirstOrDefault(c => c.Name.ToLower() == request.Name.ToLower());
        if (city == null)
        {
            return NotFound(new { message = "City not found." });
        }

        return Ok(new { city = city.Name, avgTemp = city.AvgTemperature });
    }

    [HttpPost("add")]
    public IActionResult AddCity([FromBody] City city)
    {
        _context.Cities.Add(city);
        _context.SaveChanges();
        return Ok(city);
    }
}

public class CityRequest
{
    public string Name { get; set; }
}
