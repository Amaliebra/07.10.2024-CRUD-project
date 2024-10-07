using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Register HttpClient and WeatherService for dependency injection
builder.Services.AddHttpClient<WeatherService>();

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

// Endpoint to serve the HTML page
app.MapGet("/", () => Results.Content(htmlContent, "text/html"));

// Endpoint to get the weather data for Bergen
app.MapGet("/api/weather", async (WeatherService weatherService) =>
{
    string weatherInfo = await weatherService.GetWeatherForBergenAsync();
    return Results.Ok(weatherInfo);
});

app.Run();
