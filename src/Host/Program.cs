using static Microsoft.AspNetCore.Http.StatusCodes;
using Domain.Services;
using Data;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.RegisterDbContext();
        builder.Services.AddScoped<IMoviesService, MoviesService>();
        // Add cors policy
        // Add xml and json support
        if (!builder.Environment.IsDevelopment())
        {
            builder.Services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = Status308PermanentRedirect;
                options.HttpsPort = 443;
            });
        }

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI((options) =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        // Configure the HTTP request pipeline.
        app.MapControllers();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        });

        app.Run();
    }
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
