using Newtonsoft.Json.Serialization;

namespace AdminDashboard.Entity.Json;

public class CustomContractResolver : DefaultContractResolver
{
    public CustomContractResolver()
    {
        NamingStrategy = new SnakeCaseNamingStrategy();
    }
}