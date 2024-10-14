using System.Collections.Generic;
using System.Text.Json.Serialization;

// This class represents the weather data returned by the Open-Meteo API
public class WeatherData
{
    [JsonPropertyName("hourly")]
    public HourlyData? Hourly { get; set; }
}

public class HourlyData
{
    [JsonPropertyName("temperature_2m")]
    public List<float>? Temperature2M { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public List<float>? WindSpeed10M { get; set; }

    [JsonPropertyName("weather_code")]
    public List<int>? WeatherCode { get; set; }

    [JsonPropertyName("uv_index")]
    public List<float>? UVIndex { get; set; }

    [JsonPropertyName("sunshine_duration")]
    public List<float>? SunshineDuration { get; set; }

    [JsonPropertyName("is_day")]
    public List<int>? IsDay { get; set; }

    [JsonPropertyName("visibility")]
    public List<float>? Visibility { get; set; }

    [JsonPropertyName("relative_humidity_2m")]
    public List<float>? RelativeHumidity2M { get; set; }

    [JsonPropertyName("apparent_temperature")]
    public List<float>? ApparentTemperature { get; set; }

    [JsonPropertyName("wind_gusts_10m")]
    public List<float>? WindGusts10M { get; set; }

    [JsonPropertyName("rain")]
    public List<float>? Rain { get; set; }

    [JsonPropertyName("showers")]
    public List<float>? Showers { get; set; }

    [JsonPropertyName("surface_pressure")]
    public List<float>? SurfacePressure { get; set; }

    [JsonPropertyName("cloud_cover")]
    public List<float>? CloudCover { get; set; }

    [JsonPropertyName("cloud_cover_low")]
    public List<float>? CloudCoverLow { get; set; }

    [JsonPropertyName("cloud_cover_mid")]
    public List<float>? CloudCoverMid { get; set; }

    [JsonPropertyName("cloud_cover_high")]
    public List<float>? CloudCoverHigh { get; set; }

    // Add other fields like snowfall, snow_depth if needed
}
