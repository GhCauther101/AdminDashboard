using AdminDashboard.API.Reuqests.Payment;
using AdminDashboard.API.Routes;
using AdminDashboard.API.Scopes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controllers;

[ApiController]
[Route(ApiRoutes.ServiceRoutes.ControllerBase)]
public class ServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = RoleScopes.UserScope)]
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
            "id", "sender", "reciever", "bill", "date"
        };

        return Ok(paymentDisplayProps);
    }
    
    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.ServiceRoutes.GetCurrencyStructure)]
    public IActionResult GetCurrencyTableStructure()
    {
        var currencyTableProps = new string[]
        {
            "", "code", "country", "rate"
        };

        return Ok(currencyTableProps);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.ServiceRoutes.GetSnap)]
    public async Task<IActionResult> GetSnap()
    {
        var snapRequest = new ServiceGetSnap();
        var snapResult = await _mediator.Send(snapRequest);
        
        return Ok(snapResult);
    }
}
