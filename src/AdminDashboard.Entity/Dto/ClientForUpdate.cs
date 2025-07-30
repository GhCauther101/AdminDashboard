using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Dto;

public class ClientForUpdate
{
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }
}