using System.IO;

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

app.MapGet("/", () =>
{
    return Results.Content(htmlContent, "text/html");
});

app.Run();

