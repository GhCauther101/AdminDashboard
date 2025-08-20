using AdminDashboard.API.Reuqests.Currency;
using AdminDashboard.API.Routes;
using AdminDashboard.API.Scopes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controllers;

[Route(ApiRoutes.CurrencyRoutes.ControllerBase)]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CurrencyController(IMediator mediator)
    {
        _mediator = mediator;    
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.CurrencyRoutes.GetServiceStatus)]
    public async Task<IActionResult> GetServiceStatus()
    {
        var currencyListRequest = new ServiceGetStatusRequest();
        var reply = await _mediator.Send(currencyListRequest);

        if (reply.IsSuccess)
            return Ok(reply.Data);
        else return BadRequest();
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.CurrencyRoutes.GetCurrencyList)]
    public async Task<IActionResult> GetCurrencyList()
    {
        var currencyListRequest = new CurrencyGetListRequest();
        var reply = await _mediator.Send(currencyListRequest);

        if (reply.IsSuccess)
            return Ok(reply.Data);
        else return BadRequest();
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.CurrencyRoutes.GetCurrencyRate)]
    public async Task<IActionResult> GetCurrencyRate(string currencyCode)
    {
        var currencyRateRequest = new CurrencyGetRateRequest(currencyCode);
        var reply = await _mediator.Send(currencyRateRequest);

        if (reply.IsSuccess)
            return Ok(reply.Data);
        else return BadRequest();
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.CurrencyRoutes.GetPairRate)]
    public async Task<IActionResult> GetPairRate(string baseCode, string targetCode)
    {
        var currencyPairRequest = new CurrencyGetPairRequest(baseCode, targetCode);
        var reply = await _mediator.Send(currencyPairRequest);

        if (reply.IsSuccess)
            return Ok(reply.Data);
        else return BadRequest();
    }
}
