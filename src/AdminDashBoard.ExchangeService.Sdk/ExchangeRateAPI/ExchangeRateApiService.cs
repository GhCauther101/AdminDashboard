using AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;
using AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Models.Request;
using AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Models.Response;
using AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Routes;
using System.Net;
using System.Text.Json;

namespace AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI;

public class ExchangeRateApiService
{
    private readonly HttpClient httpClient;

    public ExchangeRateApiService(HttpClient client)
    {
        httpClient = client;
    }

    public async Task<CurrencyListReply> GetCurrencyCodes()
    {
        var response = await httpClient.GetAsync(ApiRoutes.CurrencyService.GetCurrencyList);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Could not retrieve currency list.");

        string responseBody = await response.Content.ReadAsStringAsync();
        using var data = JsonSerializer.Deserialize<CurrencyListResponse>(responseBody);

        var reply = new CurrencyListReply();
        reply.SupportedCodes = data.SupportedCodes;
        return reply;
    }

    public async Task<CurrencyRateReply> GetCurrencyRate(CurrencyRateRequest currencyRateRequest)
    {
        var rateRoute = ApiRoutes.CurrencyService.GetCurrencyList.Replace("#code", currencyRateRequest.RateCode.ToUpper());
        var response = await httpClient.GetAsync(rateRoute);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Could not retrieve currency list.");

        string responseBody = await response.Content.ReadAsStringAsync();
        using var data = JsonSerializer.Deserialize<CurrencyRateResponse>(responseBody);

        var reply = new CurrencyRateReply();
        reply.RateCode = currencyRateRequest.RateCode;
        reply.ConversionRates = data.ConversionRates.ToDictionary(kvp => kvp.Key, kvp => (double)kvp.Value );
        return reply;
    }

    public async Task<CurrencyPairReply> GetCurrencyPairRate(CurrencyPairRequest currencyPairRequest)
    {
        var pairRoute = ApiRoutes.CurrencyService.GetPair.Replace("#base", currencyPairRequest.BaseCode.ToUpper());
        pairRoute = pairRoute.Replace("#target", currencyPairRequest.TargetCode.ToUpper());

        var response = await httpClient.GetAsync(pairRoute);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Could not retrieve currency list.");

        string responseBody = await response.Content.ReadAsStringAsync();
        using var data = JsonSerializer.Deserialize<CurrencyPairResponse>(responseBody);
        
        var reply = new CurrencyPairReply();
        reply.BaseCode = currencyPairRequest.BaseCode;
        reply.TargetCode = currencyPairRequest.TargetCode;
        reply.ConversionRate = (double)data.ConversionRate;
        return reply;
    }
}