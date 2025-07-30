using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Repository.Managers.Utils;

public static class JwtSettingReader
{
    public static JwtSettings ReadJwtSettingsFromConfiguration(IConfiguration configuration)
    {
        return new JwtSettings(configuration);
    }
}