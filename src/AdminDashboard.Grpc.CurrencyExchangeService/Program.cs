using AdminDashboard.ExchangeService.Extenssion;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddGrpc();
builder.Services.AddExchanger(configuration);

var app = builder.Build();
app.RegisterServices();
app.Run();
