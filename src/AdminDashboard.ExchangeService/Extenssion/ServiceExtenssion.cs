using AdminDashboard.ExchangeService.Services;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Routes;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication.Certificate;

namespace AdminDashboard.ExchangeService.Extenssion;

public static class ServiceExtenssion
{
    public static void ResolveServiceEndpoints(this IWebHostBuilder webHostBuilder, IConfiguration configuration)
    {
        var servicePort = int.Parse(configuration.GetSection("ServicePort").Value.ToString());
        var healthPort = int.Parse(configuration.GetSection("HealthPort").Value.ToString());
        var certPath = configuration["ASPNETCORE_Kestrel:Certificates:Default:Path"];
        var certPassword = configuration["ASPNETCORE_Kestrel:Certificates:Default:Password"];

        webHostBuilder.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(servicePort, listenOptions =>
            {
                listenOptions.UseHttps(certPath, certPassword);
                listenOptions.Protocols = HttpProtocols.Http2;
            });

            options.ListenAnyIP(healthPort, listenOptions =>
            {
                listenOptions.UseHttps(certPath, certPassword);
                listenOptions.Protocols = HttpProtocols.Http2;
            });

            var cert = new X509Certificate2(certPath, certPassword);

            options.ConfigureHttpsDefaults(h =>
            {
                h.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
                h.CheckCertificateRevocation = false;
                h.ServerCertificate = cert;
            });
        });
    }

    public static void RegisterServices(this WebApplication app)
    {
        app.MapGrpcService<CurrencyService>();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddGrpc(x => x.EnableDetailedErrors = true);
        services.AddAuthentication().AddCertificate(opt =>
        {
            opt.AllowedCertificateTypes = CertificateTypes.SelfSigned;
            opt.RevocationMode = X509RevocationMode.NoCheck;
            opt.Events = new CertificateAuthenticationEvents()
            {
                OnCertificateValidated = ctx =>
                {
                    ctx.Success();
                    return Task.CompletedTask;
                }
            };
        });
    }
    
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            options.AddPolicy("AllowWebApp", builder =>
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:55085"));
        });
    }
   
    public static void AddTransport(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("ExchangeApiClient", client =>
        {
            var apiKey = configuration.GetSection("ExchangerApiKey").Value.ToString();
            var baseAddress = SdkApiRoutes.CurrencyService.BaseAddress.Replace("API-KEY", apiKey);
            client.BaseAddress = new Uri(baseAddress);
        });
    }

    public static void AddExchanger(this IServiceCollection services)
    {
        services.AddTransient<ExchangeRateApiService>(builder => 
        {
            var httpClientFactory = builder.GetService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("ExchangeApiClient");
            
            return new ExchangeRateApiService(httpClient);
        });
    }
}
