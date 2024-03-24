using DepartureTimeServiceApi.Integration;
using DepartureTimeServiceApi.Integration.Refit;
using Env;
using Refit;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using DepartureTimeServiceApi.RouteManipulation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRefitClient<ISPTransIntegrationRefit>().ConfigureHttpClient(options =>
{
    options.BaseAddress = new Uri("https://api.olhovivo.sptrans.com.br/v2.1/");
});

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISPTransIntegration, SPTransIntegration>();

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

public class AuthenticateResult
{
    public bool IsAuthenticate { get; set; }
}

public class LinhasModel
{
    public int IdLinha { get; set; }
    public bool IsCircular { get; set; }
    public string? LetreiroNome { get; set; }
    public int LetreiroNumero { get; set; }
    public int Sentido { get; set; }
    public string? TerminalPrincipal { get; set; }
    public string? TerminalSecundario { get; set; }

}