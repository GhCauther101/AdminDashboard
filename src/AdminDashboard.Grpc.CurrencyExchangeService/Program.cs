using AdminDashboard.ExchangeService.Extenssion;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddGrpc();
builder.Services.AddTransport(configuration);
builder.Services.AddExchanger();

var app = builder.Build();
app.RegisterServices();

app.MapGet("/", () => "Currency service is alive.");

app.Run();