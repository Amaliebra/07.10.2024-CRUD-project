using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeatherForBergenAsync()
    {
        // Open-Meteo API endpoint for Bergen, Norway
        string requestUri = "https://api.open-meteo.com/v1/forecast?latitude=60.393&longitude=5.3242&current_weather=true";
        var response = await _httpClient.GetAsync(requestUri);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherData>(jsonResponse);
            return $"Temperature in Bergen: {weatherData.CurrentWeather.Temperature}°C, Windspeed: {weatherData.CurrentWeather.Windspeed} km/h";
        }
        else
        {
            return "Unable to retrieve weather data.";
        }
    }

    private class WeatherData
    {
        public CurrentWeatherData CurrentWeather { get; set; }
    }

    private class CurrentWeatherData
    {
        public float Temperature { get; set; }
        public float Windspeed { get; set; }
    }
}
