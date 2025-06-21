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
    private readonly IConfiguration _configuration;

    private Client user;

    public AuthenticationManager(UserManager<Client> userManager, IConfiguration configuration)
    {
        _userManger = userManager;
        _configuration = configuration;
    }

    public async Task<bool> ValidateUser(ClientForAuthentication userForAuth)
    {
        user = await _userManger.FindByNameAsync(userForAuth.Username);

        return user != null && await _userManger.CheckPasswordAsync(user, userForAuth.Password);
    }

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        string x = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return x;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET1"));
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name)
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
