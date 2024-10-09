using System.Collections.Generic;
using System.Text.Json.Serialization;

// This class represents the weather data returned by the Open-Meteo API
public class WeatherData
{
    [JsonPropertyName("hourly")]
    public HourlyData Hourly { get; set; }
}

public class HourlyData
{
    [JsonPropertyName("temperature_2m")]
    public List<float> Temperature2M { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public List<float> WindSpeed10M { get; set; }

    [JsonPropertyName("weather_code")]
    public List<int> WeatherCode { get; set; }

    // Add other fields like precipitation, rain, etc. if needed
}
