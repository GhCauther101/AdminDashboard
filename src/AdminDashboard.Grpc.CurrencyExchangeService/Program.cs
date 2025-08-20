using AdminDashboard.ExchangeService.Extenssion;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(options =>
{
    // gRPC endpoint (TLS + HTTP/2 only)
    options.ListenAnyIP(7295, listenOptions =>
    {
        listenOptions.UseHttps();
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
    });

    // Health endpoint (HTTP/1.1)
    options.ListenAnyIP(7296, listenOptions =>
    {
        listenOptions.UseHttps();
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
    });
});

builder.Services.AddGrpc();
builder.Services.AddTransport(configuration);
builder.Services.AddExchanger();

var app = builder.Build();
app.RegisterServices();

app.MapGet("/", () => "Alive");
app.Run();