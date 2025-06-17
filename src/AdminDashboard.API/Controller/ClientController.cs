using AdminDashboard.API.Reuqests.Client;
using AdminDashboard.Entity.Json;
using AdminDashboard.API.Routes;
using AdminDashboard.Entity.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controller;

[Route(ApiRoutes.ClientRoutes.ControllerBase)]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(ApiRoutes.ClientRoutes.CreateClient)]
    public async Task<IActionResult> Create([FromBody] Client client)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var clientCreateRequest = new ClientCreateRequest(client);
        var clientCommandResult = await _mediator.Send(clientCreateRequest);

        if (clientCommandResult.IsSuccess)
            return Created();
        else return BadRequest(ModelState);
    }

    [HttpPut(ApiRoutes.ClientRoutes.UpdateClient)]
    public async Task<IActionResult> Update([FromBody] Client client)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var clientUpdateRequest = new ClientUpdateRequest(client);
        var clientCommandResult = await _mediator.Send(clientUpdateRequest);
        var jsonResult = clientCommandResult.ToJsonContent();

        if (clientCommandResult.IsSuccess)
            return Ok(jsonResult);
        else return BadRequest(ModelState);
    }

    [HttpDelete(ApiRoutes.ClientRoutes.DeleteClient)]
    public async Task<IActionResult> Delete(int clientId)
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

    [HttpGet(ApiRoutes.ClientRoutes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var clientGetAllRequest = new ClientGetAllRequest();
        var clientQueryResult = await _mediator.Send(clientGetAllRequest);
        var jsonResult = clientQueryResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(clientQueryResult.Range);
        else return BadRequest(ModelState);
    }

    [HttpGet(ApiRoutes.ClientRoutes.GetSinge)]
    public async Task<IActionResult> GetSingle(int clientId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var clientGetSingleRequest = new ClientGetSingleRequest(clientId);
        var clientQueryResult = await _mediator.Send(clientGetSingleRequest);
        var jsonResult = clientQueryResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(clientQueryResult.Entity);
        else return BadRequest(ModelState);
    }
}