using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

public class WeatherService : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IActionResult> GetWeatherForBergenAsync()
    {
        try
        {
            // API request
            string requestUri = "https://api.open-meteo.com/v1/forecast?latitude=60.393&longitude=5.3242&hourly=temperature_2m,precipitation,rain,showers,weather_code,wind_speed_10m";
            var response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                
                var weatherData = JsonSerializer.Deserialize<WeatherData>(jsonResponse);

                if (weatherData?.Hourly != null)
                {
                    // Check if the first element in the lists exist and use them, otherwise return "undefined"
                    float? temperature = weatherData.Hourly.Temperature2M?.Count > 0 ? weatherData.Hourly.Temperature2M[0] : (float?)null;
                    float? windspeed = weatherData.Hourly.WindSpeed10M?.Count > 0 ? weatherData.Hourly.WindSpeed10M[0] : (float?)null;
                    int? weatherCode = weatherData.Hourly.WeatherCode?.Count > 0 ? weatherData.Hourly.WeatherCode[0] : (int?)null;

                    return Ok(new
                    {
                        temperature = temperature.HasValue ? $"{temperature}°C" : "undefined",
                        windspeed = windspeed.HasValue ? $"{windspeed} km/h" : "undefined",
                        condition = weatherCode.HasValue && weatherCode.Value == 3 ? "Cloudy" : "Clear"
                    });
                }
                else
                {
                    _logger.LogError("Hourly weather data is null.");
                    return StatusCode(500, "Weather data is not available.");
                }
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Unable to retrieve weather data.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching weather data.");
            return StatusCode(500, "An error occurred while fetching weather data.");
        }
    }
}

