using FIAP._6NETT_GRUPO31.Service.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApConfiguration(builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.Run();
