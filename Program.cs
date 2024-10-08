
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient<WeatherService>();  // Registers HttpClient for WeatherService

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();  // Serve static files from wwwroot folder
app.UseHttpsRedirection();
app.UseRouting();

// Map controller routes and fallback to index.html for any non-API request
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // Map controller routes
    // Fallback to index.html for SPA or static files
    endpoints.MapFallbackToFile("index.html");

});

app.Run();
