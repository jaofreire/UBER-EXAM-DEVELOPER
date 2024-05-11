using Amazon.SimpleEmail;
using Microservices;
using Microservices.AwsSESConfig;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAWSService<IAmazonSimpleEmailService>().AddTransient<SESWrapper>();
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


Routes.Map(app);

app.Run();

public class EmailModel
{
    public EmailModel(string? from, List<string>? to, string? subject, string? body)
    {
        From = from;
        To = to;
        Subject = subject;
        Body = body;
    }

    public string? From { get; set; }
    public List<string>? To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }

}