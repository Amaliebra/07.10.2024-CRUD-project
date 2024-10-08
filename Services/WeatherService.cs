using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;  // Add this line
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string> GetWeatherForBergenAsync()
    {
        try
        {
            // Open-Meteo API endpoint for Bergen, Norway
            string requestUri = "https://api.open-meteo.com/v1/forecast?latitude=60.393&longitude=5.3242&current_weather=true";
            var response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Attempt to deserialize the JSON response
                var weatherData = JsonSerializer.Deserialize<WeatherData>(jsonResponse);

                // Ensure that the deserialized object is not null
                if (weatherData?.CurrentWeather != null)
                {
                    return $"Temperature in Bergen: {weatherData.CurrentWeather.Temperature}°C, Windspeed: {weatherData.CurrentWeather.Windspeed} km/h";
                }
                else
                {
                    _logger.LogError("Weather data or CurrentWeather is null.");
                    return "Weather data is not available.";
                }
            }
            else
            {
                _logger.LogError("Failed to fetch weather data. Status Code: {StatusCode}", response.StatusCode);
                return "Unable to retrieve weather data.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching weather data.");
            return "An error occurred while fetching weather data.";
        }
    }

    private class WeatherData
    {
        [JsonPropertyName("current_weather")]  // Map the JSON property "current_weather" to the C# property
        public CurrentWeatherData CurrentWeather { get; set; }
    }

    private class CurrentWeatherData
    {
        [JsonPropertyName("temperature")]  // Map the JSON property "temperature" to the C# property
        public float Temperature { get; set; }

        [JsonPropertyName("windspeed")]  // Map the JSON property "windspeed" to the C# property
        public float Windspeed { get; set; }
    }
}
