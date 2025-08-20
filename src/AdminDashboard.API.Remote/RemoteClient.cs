using AdminDashboard.API.Remote.Services;
using AdminDashboard.ExchangeService;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;

namespace AdminDashboard.API.Remote;

public class RemoteClient
{
    private readonly HttpClient _httpClient;

    public RemoteClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CurrencyCodesReply> GetCurrencyListAsync()
    {
        var currencyListRequest = new CurrencyListRequest();

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