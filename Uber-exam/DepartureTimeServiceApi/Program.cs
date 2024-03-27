using DepartureTimeServiceApi.Integration;
using DepartureTimeServiceApi.Integration.Refit;
using Refit;
using DepartureTimeServiceApi.RouteManipulation;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRefitClient<ITransitLandsIntegrationRefit>().ConfigureHttpClient(options =>
{
    options.BaseAddress = new Uri("https://transit.land/api/v2/rest");
});

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITransitLandsIntegration, TransiLandsIntegration>();

var app = builder.Build();

Routes.Map(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

