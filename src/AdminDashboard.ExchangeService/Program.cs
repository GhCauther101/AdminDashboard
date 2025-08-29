using AdminDashboard.ExchangeService.Extenssion;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.WebHost.ResolveServiceEndpoints(configuration);

builder.Services.AddGrpc();
builder.Services.ConfigureServices();
builder.Services.AddTransport(configuration);
builder.Services.AddExchanger();

var app = builder.Build();
app.RegisterServices();

app.MapGet("/", () => "Alive");
app.Run();