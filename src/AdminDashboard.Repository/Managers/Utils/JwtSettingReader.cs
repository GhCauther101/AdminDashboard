using Microsoft.Extensions.Configuration;

namespace AdminDashboard.Repository.Managers.Utils;

public static class JwtSettingReader
{
    public static JwtSettings ReadJwtSettingsFromConfiguration(IConfiguration configuration)
    {
        return new JwtSettings(configuration);
    }
}