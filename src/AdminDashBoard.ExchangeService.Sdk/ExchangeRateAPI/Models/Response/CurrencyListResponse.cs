using System.Text.Json.Serialization;

namespace AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Models.Response;

public class CurrencyListResponse : IDisposable
{
    [JsonPropertyName("result")]
    public string Result { get; set; }

    [JsonPropertyName("documentation")]
    public string Documentation { get; set; }

    [JsonPropertyName("terms_of_use")]
    public string TermsOfUse { get; set; }

    [JsonPropertyName("supported_codes")]
    public IEnumerable<IEnumerable<string>> SupportedCodes { get; set; }

    public void Dispose()
    {
        Result = default;
        Documentation = default;
        TermsOfUse = default;
        SupportedCodes = default;
    }
}
