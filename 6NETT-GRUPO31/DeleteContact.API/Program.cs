using DeleteContact.Application.Interfaces;
using DeleteContact.Application.Services;
using Contact.Core.ServiceBus;
using Contact.WebApi.Core.Util;
using Contact.Core.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IDeleteContactApplication, DeleteContactApplication>(
     options => options.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlGetContact")))
    .AddPolicyHandler(RetryExtensions.CreatePolicy(10));

builder.Services.Configure<RabbitMqConnection>(builder.Configuration.GetSection("RabbitMq"));

builder.Services.AddRabitMqConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
