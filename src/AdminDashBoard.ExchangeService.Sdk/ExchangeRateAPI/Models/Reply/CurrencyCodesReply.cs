namespace AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;

public class CurrencyCodesReply
{
    public IEnumerable<IEnumerable<string>> SupportedCodes { get; set; }
}