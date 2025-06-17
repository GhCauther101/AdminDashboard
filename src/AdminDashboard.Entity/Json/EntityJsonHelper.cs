using Newtonsoft.Json;

namespace AdminDashboard.Entity.Json;

public static class EntityJsonHelper
{
    public static string ToJsonContent(this object inputObject)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CustomContractResolver(),
            Formatting = Formatting.Indented
        };

        return JsonConvert.SerializeObject(inputObject, settings);
    }

    public static T FromJsonContent<T>(this string raws)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CustomContractResolver(),
            Formatting = Formatting.Indented
        };

        return JsonConvert.DeserializeObject<T>(raws, settings);
    }
}