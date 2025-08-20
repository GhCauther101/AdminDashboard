namespace AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Routes;

public static class SdkApiRoutes
{
    public static class CurrencyService
    {
        public static string BaseAddress = "https://v6.exchangerate-api.com/v6/API-KEY/";
        public static string GetCurrencyList = "codes";
        public static string GetCurrencyRate = "latest/#code";
        public static string GetPair = "pair/#base/#target";
    }
}