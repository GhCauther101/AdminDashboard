using AdminDashboard.ExchangeService.Services;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Routes;

namespace AdminDashboard.ExchangeService.Extenssion;

public static class ServiceExtenssion
{
    public static void RegisterServices(this WebApplication app)
    {
        app.MapGrpcService<CurrencyService>();
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
            var apiKey = configuration.GetSection("exchangerApiKey").Value.ToString();
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
            
            var exchanger = new ExchangeRateApiService(httpClient);
            return exchanger;
        });
    }
}
