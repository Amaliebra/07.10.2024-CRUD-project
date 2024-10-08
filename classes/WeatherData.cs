using System.Text.Json.Serialization;

public class WeatherData
{
  [JsonPropertyName("current_weather")]
  public CurrentWeatherData CurrentWeather { get; set;}
}
// we dont use all the functions
public class CurrentWeatherData
{
  [JsonPropertyName("temperature")]
  public float Temperature { get; set; }

  [JsonPropertyName("windspeed")]
  public float Windspeed { get; set; }

  [JsonPropertyName("weathercode")]
  public int WeatherCode { get; set; }

  [JsonPropertyName("winddirection")]
  public int WindDirection { get; set; }

  [JsonPropertyName("is_day")]
  public int IsDay { get; set; }
}

