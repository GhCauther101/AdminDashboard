namespace AdminDashBoard.ExchangeService.Sdk.ExchangeRateAPI.Routes;

public static class ApiRoutes
{
    public static class CurrencyService
    {
        public static string BaseAddress = "https://v6.exchangerate-api.com/v6/";
        public static string GetCurrencyList = "/codes";
        public static string GetCurrencyRate = "/latest/#code";
        public static string GetPair = "/latest/#base/#target";
    }
}