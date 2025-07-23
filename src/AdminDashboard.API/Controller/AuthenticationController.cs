using AdminDashboard.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AdminDashboard.Entity.Dto;
using AdminDashboard.Repository.Managers;
using AdminDashboard.API.Utils;

namespace AdminDashboard.API.Controller;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<Client> _userManager;
    private readonly AuthenticationManager _authManager;

    public AuthenticationController(
        AuthenticationManager authManager,
        UserManager<Client> userManager)
    {
        _authManager = authManager;
        _userManager = userManager;
    }

    [HttpGet("getRoles")]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(_authManager.Roles);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] ClientForRegistration clientForregistration)
    {
        var client = new Client
        {
            UserName = clientForregistration.Name,
            Email = clientForregistration.Email,
            Password = clientForregistration.Password
        };

        var result = await _userManager.CreateAsync(client, client.Password);
        if (!result.Succeeded)
        {
            var errorDictionary = ControllerUtils.DefineIdentityErrors(result.Errors);
            return BadRequest(errorDictionary);
        }

        await _userManager.AddToRolesAsync(client, clientForregistration.Roles);

        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] ClientForAuthorization userAuthentication)
     {
        if (!ModelState.IsValid)
        {
            var errorDictionary = ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary
            (
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
            );

            return BadRequest(errorDictionary);
        }

        if (!await _authManager.ValidateUser(userAuthentication))
        {
            var errorDictionary = ControllerUtils.DefineUnauthorizedErrorDictionary();
            return Unauthorized(errorDictionary);
        }

        return Ok(new { Token = await _authManager.CreateToken() });
    }
}