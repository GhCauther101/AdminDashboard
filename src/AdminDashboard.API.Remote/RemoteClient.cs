using AdminDashboard.API.Remote.Services;
using AdminDashboard.ExchangeService;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;
using System.Net;

namespace AdminDashboard.API.Remote;

public class RemoteClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RemoteClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ServiceStatusReply> GetServiceAliveStatus()
    {
        try
        {
            using (var _httpClient = _httpClientFactory.CreateClient("CurrencyServiceTransport"))
            {
                var response = await _httpClient.GetAsync("/");

                if (response.StatusCode == HttpStatusCode.OK)
                    return new ServiceStatusReply { IsAlive = true };
                else
                    return new ServiceStatusReply { IsAlive = true };
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<CurrencyCodesReply> GetCurrencyListAsync()
    {
        var currencyListRequest = new CurrencyListRequest();

        using (var _httpClient = _httpClientFactory.CreateClient("CurrencyServiceTransport"))
        using (var client = new CurrencyServiceClient(_httpClient.BaseAddress))
        {
            var exchangeService = client.ExchangeService;
            var reply = await exchangeService.GetListAsync(currencyListRequest);

            return new CurrencyCodesReply
            {
                SupportedCodes = reply.CurrencyCodes
                    .Select(x => new[] { x.Code, x.Title })
            };
        }
    }

    public async Task<CurrencyRateReply> GetCurrencyRateAsync(string rateCode)
    {
        var currencyRateRequest = new RateRequest();
        currencyRateRequest.RateCode = rateCode;

        using (var _httpClient = _httpClientFactory.CreateClient("CurrencyServiceTransport"))
        using (var client = new CurrencyServiceClient(_httpClient.BaseAddress))
        {
            var exchangeService = client.ExchangeService;
            var reply = await exchangeService.RateCurrencyAsync(currencyRateRequest);

            return new CurrencyRateReply
            {
                RateCode = reply.RateCode,
                ConversionRates = reply.ConversionRates
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
            };
        }
    }

    public async Task<CurrencyPairReply> GetPairRateAsync(string baseCode, string targetCode)
    {
        var pairRequest = new ExchangeRequest();
        pairRequest.BaseCode = baseCode;
        pairRequest.TargetCode = targetCode;

        using (var _httpClient = _httpClientFactory.CreateClient("CurrencyServiceTransport"))
        using (var client = new CurrencyServiceClient(_httpClient.BaseAddress))
        {
            var exchangeService = client.ExchangeService;
            var reply = await exchangeService.GetPairRateAsync(pairRequest);

            return new CurrencyPairReply
            {
                BaseCode = reply.BaseCode,
                TargetCode = reply.TargetCode,
                ConversionRate = reply.ConversionRate
            };
        }
    }
}