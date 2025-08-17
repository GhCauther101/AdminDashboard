using AdminDashboard.ExchangeService.Services;
using AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI;
using System.Net.Http;

namespace AdminDashboard.ExchangeService.Extenssion;

public static class ServiceExtenssion
{
    public static void RegisterServices(this WebApplication app)
    {
        app.MapGrpcService<CurrencyService>();
    }

    public static void AddHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("ExchangeApiClient", client => 
        {
            var baseAddress = AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Routes.ApiRoutes.CurrencyService.BaseAddress;
            client.BaseAddress = new Uri(baseAddress);
        });
    }

    public static void AddExchanger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ExchangeRateApiService>(builder => 
        { 
            var httpClient = builder.GetService<HttpClient>();
            var apiKey = configuration.GetSection("exchangerApiKey").ToString();

            var exchanger = new ExchangeRateApiService(httpClient);
            return exchanger;
        });
    }
}
