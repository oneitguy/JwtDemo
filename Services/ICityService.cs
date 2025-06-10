using System.Threading.Tasks;
using Data;

public interface ICityService
{
    Task<CityTemperatureResult> GetCityTemperatureByNameAsync(string name);
    Task<City> AddCityAsync(City city);
}
