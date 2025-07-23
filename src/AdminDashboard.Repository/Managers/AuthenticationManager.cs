using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using AdminDashboard.Entity.Models;
using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Dto;
using System.IdentityModel.Tokens.Jwt;

namespace AdminDashboard.Repository.Managers;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly UserManager<Client> _userManger;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly JwtSettings _jwtSettings;

    private Client user;

    private string[] roles = { "admin", "manager", "user" };
    
    public AuthenticationManager(
        UserManager<Client> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManger = userManager;
        _roleManager = roleManager;
        _configuration = configuration;

        _jwtSettings  = JwtSettingReader.ReadJwtSettingsFromConfiguration(configuration);
        SeedRoles().Wait();
    }

    public string[] Roles => roles;

    private async Task SeedRoles()
    {
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    public async Task<bool> ValidateUser(ClientForAuthorization userForAuth)
    {
        user = await _userManger.FindByNameAsync(userForAuth.Username);
        var passwordChecking = await _userManger.CheckPasswordAsync(user, userForAuth.Password);
        
        return (user != null && passwordChecking);
    }

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var roles = await _userManger.GetRolesAsync(user);
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }
}

public static class JwtSettingReader
{
    public static JwtSettings ReadJwtSettingsFromConfiguration(IConfiguration configuration)
    {
        return new JwtSettings(configuration);
    }
}

public class JwtSettings(IConfiguration configuration)
{
    public string Issuer { get; init; } = configuration.GetSection("JwtSettings").GetSection("Issuer").Value ?? string.Empty;

    public string Audience { get; init; } = configuration.GetSection("JwtSettings").GetSection("Audience").Value ?? string.Empty;

    public string? Expires { get; init; } = configuration.GetSection("JwtSettings").GetSection("Expires").Value ?? string.Empty;

    public string Key { get; init; } = configuration.GetSection("JwtSettings").GetSection("Key").Value ?? string.Empty;

    public bool IsActiveKey => Key != null;
}
