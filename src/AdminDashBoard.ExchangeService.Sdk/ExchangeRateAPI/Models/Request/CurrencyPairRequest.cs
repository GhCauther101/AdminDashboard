namespace AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Models.Request;

public record CurrencyPairRequest(string BaseCode, string TargetCode);