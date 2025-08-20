namespace AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;

public class CurrencyPairReply
{
    public string BaseCode { get; set; }

    public string TargetCode { get; set; }

    public double ConversionRate { get; set; }
}