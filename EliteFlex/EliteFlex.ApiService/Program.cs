var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var taskTitles = new[]
{
    "Walk Dog", "Pet Cat", "Clean Room", "Lift", "Cardio", "Stretch", "Github commit", "Call mom", "Dance party", "Helldivers 2"
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

app.MapGet("/task", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
            new FlexTask
            (
                taskTitles[Random.Shared.Next(taskTitles.Length)],
                Random.Shared.Next(-20, 55)
            ))
        .ToArray();
    return forecast;
});


app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record FlexTask(string Title, int id)
{
   
}