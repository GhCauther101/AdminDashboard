namespace AdminDashboard.ExchangeService.Routes;

public static class ApiRoutes
{
    public static class CurrencyService
    {
        public const string GetCurrencyList = "/codes";
        public const string GetCurrencyRate = "/latest/#code";
        public const string GetPair = "/pair/#base/#target";
    }
}