using AdminDashboard.API.Routes;
using AdminDashboard.API.Scopes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controllers;

public class HomeController : ControllerBase
{
    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.HomeRoutes.GetCurrentSnapshot)]
    public IActionResult Index()
    {
        return Ok();
    }
}
