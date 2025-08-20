using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Request;
using Grpc.Core;

namespace AdminDashboard.ExchangeService.Services;

public class CurrencyService : CurrencyExchangeService.CurrencyExchangeServiceBase
{
    private readonly ILogger<CurrencyService> _logger;
    private readonly ExchangeRateApiService _exchangeService;

    public CurrencyService(
        ILogger<CurrencyService> logger,
        ExchangeRateApiService exchangeService)
    {
        _logger = logger;
        _exchangeService = exchangeService;
    }
    
    public override async Task<CurrencyListReply> GetList(CurrencyListRequest request, ServerCallContext context)
    {
        var currencyCodes = await _exchangeService.GetCurrencyCodes();
        var reply = new CurrencyListReply();

        foreach (var currencyRow in currencyCodes.SupportedCodes)
        {
            var row = currencyRow.ToArray();
            var code = row[0];
            var title = row[1];
         
            var currencyRowItem = new CurrencyRow();
            currencyRowItem.Code = code;
            currencyRowItem.Title = title;
            
            reply.CurrencyCodes.Add(currencyRowItem);
        }

        return reply;
    }

    public override async Task<RateReply> RateCurrency(RateRequest request, ServerCallContext context)
    {
        var currencyRateReuqest = new CurrencyRateRequest(request.RateCode);
        var rateReply = await _exchangeService.GetCurrencyRate(currencyRateReuqest);
        var reply = new RateReply();

        reply.RateCode = rateReply.RateCode;

        foreach (var conversionRate in rateReply.ConversionRates)
        {
            reply.ConversionRates.Add(conversionRate.Key, conversionRate.Value);
        }

        return reply;
    }

    public override async Task<ExchangeReply> GetPairRate(ExchangeRequest request, ServerCallContext context)
    {
        var currencyPairReuqest = new CurrencyPairRequest(request.BaseCode, request.TargetCode);
        var exchangeReply = await _exchangeService.GetCurrencyPairRate(currencyPairReuqest);
        var reply = new ExchangeReply();

        reply.BaseCode = exchangeReply.BaseCode;
        reply.TargetCode = exchangeReply.TargetCode;
        reply.ConversionRate = exchangeReply.ConversionRate;

        return reply;
    }
}