using AdminDashboard.API.Reuqests.Client;
using AdminDashboard.Entity.Json;
using AdminDashboard.API.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AdminDashboard.API.Scopes;
using AutoMapper;
using AdminDashboard.Entity.Dto;

namespace AdminDashboard.API.Controller;

[Route(ApiRoutes.ClientRoutes.ControllerBase)]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ClientController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.ClientRoutes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var clientGetAllRequest = new ClientGetAllRequest();
        var clientQueryResult = await _mediator.Send(clientGetAllRequest);
        var clientDtoResult = _mapper.Map<IEnumerable<ClientDto>>(clientQueryResult.Data);
        var jsonResult = clientDtoResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(jsonResult);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.ClientRoutes.GetSinge)]
    public async Task<IActionResult> GetSingle(Guid clientId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var clientGetSingleRequest = new ClientGetSingleRequest(clientId);
        var clientQueryResult = await _mediator.Send(clientGetSingleRequest);
        var clientDtoResult = _mapper.Map<ClientDto>(clientQueryResult.Data);
        var jsonResult = clientDtoResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(clientQueryResult.Data);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.ClientRoutes.GetPager)]
    public async Task<IActionResult> GetPager()
    {
        var clientGetPagerRequest = new ClientGetPagerRequest();
        var clientPagerResult = await _mediator.Send(clientGetPagerRequest);
        var jsonResult = clientPagerResult.ToJsonContent();

        if (clientPagerResult.IsSuccess)
            return Ok(clientPagerResult.Entity);
        else return BadRequest(ModelState);
    }
}