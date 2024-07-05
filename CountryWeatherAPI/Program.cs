using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Concrete;
using CountryWeatherAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CountryWeatherAPI", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Register DbContext with dependency injection
builder.Services.AddDbContext<CountryWeatherDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

// Register repositories or services
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IResponsiblePersonRepository, ResponsiblePersonRepository>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();