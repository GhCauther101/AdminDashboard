using AdminDashboard.API.Routes;
using AdminDashboard.API.Scopes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controller;

public class StructureController : ControllerBase
{
    public StructureController()
    {}

    [Authorize]
    [HttpGet(ApiRoutes.ServiceRoutes.GetClientStructure)]
    public IActionResult GetClientStructure()
    {
        var clientDisplayProps = new string[]
        {
            "username", "email"
        };

        return Ok(clientDisplayProps);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.ServiceRoutes.GetPaymentStructure)]
    public IActionResult GetPaymentStructure()
    {
        var paymentDisplayProps = new string[]
        {
            "sourceClientId", "sourceClientUsername", "destinationClientId", "destinationClientUsername"
        };

        return Ok(paymentDisplayProps);
    }
}
