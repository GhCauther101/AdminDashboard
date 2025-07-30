using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using AdminDashboard.Entity.Models;
using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Dto;
using System.IdentityModel.Tokens.Jwt;
using AdminDashboard.Repository.Managers.Utils;

namespace AdminDashboard.Repository.Managers;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly UserManager<Client> _userManager;
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
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;

        _jwtSettings  = JwtSettingReader.ReadJwtSettingsFromConfiguration(configuration);
        SeedRoles().Wait();
    }

    public string[] Roles () 
    {
        return roles; 
    }

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
        user = await _userManager.FindByNameAsync(userForAuth.UserName);
        var passwordChecking = await _userManager.CheckPasswordAsync(user, userForAuth.Password);
        
        return (user != null && passwordChecking);
    }

    public async Task<Client> ApplyClientUpdates(Client client, ClientForUpdate clientUpdate)
    {
        if (clientUpdate.UserName != String.Empty)
        {
            client.UserName = clientUpdate.UserName;
            client.NormalizedUserName = clientUpdate.UserName.ToUpper();
        }
        if (clientUpdate.Email != String.Empty)
        {
            client.Email = clientUpdate.Email;
            client.NormalizedEmail = clientUpdate.Email.ToUpper();
        }
        if (clientUpdate.Password != String.Empty)
        {
            client.Password = clientUpdate.Password;
        }
        return client;
    }

    public async Task<IdentityResult> UpdateClientPassword(Client client)
    {
        var token = await _userManager.GeneratePasswordResetTokenAsync(client);
        return await _userManager.ResetPasswordAsync(client, token, client.Password);
    }

    public async Task UpdateClientRoles(Client client, string[] newRoles)
    {
        var roles = await _userManager.GetRolesAsync(client);
        await _userManager.RemoveFromRolesAsync(client, roles);
        await _userManager.AddToRolesAsync(client, newRoles);
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

        var roles = await _userManager.GetRolesAsync(user);
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