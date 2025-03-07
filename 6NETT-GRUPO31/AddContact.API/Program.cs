using AddContact.Application.Interfaces;
using AddContact.Application.Services;
using Contact.Core.ServiceBus;
using Contact.WebApi.Core.Util;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IAddContactApplication, AddContactApplication>(
    options => options.BaseAddress = new Uri(builder.Configuration.GetSection("UrlGetContact").ToString()))
    .AddPolicyHandler(RetryExtensions.CreatePolicy(10));

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
