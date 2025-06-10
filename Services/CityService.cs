using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

public class CityService : ICityService
{
    private readonly AppDbContext _context;

    public CityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CityTemperatureResult> GetCityTemperatureByNameAsync(string name)
    {
        var city = await _context.Cities
            .FirstOrDefaultAsync(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));

        if (city == null)
        {
            return new CityTemperatureResult
            {
                IsFound = false,
                Message = "City not found."
            };
        }

        return new CityTemperatureResult
        {
            IsFound = true,
            CityName = city.Name,
            AvgTemperature = city.AvgTemperature
        };
    }

    public async Task<City> AddCityAsync(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return city;
    }
}
