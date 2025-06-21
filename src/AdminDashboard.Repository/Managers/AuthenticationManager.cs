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

    private Client user;

    public AuthenticationManager(
        UserManager<Client> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManger = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        SeedRoles().Wait();
    }

    public async Task SeedRoles()
    {
        var roles = new[] { "admin", "user", "manager" };

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    public async Task<bool> ValidateUser(ClientForAuthorization userForAuth)
    {

        user = await _userManger.FindByNameAsync(userForAuth.Username);

        return (user != null && await _userManger.CheckPasswordAsync(user, userForAuth.Password));
        //bool result = await _userManger.CheckPasswordAsync(user, inputPassword);
        //return result;
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
        var jwtSettingsKey = _configuration.GetSection("JwtSettings").GetSection("Key").Value;
        var key = Encoding.UTF8.GetBytes(jwtSettingsKey);
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
            issuer: jwtSettings.GetSection("validIssuer").Value,
            audience: jwtSettings.GetSection("validAudience").Value,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }
}
