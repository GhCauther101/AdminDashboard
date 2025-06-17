using AdminDashboard.API.Reuqests.Client;
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

        return Created();
    }

    [HttpPut(ApiRoutes.ClientRoutes.UpdateClient)]
    public async Task<IActionResult> Update([FromBody] Client client)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var clientUpdateRequest = new ClientUpdateRequest(client);

        return Ok();
    }

    [HttpDelete(ApiRoutes.ClientRoutes.DeleteClient)]
    public async Task<IActionResult> Delete(int clientId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var clientDeleteRequest = new ClientDeleteRequest(clientId);

        return Ok();
    }

    [HttpGet(ApiRoutes.ClientRoutes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var clientGetAllRequest = new ClientGetAllRequest();

        return Ok();
    }

    [HttpGet(ApiRoutes.ClientRoutes.GetSinge)]
    public async Task<IActionResult> GetSingle(int clientId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var clientGetSingleRequest = new ClientGetSingleRequest(clientId);

        return Ok();
    }
}