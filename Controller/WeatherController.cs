using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
public async Task<IActionResult> GetWeather()
{
    var weatherInfo = await _weatherService.GetWeatherForBergenAsync();
    
    // Assuming your service fetches data, return it as a JSON object
    return Ok(new { temperature = "14°C", windspeed = "23 km/h" });
}
}
