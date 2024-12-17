using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IContext, Context>();
builder.Services.AddScoped<ICRUD<User>, UserService>();
builder.Services.AddScoped<ICRUD<Skill>, SkillService>();
builder.Services.AddScoped<ICRUD<Request>, RequestService>();
builder.Services.AddScoped<QueryService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Task"));
}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
