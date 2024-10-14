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
            string requestUri = "https://api.open-meteo.com/v1/forecast?latitude=60.393&longitude=5.3242&hourly=temperature_2m,relative_humidity_2m,apparent_temperature,rain,showers,snowfall,snow_depth,weather_code,surface_pressure,cloud_cover,cloud_cover_low,cloud_cover_mid,cloud_cover_high,visibility,wind_speed_10m,uv_index,is_day,sunshine_duration&forecast_days=1";

            var response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                
                var weatherData = JsonSerializer.Deserialize<WeatherData>(jsonResponse);

                if (weatherData?.Hourly != null)
                {
                    // Return only fields that are working
                    float? temperature = weatherData.Hourly.Temperature2M?.Count > 0 ? weatherData.Hourly.Temperature2M[0] : (float?)null;
                    float? windspeed = weatherData.Hourly.WindSpeed10M?.Count > 0 ? weatherData.Hourly.WindSpeed10M[0] : (float?)null;
                    int? weatherCode = weatherData.Hourly.WeatherCode?.Count > 0 ? weatherData.Hourly.WeatherCode[0] : (int?)null;
                    float? visibility = weatherData.Hourly.Visibility?.Count > 0 ? weatherData.Hourly.Visibility[0] : (float?)null;
                    string humidity = weatherData.Hourly.RelativeHumidity2M?.Count > 0 ? $"{weatherData.Hourly.RelativeHumidity2M[0]}%" : "undefined";
                    bool? isDay = weatherData.Hourly.IsDay?.Count > 0 ? (weatherData.Hourly.IsDay[0] == 1) : (bool?)null;

                    return Ok(new
                    {
                        temperature = temperature.HasValue ? $"{temperature}°C" : "undefined",
                        windspeed = windspeed.HasValue ? $"{windspeed} km/h" : "undefined",
                        condition = weatherCode.HasValue && weatherCode.Value == 3 ? "Cloudy" : "Clear",
                        visibility = visibility.HasValue ? $"{visibility} km" : "undefined",
                        humidity = humidity,
                        isDay = isDay.HasValue ? (isDay.Value ? "Day" : "Night") : "undefined"
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
