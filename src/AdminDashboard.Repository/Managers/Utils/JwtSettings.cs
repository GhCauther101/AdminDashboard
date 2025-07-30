using Microsoft.Extensions.Configuration;

namespace AdminDashboard.Repository.Managers.Utils;

public class JwtSettings(IConfiguration configuration)
{
    public string Issuer { get; init; } = configuration.GetSection("JwtSettings").GetSection("Issuer").Value ?? string.Empty;

    public string Audience { get; init; } = configuration.GetSection("JwtSettings").GetSection("Audience").Value ?? string.Empty;

    public string? Expires { get; init; } = configuration.GetSection("JwtSettings").GetSection("Expires").Value ?? string.Empty;

    public string Key { get; init; } = configuration.GetSection("JwtSettings").GetSection("Key").Value ?? string.Empty;

    public bool IsActiveKey => Key != null;
}