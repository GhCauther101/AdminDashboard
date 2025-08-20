using AdminDashboard.API.Reuqests.Payment;
using AdminDashboard.API.Routes;
using AdminDashboard.API.Scopes;
using AdminDashboard.API.Validation;
using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controllers;

[ApiController]
[Route(ApiRoutes.PaymentRoutes.ControllerBase)]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ValidateModel]
    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpPost(ApiRoutes.PaymentRoutes.CreatePayment)]
    public async Task<IActionResult> Create([FromBody] PaymentDto payment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentCreateRequest = new PaymentCreateRequest(payment);
        var clientCommandResult = await _mediator.Send(paymentCreateRequest);

        if (clientCommandResult.IsSuccess)
            return Created();
        else return BadRequest(ModelState);
    }

    [ValidateModel]
    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpPut(ApiRoutes.PaymentRoutes.UpdatePayment)]
    public async Task<IActionResult> Update([FromBody] PaymentDto payment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentUpdateRequest = new PaymentUpdateRequest(payment);
        var clientCommandResult = await _mediator.Send(paymentUpdateRequest);
        var jsonResult = clientCommandResult.ToJsonContent();

        if (clientCommandResult.IsSuccess)
            return Ok(jsonResult);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpDelete(ApiRoutes.PaymentRoutes.DeletePayment)]
    public async Task<IActionResult> Delete([FromBody] int paymentId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentDeleteRequest = new PaymentDeleteRequest(paymentId);
        var clientCommandResult = await _mediator.Send(paymentDeleteRequest);
        var jsonResult = clientCommandResult.ToJsonContent();

        if (clientCommandResult.IsSuccess)
            return NoContent();
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.PaymentRoutes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentGetAllRequest = new PaymentGetAllRequest();
        var clientQueryResult = await _mediator.Send(paymentGetAllRequest);
        var jsonResult = clientQueryResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(clientQueryResult.Range);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.PaymentRoutes.GetSinge)]
    public async Task<IActionResult> GetSingle(Guid paymentId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentGetAllRequest = new PaymentGetSingleRequest(paymentId);
        var clientQueryResult = await _mediator.Send(paymentGetAllRequest);
        var jsonResult = clientQueryResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(clientQueryResult.Entity);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.PaymentRoutes.GetLastRange)]
    public async Task<IActionResult> GetLast(int width)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentLastRequest = new PaymentGetLastRequest(width);
        var clientQueryResult = await _mediator.Send(paymentLastRequest);
        var jsonResult = clientQueryResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(clientQueryResult.Range);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.PaymentRoutes.GetHistory)]
    public async Task<IActionResult> GetHistory(Guid clientId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentLastRequest = new PaymentGetClientHistory(clientId);
        var clientQueryResult = await _mediator.Send(paymentLastRequest);
        var jsonResult = clientQueryResult.ToJsonContent();

        if (clientQueryResult.IsSuccess)
            return Ok(clientQueryResult.Range);
        else return BadRequest(ModelState);
    }

    [Authorize(Roles = RoleScopes.UserScope)]
    [HttpGet(ApiRoutes.PaymentRoutes.GetPager)]
    public async Task<IActionResult> GetPager()
    {
        var paymentGetPagerRequest = new PaymentGetPagerRequest();
        var clientPagerResult = await _mediator.Send(paymentGetPagerRequest);
        var jsonResult = clientPagerResult.ToJsonContent();

        if (clientPagerResult.IsSuccess)
            return Ok(clientPagerResult.Entity);
        else return BadRequest(ModelState);
    }
}