using AdminDashboard.API.Reuqests.Client;
using AdminDashboard.API.Routes;
using AdminDashboard.API.Scopes;
using AdminDashboard.API.Utils;
using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Json;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Managers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controller;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<Client> _userManager;
    private readonly AuthenticationManager _authManager;

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(
        IMediator mediator,
        IMapper mapper,
        AuthenticationManager authManager,
        UserManager<Client> userManager)
    {
        _authManager = authManager;
        _userManager = userManager;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(ApiRoutes.AccountRoutes.GetRoles)]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(_authManager.Roles);
    }

    [HttpPost(ApiRoutes.AccountRoutes.Register)]
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

    [HttpPost(ApiRoutes.AccountRoutes.Login)]
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

        var token = await _authManager.CreateToken();

        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        });

        return Ok("Logged in.");
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok("Logged out.");
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpPut(ApiRoutes.AccountRoutes.UpdateClient)]
    public async Task<IActionResult> Update([FromBody] ClientForUpdate clientForUpdate)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var clientUpdateRequest = new ClientUpdateRequest(clientForUpdate);
        var clientCommandResult = await _mediator.Send(clientUpdateRequest);
        var jsonResult = clientCommandResult.ToJsonContent();

        if (clientCommandResult.IsSuccess)
            return Ok(jsonResult);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpDelete(ApiRoutes.AccountRoutes.DeleteClient)]
    public async Task<IActionResult> Delete(Guid clientId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var clientDeleteRequest = new ClientDeleteRequest(clientId);
        var clientCommandResult = await _mediator.Send(clientDeleteRequest);
        var jsonResult = clientCommandResult.ToJsonContent();

        if (clientCommandResult.IsSuccess)
            return NoContent();
        else return BadRequest(ModelState);
    }
}