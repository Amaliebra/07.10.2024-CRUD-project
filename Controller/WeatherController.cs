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
    public async Task<IActionResult> GetWeather() // Use IActionResult for HTTP response
    {
        var weatherInfo = await _weatherService.GetWeatherForBergenAsync(); // Call WeatherService
        return weatherInfo; // Return the result directly
    }
}
