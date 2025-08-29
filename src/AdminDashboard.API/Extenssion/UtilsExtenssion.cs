namespace AdminDashboard.API.Extenssion;

public static class UtilsExtenssion
{
    public static string ResolveServiceUrl(this string serviceUrl, IConfiguration configuration)
    {
        if (String.IsNullOrEmpty(serviceUrl) && String.IsNullOrWhiteSpace(serviceUrl))
            return configuration.GetSection("CurrencyServiceLink").Value.ToString();
        else if (serviceUrl.Equals("container"))
            return configuration.GetSection("EXCHANGE_SERVICE_URL").Value.ToString();
        return serviceUrl;
    }
}
