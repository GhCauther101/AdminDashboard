namespace AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;

public class CurrencyRateReply
{
    public string RateCode { get; set; }

    public Dictionary<string, double> ConversionRates { get; set; }
}
