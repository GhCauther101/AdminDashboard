using AdminDashboard.API.Routes;
using AdminDashboard.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controller;

[Route(ApiRoutes.ClientRoutes.ControllerBase)]
[ApiController]
public class ClientController : ControllerBase
{
    [HttpPost(ApiRoutes.ClientRoutes.CreateClient)]
    public async Task<IActionResult> Create([FromBody] Client client)
    {
        return default;
    }

    [HttpPut(ApiRoutes.ClientRoutes.UpdateClient)]
    public async Task<IActionResult> Update([FromBody] Client client)
    {
        return default;
    }

    [HttpDelete(ApiRoutes.ClientRoutes.DeleteClient)]
    public async Task<IActionResult> Delete([FromBody] Client client)
    {
        return default;
    }

    [HttpGet(ApiRoutes.ClientRoutes.GetAllClients)]
    public async Task<IActionResult> GetAll()
    {
        return default;
    }

    [HttpGet(ApiRoutes.ClientRoutes.GetSinge)]
    public async Task<IActionResult> GetSingle(int clientId)
    {
        return default;
    }
}
