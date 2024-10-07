using System.IO;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;

public class WeatherData
{
    public Current Current { get; set; }
}

public class Current
{
    public double temperature_2m { get; set; }
    public double Rain { get; set; }
}


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html");
string htmlContent = File.ReadAllText(htmlPath);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();

}

app.UseHttpsRedirection();
app.UseRouting();

app.UseStaticFiles();
app.UseDefaultFiles();


app.MapGet("/", async () =>
{
    string url = $"https://api.open-meteo.com/v1/forecast?latitude=60.393&longitude=5.3242&current=temperature_2m,rain,weather_code&hourly=temperature_2m&forecast_days=3";
    using (var httpClient = new HttpClient())
    {
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherData>(responseString);
            htmlContent = htmlContent.Replace("", weatherData.Current.temperature_2m.ToString());
            htmlContent = htmlContent.Replace("", weatherData.Current.Rain.ToString());

            return Results.Content(htmlContent, "text/html");
        }
        else
        {
            return Results.StatusCode((int)response.StatusCode);
        }
    }
});

app.Run();

